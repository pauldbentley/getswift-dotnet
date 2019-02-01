namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DeliveryCancelFinishedJob : AsyncTestMethod<DeliveryCancelInput, GetSwiftException>
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
            if (!TestConstants.FinishedDeliveryId.HasValue)
            {
                return false;
            }

            Service = new DeliveryService(TestConstants.ApiKey);
            Input = new DeliveryCancelInput(TestConstants.FinishedDeliveryId.Value);

            return true;
        }

        public override void Assert(GetSwiftException actual)
        {
            base.Assert(actual);

            actual.Response.ErrorCode.ShouldBe(ErrorCode.Unspecified);
            actual.Message.ShouldBe("Job already finished");
        }
    }
}
