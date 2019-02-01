namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryGetTest : AsyncTestMethod<DeliveryGetInput, DeliveryDetails>
    {
        private DeliveryService Service { get; set; }

        public override DeliveryDetails Act(DeliveryGetInput input)
        {
            return Service.Get(input);
        }

        public override Task<DeliveryDetails> ActAsync(DeliveryGetInput input)
        {
            return Service.GetAsync(input);
        }

        public override DeliveryGetInput Arrange()
        {
            Service = new DeliveryService(TestConstants.ApiKey);

            return new DeliveryGetInput(TestConstants.DeliveryId);
        }

        public override void Assert(DeliveryGetInput input, DeliveryDetails actual)
        {
            base.Assert(input, actual);

            if (!input.ExpandStageHistory)
            {
                actual.StageHistory.ShouldBeEmpty();
            }

            if (!input.ExpandConstraints)
            {
                actual.Constraints.ShouldBeEmpty();
            }

            if (!input.ExpandItems)
            {
                actual.Items.ShouldBeEmpty();
            }
        }
    }
}
