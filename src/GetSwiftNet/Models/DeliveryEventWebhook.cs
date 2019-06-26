namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using EnsuredOutcomes;
    using Newtonsoft.Json;

    /// <summary>
    /// Describes a webhook callback for a particular delivery event.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class DeliveryEventWebhook : IEquatable<DeliveryEventWebhook>
    {
        /// <summary>
        /// The minimum length of the <see cref="EventName"/> property.
        /// </summary>
        public const int MinEventNameLength = 1;

        [JsonConstructor]
        private DeliveryEventWebhook(string eventName, Uri url)
        {
            EventName = eventName;
            Url = url;
        }

        /// <summary>
        /// Gets the name of event (see webhooks documentation for a list of events and data).
        /// </summary>
        public string EventName { get; }

        /// <summary>
        /// Gets the URL to be called when the event occurs.
        /// </summary>
        public Uri Url { get; }

        /// <summary>
        /// Creates a <see cref="DeliveryEventWebhook"/> with the specified values.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="url">The URL to be called when the event occurs.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryEventWebhook> Create(string eventName, string url)
        {
            var errors = new[]
            {
                ValidateEventName(eventName),
                ValidateUrl(url),
            };

            if (!Exceptions.Any(errors))
            {
                return Outcomes.Success(new DeliveryEventWebhook(eventName, new Uri(url)));
            }

            return Outcomes.Failure<DeliveryEventWebhook>(errors);
        }

        /// <summary>
        /// Creates a <see cref="DeliveryEventWebhook"/> with the specified values.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="url">The URL to be called when the event occurs.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryEventWebhook> Create(string eventName, Uri url)
        {
            var errors = new[]
            {
                ValidateEventName(eventName),
                ValidateUrl(url),
            };

            if (!Exceptions.Any(errors))
            {
                return Outcomes.Success(new DeliveryEventWebhook(eventName, url));
            }

            return Outcomes.Failure<DeliveryEventWebhook>(errors);
        }

        /// <summary>
        /// Determines whether the specified event name is valid.
        /// </summary>
        /// <param name="eventName">The event name to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckEventName(string eventName)
        {
            return Outcomes.Determine(ValidateEventName(eventName));
        }

        /// <summary>
        /// Determines whether the specified URL is valid.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckUrl(string url)
        {
            return Outcomes.Determine(ValidateUrl(url));
        }

        /// <summary>
        /// Determines whether the specified URL is valid.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckUrl(Uri url)
        {
            return Outcomes.Determine(ValidateUrl(url));
        }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as DeliveryEventWebhook);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(DeliveryEventWebhook other)
        {
            return other is null
                ? false
                : EventName == other.EventName && Url == other.Url;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="DeliveryEventWebhook"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="DeliveryEventWebhook"/> instance.</returns>
        public override int GetHashCode() => new { EventName, Url }.GetHashCode();

        private static Exception ValidateEventName(string eventName)
        {
            return
                Exceptions.WhenNullOrWhiteSpace(eventName, nameof(eventName)) ??
                Exceptions.WhenLengthIsIncorrect(eventName, MinEventNameLength, int.MaxValue, nameof(eventName));
        }

        private static Exception ValidateUrl(string url)
        {
            var nullCheck = Exceptions.WhenNullOrWhiteSpace(url, nameof(url));

            if (nullCheck != null)
            {
                return nullCheck;
            }

            try
            {
                var uri = new Uri(url);
            }
            catch (UriFormatException exception)
            {
                return exception;
            }

            return null;
        }

        private static Exception ValidateUrl(Uri url)
        {
            return Exceptions.WhenNull(url, nameof(url));
        }

        private string DebuggerDisplay() => EventName;
    }
}
