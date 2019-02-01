namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the location on a quote.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class QuoteLocationDetail : IEquatable<QuoteLocationDetail>
    {
        [JsonConstructor]
        private QuoteLocationDetail(TimeEstimate time, string address)
        {
            Time = time;
            Address = address;
        }

        /// <summary>
        /// Gets the estimated time window in UTC (earliest, latest and average).
        /// </summary>
        public TimeEstimate Time { get; }

        /// <summary>
        /// Gets the address as it was resolved to on our server.
        /// This should be verified before sending us a final booking in case there was a problem geocoding the original address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as QuoteLocationDetail);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(QuoteLocationDetail other)
        {
            return other is null
                ? false
                : Time == other.Time && Address == other.Address;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="QuoteLocationDetail"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="QuoteLocationDetail"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Time, Address).GetHashCode();
        }

        private string DebuggerDisplay()
        {
            return !string.IsNullOrEmpty(Address)
                ? Address
                : ToString();
        }
    }
}
