namespace GetSwiftNet
{
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// Defines the response from a test run.
    /// </summary>
    internal class TestRunResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the test succeeded.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets the full response sent by the server.
        /// </summary>
        public ServiceResponse Response { get; private set; }
    }
}
