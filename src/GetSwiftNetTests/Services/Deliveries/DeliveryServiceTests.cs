namespace GetSwiftNet.Tests
{
    using Xunit;

    public class DeliveryServiceTests
    {
        [Fact]
        public void Get()
        {
            new DeliveryGetTest().Run();
        }

        [Fact]
        public void GetAsync()
        {
            new DeliveryGetTest().RunAsync();
        }

        [Fact]
        public void GetExpanded()
        {
            new DeliveryGetExpandedTest().Run();
        }

        [Fact]
        public void GetExpandedAsync()
        {
            new DeliveryGetExpandedTest().RunAsync();
        }

        [Fact]
        public void CancelInvalidJob()
        {
            new DeliveryCancelInvalidJobTest().Run();
        }

        [Fact]
        public void CancelInvalidJobAsync()
        {
            new DeliveryCancelInvalidJobTest().RunAsync();
        }
    }
}