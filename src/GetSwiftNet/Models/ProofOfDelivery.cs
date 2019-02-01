namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Proof of delivery.
    /// </summary>
    public sealed class ProofOfDelivery
    {
        [JsonConstructor]
        private ProofOfDelivery(Uri signatureUrl)
        {
            SignatureUrl = signatureUrl;
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the signature.
        /// </summary>
        public Uri SignatureUrl { get; }

        public List<string> Attachments { get; } = new List<string>();
    }
}
