namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// Packages included in a delivery.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class DeliveryBookingItem : IEquatable<DeliveryBookingItem>
    {
        /// <summary>
        /// The minimum length of the <see cref="Description"/> property.
        /// </summary>
        public const int MinDescriptionLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="Description"/> property.
        /// </summary>
        public const int MaxDescriptionLength = 250;

        /// <summary>
        /// The maximum length of the <see cref="StockKeepingUnit"/> property.
        /// </summary>
        public const int MaxStockKeepingUnitLength = 50;

        private string stockKeepingUnit;

        [JsonConstructor]
        private DeliveryBookingItem(string description, string stockKeepingUnit, int? quantity, decimal? price)
        {
            Description = description;
            this.stockKeepingUnit = stockKeepingUnit;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Gets the item description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets or sets the stock keeping unit.
        /// </summary>
        [JsonProperty("sku")]
        public string StockKeepingUnit
        {
            get => stockKeepingUnit;
            set
            {
                Exceptions.Throw(ValidateStockKeepingUnit(value));
                stockKeepingUnit = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity of this item.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total price for this line (i.e. includes the qty calculation, not the unit price).
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Creates a new <see cref="DeliveryBookingItem"/> with a specified description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingItem> Create(string description) => Create(description, null);

        /// <summary>
        /// Creates a new <see cref="DeliveryBookingItem"/> with a specified description and stock keeping unit.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="stockKeepingUnit">The stock keeping unit.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingItem> Create(string description, string stockKeepingUnit)
        {
            var errors = new[]
            {
                ValidateDescription(description),
                ValidateStockKeepingUnit(stockKeepingUnit)
            };

            return !Exceptions.Any(errors)
                ? Outcomes.Success(new DeliveryBookingItem(description, stockKeepingUnit, null, null))
                : Outcomes.Failure<DeliveryBookingItem>(errors);
        }

        /// <summary>
        /// Creates a new <see cref="DeliveryBookingItem"/> with the specified values.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="stockKeepingUnit">The stock keeping unit.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="price">The price.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingItem> Create(string description, string stockKeepingUnit, int quantity, decimal price)
        {
            var result = Create(description, stockKeepingUnit);

            if (result.Success)
            {
                result.Value.Quantity = quantity;
                result.Value.Price = price;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the description is valid.
        /// </summary>
        /// <param name="description">The description to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckDescription(string description)
        {
            return Outcomes.Create(ValidateDescription(description));
        }

        /// <summary>
        /// Determines whether the specified stock keeping unit is valid.
        /// </summary>
        /// <param name="stockKeepingUnit">The stock keeping unit to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckStockKeepingUnit(string stockKeepingUnit)
        {
            return Outcomes.Create(ValidateStockKeepingUnit(stockKeepingUnit));
        }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as DeliveryBookingItem);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(DeliveryBookingItem other)
        {
            return other is null
                ? false
                : Description == other.Description && StockKeepingUnit == other.StockKeepingUnit && Quantity == other.Quantity && Price == other.Price;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="DeliveryEventWebhook"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="DeliveryEventWebhook"/> instance.</returns>
        public override int GetHashCode() => new { Description, StockKeepingUnit, Quantity, Price }.GetHashCode();

        private static Exception ValidateDescription(string description)
        {
            return
                Exceptions.WhenNullOrWhitespace(description, nameof(description)) ??
                Exceptions.WhenLengthIsIncorrect(description, MinDescriptionLength, MaxDescriptionLength, nameof(description));
        }

        private static Exception ValidateStockKeepingUnit(string stockKeepingUnit)
        {
            return
                (stockKeepingUnit != null ? Exceptions.WhenNullOrWhitespace(stockKeepingUnit, nameof(stockKeepingUnit)) : null) ??
                Exceptions.WhenLengthIsIncorrect(stockKeepingUnit, 0, MaxStockKeepingUnitLength, nameof(stockKeepingUnit));
        }

        private string DebuggerDisplay() => Description;
    }
}
