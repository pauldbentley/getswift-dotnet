namespace GetSwiftNet.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Restfully;
    using RestSharp;

    /// <summary>
    /// A RESTful Api client using RestSharp.
    /// </summary>
    internal abstract class ApiClient : IApiClient
    {
        /// <summary>
        /// Sends the API request to the REST server and obtains a response.
        /// </summary>
        /// <param name="restApiRequest">The request to send.</param>
        /// <returns>The response from the server.</returns>
        public virtual IApiResponse Send(IApiRequest restApiRequest)
        {
            PrepareForSend(restApiRequest);

            var client = BuildClient(restApiRequest);
            var restRequest = BuildRequest(restApiRequest);

            var restResponse = client.Execute(restRequest);
            var apiResponse = BuildResponse(restResponse);
            return apiResponse;
        }

        /// <summary>
        /// Sends the API request to the REST server and obtains a response asynchronously.
        /// </summary>
        /// <param name="restApiRequest">The request to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response from the server.</returns>
        public virtual async Task<IApiResponse> SendAsync(IApiRequest restApiRequest, CancellationToken cancellationToken)
        {
            PrepareForSend(restApiRequest);

            var client = BuildClient(restApiRequest);
            var restRequest = BuildRequest(restApiRequest);

            var restResponse = await client
                .ExecuteTaskAsync(restRequest, cancellationToken)
                .ConfigureAwait(false);

            var apiResponse = BuildResponse(restResponse);
            return apiResponse;
        }

        /// <summary>
        /// Set any properties on the request before it is sent.
        /// </summary>
        /// <param name="restApiRequest">The request.</param>
        protected virtual void PrepareForSend(IApiRequest restApiRequest)
        {
        }

        private static RestClient BuildClient(IApiRequest restApiRequest)
        {
            var client = new RestClient(restApiRequest.BaseAddress)
            {
                Proxy = restApiRequest.Proxy,
                Timeout = restApiRequest.Timeout,
                FollowRedirects = restApiRequest.AllowAutoRedirect,
            };

            return client;
        }

        private static RestRequest BuildRequest(IApiRequest restApiRequest)
        {
            var restRequest = new RestRequest(restApiRequest.Endpoint, GetMethod(restApiRequest.Method))
            {
                RequestFormat = DataFormat.Json,
            };

            restRequest.AddHeader("Content-Type", restApiRequest.ContentType);

            if (restApiRequest.Body != null)
            {
                restRequest.AddParameter("text/json", restApiRequest.Body, ParameterType.RequestBody);
            }

            foreach (var header in restApiRequest.Headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }

            foreach (var parameter in restApiRequest.Parameters)
            {
                restRequest.AddParameter(parameter.Key, parameter.Value);
            }

            return restRequest;
        }

        private static IApiResponse BuildResponse(IRestResponse response)
        {
            var headers = new Dictionary<string, string>();

            foreach (var header in response.Headers)
            {
                headers.Add(header.Name, (string)header.Value);
            }

            var apiResponse = new ApiResponse
            {
                Content = response.Content,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                ErrorException = response.ErrorException,
                ErrorMessage = response.ErrorMessage,
                ResponseUri = response.ResponseUri,
                Headers = headers,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription,
            };

            return apiResponse;
        }

        private static Method GetMethod(string method)
        {
            switch (method)
            {
                case "POST":
                    return Method.POST;

                default:
                    return Method.GET;
            }
        }
    }
}
