namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// Distance in miles and kilometers.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class Distance : IEquatable<Distance>
    {
        [JsonConstructor]
        private Distance(decimal kilometres, decimal miles)
        {
            Kilometres = kilometres;
            Miles = miles;
        }

        /// <summary>
        /// Gets the distance in kilometers.
        /// </summary>
        public decimal Kilometres { get; }

        /// <summary>
        /// Gets the distance in miles.
        /// </summary>
        public decimal Miles { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Distance);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Distance other)
        {
            return other is null
                ? false
                : Kilometres == other.Kilometres && Miles == other.Miles;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="Distance"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Distance"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Kilometres, Miles).GetHashCode();
        }

        private string DebuggerDisplay() => $"{Kilometres} Kilometres, {Miles} Miles";
    }
}
