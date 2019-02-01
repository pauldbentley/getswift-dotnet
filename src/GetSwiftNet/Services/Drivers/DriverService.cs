namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Drivers service.
    /// </summary>
    public class DriverService : Service
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// </summary>
        public DriverService()
            : base(GetSwiftConfiguration.BaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class with a given API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public DriverService(Guid apiKey)
            : base(GetSwiftConfiguration.BaseUrl, apiKey)
        {
        }

        /// <summary>
        /// Gets the base path to the service.
        /// </summary>
        public override string ServicePath => "drivers";

        /// <summary>
        /// View information about a driver.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>The driver with the given identifier or null if the driver doesn't exist.</returns>
        public Driver Get(DriverGetInput input)
        {
            Guard.NotNull(input, nameof(input));

            return GetRequest<Driver>(input.Id.ToString(), input);
        }

        /// <summary>
        /// View information about a driver asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Driver"/> with the given identifier or null if the driver doesn't exist.</returns>
        public Task<Driver> GetAsync(DriverGetInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return GetRequestAsync<Driver>(input.Id.ToString(), input, cancellationToken);
        }

        /// <summary>
        /// List drivers.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>A <see cref="ModelCollection{T}"/> of <see cref="Driver"/> objects.</returns>
        public ModelCollection<Driver> List(DriverListInput input)
        {
            Guard.NotNull(input, nameof(input));

            return GetRequest<ModelCollection<Driver>>(input);
        }

        /// <summary>
        /// List drivers asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="ModelCollection{T}"/> of <see cref="Driver"/> objects.</returns>
        public Task<ModelCollection<Driver>> ListAsync(DriverListInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return GetRequestAsync<ModelCollection<Driver>>(input, cancellationToken);
        }
    }
}