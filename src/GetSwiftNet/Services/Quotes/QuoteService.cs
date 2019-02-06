namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// The Quotes service.
    /// </summary>
    public class QuoteService : Service
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteService"/> class.
        /// </summary>
        public QuoteService()
            : base(GetSwiftConfiguration.BaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteService"/> class with a given API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public QuoteService(Guid apiKey)
            : base(GetSwiftConfiguration.BaseUrl, apiKey)
        {
        }

        /// <summary>
        /// Gets the base path to the service.
        /// </summary>
        public override string ServicePath => "quotes";

        /// <summary>
        /// Obtain time and price estimations for a delivery.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        public QuoteResponse Create(QuoteCreateInput input)
        {
            Guard.NotNull(input, nameof(input));

            return PostRequest<QuoteResponse>(input);
        }

        /// <summary>
        /// Obtain time and price estimations for a delivery asynchronously.
        /// </summary>
        /// <param name="input">The details to create the quote.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="QuoteResponse"/> containing a quote.</returns>
        public Task<QuoteResponse> CreateAsync(QuoteCreateInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return PostRequestAsync<QuoteResponse>(input, cancellationToken);
        }
    }
}