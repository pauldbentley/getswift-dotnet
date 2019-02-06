namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DeliveryListSuccessfulAssert : IDeliveryListAssert
    {
        public void Assert(PagedApiList<DeliveryDetails> actual)
        {
            if (TestConstants.HasSuccessfulDeliveries)
            {
                actual.Data.ShouldNotBeEmpty();
            }
        }
    }
}
