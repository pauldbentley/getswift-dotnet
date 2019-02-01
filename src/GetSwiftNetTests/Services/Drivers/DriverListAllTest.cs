namespace GetSwiftNet.Tests
{
    using Shouldly;

    public class DriverListAllTest : IDriverListTestAssert
    {
        public void Assert(ApiList<Driver> actual)
        {
            actual.Data.ShouldNotBeEmpty();
        }
    }
}
