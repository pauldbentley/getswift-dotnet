namespace GetSwiftNet
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// A test service.
    /// </summary>
    internal class TestService : Service
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class.
        /// </summary>
        public TestService()
            : base(Urls.TestBaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class with the given API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public TestService(Guid apiKey)
            : base(Urls.TestBaseUrl, apiKey)
        {
        }

        /// <summary>
        /// Gets the base path to the test service.
        /// </summary>
        public override string ServicePath => "test";

        /// <summary>
        /// Runs a test.
        /// </summary>
        /// <param name="input">The details to run the test.</param>
        /// <returns>A <see cref="TestRunResponse"/>.</returns>
        public TestRunResponse Run(TestRunInput input)
        {
            Guard.NotNull(input, nameof(input));

            return GetRequest<TestRunResponse>(input);
        }

        /// <summary>
        /// Runs a test asynchronously.
        /// </summary>
        /// <param name="input">The details to run the test.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="TestRunResponse"/>.</returns>
        public Task<TestRunResponse> RunAsync(TestRunInput input, CancellationToken cancellationToken = default(CancellationToken))
        {
            Guard.NotNull(input, nameof(input));

            return GetRequestAsync<TestRunResponse>(input, cancellationToken);
        }
    }
}
