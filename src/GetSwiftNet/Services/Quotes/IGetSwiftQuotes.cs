namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to Drivers in GetSwift.
    /// </summary>
    public interface IGetSwiftQuotes
    {
        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        string ServicePath { get; }

        /// <summary>
        /// Obtain time and price estimations for a delivery.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        QuoteResponse Create(QuoteCreateInput input);

        /// <summary>
        /// Obtain time and price estimations for a delivery asynchronously.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        Task<QuoteResponse> CreateAsync(QuoteCreateInput input, CancellationToken cancellationToken = default);
    }
}