namespace GetSwiftNet
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A list of objects returned from the API service.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ApiList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiList{T}"/> class with the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        [JsonConstructor]
        protected ApiList(IEnumerable<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IEnumerable<T> Data { get; }

        /// <summary>
        /// Gets the response sent by the server.
        /// </summary>
        public ServiceResponse Response { get; private set; }
    }
}
