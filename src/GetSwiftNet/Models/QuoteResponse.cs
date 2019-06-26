namespace GetSwiftNet
{
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// The response when creating a quote.
    /// </summary>
    public sealed class QuoteResponse
    {
        [JsonConstructor]
        private QuoteResponse(Quote quote, DeliveryBooking request)
        {
            Quote = quote;
            Request = request;
        }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        public Quote Quote { get; }

        /// <summary>
        /// Gets the request data used when making the quote.
        /// </summary>
        public DeliveryBooking Request { get; }

        /// <summary>
        /// Gets the response sent by the server.
        /// </summary>
        public GetSwiftResponse Response { get; private set; }
    }
}
