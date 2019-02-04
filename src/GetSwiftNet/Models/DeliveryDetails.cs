namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The details of a dlivery.
    /// </summary>
    public sealed class DeliveryDetails
    {
        [JsonConstructor]
        private DeliveryDetails(DateTime created, Guid id, string reference, LocationApi pickupLocation, LocationApi dropoffLocation, DateTime lastUpdated, string currentStatus, Driver driver, DateTime? pickupTime, TimeFrame dropoffTime, string deliveryInstructions, string customerReference, TrackingUrls trackingUrls, ProofOfDelivery proofOfDelivery, decimal driverTip, decimal deliveryFee, Distance estimatedDistance)
        {
            Created = created;
            Id = id;
            Reference = reference;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            LastUpdated = lastUpdated;
            CurrentStatus = currentStatus;
            Driver = driver;
            PickupTime = pickupTime;
            DropoffTime = dropoffTime;
            DeliveryInstructions = deliveryInstructions;
            CustomerReference = customerReference;
            TrackingUrls = trackingUrls;
            ProofOfDelivery = proofOfDelivery;
            DriverTip = driverTip;
            DeliveryFee = deliveryFee;
            EstimatedDistance = estimatedDistance;
        }

        /// <summary>
        /// Gets the date the booking was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// Gets the unique identifier for this delivery.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the internal reference id for this delivery.
        /// If your internal reference was not provided, this will contain a reference number provided by Swift.
        /// </summary>
        public string Reference { get; }

        /// <summary>
        /// Gets the details of the delivery origin.
        /// </summary>
        public LocationApi PickupLocation { get; }

        /// <summary>
        /// Gets the details of the delivery destination.
        /// </summary>
        public LocationApi DropoffLocation { get; }

        /// <summary>
        /// Gets the time (in UTC) of the last status update.
        /// </summary>
        public DateTime LastUpdated { get; }

        /// <summary>
        /// Gets the most recent delivery status.
        /// </summary>
        public string CurrentStatus { get; }

        /// <summary>
        /// Gets the details of the driver assigned to your delivery.
        /// </summary>
        public Driver Driver { get; }

        /// <summary>
        /// Gets a list of packages to be delivered.
        /// </summary>
        public List<string> Items { get; } = new List<string>();

        /// <summary>
        /// Gets a list of job requirement constraints so only particular drivers matching the required constraints will be notified.
        /// </summary>
        public List<string> Constraints { get; } = new List<string>();

        /// <summary>
        /// Gets the time (if any) that the delivery is scheduled to be pickup up.
        /// Time is in UTC
        /// </summary>
        public DateTime? PickupTime { get; }

        /// <summary>
        /// Gets the time (if any) that the delivery is scheduled to be dropped off.
        /// Time is in UTC
        /// </summary>
        public TimeFrame DropoffTime { get; }

        /// <summary>
        /// Gets the delivery instructions.
        /// </summary>
        public string DeliveryInstructions { get; }

        /// <summary>
        /// Gets a reference used to identify the customer who placed this order.
        /// For example, this will contain the customer's unique business name for deliveries placed via the the public booking form.
        /// </summary>
        public string CustomerReference { get; }

        /// <summary>
        /// Gets the tracking URLs.
        /// </summary>
        public TrackingUrls TrackingUrls { get; }

        /// <summary>
        /// Gets the proof of delivery information.
        /// </summary>
        public ProofOfDelivery ProofOfDelivery { get;  }

        /// <summary>
        /// Gets the driver tip
        /// </summary>
        public decimal DriverTip { get; }

        /// <summary>
        /// Gets the delivery fee.
        /// </summary>
        public decimal DeliveryFee { get; }

        /// <summary>
        /// Gets the estimated distance.
        /// </summary>
        public Distance EstimatedDistance { get; }

        /// <summary>
        /// Gets the stages the job progressed through in ascending order.
        /// </summary>
        public List<StageEntry> StageHistory { get; } = new List<StageEntry>();

        /// <summary>
        /// Gets the full response sent by the server.
        /// </summary>
        public ServiceResponse Response { get; private set; }
    }
}
