namespace GetSwiftNet
{
    /// <summary>
    /// Defines the response from a test run.
    /// </summary>
    public class TestRunResponse
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
