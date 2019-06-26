namespace GetSwiftNet
{
    using System.Collections;
    using System.Collections.Generic;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

#pragma warning disable CA1710
    /// <summary>
    /// A list of objects returned from the API service.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ApiList<T> : IEnumerable<T>
#pragma warning restore CA1710
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiList{T}"/> class with the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        [JsonConstructor]
        protected ApiList(List<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the response sent by the server.
        /// </summary>
        public GetSwiftResponse Response { get; private set; }

        private List<T> Data { get; }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ApiList{T}"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> for the <see cref="ApiList{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ApiList{T}"/>.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> for the <see cref="ApiList{T}"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
