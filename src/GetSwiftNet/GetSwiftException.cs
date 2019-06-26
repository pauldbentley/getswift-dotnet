namespace GetSwiftNet
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using EnsuredOutcomes;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// Represents errors that occur when accessing the GetSwift server.
    /// </summary>
    [Serializable]
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
        internal GetSwiftException(string message, Exception innerException, GetSwiftResponse response)
            : base(message, innerException)
        {
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected GetSwiftException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the response from the service.
        /// </summary>
        public GetSwiftResponse Response { get; internal set; }

        /// <summary>
        /// Gets the error code returned in the response.
        /// </summary>
        public GetSwiftError GetSwiftError { get; internal set; } = GetSwiftError.None;

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; internal set; }

        /// <summary>
        /// Sets the <see cref="SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Contract.Requires(info != null);
            Ensure.NotNull(info, nameof(info));
            info.AddValue(nameof(Response), Response);
            info.AddValue(nameof(GetSwiftError), GetSwiftError);
            info.AddValue(nameof(HttpStatusCode), HttpStatusCode);
            base.GetObjectData(info, context);
        }
    }
}
