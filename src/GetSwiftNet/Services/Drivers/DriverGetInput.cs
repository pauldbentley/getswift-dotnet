namespace GetSwiftNet
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the input required to get the details of a driver.
    /// </summary>
    public class DriverGetInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverGetInput"/> class.
        /// </summary>
        /// <param name="id">The driver identifier.</param>
        public DriverGetInput(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the driver identifier.
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; }
    }
}
