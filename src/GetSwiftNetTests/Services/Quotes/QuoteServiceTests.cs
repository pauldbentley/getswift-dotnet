namespace GetSwiftNet.Tests
{
    using Xunit;

    public class QuoteServiceTests
    {
        [Fact]
        public void Create()
        {
            new QuoteCreateTest().Run();
        }

        [Fact]
        public void CreateAsync()
        {
            new QuoteCreateTest().RunAsync();
        }

        [Fact]
        public void CreateWithNoPickup()
        {
            new QuoteCreateWithNoPickupTest().Run();
        }

        [Fact]
        public void CreateWithNoPickupAsync()
        {
            new QuoteCreateWithNoPickupTest().RunAsync();
        }

        [Fact]
        public void CreateWithPastDeliveryWindow()
        {
            new QuoteCreateWithPastDeliveryWindow().Run();
        }

        [Fact]
        public void CreateWithPastDeliveryWindowAsync()
        {
            new QuoteCreateWithPastDeliveryWindow().RunAsync();
        }
    }
}