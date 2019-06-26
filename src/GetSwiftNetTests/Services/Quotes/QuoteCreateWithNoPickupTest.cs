namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class QuoteCreateWithNoPickupTest : AsyncTestMethod<QuoteCreateInput, GetSwiftException>
    {
        private QuoteService Service { get; set; }

        public override GetSwiftException Act()
        {
            return Should.Throw<GetSwiftException>(() => Service.Create(Input));
        }

        public override Task<GetSwiftException> ActAsync()
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.CreateAsync(Input));
        }

        public override bool Arrange()
        {
            if (TestConstants.ServiceBasedMarchant)
            {
                return false;
            }

            Service = new QuoteService(TestConstants.Configuration);
            Input = new QuoteCreateInput("105 collins st, 3000");

            return true;
        }

        public override void Assert(GetSwiftException actual)
        {
            base.Assert(actual);

            actual.GetSwiftError.ShouldBe(GetSwiftError.InvalidPickupAddress);
        }
    }
}
