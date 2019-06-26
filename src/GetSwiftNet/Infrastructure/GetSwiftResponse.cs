namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using EnsuredOutcomes;
    using Restfully;

    /// <summary>
    /// Defines the response from the GetSwift REST API.
    /// </summary>
    public sealed class GetSwiftResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftResponse"/> class with the given response.
        /// </summary>
        /// <param name="response">The response from the REST API service.</param>
        internal GetSwiftResponse(IApiResponse response)
        {
            Ensure.NotNull(response, nameof(response));

            Content = response.Content;
            ContentLength = response.ContentLength;
            ContentType = response.ContentType;
            ResponseUri = response.ResponseUri;
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;

            var headers = new Dictionary<string, string>();

            foreach (var header in response.Headers)
            {
                headers.Add(header.Key, header.Value);
            }

            Headers = headers;
        }

        /// <summary>
        /// Gets the response body.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Gets the length in bytes of the response content.
        /// </summary>
        public long ContentLength { get; }

        /// <summary>
        /// Gets the MIME content type of response.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Gets the headers returned by server with the response.
        /// </summary>
        public IReadOnlyDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets the URL that actually responded to the content (different from request if redirected).
        /// </summary>
        public Uri ResponseUri { get; }

        /// <summary>
        /// Gets the HTTP response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the description of HTTP status returned.
        /// </summary>
        public string StatusDescription { get; }

        /// <summary>
        /// Gets the response from the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="GetSwiftResponse"/> object if there is a response; otherwise, null.</returns>
        public static GetSwiftResponse GetResponse(object value) =>
            EntityResponseHelper.GetResponse(value) as GetSwiftResponse;
    }
}
