namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverGetWithInvalidIdTest : AsyncTestMethod<DriverGetInput, GetSwiftException>
    {
        private DriverService Service { get; set; }

        public override GetSwiftException Act()
        {
            return Should.Throw<GetSwiftException>(() => Service.Get(Input));
        }

        public override Task<GetSwiftException> ActAsync()
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.GetAsync(Input));
        }

        public override bool Arrange()
        {
            Service = new DriverService();
            Input = new DriverGetInput(Guid.Empty);

            return true;
        }

        public override void Assert(GetSwiftException actual)
        {
            base.Assert(actual);

            actual.Response.ErrorCode.ShouldBe(ErrorCode.NoData);
        }
    }
}
