namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;
    using EnsuredOutcomes;

    /// <summary>
    /// The Drivers service.
    /// </summary>
    public class DriverService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// </summary>
        /// <param name="configuration">The system configuration.</param>
        public DriverService(GetSwiftConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        public override string ServicePath => "drivers";

        /// <summary>
        /// View information about a driver.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>The driver with the given identifier or null if the driver doesn't exist.</returns>
        public Driver Get(DriverGetInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequest<Driver>(input.Id.ToString(), input);
        }

        /// <summary>
        /// View information about a driver asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Driver"/> with the given identifier or null if the driver doesn't exist.</returns>
        public Task<Driver> GetAsync(DriverGetInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequestAsync<Driver>(input.Id.ToString(), input, cancellationToken);
        }

        /// <summary>
        /// List drivers.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>An <see cref="ApiList{T}"/> of <see cref="Driver"/> objects.</returns>
        public ApiList<Driver> List(DriverListInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequest<ApiList<Driver>>(string.Empty, input);
        }

        /// <summary>
        /// List drivers asynchronously.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="ApiList{T}"/> of <see cref="Driver"/> objects.</returns>
        public Task<ApiList<Driver>> ListAsync(DriverListInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequestAsync<ApiList<Driver>>(string.Empty, input, cancellationToken);
        }
    }
}