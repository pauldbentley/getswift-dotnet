namespace GetSwiftNet.Tests
{
    using System;
    using Shouldly;

    public class TestApiKeyFromInputTest : TestMethod<TestRunInput, TestRunResponse>
    {
        private static readonly Guid ConfigurationApiKey = new Guid("00000000-0000-0000-0000-000000000001");
        private static readonly Guid ServiceApiKey = new Guid("00000000-0000-0000-0000-000000000002");
        private static readonly Guid InputApiKey = new Guid("00000000-0000-0000-0000-000000000003");

        private TestService Service { get; set; }

        public override TestRunResponse Act(TestRunInput input)
        {
            // This should take the API from the service
            var actual = Service.Run(input);
            GetSwiftConfiguration.ApiKey = null;
            return actual;
        }

        public override TestRunInput Arrange()
        {
            GetSwiftConfiguration.ApiKey = ConfigurationApiKey;
            Service = new TestService(ServiceApiKey);
            return new TestRunInput
            {
                ApiKey = InputApiKey
            };
        }

        public override void Assert(TestRunInput input, TestRunResponse actual)
        {
            base.Assert(input, actual);
            actual.Success.ShouldBe(true);
            input.ApiKey.ShouldBe(InputApiKey);
        }
    }
}
