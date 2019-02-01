namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryCancelInvalidJobTest : AsyncTestMethod<DeliveryCancelInput, GetSwiftException>
    {
        private DeliveryService Service { get; set; }

        public override GetSwiftException Act(DeliveryCancelInput input)
        {
            return Should.Throw<GetSwiftException>(() => Service.Cancel(input));
        }

        public override Task<GetSwiftException> ActAsync(DeliveryCancelInput input)
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.CancelAsync(input));
        }

        public override DeliveryCancelInput Arrange()
        {
            Service = new DeliveryService(TestConstants.ApiKey);

            return new DeliveryCancelInput(Guid.Empty);
        }

        public override void Assert(DeliveryCancelInput input, GetSwiftException actual)
        {
            base.Assert(input, actual);

            // The error code could be better here
            // but this is what it returned.
            actual.Response.ErrorCode.ShouldBe(ErrorCode.Unspecified);
        }
    }
}
