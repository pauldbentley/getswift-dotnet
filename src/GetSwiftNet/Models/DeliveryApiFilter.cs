namespace GetSwiftNet
{
    /// <summary>
    /// Defines the options to filter deliveries.
    /// </summary>
    public enum DeliveryApiFilter
    {
        /// <summary>
        /// Jobs that are currently in progress.
        /// </summary>
        Active = 0,

        /// <summary>
        /// The entire delivery history.
        /// </summary>
        All = 1,

        /// <summary>
        /// Deliveries that have previously completed successfully.
        /// </summary>
        Successful = 2,

        /// <summary>
        /// Deliveries that have been cancelled.
        /// </summary>
        Cancelled = 3
    }
}
