namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;

    public abstract class AsyncTestMethod<TInput, TOutput> : TestMethod<TInput, TOutput>
    {
        public async void RunAsync()
        {
            var input = Arrange();
            var actual = await ActAsync(input).ConfigureAwait(false);
            Assert(input, actual);
        }

        public abstract Task<TOutput> ActAsync(TInput input);
    }
}