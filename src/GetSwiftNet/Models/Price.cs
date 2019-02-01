namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a cost breakdown for a delivery.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class Price : IEquatable<Price>
    {
        [JsonConstructor]
        private Price(decimal cost, int costCents)
        {
            Cost = cost;
            CostCents = costCents;
        }

        /// <summary>
        /// Gets the total cost.
        /// </summary>
        public decimal Cost { get; }

        /// <summary>
        /// Gets the total cost in cents.
        /// </summary>
        public int CostCents { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Price);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Price other)
        {
            return other is null
                ? false
                : Cost == other.Cost && CostCents == other.CostCents;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="Price"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Price"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Cost, CostCents).GetHashCode();
        }

        private decimal DebuggerDisplay() => Cost;
    }
}
