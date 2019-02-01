namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A result wrapper indicating the outcome of an operation.
    /// </summary>
    public class Outcome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome"/> class as a success outcome.
        /// </summary>
        protected internal Outcome()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome"/> class as a failure outcome.
        /// </summary>
        /// <param name="errors">Any errors which occurred during the operation.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="errors"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="errors"/> do not contain any non-null values.</exception>
        protected internal Outcome(params Exception[] errors)
        {
            Guard.NotNull(errors, nameof(errors));

            var nonNullErrors = errors.Where(e => e != null);
            if (!nonNullErrors.Any())
            {
                throw Exceptions.ArgumentOutOfRange(nameof(errors), errors);
            }

            Errors = errors.Where(e => e != null);
        }

        /// <summary>
        /// Gets a value indicating whether the result of the operation was a failure.
        /// </summary>
        public bool Failure => Errors.Any();

        /// <summary>
        /// Gets a value indicating whether the result of the operation was a success.
        /// </summary>
        public bool Success => !Failure;

        /// <summary>
        /// Gets an <see cref="Exception"/> raised when <see cref="Failure"/> is true, null otherwise.
        /// </summary>
        public IEnumerable<Exception> Errors { get; } = Enumerable.Empty<Exception>();
    }
}
