namespace GetSwiftNet
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using RestSharp;

    /// <summary>
    /// Defines the response from the GetSwift API service.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class ServiceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse"/> class with the given response.
        /// </summary>
        /// <param name="response">The response from the REST API service.</param>
        /// <param name="errorCode">The <see cref="ErrorCode"/> raised, if any.</param>
        internal ServiceResponse(IRestResponse response, ErrorCode errorCode)
        {
            Guard.NotNull(response, nameof(response));

            Content = response.Content;
            ContentLength = response.ContentLength;
            ContentType = response.ContentType;
            ResponseUri = response.ResponseUri;
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;

            foreach (var header in response.Headers)
            {
                Headers.Add(header.Name, (string)header.Value);
            }

            ErrorCode = errorCode;
            ErrorMessage = response.ErrorMessage;
            ErrorException = response.ErrorException;
        }

        /// <summary>
        /// Gets a string representation of response content.
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
        public NameValueCollection Headers { get; } = new NameValueCollection();

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
        /// Gets the error code returned in the response.
        /// </summary>
        public ErrorCode ErrorCode { get; }

        /// <summary>
        /// Gets the transport or other non-HTTP error generated while attempting request.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the exceptions thrown during the request, if any.
        /// </summary>
        public Exception ErrorException { get; }

        /// <summary>
        /// Returns a <see cref="ServiceResponse"/> object defined on the given object, if any.
        /// </summary>
        /// <param name="value">The object to inspect.</param>
        /// <returns>A <see cref="ServiceResponse"/> object or null.</returns>
        public static ServiceResponse ObtainResponse(object value)
        {
            if (value == null)
            {
                return null;
            }

            var property = GetResponseProperty(value);

            return property != null
                ? property.GetValue(value) as ServiceResponse
                : null;
        }

        /// <summary>
        /// Allocates the current response to a property of the given value with a type of <see cref="ServiceResponse"/>.
        /// </summary>
        /// <param name="value">The value to allocate the response to.</param>
        internal void AllocateResponse(object value)
        {
            if (value == null)
            {
                return;
            }

            var property = GetResponseProperty(value);

            if (property != null)
            {
                property.SetValue(value, this);
            }
        }

        private static PropertyInfo GetResponseProperty(object value)
        {
            // find the first property of the response type
            var property = value
                .GetType()
                .GetRuntimeProperties()
                .Where(t => t.PropertyType == typeof(ServiceResponse))
                .FirstOrDefault();

            return property;
        }

        private string DebuggerDisplay()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "StatusCode: {0}, Content-Type: {1}, Content-Length: {2})",
                StatusCode,
                ContentType,
                ContentLength);
        }
    }
}
