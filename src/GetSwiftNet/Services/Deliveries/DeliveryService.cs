namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;
    using EnsuredOutcomes;

    /// <summary>
    /// The Deliveries service.
    /// </summary>
    public class DeliveryService : ServiceBase, IGetSwiftDeliveries
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryService"/> class.
        /// </summary>
        /// <param name="configuration">The system configuration.</param>
        public DeliveryService(GetSwiftConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        public override string ServicePath => "deliveries";

        /// <summary>
        /// Get the details of a delivery.
        /// </summary>
        /// <param name="input">The input required to obtain the details of a delivery.</param>
        /// <returns>The details of the requested delivery.</returns>
        public DeliveryDetails Get(DeliveryGetInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequest<DeliveryDetails>(input.Id.ToString(), input);
        }

        /// <summary>
        /// Get the details of a delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to obtain the details of a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the requested delivery.</returns>
        public Task<DeliveryDetails> GetAsync(DeliveryGetInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequestAsync<DeliveryDetails>(input.Id.ToString(), input, cancellationToken);
        }

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        public PagedApiList<DeliveryDetails> List(DeliveryListInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequest<PagedApiList<DeliveryDetails>>(string.Empty, input);
        }

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        public Task<PagedApiList<DeliveryDetails>> ListAsync(DeliveryListInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return GetRequestAsync<PagedApiList<DeliveryDetails>>(string.Empty, input, cancellationToken);
        }

        /// <summary>
        /// Cancels an active delivery.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        public DeliveryDetails Cancel(DeliveryCancelInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return PostRequest<DeliveryDetails>("cancel", input);
        }

        /// <summary>
        /// Cancels an active delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        public Task<DeliveryDetails> CancelAsync(DeliveryCancelInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return PostRequestAsync<DeliveryDetails>("cancel", input, cancellationToken);
        }
    }
}