namespace GetSwiftNet.Tests
{
    public interface IDeliveryListAssert
    {
        void Assert(PagedApiList<DeliveryDetails> actual);
    }
}
