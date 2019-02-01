namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class DriverGetWithNonExistentIdTest : AsyncTestMethod<DriverGetInput, GetSwiftException>
    {
        private DriverService Service { get; set; }

        public override GetSwiftException Act(DriverGetInput input)
        {
            return Should.Throw<GetSwiftException>(() => Service.Get(input));
        }

        public override Task<GetSwiftException> ActAsync(DriverGetInput input)
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.GetAsync(input));
        }

        public override DriverGetInput Arrange()
        {
            Service = new DriverService();
            return new DriverGetInput(Guid.Empty);
        }

        public override void Assert(DriverGetInput input, GetSwiftException actual)
        {
            base.Assert(input, actual);

            actual.Response.ErrorCode.ShouldBe(ErrorCode.NoData);
        }
    }
}
