namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Helper class for creating <see cref="Outcome"/> instances.
    /// </summary>
    internal static class Outcomes
    {
        /// <summary>
        /// Creates a successful outcome.
        /// </summary>
        /// <returns>An <see cref="Outcome"/> with the <see cref="Outcome.Success"/> property set to true.</returns>
        public static Outcome Success() => new Outcome();

        /// <summary>
        /// Creates a successful outcome.
        /// </summary>
        /// <typeparam name="T">The type of object returned.</typeparam>
        /// <param name="value">The object returned.</param>
        /// <returns>An <see cref="Outcome"/> with the <see cref="Outcome.Success"/> property set to true.</returns>
        public static Outcome<T> Success<T>(T value) => new Outcome<T>(value);

        /// <summary>
        /// Creates a failure outcome.
        /// </summary>
        /// <param name="errors">The errors raised during the operation.</param>
        /// <returns>An <see cref="Outcome"/> with the <see cref="Outcome.Failure"/> property set to true.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="errors"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="errors"/> do not contain any non-null values.</exception>
        public static Outcome Failure(params Exception[] errors) => new Outcome(errors);

        /// <summary>
        /// Creates a failure outcome.
        /// </summary>
        /// <typeparam name="T">The type of object returned.</typeparam>
        /// <param name="errors">The errors raised during the operation.</param>
        /// <returns>An <see cref="Outcome"/> with the <see cref="Outcome.Failure"/> property set to true.</returns>
        public static Outcome<T> Failure<T>(params Exception[] errors) => new Outcome<T>(errors);

        /// <summary>
        /// Creates the revelant <see cref="Outcome"/> based on there being an exception or not.
        /// </summary>
        /// <param name="errorException">The error raised during the operation, if any.</param>
        /// <returns>An <see cref="Outcome"/>.</returns>
        public static Outcome Create(Exception errorException)
        {
            return errorException == null
                ? Success()
                : Failure(errorException);
        }
    }
}
