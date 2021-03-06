﻿namespace GetSwiftNet.Infrastructure
{
    using System;

    /// <summary>
    /// Defines the GetSwift service URLs.
    /// </summary>
    internal static class Urls
    {
        /// <summary>
        /// Gets the default base url to the service.
        /// </summary>
        public static Uri DefaultBaseUrl { get; } = new Uri("https://app.getswift.co/api/v2");
    }
}
