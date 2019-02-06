namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DeliveryListAllAssert : IDeliveryListAssert
    {
        public void Assert(PagedApiList<DeliveryDetails> actual)
        {
            actual.Data.ShouldNotBeEmpty();
        }
    }
}
