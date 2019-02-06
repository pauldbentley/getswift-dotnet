namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DeliveryListActiveAssert : IDeliveryListAssert
    {
        public void Assert(PagedApiList<DeliveryDetails> actual)
        {
            if (TestConstants.HasActiveDeliveries)
            {
                actual.Data.ShouldNotBeEmpty();
            }
        }
    }
}
