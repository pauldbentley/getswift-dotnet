namespace GetSwiftNet.Tests
{
    using System;
    using Shouldly;

    public class TestApiKeyFromConfigurationTest : TestMethod<TestRunInput, TestRunResponse>
    {
        private static readonly Guid ConfigurationApiKey = new Guid("00000000-0000-0000-0000-000000000001");

        private TestService Service { get; set; }

        public override TestRunResponse Act(TestRunInput input)
        {
            // This should take the API from the configuration
            var actual = Service.Run(input);
            GetSwiftConfiguration.ApiKey = null;
            return actual;
        }

        public override TestRunInput Arrange()
        {
            GetSwiftConfiguration.ApiKey = ConfigurationApiKey;
            Service = new TestService();
            return new TestRunInput();
        }

        public override void Assert(TestRunInput input, TestRunResponse actual)
        {
            base.Assert(input, actual);
            actual.Success.ShouldBe(true);
            input.ApiKey.ShouldBe(ConfigurationApiKey);
        }
    }
}
