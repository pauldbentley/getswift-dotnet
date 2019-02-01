namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Represents errors that occur when accessing the GetSwift server.
    /// </summary>
    public class GetSwiftException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftException"/> class.
        /// </summary>
        public GetSwiftException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public GetSwiftException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public GetSwiftException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftException"/> class with a specific error
        /// message, a reference to the inner exception that is the cause of this exception, and the response
        /// from the server.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        /// <param name="response">The response from the server.</param>
        internal GetSwiftException(string message, Exception innerException, ServiceResponse response)
            : base(message, innerException)
        {
            Response = response;
        }

        /// <summary>
        /// Gets the response from the service.
        /// </summary>
        public ServiceResponse Response { get; }
    }
}
