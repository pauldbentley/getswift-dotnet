namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverGetTest : AsyncTestMethod<DriverGetInput, Driver>
    {
        private DriverService Service { get; set; }

        public override Driver Act()
        {
            return Service.Get(Input);
        }

        public override Task<Driver> ActAsync()
        {
            return Service.GetAsync(Input);
        }

        public override bool Arrange()
        {
            if (!TestConstants.HasDrivers || !TestConstants.DriverId.HasValue)
            {
                return false;
            }

            Service = new DriverService(TestConstants.Configuration);
            Input = new DriverGetInput(TestConstants.DriverId.Value);

            return true;
        }

        public override void Assert(Driver actual)
        {
            base.Assert(actual);

            actual.Identifier.ShouldBe(Input.Id);
        }
    }
}
