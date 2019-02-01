namespace GetSwiftNet.Tests
{
    using System.Threading.Tasks;

    public abstract class AsyncTestMethod<TInput, TOutput> : TestMethod<TInput, TOutput>
    {
        public async void RunAsync()
        {
            if (Arrange())
            {
                var actual = await ActAsync().ConfigureAwait(false);
                Assert(actual);
            }

            Cleanup();
        }

        public abstract Task<TOutput> ActAsync();
    }
}