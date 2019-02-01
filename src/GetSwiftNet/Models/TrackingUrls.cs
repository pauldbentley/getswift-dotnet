namespace GetSwiftNet
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The URLs to track a booking via the web or the API.
    /// </summary>
    public sealed class TrackingUrls : IEquatable<TrackingUrls>
    {
        [JsonConstructor]
        private TrackingUrls(Uri www, Uri api)
        {
            Www = www;
            Api = api;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> to track via the web.
        /// </summary>
        public Uri Www { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to track via the API.
        /// </summary>
        public Uri Api { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as TrackingUrls);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(TrackingUrls other)
        {
            return other is null
                ? false
                : Www == other.Www && Api == other.Api;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="TrackingUrls"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="TrackingUrls"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Www, Api).GetHashCode();
        }
    }
}
