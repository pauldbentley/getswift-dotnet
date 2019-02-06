namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides the base class for enumeration values.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="name">The name of the enumeration value.</param>
        /// <param name="value">The enumeration value.</param>
        /// <param name="displayName">The display name of the enumeration value</param>
        protected Enumeration(string name, int value, string displayName)
        {
            Guard.NotNullOrWhitespace(name, nameof(name));

            Name = name;
            Value = value;
            DisplayName = displayName;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the values are equal, false otherwise.</returns>
        public static bool operator ==(Enumeration left, Enumeration right)
        {
            return left is null
                ? right is null
                : left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the values are not equal, false otherwise.</returns>
        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Less-than operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the left value is less than the right value, false otherwise.</returns>
        public static bool operator <(Enumeration left, Enumeration right)
        {
            bool rightIsNull = right is null;
            return left is null
                ? !rightIsNull
                : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Less-than, or equal to operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the left value is less than or equal to the right value, false otherwise.</returns>
        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Greater-than operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the left value is greater than the right value, false otherwise.</returns>
        public static bool operator >(Enumeration left, Enumeration right)
        {
            bool leftIsNull = left is null;
            return !leftIsNull && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Greater-than, or equal to operator.
        /// </summary>
        /// <param name="left">The left value.</param>
        /// <param name="right">The right value.</param>
        /// <returns>true if the left value is greater than or equal to the right value, false otherwise.</returns>
        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return left is null
                ? right is null
                : left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Gets all enumeration values for the given type.
        /// </summary>
        /// <typeparam name="T">The type of enumeration</typeparam>
        /// <returns>A list of enumeration values.</returns>
        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration
        {
            return typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();
        }

        /// <summary>
        /// Returns the absolute different between the two values.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value.</param>
        /// <returns>A 32-bit signed integer, x, such that 0 ≤ x ≤ <see cref="int.MaxValue"/>.</returns>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            return Math.Abs(firstValue.Value - secondValue.Value);
        }

        /// <summary>
        /// Parse a specific type of <see cref="Enumeration"/> with a given name.
        /// </summary>
        /// <typeparam name="TEnum">The type of <see cref="Enumeration"/> to parse.</typeparam>
        /// <param name="name">The name of enumeration value.</param>
        /// <exception cref="InvalidOperationException">If an enumeration value with the given name is not found.</exception>
        /// <returns>An <see cref="Enumeration"/> value of the specific type.</returns>
        public static TEnum ParseFromName<TEnum>(string name)
            where TEnum : Enumeration
        {
            return Parse<TEnum, string>(name, nameof(name), item => !string.IsNullOrWhiteSpace(name) && item.Name == name);
        }

        /// <summary>
        /// Try to parse a specific type of <see cref="Enumeration"/> with a given name.
        /// </summary>
        /// <typeparam name="TEnum">The type of <see cref="Enumeration"/> to parse.</typeparam>
        /// <param name="name">The name of enumeration value.</param>
        /// <param name="result">The type of enumeration result.</param>
        /// <returns>true if the parse was successful, false otherwise.</returns>
        public static bool TryParseFromName<TEnum>(string name, out TEnum result)
            where TEnum : Enumeration
        {
            return TryParse<TEnum, string>(item => !string.IsNullOrWhiteSpace(name) && item.Name == name, out result);
        }

        /// <summary>
        /// Parses an <see cref="Enumeration"/> type with a specified value.
        /// </summary>
        /// <typeparam name="TEnum">The type of <see cref="Enumeration"/> value.</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <returns>The parsed value.</returns>
        /// <exception cref="InvalidOperationException">If the value doesn't exist for the enumeration.</exception>
        public static TEnum ParseFromValue<TEnum>(int value)
            where TEnum : Enumeration
        {
            return Parse<TEnum, int>(value, nameof(value), item => item.Value == value);
        }

        /// <summary>
        /// Try to parse a specific type of <see cref="Enumeration"/> with a given value.
        /// </summary>
        /// <typeparam name="TEnum">The type of <see cref="Enumeration"/> to parse.</typeparam>
        /// <param name="value">The value of the enumeration.</param>
        /// <param name="result">The type of enumeration result.</param>
        /// <returns>true if the parse was successful, false otherwise.</returns>
        public static bool TryParseFromValue<TEnum>(int value, out TEnum result)
            where TEnum : Enumeration
        {
            return TryParse<TEnum, string>(item => item.Value == value, out result);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Calculates the hash code for the current <see cref="Email"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Email"/> instance.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        ///  Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            if (!GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var e = (Enumeration)obj;
            return Value == e.Value;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates
        /// whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object other) => Value.CompareTo(((Enumeration)other).Value);

        private static TEnum Parse<TEnum, TProperty>(TProperty value, string description, Func<TEnum, bool> predicate)
            where TEnum : Enumeration
        {
            return GetAll<TEnum>().FirstOrDefault(predicate) ?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(TEnum)}");
        }

        private static bool TryParse<TEnum, TProperty>(Func<TEnum, bool> predicate, out TEnum result)
            where TEnum : Enumeration
        {
            return (result = GetAll<TEnum>().FirstOrDefault(predicate)) != null;
        }
    }
}