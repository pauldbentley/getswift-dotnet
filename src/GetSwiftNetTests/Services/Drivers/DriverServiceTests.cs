namespace GetSwiftNet.Tests
{
    using Xunit;

    public class DriverServiceTests
    {
        [Fact]
        public void Get()
        {
            new DriverGetTest().Run();
        }

        [Fact]
        public void GetAsync()
        {
            new DriverGetTest().RunAsync();
        }

        [Fact]
        public void GetWithNonExistentId()
        {
            new DriverGetWithNonExistentIdTest().Run();
        }

        [Fact]
        public void GetWithNonExistentIdAsync()
        {
            new DriverGetWithNonExistentIdTest().RunAsync();
        }

        [Theory]
        [InlineData(DriverApiFilter.Activated)]
        [InlineData(DriverApiFilter.All)]
        [InlineData(DriverApiFilter.Deactivated)]
        [InlineData(DriverApiFilter.Invited)]
        [InlineData(DriverApiFilter.OnlineNow)]
        public void List(DriverApiFilter filter)
        {
            new DriverListTest(filter).Run();
        }

        [Theory]
        [InlineData(DriverApiFilter.Activated)]
        [InlineData(DriverApiFilter.All)]
        [InlineData(DriverApiFilter.Deactivated)]
        [InlineData(DriverApiFilter.Invited)]
        [InlineData(DriverApiFilter.OnlineNow)]
        public void ListAsync(DriverApiFilter filter)
        {
            new DriverListTest(filter).RunAsync();
        }
    }
}
