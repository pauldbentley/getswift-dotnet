namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using EnsuredOutcomes;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// An email address.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    [JsonConverter(typeof(StringValueTypeConverter))]
    public sealed class Email : IEquatable<Email>
    {
        /// <summary>
        /// The minimum length of an email.
        /// </summary>
        public const int MinLength = 6;

        /// <summary>
        /// The maximum length of an email.
        /// </summary>
        public const int MaxLength = 100;

        /// <summary>
        /// The regular expression pattern of a valid email.
        /// </summary>
        public const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        private Email(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of the email.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Implicit operator from <see cref="Email"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="email">The email.</param>
        public static implicit operator string(Email email) => email?.Value;

        /// <summary>
        /// Implicit operator from <see cref="string"/> to <see cref="Email"/>.
        /// </summary>
        /// <param name="value">The email.</param>
        public static implicit operator Email(string value) => FromString(value);

        /// <summary>
        /// Creates a new <see cref="Email"/> instance with a specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<Email> Create(string value)
        {
            var error = ValidateValue(value);

            if (error == null)
            {
                return Outcomes.Success(new Email(value));
            }

            return Outcomes.Failure<Email>(error);
        }

        /// <summary>
        /// Determines whether the value is valid for an email.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckValue(string value)
        {
            return Outcomes.Determine(ValidateValue(value));
        }

        /// <summary>
        /// Attemps to create an <see cref="Email"/> from the given value.
        /// </summary>
        /// <param name="value">The string value of an email.</param>
        /// <returns>An <see cref="Email"/> with the given value if valid.</returns>
        /// <exception cref="ArgumentException">If the value is not a valid email.</exception>
        public static Email FromString(string value) => Create(value);

        /// <summary>
        ///  Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as Email);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Email other)
        {
            return other is null
                ? false
                : Value == other.Value;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="Email"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Email"/> instance.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => Value;

        private static ArgumentException ValidateValue(string value)
        {
            return
                Exceptions.WhenNullOrWhiteSpace(value, nameof(value)) ??
                Exceptions.WhenLengthIsIncorrect(value, MinLength, MaxLength, nameof(value)) ??
                Exceptions.WhenDoesNotMatchPattern(value, Pattern, nameof(value));
        }

        private string DebuggerDisplay() => Value;
    }
}
