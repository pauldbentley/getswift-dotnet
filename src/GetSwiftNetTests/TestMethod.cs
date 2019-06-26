namespace GetSwiftNet.Tests
{
    using System;
    using System.Net;
    using GetSwiftNet.Infrastructure;
    using Shouldly;

    /// <summary>
    /// Represents an AAA (Arrange, Act, Assert) pattern which is a common way of writing unit tests for a method under test.
    /// </summary>
    /// <typeparam name="TInput">The type of input the test accepts</typeparam>
    /// <typeparam name="TOutput">The type of output the test creats.</typeparam>
    public abstract class TestMethod<TInput, TOutput>
    {
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        public TInput Input { get; set; }

        /// <summary>
        /// Run the test.
        /// </summary>
        public void Run()
        {
            if (Arrange())
            {
                var actual = Act();
                Assert(actual);
            }

            Cleanup();
        }

        /// <summary>
        /// Initializes objects and sets the value of <see cref="Input"/> which will be passed to the method under test.
        /// </summary>
        /// <returns>true if the test should execute, false otherwise.</returns>
        public abstract bool Arrange();

        /// <summary>
        /// Invokes the method under test with the arranged <see cref="Input"/> parameter.
        /// </summary>
        /// <returns>The output created by the method under test.</returns>
        public abstract TOutput Act();

        /// <summary>
        /// Verifies that the action of the method under test behaves as expected.
        /// </summary>
        /// <param name="actual">The output created by the method under test.</param>
        public virtual void Assert(TOutput actual)
        {
            actual.ShouldNotBeNull();

            var response = GetSwiftResponse.GetResponse(actual);
            response.ShouldNotBeNull();

            if (actual is GetSwiftException exception)
            {
                exception.HttpStatusCode.ShouldBe(HttpStatusCode.BadRequest);
            }
            else if (actual is Exception)
            {
            }
            else
            {
                response.StatusCode.ShouldBe(HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Performs a post-test cleanup.
        /// </summary>
        public virtual void Cleanup()
        {
            Input = default;
        }
    }
}
