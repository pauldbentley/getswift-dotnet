namespace GetSwiftNet.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverListTest : AsyncTestMethod<DriverListInput, ModelCollection<Driver>>
    {
        public DriverListTest(DriverApiFilter filter)
        {
            Filter = filter;
        }

        public DriverApiFilter Filter { get; }

        private DriverService Service { get; set; }

        public override ModelCollection<Driver> Act(DriverListInput input)
        {
            return Service.List(input);
        }

        public override Task<ModelCollection<Driver>> ActAsync(DriverListInput input)
        {
            return Service.ListAsync(input);
        }

        public override DriverListInput Arrange()
        {
            Service = new DriverService(TestConstants.ApiKey);

            return new DriverListInput
            {
                Filter = Filter
            };
        }

        public override void Assert(DriverListInput input, ModelCollection<Driver> actual)
        {
            base.Assert(input, actual);
        }
    }
}
