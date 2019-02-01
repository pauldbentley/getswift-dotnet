namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverListTest : AsyncTestMethod<DriverListInput, ApiList<Driver>>
    {
        public DriverListTest(DriverApiFilter filter)
        {
            Filter = filter;
        }

        private DriverApiFilter Filter { get; }

        private DriverService Service { get; set; }

        public override ApiList<Driver> Act()
        {
            return Service.List(Input);
        }

        public override Task<ApiList<Driver>> ActAsync()
        {
            return Service.ListAsync(Input);
        }

        public override bool Arrange()
        {
            if (!TestConstants.HasDrivers)
            {
                return false;
            }

            Service = new DriverService(TestConstants.ApiKey);
            Input = new DriverListInput
            {
                Filter = Filter
            };

            return true;
        }

        public override void Assert(ApiList<Driver> actual)
        {
            base.Assert(actual);

            actual.Data.ShouldNotBeNull();

            var assert = CreateAssert(Filter);
            assert.Assert(actual);
        }

        private static IDriverListTestAssert CreateAssert(DriverApiFilter filter)
        {
            switch (filter)
            {
                case DriverApiFilter.Activated:
                    return new DriverListActivatedTest();

                case DriverApiFilter.Deactivated:
                    return new DriverListDeactivatedTest();

                case DriverApiFilter.Invited:
                    return new DriverListInvitedTest();

                case DriverApiFilter.OnlineNow:
                    return new DriverListOnlineNowTest();

                default:
                    return new DriverListAllTest();
            }
        }
    }
}
