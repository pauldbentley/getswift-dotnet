namespace GetSwiftNet
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the input required to get the details of a delivery.
    /// </summary>
    public class DeliveryGetInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryGetInput"/> class.
        /// </summary>
        /// <param name="id">The delivery identifier.</param>
        public DeliveryGetInput(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the delivery identifier.
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="DeliveryDetails.StageHistory"/> property should be expanded.
        /// </summary>
        [JsonIgnore]
        public bool ExpandStageHistory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="DeliveryDetails.Constraints"/> property should be expanded.
        /// </summary>
        [JsonIgnore]
        public bool ExpandConstraints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="DeliveryDetails.Items"/> property should be expanded.
        /// </summary>
        [JsonIgnore]
        public bool ExpandItems { get; set; }
    }
}