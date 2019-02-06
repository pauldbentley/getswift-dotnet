namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// Information about a driver.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class Driver : IEquatable<Driver>
    {
        [JsonConstructor]
        private Driver(Guid identifier, string name, string phone, Uri photoUrl, string email)
        {
            Identifier = identifier;
            Name = name;
            Phone = phone;
            PhotoUrl = photoUrl;
            Email = email;
        }

        /// <summary>
        /// Gets the driver identifier.
        /// </summary>
        public Guid Identifier { get; }

        /// <summary>
        /// Gets the name of the driver.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the drivers phone number.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets the URL to the drivers photo.
        /// </summary>
        public Uri PhotoUrl { get; }

        /// <summary>
        /// Gets the drivers email address.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the response sent by the server.
        /// </summary>
        public ServiceResponse Response { get; private set; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Driver);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Driver other)
        {
            return other is null
                ? false
                : Identifier == other.Identifier;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="Driver"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Driver"/> instance.</returns>
        public override int GetHashCode() => Identifier.GetHashCode();

        private string DebuggerDisplay()
        {
            return !string.IsNullOrEmpty(Name)
                ? Name
                : ToString();
        }
    }
}
