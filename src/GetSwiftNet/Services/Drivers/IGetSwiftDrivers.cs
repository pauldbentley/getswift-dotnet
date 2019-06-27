namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to Drivers in GetSwift.
    /// </summary>
    public interface IGetSwiftDrivers
    {
        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        string ServicePath { get; }

#pragma warning disable CA1716 // Identifiers should not match keywords
        /// <summary>
        /// View information about a driver.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>The driver with the given identifier or null if the driver doesn't exist.</returns>
        Driver Get(DriverGetInput input);
#pragma warning restore CA1716 // Identifiers should not match keywords

        /// <summary>
        /// View information about a driver asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Driver"/> with the given identifier or null if the driver doesn't exist.</returns>
        Task<Driver> GetAsync(DriverGetInput input, CancellationToken cancellationToken = default);

        /// <summary>
        /// List drivers.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>An <see cref="ApiList{T}"/> of <see cref="Driver"/> objects.</returns>
        ApiList<Driver> List(DriverListInput input);

        /// <summary>
        /// List drivers asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="ApiList{T}"/> of <see cref="Driver"/> objects.</returns>
        Task<ApiList<Driver>> ListAsync(DriverListInput input, CancellationToken cancellationToken = default);
    }
}