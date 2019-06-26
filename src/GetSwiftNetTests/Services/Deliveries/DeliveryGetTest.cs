namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryGetTest : AsyncTestMethod<DeliveryGetInput, DeliveryDetails>
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

            Service = new DeliveryService(TestConstants.Configuration);
            Input = new DeliveryGetInput(TestConstants.DeliveryId.Value);

            return true;
        }

        public override void Assert(DeliveryDetails actual)
        {
            base.Assert(actual);

            actual.StageHistory.ShouldBeEmpty();
            actual.Constraints.ShouldBeEmpty();
            actual.Items.ShouldBeEmpty();
        }
    }
}
