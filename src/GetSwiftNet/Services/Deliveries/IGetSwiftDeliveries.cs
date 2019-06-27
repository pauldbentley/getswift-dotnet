namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to Deliveries in GetSwift.
    /// </summary>
    public interface IGetSwiftDeliveries
    {
        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        string ServicePath { get; }

#pragma warning disable CA1716 // Identifiers should not match keywords
        /// <summary>
        /// Get the details of a delivery.
        /// </summary>
        /// <param name="input">The input required to obtain the details of a delivery.</param>
        /// <returns>The details of the requested delivery.</returns>
        DeliveryDetails Get(DeliveryGetInput input);
#pragma warning restore CA1716 // Identifiers should not match keywords

        /// <summary>
        /// Get the details of a delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to obtain the details of a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the requested delivery.</returns>
        Task<DeliveryDetails> GetAsync(DeliveryGetInput input, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        PagedApiList<DeliveryDetails> List(DeliveryListInput input);

        /// <summary>
        /// Gets a list of deliveries.
        /// </summary>
        /// <param name="input">The input required to list deliveries.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="PagedApiList{T}"/> of <see cref="DeliveryDetails"/> objects.</returns>
        Task<PagedApiList<DeliveryDetails>> ListAsync(DeliveryListInput input, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an active delivery.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        DeliveryDetails Cancel(DeliveryCancelInput input);

        /// <summary>
        /// Cancels an active delivery asynchronously.
        /// </summary>
        /// <param name="input">The input required to cancel a delivery.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the cancelled delivery.</returns>
        Task<DeliveryDetails> CancelAsync(DeliveryCancelInput input, CancellationToken cancellationToken = default);
    }
}
