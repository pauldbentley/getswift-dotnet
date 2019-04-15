namespace GetSwiftNet
{
    using System.Collections.Generic;
    using System.Linq;
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// Extension Add methods for <see cref="JobConstraint"/> collection initializers.
    /// </summary>
    public static class JobConstraintCollectionExtensions
    {
        /// <summary>
        /// Adds a new <see cref="JobConstraint"/> to the end of the <see cref="ICollection{T}"/> with the given values.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void Add(this ICollection<JobConstraint> collection, string name, string value)
        {
            Guard.NotNull(collection, nameof(collection));

            var outcome = JobConstraint.Create(name, value);
            collection.AddOrThrow(outcome);
        }
    }
}