namespace GetSwiftNet
{
    using System.Threading;
    using System.Threading.Tasks;
    using EnsuredOutcomes;

    /// <summary>
    /// The Quotes service.
    /// </summary>
    public class QuoteService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteService"/> class.
        /// </summary>
        /// <param name="configuration">The system configuration.</param>
        public QuoteService(GetSwiftConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Gets the path to the service.
        /// </summary>
        public override string ServicePath => "quotes";

        /// <summary>
        /// Obtain time and price estimations for a delivery.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        public QuoteResponse Create(QuoteCreateInput input)
        {
            Ensure.NotNull(input, nameof(input));
            return PostRequest<QuoteResponse>(string.Empty, input);
        }

        /// <summary>
        /// Obtain time and price estimations for a delivery asynchronously.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        public Task<QuoteResponse> CreateAsync(QuoteCreateInput input, CancellationToken cancellationToken = default)
        {
            Ensure.NotNull(input, nameof(input));
            return PostRequestAsync<QuoteResponse>(string.Empty, input, cancellationToken);
        }
    }
}