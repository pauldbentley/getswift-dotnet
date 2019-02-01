namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Defines the input required to list drivers.
    /// </summary>
    public class DriverListInput
    {
        /// <summary>
        /// Gets or sets the API key for the merchant.
        /// This key will take priority over the key defined on the service or the <see cref="GetSwiftConfiguration.ApiKey"/>.
        /// </summary>
        public Guid? ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the driver filter.
        /// </summary>
        public DriverApiFilter Filter { get; set; }
    }
}