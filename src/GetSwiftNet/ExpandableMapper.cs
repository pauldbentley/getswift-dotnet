namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides helper functions to map expandable properties
    /// </summary>
    internal static class ExpandableMapper
    {
        /// <summary>
        /// The prefix for an expandable property.
        /// </summary>
        public const string ExpandPropertyNamePrefix = "Expand";

        /// <summary>
        /// Creates a collection of expandable properties from the given object.
        /// </summary>
        /// <param name="data">The object to extract expandable properties.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> of expandable properties.</returns>
        public static IEnumerable<string> MapFromObject(object data)
        {
            if (data is null)
            {
                return Enumerable.Empty<string>();
            }

            // expandable properties
            return data
                .GetType()
                .GetRuntimeProperties()
                .Where(p => p.Name.StartsWith(ExpandPropertyNamePrefix, StringComparison.OrdinalIgnoreCase))
                .Where(p => p.PropertyType == typeof(bool))
                .Where(p => (bool)p.GetValue(data, null))
                .Select(p => p.Name.Substring(ExpandPropertyNamePrefix.Length));
        }
    }
}