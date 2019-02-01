namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Defines the GetSwift service URLs.
    /// </summary>
    public static class Urls
    {
        /// <summary>
        /// Gets the default base url to the service.
        /// </summary>
        public static Uri DefaultBaseUrl { get; } = new Uri("https://app.getswift.co/api/v2");

        /// <summary>
        /// Gets the base url to the test service.
        /// </summary>
        public static Uri TestBaseUrl { get; } = new Uri("https://tempuri.org");
    }
}
