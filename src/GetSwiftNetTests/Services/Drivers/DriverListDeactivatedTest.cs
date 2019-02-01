namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DriverListDeactivatedTest : IDriverListTestAssert
    {
        public void Assert(ApiList<Driver> actual)
        {
            if (TestConstants.HasDeactivatedDrivers)
            {
                actual.Data.ShouldNotBeEmpty();
            }
        }
    }
}
