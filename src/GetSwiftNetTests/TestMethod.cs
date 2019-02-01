namespace GetSwiftNet.Tests
{
    using System;
    using System.Net;
    using Shouldly;

    /// <summary>
    /// Represents an AAA (Arrange, Act, Assert) pattern which is a common way of writing unit tests for a method under test.
    /// </summary>
    /// <typeparam name="TInput">The type of input the test accepts</typeparam>
    /// <typeparam name="TOutput">The type of output the test creats.</typeparam>
    public abstract class TestMethod<TInput, TOutput>
    {
        /// <summary>
        /// Run the test.
        /// </summary>
        public void Run()
        {
            var input = Arrange();
            var actual = Act(input);
            Assert(input, actual);
        }

        /// <summary>
        /// Initializes objects and sets the value of each set of data that is passed to the method under test.
        /// </summary>
        /// <returns>The input for the test.</returns>
        public abstract TInput Arrange();

        /// <summary>
        /// Invokes the method under test with the arranged parameters.
        /// </summary>
        /// <param name="input">The input to the method under test.</param>
        /// <returns>The output created by the method under test.</returns>
        public abstract TOutput Act(TInput input);

        /// <summary>
        /// Verifies that the action of the method under test behaves as expected.
        /// </summary>
        /// <param name="input">The input given to the method under test.</param>
        /// <param name="actual">The output created by the method under test.</param>
        public virtual void Assert(TInput input, TOutput actual)
        {
            actual.ShouldNotBeNull();

            var response = ServiceResponse.ObtainResponse(actual);
            response.ShouldNotBeNull();

            if (actual is GetSwiftException)
            {
                response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            }
            else if (actual is Exception)
            {
            }
            else
            {
                response.StatusCode.ShouldBe(HttpStatusCode.OK);
                response.ErrorCode.ShouldBe(ErrorCode.None);
            }
        }
    }
}
