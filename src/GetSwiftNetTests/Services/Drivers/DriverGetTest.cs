namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverGetTest : AsyncTestMethod<DriverGetInput, Driver>
    {
        private DriverService Service { get; set; }

        public override Driver Act(DriverGetInput input)
        {
            return Service.Get(input);
        }

        public override Task<Driver> ActAsync(DriverGetInput input)
        {
            return Service.GetAsync(input);
        }

        public override DriverGetInput Arrange()
        {
            Service = new DriverService();
            return new DriverGetInput(TestConstants.DriverId);
        }

        public override void Assert(DriverGetInput input, Driver actual)
        {
            base.Assert(input, actual);

            actual.Identifier.ShouldBe(input.Id);
        }
    }
}
