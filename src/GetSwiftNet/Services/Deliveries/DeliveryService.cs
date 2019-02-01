namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Deliveries service.
    /// </summary>
    public class DeliveryService : Service
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryService"/> class.
        /// </summary>
        public DeliveryService()
            : base(GetSwiftConfiguration.BaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryService"/> class with the specified API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public DeliveryService(Guid apiKey)
            : base(GetSwiftConfiguration.BaseUrl, apiKey)
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
            Guard.NotNull(input, nameof(input));

            return GetRequest<DeliveryDetails>(input.Id.ToString(), input);
        }

        /// <summary>
        /// Get the details of a delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to obtain the details of a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the requested delivery.</returns>
        public Task<DeliveryDetails> GetAsync(DeliveryGetInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return GetRequestAsync<DeliveryDetails>(input.Id.ToString(), input, cancellationToken);
        }

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        public PagedApiList<DeliveryDetails> List(DeliveryListInput input)
        {
            Guard.NotNull(input, nameof(input));

            return GetRequest<PagedApiList<DeliveryDetails>>(input);
        }

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        public Task<PagedApiList<DeliveryDetails>> ListAsync(DeliveryListInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return GetRequestAsync<PagedApiList<DeliveryDetails>>(input, cancellationToken);
        }

        /// <summary>
        /// Cancels an active delivery.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        public DeliveryDetails Cancel(DeliveryCancelInput input)
        {
            Guard.NotNull(input, nameof(input));

            return PostRequest<DeliveryDetails>("cancel", input);
        }

        /// <summary>
        /// Cancels an active delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        public Task<DeliveryDetails> CancelAsync(DeliveryCancelInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return PostRequestAsync<DeliveryDetails>("cancel", input, cancellationToken);
        }
    }
}