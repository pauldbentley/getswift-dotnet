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
        public void CancelFinishedJob()
        {
            new DeliveryCancelFinishedJob().Run();
        }

        [Fact]
        public void CancelFinishedJobAsync()
        {
            new DeliveryCancelFinishedJob().RunAsync();
        }

        [Fact]
        public void CancelWithInvalidId()
        {
            new DeliveryCancelWithInvalidIdTest().Run();
        }

        [Fact]
        public void CancelWithInvalidIdAsync()
        {
            new DeliveryCancelWithInvalidIdTest().RunAsync();
        }

        [Theory]
        [InlineData(DeliveryApiFilter.Active)]
        [InlineData(DeliveryApiFilter.All)]
        [InlineData(DeliveryApiFilter.Cancelled)]
        [InlineData(DeliveryApiFilter.Successful)]
        public void List(DeliveryApiFilter filter)
        {
            new DeliveryListTest(filter).Run();
        }

        [Theory]
        [InlineData(DeliveryApiFilter.Active)]
        [InlineData(DeliveryApiFilter.All)]
        [InlineData(DeliveryApiFilter.Cancelled)]
        [InlineData(DeliveryApiFilter.Successful)]
        public void ListAsync(DeliveryApiFilter filter)
        {
            new DeliveryListTest(filter).RunAsync();
        }
    }
}