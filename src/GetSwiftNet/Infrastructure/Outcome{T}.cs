namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Linq;

    /// <summary>
    /// A result wrapper indicating the outcome of an operation.
    /// </summary>
    /// <typeparam name="T">The type of object returned.</typeparam>
    public class Outcome<T> : Outcome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome{T}"/> class.
        /// </summary>
        /// <param name="value">The value of object returned.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="value"/> is null.</exception>
        internal Outcome(T value)
            : base()
        {
            Guard.NotNull(value, nameof(value));
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Outcome{T}"/> class.
        /// </summary>
        /// <param name="errors">The errors raised during the operation.</param>
        internal Outcome(params Exception[] errors)
            : base(errors)
        {
        }

        /// <summary>
        /// Gets the value of the object returned from successful operations.  Otherwise, null.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Implicit operator from <see cref="Outcome{T}"/> to a given type.
        /// </summary>
        /// <param name="result">The result.</param>
        public static implicit operator T(Outcome<T> result) => result.ToT();

        /// <summary>
        /// Returns the value of the result.
        /// </summary>
        /// <returns>The value of the result.</returns>
        /// <exception cref="Exception">When the outcome of the operation is a failure.</exception>
        public T ToT()
        {
            Exceptions.Throw(Errors.FirstOrDefault());
            return Value;
        }
    }
}
