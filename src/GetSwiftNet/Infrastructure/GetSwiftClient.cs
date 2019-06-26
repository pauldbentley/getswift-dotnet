namespace GetSwiftNet.Infrastructure
{
    using System.Linq;
    using Restfully;

    /// <summary>
    /// A RESTful Api client for GetSwift.
    /// </summary>
    internal sealed class GetSwiftClient : ApiClient
    {
        /// <summary>
        /// Sets the relevant properties on the request for send.
        /// </summary>
        /// <param name="restApiRequest">The request.</param>
        protected override void PrepareForSend(IApiRequest restApiRequest)
        {
            AddExpandables(restApiRequest);
        }

        private static void AddExpandables(IApiRequest restApiRequest)
        {
            var expandables = ExpandableMapper
                .Extract(restApiRequest.Parameters)
                .Select((value, index) => new
                {
                    SourceParameterName = value.Key,
                    ParameterName = $"expand[{index}]",
                    value.Value,
                });

            foreach (var expandable in expandables)
            {
                // remove the Expandable property
                restApiRequest.Parameters.Remove(expandable.SourceParameterName);

                // add all the expandables in the correct format
                restApiRequest.Parameters.Add(expandable.ParameterName, expandable.Value);
            }
        }
    }
}
