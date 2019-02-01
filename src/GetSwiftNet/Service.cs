namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for all GetSwift services.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class with the specified base URL.
        /// </summary>
        /// <param name="baseUrl">The base URL of the service.</param>
        protected Service(Uri baseUrl)
        {
            Guard.NotNull(baseUrl, nameof(baseUrl));

            Client = new ServiceClient(baseUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class with the specified base URL and API key.
        /// </summary>
        /// <param name="baseUrl">The base URL of the service.</param>
        /// <param name="apiKey">The API key.</param>
        protected Service(Uri baseUrl, Guid apiKey)
            : this(baseUrl)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        public Guid? ApiKey { get; }

        /// <summary>
        /// Gets the service path.  All requests are made from this path as a starting point.
        /// </summary>
        public abstract string ServicePath { get; }

        private ServiceClient Client { get; }

        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        protected T GetRequest<T>(object data) => GetRequest<T>(string.Empty, data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        protected T GetRequest<T>(string resource, object data)
        {
            return ObjectMapper<T>.MapFromJson(
                Client.Get(
                    PrepareResource(resource),
                    PrepareRequestData(data)));
        }

        /// <summary>
        /// Performs a GET request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        protected Task<T> GetRequestAsync<T>(object data, CancellationToken cancellationToken) => GetRequestAsync<T>(string.Empty, data, cancellationToken);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        protected async Task<T> GetRequestAsync<T>(string resource, object data, CancellationToken cancellationToken)
        {
            return ObjectMapper<T>.MapFromJson(
                await Client.GetAsync(
                    PrepareResource(resource),
                    PrepareRequestData(data),
                    cancellationToken).ConfigureAwait(false));
        }

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        protected T PostRequest<T>(object data) => PostRequest<T>(string.Empty, data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        protected T PostRequest<T>(string resource, object data)
        {
            return ObjectMapper<T>.MapFromJson(
                Client.Post(
                    PrepareResource(resource),
                    PrepareRequestData(data)));
        }

        /// <summary>
        /// Performs a POST request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        protected Task<T> PostRequestAsync<T>(object data, CancellationToken cancellationToken) => PostRequestAsync<T>(string.Empty, data, cancellationToken);

        /// <summary>
        /// Performs a POST request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An object based on the server response.</returns>
        protected async Task<T> PostRequestAsync<T>(string resource, object data, CancellationToken cancellationToken)
        {
            return ObjectMapper<T>.MapFromJson(
                await Client.PostAsync(
                    PrepareResource(resource),
                    PrepareRequestData(data),
                    cancellationToken).ConfigureAwait(false));
        }

        private object PrepareRequestData(object data)
        {
            ApiKeyHelper.AllocateApiKey(data, ApiKey);
            return data;
        }

        private string PrepareResource(string resource)
        {
            return string.IsNullOrWhiteSpace(resource)
                ? ServicePath
                : $"{ServicePath}/{resource}";
        }
    }
}