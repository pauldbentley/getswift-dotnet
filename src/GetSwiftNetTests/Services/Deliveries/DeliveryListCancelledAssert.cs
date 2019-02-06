namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DeliveryListCancelledAssert : IDeliveryListAssert
    {
        public void Assert(PagedApiList<DeliveryDetails> actual)
        {
            if (TestConstants.HasCancelledDeliveries)
            {
                actual.Data.ShouldNotBeEmpty();
            }
        }
    }
}
