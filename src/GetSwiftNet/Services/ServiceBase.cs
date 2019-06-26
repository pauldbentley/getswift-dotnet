namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GetSwiftNet.Infrastructure;
    using Restfully;

    /// <summary>
    /// Base class for all services.
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="configuration">The system configuration.</param>
        protected ServiceBase(GetSwiftConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ApiKey = Configuration.ApiKey;
            Service = new GetSwiftService(ServicePath, configuration);
        }

        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        public abstract string ServicePath { get; }

        /// <summary>
        /// Gets or sets the API Key to send with the requests.
        /// </summary>
        public Guid? ApiKey { get; set; }

        private IApiService Service { get; }

        private GetSwiftConfiguration Configuration { get; }

        /// <summary>
        /// Performs a GET request and returns the model.
        /// </summary>
        /// <typeparam name="TModel">The type of model to return.</typeparam>
        /// <param name="resource">The resource where the model is located.</param>
        /// <param name="input">Input to retrieve the model.</param>
        /// <returns>The model.</returns>
        protected TModel GetRequest<TModel>(string resource, object input)
        {
            ApiKeyHelper.AllocateApiKey(input, ApiKey);
            return Service.GetRequest<TModel>(resource, input);
        }

        /// <summary>
        /// Performs a GET request and returns the model asynchronously.
        /// </summary>
        /// <typeparam name="TModel">The type of model to return.</typeparam>
        /// <param name="resource">The resource where the model is located.</param>
        /// <param name="input">Input to retrieve the model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The model.</returns>
        protected Task<TModel> GetRequestAsync<TModel>(string resource, object input, CancellationToken cancellationToken = default)
        {
            ApiKeyHelper.AllocateApiKey(input, ApiKey);
            return Service.GetRequestAsync<TModel>(resource, input, cancellationToken);
        }

        /// <summary>
        /// Performs a POST request and returns the model.
        /// </summary>
        /// <typeparam name="TModel">The type of model to return.</typeparam>
        /// <param name="resource">The resource where the model is located.</param>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <returns>The model.</returns>
        protected TModel PostRequest<TModel>(string resource, object input)
        {
            ApiKeyHelper.AllocateApiKey(input, ApiKey);
            return Service.PostRequest<TModel>(resource, input);
        }

        /// <summary>
        /// Performs a POST request and returns the model asynchronously.
        /// </summary>
        /// <typeparam name="TModel">The type of model to return.</typeparam>
        /// <param name="resource">The resource where the model is located.</param>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        protected Task<TModel> PostRequestAsync<TModel>(string resource, object input, CancellationToken cancellationToken = default)
        {
            ApiKeyHelper.AllocateApiKey(input, ApiKey);
            return Service.PostRequestAsync<TModel>(resource, input, cancellationToken);
        }
    }
}
