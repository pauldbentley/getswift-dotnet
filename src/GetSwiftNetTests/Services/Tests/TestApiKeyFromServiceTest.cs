namespace GetSwiftNet.Tests
{
    using System;
    using Shouldly;

    internal class TestApiKeyFromServiceTest : TestMethod<TestRunInput, TestRunResponse>
    {
        private static Guid ConfigurationApiKey { get; } = new Guid("00000000-0000-0000-0000-000000000001");

        private static Guid ServiceApiKey { get; } = new Guid("00000000-0000-0000-0000-000000000002");

        private TestService Service { get; set; }

        public override TestRunResponse Act()
        {
            // This should take the API from the service
            var actual = Service.Run(Input);
            return actual;
        }

        public override bool Arrange()
        {
            GetSwiftConfiguration.ApiKey = ConfigurationApiKey;
            Service = new TestService(ServiceApiKey);
            Input = new TestRunInput();

            return true;
        }

        public override void Assert(TestRunResponse actual)
        {
            base.Assert(actual);
            actual.Success.ShouldBe(true);
            Input.ApiKey.ShouldBe(ServiceApiKey);
        }

        public override void Cleanup()
        {
            base.Cleanup();

            GetSwiftConfiguration.ApiKey = null;
        }
    }
}
