namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryCancelWithInvalidIdTest : AsyncTestMethod<DeliveryCancelInput, GetSwiftException>
    {
        private DeliveryService Service { get; set; }

        public override GetSwiftException Act()
        {
            return Should.Throw<GetSwiftException>(() => Service.Cancel(Input));
        }

        public override Task<GetSwiftException> ActAsync()
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.CancelAsync(Input));
        }

        public override bool Arrange()
        {
            Service = new DeliveryService(TestConstants.Configuration);
            Input = new DeliveryCancelInput(Guid.Empty);

            return true;
        }

        public override void Assert(GetSwiftException actual)
        {
            base.Assert(actual);

            actual.GetSwiftError.ShouldBe(GetSwiftError.Unspecified);
        }
    }
}
