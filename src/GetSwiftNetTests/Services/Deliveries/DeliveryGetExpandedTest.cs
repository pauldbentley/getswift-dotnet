namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    /// <summary>
    /// Tests the Expand properties.
    /// The delivery tested should have items and contraints otherwise it will fail.
    /// </summary>
    public class DeliveryGetExpandedTest : AsyncTestMethod<DeliveryGetInput, DeliveryDetails>
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

            return new DeliveryGetInput(TestConstants.DeliveryId)
            {
                ExpandStageHistory = true,
                ExpandConstraints = true,
                ExpandItems = true
            };
        }

        public override void Assert(DeliveryGetInput input, DeliveryDetails actual)
        {
            base.Assert(input, actual);

            actual.StageHistory.ShouldNotBeEmpty();

            actual.Items.ShouldNotBeEmpty();

            actual.Constraints.ShouldNotBeEmpty();
        }
    }
}
