namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using EnsuredOutcomes;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a particular job requirement constraint.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class JobConstraint : IEquatable<JobConstraint>
    {
        /// <summary>
        /// The minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 1;

        /// <summary>
        /// The minimum length of the <see cref="Value"/> property.
        /// </summary>
        public const int MinValueLength = 1;

        [JsonConstructor]
        private JobConstraint(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the name of the constraint.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the constraint.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates an <see cref="JobConstraint"/> instance with a specified name and value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<JobConstraint> Create(string name, string value)
        {
            var errors = new[]
            {
                ValidateName(name),
                ValidateValue(value),
            };

            if (!Exceptions.Any(errors))
            {
                return Outcomes.Success(new JobConstraint(name, value));
            }

            return Outcomes.Failure<JobConstraint>(errors);
        }

        /// <summary>
        /// Determines whether the name is valid.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckName(string name)
        {
            return Outcomes.Determine(ValidateName(name));
        }

        /// <summary>
        /// Determines whether the value is valid.
        /// </summary>
        /// <param name="value">The name to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckValue(string value)
        {
            return Outcomes.Determine(ValidateValue(value));
        }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as JobConstraint);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(JobConstraint other)
        {
            return other is null
                ? false
                : Name == other.Name && Value == other.Value;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="JobConstraint"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="JobConstraint"/> instance.</returns>
        public override int GetHashCode() => new { Name, Value }.GetHashCode();

        private static Exception ValidateName(string name)
        {
            return
                Exceptions.WhenNullOrWhiteSpace(name, nameof(name)) ??
                Exceptions.WhenLengthIsIncorrect(name, MinNameLength, int.MaxValue, nameof(name));
        }

        private static Exception ValidateValue(string value)
        {
            return
                Exceptions.WhenNullOrWhiteSpace(value, nameof(value)) ??
                Exceptions.WhenLengthIsIncorrect(value, MinValueLength, int.MaxValue, nameof(value));
        }

        private string DebuggerDisplay() => Name;
    }
}