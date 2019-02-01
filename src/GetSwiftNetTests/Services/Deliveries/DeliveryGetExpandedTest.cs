namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryGetExpandedTest : AsyncTestMethod<DeliveryGetInput, DeliveryDetails>
    {
        private DeliveryService Service { get; set; }

        public override DeliveryDetails Act()
        {
            return Service.Get(Input);
        }

        public override Task<DeliveryDetails> ActAsync()
        {
            return Service.GetAsync(Input);
        }

        public override bool Arrange()
        {
            if (!TestConstants.DeliveryId.HasValue)
            {
                return false;
            }

            Service = new DeliveryService(TestConstants.ApiKey);
            Input = new DeliveryGetInput(TestConstants.DeliveryId.Value)
            {
                ExpandStageHistory = true,
                ExpandConstraints = TestConstants.DeliveryHasContraints,
                ExpandItems = TestConstants.DeliveryHasItems
            };

            return true;
        }

        public override void Assert(DeliveryDetails actual)
        {
            base.Assert(actual);

            actual.StageHistory.ShouldNotBeEmpty();

            if (Input.ExpandItems)
            {
                actual.Items.ShouldNotBeEmpty();
            }

            if (Input.ExpandConstraints)
            {
                actual.Constraints.ShouldNotBeEmpty();
            }
        }
    }
}
