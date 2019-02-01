namespace GetSwiftNet.Tests
{
    using Xunit;

    public class TestServiceTests
    {
        [Fact]
        public void ApiKeyFromConfiguration()
        {
            new TestApiKeyFromConfigurationTest().Run();
        }

        [Fact]
        public void ApiKeyFromService()
        {
            new TestApiKeyFromServiceTest().Run();
        }

        [Fact]
        public void ApiKeyFromInput()
        {
            new TestApiKeyFromInputTest().Run();
        }
    }
}
