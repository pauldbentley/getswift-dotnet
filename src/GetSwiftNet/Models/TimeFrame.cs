namespace GetSwiftNet
{
    using System;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a time frame for a delivery.
    /// </summary>
    public sealed class TimeFrame : IEquatable<TimeFrame>
    {
        [JsonConstructor]
        private TimeFrame(DateTime earliestTime, DateTime latestTime)
        {
            EarliestTime = earliestTime;
            LatestTime = latestTime;
        }

        /// <summary>
        /// Gets the earliest time for delivery.
        /// </summary>
        public DateTime EarliestTime { get; }

        /// <summary>
        /// Gets the latest time for delivery.  Must be greater than or equal to the earliest time.
        /// </summary>
        public DateTime LatestTime { get; }

        /// <summary>
        /// Creates a new <see cref="TimeFrame"/> instance with the given times.
        /// </summary>
        /// <param name="earliestTime">The earliest time for delivery.</param>
        /// <param name="latestTime">The latest time for delivery.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<TimeFrame> Create(DateTime earliestTime, DateTime latestTime)
        {
            var error = Exceptions.WhenOutOfRange(latestTime, earliestTime, nameof(latestTime));

            return error == null
                ? Outcomes.Success(new TimeFrame(earliestTime, latestTime))
                : Outcomes.Failure<TimeFrame>(error);
        }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as TimeFrame);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(TimeFrame other)
        {
            return other is null
                ? false
                : EarliestTime.ToUniversalTime() == other.EarliestTime.ToUniversalTime() && LatestTime.ToUniversalTime() == other.LatestTime.ToUniversalTime();
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="TimeFrame"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="TimeFrame"/> instance.</returns>
        public override int GetHashCode() => new { EarliestTime, LatestTime }.GetHashCode();

        private string DebuggerDisplay() => $"{EarliestTime} > {LatestTime}";
    }
}
