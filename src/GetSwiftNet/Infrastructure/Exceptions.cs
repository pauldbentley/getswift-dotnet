namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Exceptions for invalid input parameters.
    /// </summary>
    internal static class Exceptions
    {
        /// <summary>
        /// Tests if the <paramref name="value"/> is null.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> if the test is true, null otherwise.</returns>
        public static ArgumentException WhenNull(object value, string parameterName)
        {
            return value == null
                ? ArgumentNull(parameterName)
                : null;
        }

        /// <summary>
        /// Tests if the <paramref name="value"/> is null or empty.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> if the test is true, null otherwise.</returns>
        public static ArgumentException WhenNullOrEmpty(string value, string parameterName)
        {
            return
                WhenNull(value, parameterName) ??
                (string.IsNullOrEmpty(value) ? ArgumentOutOfRange(parameterName, null, $"Value was out of range.  Must not be empty.") : null);
        }

        /// <summary>
        /// Tests if the <paramref name="value"/> is null or whitespace.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> if the test is true, null otherwise.</returns>
        public static ArgumentException WhenNullOrWhitespace(string value, string parameterName)
        {
            return
                WhenNullOrEmpty(value, parameterName) ??
                (string.IsNullOrWhiteSpace(value) ? ArgumentOutOfRange(parameterName, null, $"Value was out of range.  Must not be whitespace.") : null);
        }

        /// <summary>
        /// Tests if the length of <paramref name="value"/> is outside a minimum and maximum.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="maximumLength">The maximum length.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> instance if the test fails, null otherwise.</returns>
        public static ArgumentException WhenLengthIsIncorrect(string value, int minimumLength, int maximumLength, string parameterName)
        {
            // It is assumed that callers would have chacked for null or
            // empty prior to this call if this was a contraint.
            if (value == null)
            {
                return null;
            }

            string message = minimumLength == 0
                ? $"Value was out of range.  The length must be less than {maximumLength}."
                : $"Value was out of range.  The length must be between {minimumLength} and {maximumLength}.";

            return value.Length < minimumLength || value.Length > maximumLength
                ? ArgumentOutOfRange(parameterName, value, message)
                : null;
        }

        /// <summary>
        /// Tests if the <paramref name="value"/> matches a given pattern.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> instance if the test fails, null otherwise.</returns>
        public static ArgumentException WhenDoesNotMatchPattern(string value, string pattern, string parameterName)
        {
            return !Regex.IsMatch(value, pattern)
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range. Must match the pattern {pattern}.")
                : null;
        }

        /// <summary>
        /// Tests if the <paramref name="value"/> is greater than or equal to a minimum value.
        /// Dates are converted to universal time before comparison.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentException"/> instance if the test fails, null otherwise.</returns>
        public static ArgumentException WhenOutOfRange(DateTime value, DateTime minValue, string parameterName)
        {
            return value.ToUniversalTime() < minValue.ToUniversalTime()
                ? ArgumentOutOfRange(parameterName, value, $"Value was out of range.  Must be greater than {minValue}.")
                : null;
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentNullException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>An <see cref="ArgumentNullException"/></returns>
        public static ArgumentNullException ArgumentNull(string parameterName)
        {
            return new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception.</param>
        /// <param name="value">The value of the argument that causes this exception.</param>
        /// <returns>A new <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName, object value) => ArgumentOutOfRange(parameterName, value, null);

        /// <summary>
        /// Creates a new <see cref="ArgumentOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception.</param>
        /// <param name="value">The value of the argument that causes this exception.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <returns>A new <see cref="ArgumentOutOfRangeException"/> instance.</returns>
        public static ArgumentOutOfRangeException ArgumentOutOfRange(string parameterName, object value, string message)
        {
            return value == null
                ? new ArgumentOutOfRangeException(parameterName, message)
                : new ArgumentOutOfRangeException(parameterName, value, message);
        }

        /// <summary>
        /// Throws the given <see cref="Exception"/> if it is not null.
        /// </summary>
        /// <param name="exception">The exception to throw.</param>
        public static void Throw(Exception exception)
        {
            if (exception != null)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Determines whether any element in a sequence of <see cref="Exception"/> is not null.
        /// </summary>
        /// <param name="exceptions">A sequence of <see cref="Exception"/> to test.</param>
        /// <returns>true if there are any <see cref="Exception"/> object which are null.  Otherwise, false.</returns>
        public static bool Any(params Exception[] exceptions) => exceptions != null && exceptions.Any(e => e != null);
    }
}
