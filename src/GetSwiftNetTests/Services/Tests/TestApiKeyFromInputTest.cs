namespace GetSwiftNet.Tests
{
    using System;
    using Shouldly;

    public class TestApiKeyFromInputTest : TestMethod<TestRunInput, TestRunResponse>
    {
        private static Guid ConfigurationApiKey { get; } = new Guid("00000000-0000-0000-0000-000000000001");

        private static Guid ServiceApiKey { get; } = new Guid("00000000-0000-0000-0000-000000000002");

        private static Guid InputApiKey { get; } = new Guid("00000000-0000-0000-0000-000000000003");

        private TestService Service { get; set; }

        public override TestRunResponse Act()
        {
            var actual = Service.Run(Input);
            return actual;
        }

        public override bool Arrange()
        {
            GetSwiftConfiguration.ApiKey = ConfigurationApiKey;
            Service = new TestService(ServiceApiKey);
            Input = new TestRunInput
            {
                ApiKey = InputApiKey
            };

            return true;
        }

        public override void Assert(TestRunResponse actual)
        {
            base.Assert(actual);
            actual.Success.ShouldBe(true);
            Input.ApiKey.ShouldBe(InputApiKey);
        }

        public override void Cleanup()
        {
            base.Cleanup();

            GetSwiftConfiguration.ApiKey = null;
        }
    }
}
