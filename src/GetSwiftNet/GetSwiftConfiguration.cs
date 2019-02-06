namespace GetSwiftNet
{
    using System;
    using System.Net;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Defines global configuration options for communicating with the GetSwift API.
    /// </summary>
    public static class GetSwiftConfiguration
    {
        /// <summary>
        /// Gets or sets the API key.
        /// If an API key is not provided on the request input or in the service this will be used.
        /// </summary>
        public static Guid? ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the Base URL of the GetSwift API service.
        /// </summary>
        public static Uri BaseUrl { get; set; } = Urls.DefaultBaseUrl;

        /// <summary>
        /// Gets or sets a timeout in milliseconds to use for requests made to the service.
        /// </summary>
        public static int? HttpTimeout { get; set; }

        /// <summary>
        /// Gets or sets a proxy to use for requests made to the service.
        /// </summary>
        public static WebProxy Proxy { get; set; }

        /// <summary>
        /// Gets the settings used when reading JSON in the API.
        /// </summary>
        internal static JsonSerializerSettings SerializerSettings { get; } = BuildSerializerSettings();

        private static JsonSerializerSettings BuildSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                DateParseHandling = DateParseHandling.DateTime,
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
