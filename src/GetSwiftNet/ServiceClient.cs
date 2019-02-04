namespace GetSwiftNet
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    /// <summary>
    /// Defines a client to connect to the GetSwift API REST service.
    /// </summary>
    internal class ServiceClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClient"/> class with the given base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL of the service.</param>
        public ServiceClient(Uri baseUrl)
        {
            Client = new RestClient(baseUrl)
            {
                Proxy = GetSwiftConfiguration.Proxy
            };

            if (GetSwiftConfiguration.HttpTimeout.HasValue)
            {
                Client.Timeout = GetSwiftConfiguration.HttpTimeout.Value;
            }
        }

        private RestClient Client { get; }

        /// <summary>
        /// Gets the given resource and returns the response from the server.
        /// </summary>
        /// <param name="resource">The resource to get.</param>
        /// <returns>The response from the server.</returns>
        public ServiceResponse Get(string resource)
        {
            return Get(resource, null);
        }

        /// <summary>
        /// Performs a GET to the given URL with specific data and returns the response from the server.
        /// </summary>
        /// <param name="resource">The URL to GET.</param>
        /// <param name="data">The data to pass with the request on the query string.</param>
        /// <returns>The response from the server.</returns>
        public ServiceResponse Get(string resource, object data)
        {
            var request = PrepareRequest(resource, Method.GET, data);
            return ExecuteRequest(request);
        }

        /// <summary>
        /// Gets the given resource and returns the response from the server asynchronously.
        /// </summary>
        /// <param name="resource">The resource to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response from the server.</returns>
        public Task<ServiceResponse> GetAsync(string resource, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync(resource, null, cancellationToken);
        }

        /// <summary>
        /// Gets the given resource with specific data and returns the response from the server asynchronously.
        /// </summary>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to pass in the request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response from the server.</returns>
        public Task<ServiceResponse> GetAsync(string resource, object data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = PrepareRequest(resource, Method.GET, data);
            return ExecuteRequestAsync(request, cancellationToken);
        }

        /// <summary>
        /// Posts data to the given resource with specific data and returns the response from the server.
        /// </summary>
        /// <param name="resource">The resource to post data to.</param>
        /// <param name="data">The data to pass in the request body.</param>
        /// <returns>The response from the server.</returns>
        public ServiceResponse Post(string resource, object data)
        {
            var request = PrepareRequest(resource, Method.POST, data);
            return ExecuteRequest(request);
        }

        /// <summary>
        /// Posts data to the given resource with specific data and returns the response from the server asynchronously.
        /// </summary>
        /// <param name="resource">The resource to to post data to.</param>
        /// <param name="data">The data to pass in the request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response from the server.</returns>
        public Task<ServiceResponse> PostAsync(string resource, object data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = PrepareRequest(resource, Method.POST, data);
            return ExecuteRequestAsync(request, cancellationToken);
        }

        private static IRestRequest PrepareRequest(string resource, Method method, object data)
        {
            ConfigureData(data);

            var request = new RestRequest(resource, method)
            {
                RequestFormat = DataFormat.Json
            };

            if (data != null)
            {
                request.AddHeader("Content-type", "application/json");
                string json = JsonConvert.SerializeObject(data, GetSwiftConfiguration.SerializerSettings);

                if (method == Method.POST)
                {
                    // for POST we add the JSON directly to the body
                    request.AddParameter("text/json", json, ParameterType.RequestBody);
                }
                else
                {
                    // for GET we add a query string parameters
                    // We serialize the JSON back to a JObject, so
                    // the SerializerSettings are followed
                    var jObject = (JObject)JsonConvert.DeserializeObject(json, GetSwiftConfiguration.SerializerSettings);

                    foreach (var property in jObject)
                    {
                        request.AddParameter(property.Key, property.Value);
                    }

                    // expandable
                    var expandables = ExpandableMapper.MapFromObject(data)
                        .Select((name, index) => new
                        {
                            name = $"expand[{index}]",
                            value = name
                        });

                    foreach (var expandable in expandables)
                    {
                        request.AddParameter(expandable.name, expandable.value);
                    }
                }
            }

            return request;
        }

        private static void ConfigureData(object data)
        {
            ApiKeyHelper.AllocateApiKey(data, GetSwiftConfiguration.ApiKey);
        }

        private static GetSwiftException BuildException(IRestResponse response)
        {
            // All validation and other error messages are returned through the 400 Bad request.
            // The response will include an error code as well as a message describing the error
            // There may be a message with no code, or there may be no error at all in the JSON.
            var error = response.StatusCode == HttpStatusCode.BadRequest
                ? ObjectMapper<ErrorMessage>.MapFromJson(response.Content)
                : null;

            var errorCode = ErrorCode.TryParseFromName(error?.Code, out ErrorCode result)
                ? result
                : error != null ? ErrorCode.Unknown : ErrorCode.None; // if there is no error code then we are Unknown, otherwise there is no error

            var serviceResponse = new ServiceResponse(response, errorCode);

            // We may get a TooManyRequests error
            // in this case the response.Content contains the error message
            // If we have a message from the response this is what we use on the error
            // otherwise we will use the error messages on the REST response
            // otherwise we will use the status description on the exception
            // See: https://app.getswift.co/apidocs/intro#toc-http-error-codes
            string message = response.StatusCode == (HttpStatusCode)429
                ? response.Content
                : error?.Message ?? response.ErrorMessage ?? response.StatusDescription;

            return new GetSwiftException(message, response.ErrorException, serviceResponse);
        }

        private static ServiceResponse ResponseIfSuccessful(IRestResponse response)
        {
            return response.IsSuccessful
                ? new ServiceResponse(response, ErrorCode.None)
                : throw BuildException(response);
        }

        private ServiceResponse ExecuteRequest(IRestRequest request)
        {
            var response = Client.BaseUrl == Urls.TestBaseUrl
                ? TestResponse(request)
                : Client.Execute(request);

            return ResponseIfSuccessful(response);
        }

        private async Task<ServiceResponse> ExecuteRequestAsync(IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = Client.BaseUrl == Urls.TestBaseUrl
                ? TestResponse(request)
                : await Client
                    .ExecuteTaskAsync(request, cancellationToken)
                    .ConfigureAwait(false);

            return ResponseIfSuccessful(response);
        }

        private IRestResponse TestResponse(IRestRequest request)
        {
            return new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                ResponseStatus = ResponseStatus.Completed,
                ResponseUri = new Uri($"{Client.BaseUrl}/{request.Resource}"),
                Content = "{ \"Success\": \"true\" }",
                ContentType = "application/json"
            };
        }
    }
}
