namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DriverListActivatedTest : IDriverListTestAssert
    {
        public void Assert(ApiList<Driver> actual)
        {
            if (TestConstants.HasActivatedDrivers)
            {
                actual.ShouldNotBeEmpty();
            }
        }
    }
}
