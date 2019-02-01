namespace GetSwiftNet
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a delivery time estimate.
    /// </summary>
    public sealed class TimeEstimate : IEquatable<TimeEstimate>
    {
        [JsonConstructor]
        private TimeEstimate(DateTime average, DateTime earliest, DateTime latest)
        {
            Average = average;
            Earliest = earliest;
            Latest = latest;
        }

        /// <summary>
        /// Gets the average time.
        /// </summary>
        public DateTime Average { get; }

        /// <summary>
        /// Gets the earliest time.
        /// </summary>
        public DateTime Earliest { get; }

        /// <summary>
        /// Gets the latest time.
        /// </summary>
        public DateTime Latest { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as TimeEstimate);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(TimeEstimate other)
        {
            return other is null
                ? false
                : Average == other.Average && Earliest == other.Earliest && Latest == other.Latest;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="TimeEstimate"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="TimeEstimate"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Average, Earliest, Latest).GetHashCode();
        }
    }
}
