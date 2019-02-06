namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A paged list of objects returned from the API service.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class PagedApiList<T>
    {
        [JsonConstructor]
        private PagedApiList(int currentPage, int pageCount, int pageSize, int totalCount, Uri firstPageUrl, Uri previousPageUrl, Uri nextPageUrl, Uri lastPageUrl, List<T> data)
        {
            CurrentPage = currentPage;
            PageCount = pageCount;
            PageSize = pageSize;
            TotalCount = totalCount;
            FirstPageUrl = firstPageUrl;
            PreviousPageUrl = previousPageUrl;
            NextPageUrl = nextPageUrl;
            LastPageUrl = lastPageUrl;
            Data = data;
        }

        /// <summary>
        /// Gets the current page number, starting from 1.
        /// </summary>
        public int CurrentPage { get; }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        public int PageCount { get; }

        /// <summary>
        /// Gets the page size.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets the total count of records.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to the first page.
        /// </summary>
        public Uri FirstPageUrl { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to the previous page.
        /// </summary>
        public Uri PreviousPageUrl { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to the next page.
        /// </summary>
        public Uri NextPageUrl { get; }

        /// <summary>
        /// Gets the <see cref="Uri"/> to the last page.
        /// </summary>
        public Uri LastPageUrl { get; }

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
