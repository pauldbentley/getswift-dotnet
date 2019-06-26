namespace GetSwiftNet.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides helper functions to map expandable properties.
    /// </summary>
    internal static class ExpandableMapper
    {
        /// <summary>
        /// The prefix for an expandable property.
        /// </summary>
        public const string ExpandPropertyNamePrefix = "Expand";

        /// <summary>
        /// Creates a collection of expandable properties from the given dictionary.
        /// </summary>
        /// <param name="data">The object to extract expandable properties.</param>
        /// <returns>A <see cref="IDictionary{T, T}"/> of expandable properties with the Key being the full property name, and the value being the shortened name.</returns>
        public static IDictionary<string, string> Extract(IDictionary<string, object> data)
        {
            if (data is null)
            {
                return new Dictionary<string, string>();
            }

            // expandable keys
            return data
                .Where(p => p.Key.StartsWith(ExpandPropertyNamePrefix, StringComparison.Ordinal))
                .Select(p => new
                {
                    p.Key,
                    Value = p.Key.Substring(ExpandPropertyNamePrefix.Length),
                })
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}