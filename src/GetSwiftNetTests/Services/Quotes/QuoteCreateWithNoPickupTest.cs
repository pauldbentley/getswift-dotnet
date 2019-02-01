namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    /// <summary>
    /// Tests that there is is pickup address defined.
    /// This will fail for service based marchants where a pickup address isn't required.
    /// </summary>
    public class QuoteCreateWithNoPickupTest : AsyncTestMethod<QuoteCreateInput, GetSwiftException>
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

            return new QuoteCreateInput("105 collins st, 3000");
        }

        public override void Assert(QuoteCreateInput input, GetSwiftException actual)
        {
            base.Assert(input, actual);

            actual.Response.ErrorCode.ShouldBe(ErrorCode.InvalidPickupAddress);
        }
    }
}
