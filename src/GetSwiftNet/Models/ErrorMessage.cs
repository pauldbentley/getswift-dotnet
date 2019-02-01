namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines an error returned by the GetSwift server.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public class ErrorMessage : IEquatable<ErrorMessage>
    {
        [JsonConstructor]
        private ErrorMessage(string message, string code)
        {
            Message = message;
            Code = code;
        }

        /// <summary>
        /// Gets a message which describes the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets a code which defines the type of error.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as ErrorMessage);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(ErrorMessage other)
        {
            return other is null
                ? false
                : Message == other.Message && Code == other.Code;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="ErrorMessage"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="ErrorMessage"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Message, Code).GetHashCode();
        }

        private string DebuggerDisplay() => Message ?? Code;
    }
}
