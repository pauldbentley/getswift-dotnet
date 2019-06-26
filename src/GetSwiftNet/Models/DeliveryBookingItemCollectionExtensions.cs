namespace GetSwiftNet
{
    using System.Collections.Generic;
    using EnsuredOutcomes;

    /// <summary>
    /// Extension Add methods for <see cref="DeliveryBookingItem"/> collection initializers.
    /// </summary>
    public static class DeliveryBookingItemCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="DeliveryBookingItem"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="description">The description.</param>
        /// <param name="stockKeepingUnit">The stock keeping unit.</param>
        public static void Add(this ICollection<DeliveryBookingItem> collection, string description, string stockKeepingUnit)
        {
            Ensure.NotNull(collection, nameof(collection));

            var outcome = DeliveryBookingItem.Create(description, stockKeepingUnit);
            collection.AddOrThrow(outcome);
        }

        /// <summary>
        /// Adds a new <see cref="DeliveryBookingItem"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="description">The description.</param>
        /// <param name="stockKeepingUnit">The stock keeping unit.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="price">The price.</param>
        public static void Add(this ICollection<DeliveryBookingItem> collection, string description, string stockKeepingUnit, int quantity, decimal price)
        {
            Ensure.NotNull(collection, nameof(collection));

            var outcome = DeliveryBookingItem.Create(description, stockKeepingUnit, quantity, price);
            collection.AddOrThrow(outcome);
        }
    }
}