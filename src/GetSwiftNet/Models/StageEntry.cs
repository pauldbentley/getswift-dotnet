namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    /// <summary>
    /// A stage that a delivery booking has progressed through.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class StageEntry : IEquatable<StageEntry>
    {
        [JsonConstructor]
        private StageEntry(DateTime created, string stage, string notes)
        {
            Created = created;
            Stage = stage;
            Notes = notes;
        }

        /// <summary>
        /// Gets the UTC time the entry was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// Gets the name of the stage.
        /// </summary>
        public string Stage { get; }

        /// <summary>
        /// Gets the extra notes about the stage.
        /// </summary>
        public string Notes { get; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as StageEntry);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(StageEntry other)
        {
            return other is null
                ? false
                : Created == other.Created && Stage == other.Stage && Notes == other.Notes;
        }

        /// <summary>
        /// Calculates the hash code for the current <see cref="StageEntry"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="StageEntry"/> instance.</returns>
        public override int GetHashCode()
        {
            return (Created, Stage, Notes).GetHashCode();
        }

        private string DebuggerDisplay() => Stage;
    }
}
