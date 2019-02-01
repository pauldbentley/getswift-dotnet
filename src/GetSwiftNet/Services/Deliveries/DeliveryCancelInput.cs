namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Defines the inpt required to cancel a booking using your merchant key.
    /// </summary>
    public class DeliveryCancelInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryCancelInput"/> class.
        /// </summary>
        /// <param name="jobId">The identifier of the booking to be cancelled.</param>
        public DeliveryCancelInput(Guid jobId)
            : this(jobId, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryCancelInput"/> class.
        /// </summary>
        /// <param name="jobId">The identifier of the booking to be cancelled.</param>
        /// <param name="cancellationNotes">Optional cancellation notes.</param>
        public DeliveryCancelInput(Guid jobId, string cancellationNotes)
        {
            JobId = jobId;
            CancellationNotes = cancellationNotes;
        }

        /// <summary>
        /// Gets or sets your merchant API key.
        /// This key will take priority over the key defined on the service or the <see cref="GetSwiftConfiguration.ApiKey"/>.
        /// </summary>
        public Guid? ApiKey { get; set; }

        /// <summary>
        /// Gets the identifier of the booking to be cancelled.
        /// </summary>
        public Guid JobId { get; }

        /// <summary>
        /// Gets or sets optional cancellation notes.
        /// </summary>
        public string CancellationNotes { get; set; }
    }
}
