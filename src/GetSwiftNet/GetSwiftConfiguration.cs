namespace GetSwiftNet
{
    using System;
    using System.Net;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// Defines global configuration options for communicating with the GetSwift API.
    /// </summary>
    public class GetSwiftConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftConfiguration"/> class.
        /// </summary>
        /// <param name="apiKey"></param>
        public GetSwiftConfiguration(Guid apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftConfiguration"/> class.
        /// </summary>
        /// <param name="baseUrl"></param>
        public GetSwiftConfiguration(Uri baseUrl)
        {
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftConfiguration"/> class.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="baseUrl"></param>
        public GetSwiftConfiguration(Guid apiKey, Uri baseUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        /// <summary>
        /// Gets the API key.
        /// If an API key is not provided on the request input or in the service this will be used.
        /// </summary>
        public Guid? ApiKey { get; }

        /// <summary>
        /// Gets the Base URL of the GetSwift API service.
        /// </summary>
        public Uri BaseUrl { get; } = Urls.DefaultBaseUrl;

        /// <summary>
        /// Gets or sets a timeout in milliseconds to use for requests made to the service.
        /// </summary>
        public int? HttpTimeout { get; set; }

        /// <summary>
        /// Gets or sets a proxy to use for requests made to the service.
        /// </summary>
        public IWebProxy Proxy { get; set; }
    }
}
