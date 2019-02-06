namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DriverListInvitedTest : IDriverListTestAssert
    {
        public void Assert(ApiList<Driver> actual)
        {
            if (TestConstants.HasInvitedDrivers)
            {
                actual.ShouldNotBeEmpty();
            }
        }
    }
}
