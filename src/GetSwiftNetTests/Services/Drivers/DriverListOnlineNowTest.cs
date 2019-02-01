namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DriverListOnlineNowTest : IDriverListTestAssert
    {
        public void Assert(ApiList<Driver> actual)
        {
            if (TestConstants.HasOnlineDrivers)
            {
                actual.Data.ShouldNotBeEmpty();
            }
        }
    }
}
