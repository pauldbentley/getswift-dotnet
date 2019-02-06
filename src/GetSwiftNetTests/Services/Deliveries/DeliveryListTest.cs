namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryListTest : AsyncTestMethod<DeliveryListInput, PagedApiList<DeliveryDetails>>
    {
        public DeliveryListTest(DeliveryApiFilter filter)
        {
            Filter = filter;
        }

        private DeliveryApiFilter Filter { get; }

        private DeliveryService Service { get; set; }

        public override PagedApiList<DeliveryDetails> Act()
        {
            return Service.List(Input);
        }

        public override Task<PagedApiList<DeliveryDetails>> ActAsync()
        {
            return Service.ListAsync(Input);
        }

        public override bool Arrange()
        {
            if (!TestConstants.HasDeliveries)
            {
                return false;
            }

            Service = new DeliveryService(TestConstants.ApiKey);
            Input = new DeliveryListInput
            {
                Filter = Filter
            };

            return true;
        }

        public override void Assert(PagedApiList<DeliveryDetails> actual)
        {
            base.Assert(actual);

            actual.Data.ShouldNotBeNull();
            actual.CurrentPage.ShouldBe(1);

            var assert = CreateAssert(Filter);
            assert.Assert(actual);
        }

        private static IDeliveryListAssert CreateAssert(DeliveryApiFilter filter)
        {
            switch (filter)
            {
                case DeliveryApiFilter.Active:
                    return new DeliveryListActiveAssert();

                case DeliveryApiFilter.Cancelled:
                    return new DeliveryListCancelledAssert();

                case DeliveryApiFilter.Successful:
                    return new DeliveryListSuccessfulAssert();

                default:
                    return new DeliveryListAllAssert();
            }
        }
    }
}
