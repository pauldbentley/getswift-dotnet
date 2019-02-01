namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class QuoteCreateWithPastDeliveryWindow : AsyncTestMethod<QuoteCreateInput, GetSwiftException>
    {
        private QuoteService Service { get; set; }

        public override GetSwiftException Act(QuoteCreateInput input)
        {
            return Should.Throw<GetSwiftException>(() => Service.Create(input));
        }

        public override Task<GetSwiftException> ActAsync(QuoteCreateInput input)
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.CreateAsync(input));
        }

        public override QuoteCreateInput Arrange()
        {
            Service = new QuoteService(TestConstants.ApiKey);

            var input = new QuoteCreateInput("57 luscombe st, brunswick, melbourne", "105 collins st, 3000");

            input.Booking.DropoffWindow = TimeFrame.Create(DateTime.Now.AddDays(-100), DateTime.Now);

            return input;
        }

        public override void Assert(QuoteCreateInput input, GetSwiftException actual)
        {
            base.Assert(input, actual);

            actual.Response.ErrorCode.ShouldBe(ErrorCode.PastDeliveryWindow);
        }
    }
}
