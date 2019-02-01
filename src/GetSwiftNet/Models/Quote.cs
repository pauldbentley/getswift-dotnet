namespace GetSwiftNet
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A quote for a delivery.
    /// </summary>
    public sealed class Quote : IEquatable<Quote>
    {
        [JsonConstructor]
        private Quote(DateTime created, DateTime start, decimal distanceKm, Price fee, QuoteLocationDetail pickup, QuoteLocationDetail dropoff)
        {
            Created = created;
            Start = start;
            DistanceKm = distanceKm;
            Fee = fee;
            Pickup = pickup;
            Dropoff = dropoff;
        }

        /// <summary>
        /// Gets the time the quote was created (in UTC).
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// Gets the delivery commencement date.
        /// This is the time when the driver was or will be notified.
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Gets the estimated distance in kilometers between the pickup and destination (by road).
        /// </summary>
        public decimal DistanceKm { get; }

        /// <summary>
        /// Gets the merchant price including GST.
        /// </summary>
        public Price Fee { get; }

        /// <summary>
        /// Gets the details of the delivery origin.
        /// </summary>
        public QuoteLocationDetail Pickup { get; }

        /// <summary>
        /// Gets details of the delivery destination.
        /// </summary>
        public QuoteLocationDetail Dropoff { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Quote);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Quote other)
        {
            return other is null
                ? false
                : Created.ToUniversalTime() == other.Created.ToUniversalTime() && DistanceKm == other.DistanceKm && Fee == other.Fee && Pickup == other.Pickup && Dropoff == other.Dropoff;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="Quote"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Quote"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Created, DistanceKm, Fee, Pickup, Dropoff).GetHashCode();
        }
    }
}
