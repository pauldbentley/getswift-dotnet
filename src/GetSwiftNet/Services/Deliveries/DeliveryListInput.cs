namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Defines the input required to list deliveries.
    /// </summary>
    public class DeliveryListInput
    {
        /// <summary>
        /// Gets or sets the merchant API key.
        /// </summary>
        /// <remarks>This key will take priority over the key defined on the service.</remarks>
        public Guid? ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the delivery filter, e.g. to show only current orders.
        /// </summary>
        public DeliveryApiFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets date to only show deliveries starting at this date.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the driver identifier to only show deliveries allocated to this driver.
        /// </summary>
        public Guid? DriverId { get; set; }

        /// <summary>
        /// Gets or sets the page number of the results. Note the first page is 1 (not 0). Defaults to first page.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount of items to display in each page. Defaults to 50 records.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the maximum paging identifier.
        /// </summary>
        public int? PagingMaxId { get; set; }
    }
}