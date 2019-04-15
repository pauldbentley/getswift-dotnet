namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// Extension Add methods for <see cref="DeliveryEventWebhook"/> collection initializers.
    /// </summary>
    public static class DeliveryEventWebhookCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="DeliveryEventWebhook"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="url">The URL to be called when the event occurs.</param>
        public static void Add(this ICollection<DeliveryEventWebhook> collection, string eventName, Uri url)
        {
            Guard.NotNull(collection, nameof(collection));

            var outcome = DeliveryEventWebhook.Create(eventName, url);

            if (outcome.Success)
            {
                collection.Add(outcome.Value);
            }
            else
            {
                Exceptions.Throw(outcome.Errors.First());
            }
        }

        /// <summary>
        /// Adds a new <see cref="DeliveryEventWebhook"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="url">The URL to be called when the event occurs.</param>
        public static void Add(this ICollection<DeliveryEventWebhook> collection, string eventName, string url) => Add(collection, eventName, new Uri(url));
    }
}
