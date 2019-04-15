namespace GetSwiftNet.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="Outcomes"/>.
    /// </summary>
    internal static class OutcomeExtensions
    {
        /// <summary>
        /// Adds the value of the outcome to the collection, or throws the first exception on failure.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="outcome">The outcome.</param>
        public static void AddOrThrow<T>(this ICollection<T> collection, Outcome<T> outcome)
        {
            Guard.NotNull(collection, nameof(collection));

            if (outcome.Success)
            {
                collection.Add(outcome.Value);
            }
            else
            {
                Exceptions.Throw(outcome.Errors.First());
            }
        }
    }
}
