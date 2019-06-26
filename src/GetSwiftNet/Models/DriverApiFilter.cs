namespace GetSwiftNet
{
    /// <summary>
    /// Defines the options to filter drivers.
    /// </summary>
    public enum DriverApiFilter
    {
        /// <summary>
        /// Add drivers.
        /// </summary>
        All = 0,

        /// <summary>
        /// Drivers who are currently online.
        /// </summary>
        OnlineNow = 1,

        /// <summary>
        /// Drivers who are activated.
        /// </summary>
        Activated = 2,

        /// <summary>
        /// Drivers who have been invited.
        /// </summary>
        Invited = 3,

        /// <summary>
        /// Drivers who have been deactivated.
        /// </summary>
        Deactivated = 4,
    }
}