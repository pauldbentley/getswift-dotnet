namespace GetSwiftNet
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a strongly typed list of objects which have been returned from the service that can be accessed by index.
    /// Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ModelCollection<T> : List<T>
    {
        /// <summary>
        /// Gets the response sent by the server.
        /// </summary>
        public ServiceResponse Response { get; private set; }
    }
}
