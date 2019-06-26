namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Net;
    using Restfully;

    /// <summary>
    /// A GetSwift API service.
    /// </summary>
    internal sealed class GetSwiftService : ApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftService"/> class with a given path.
        /// </summary>
        /// <param name="path">The path to the service.</param>
        /// <param name="configuration">The system configuration.</param>
        public GetSwiftService(string path, GetSwiftConfiguration configuration)
            : base(configuration?.BaseUrl, path, new GetSwiftClient(), new GetSwiftSerializer())
        {
            AllowAutoRedirect = true;
            HttpTimeout = configuration.HttpTimeout;
            Proxy = configuration.Proxy;
            ContentType = "application/json";
        }

        /// <summary>
        /// Gets a response object to be set on the returned entity.
        /// </summary>
        /// <param name="response">The API response.</param>
        /// <returns>An object to be set on the returned entity.</returns>
        protected override object GetEntityResponse(IApiResponse response)
            => new GetSwiftResponse(response);

        /// <summary>
        /// Returns an exception to throw when an error has occured.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        /// <returns>A <see cref="Exception"/> object.</returns>
        protected override Exception HandleError(IApiResponse response)
        {
            // All validation and other error messages are returned through the 400 Bad request.
            // The response will include an error code as well as a message describing the error
            // There may be a message with no code, or there may be no error at all in the JSON.
            var errorMessage = response.StatusCode == HttpStatusCode.BadRequest
                ? Serializer.Deserialize<ErrorMessage>(response.Content)
                : null;

            var getSwiftError = GetSwiftError.TryParseFromName(errorMessage?.Code, out GetSwiftError result)
                ? result

                // if there is no error code then we are Unknown, otherwise there is no error
                : errorMessage != null ? GetSwiftError.Unknown : GetSwiftError.None;

            // We may get a TooManyRequests error
            // in this case the response.Content contains the error message
            // If we have a message from the response this is what we use on the error
            // otherwise we will use the error messages on the REST response
            // otherwise we will use the status description on the response
            // See: https://app.getswift.co/apidocs/intro#toc-http-error-codes
            string message = response.StatusCode == (HttpStatusCode)429
                ? response.Content
                : errorMessage?.Message ?? response.ErrorMessage ?? response.StatusDescription;

            var exception = new GetSwiftException(message, response.ErrorException)
            {
                GetSwiftError = getSwiftError,
                Response = new GetSwiftResponse(response),
                HttpStatusCode = response.StatusCode,
            };

            return exception;
        }
    }
}
