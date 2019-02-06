namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// The details of a location.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class LocationApi : IEquatable<LocationApi>
    {
        [JsonConstructor]
        private LocationApi(string name, string address, string phone, string postcode, string suburb)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Postcode = postcode;
            Suburb = suburb;
        }

        /// <summary>
        /// Gets the contact name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets the contact phone number.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets the postcode.
        /// </summary>
        public string Postcode { get; }

        /// <summary>
        /// Gets the suburb.
        /// </summary>
        public string Suburb { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as LocationApi);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(LocationApi other)
        {
            return other is null
                ? false
                : Name == other.Name && Address == other.Address && Phone == other.Phone && Suburb == other.Suburb;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="LocationApi"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="LocationApi"/> instance.</returns>
        public override int GetHashCode() => new { Name, Address, Phone, Postcode, Suburb }.GetHashCode();

        private string DebuggerDisplay() => Address;
    }
}
