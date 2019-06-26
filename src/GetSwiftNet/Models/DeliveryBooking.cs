namespace GetSwiftNet
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using EnsuredOutcomes;
    using Newtonsoft.Json;

    /// <summary>
    /// Used to get a quote or book a delivery.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class DeliveryBooking
    {
        /// <summary>
        /// The maximum length of the <see cref="Reference"/> property.
        /// </summary>
        public const int MaxReferenceLength = 50;

        /// <summary>
        /// The maximum length of the <see cref="DeliveryInstructions"/> property.
        /// </summary>
        public const int MaxDeliveryInstructionsLength = 2000;

        /// <summary>
        /// The maximum length of the <see cref="CustomerReference"/> property.
        /// </summary>
        public const int MaxCustomerReferenceLength = 50;

        private string reference;
        private string deliveryInstructions;
        private string customerReference;

        private DeliveryBooking(DeliveryBookingLocation dropoffDetail)
            : this(null, null, false, null, null, null, dropoffDetail, null, null, null, null, null, null, null, null, null, null)
        {
        }

        private DeliveryBooking(DeliveryBookingLocation pickupDetail, DeliveryBookingLocation dropoffDetail)
            : this(null, null, false, null, pickupDetail, null, dropoffDetail, null, null, null, null, null, null, null, null, null, null)
        {
        }

        [JsonConstructor]
        private DeliveryBooking(string reference, string deliveryInstructions, bool? itemsRequirePurchase, DateTime? pickupTime, DeliveryBookingLocation pickupDetail, TimeFrame dropoffWindow, DeliveryBookingLocation dropoffDetail, decimal? customerFee, string customerReference, decimal? tax, bool? taxInclusivePrice, decimal? tip, decimal? driverFeePercentage, string driverMatchCode, int? deliverySequence, string deliveryRouteIdentifier, string template)
        {
            this.reference = reference;
            this.deliveryInstructions = deliveryInstructions;
            ItemsRequirePurchase = itemsRequirePurchase;
            PickupTime = pickupTime;
            PickupDetail = pickupDetail;
            DropoffWindow = dropoffWindow;
            DropoffDetail = dropoffDetail;
            CustomerFee = customerFee;
            this.customerReference = customerReference;
            Tax = tax;
            TaxInclusivePrice = taxInclusivePrice;
            Tip = tip;
            DriverFeePercentage = driverFeePercentage;
            DriverMatchCode = driverMatchCode;
            DeliverySequence = deliverySequence;
            DeliveryRouteIdentifier = deliveryRouteIdentifier;
            Template = template;
        }

        /// <summary>
        /// Gets or sets your internal reference id for this delivery.
        /// If the reference is not provided, a new reference number will be assigned.
        /// </summary>
        public string Reference
        {
            get => reference;
            set
            {
                Exceptions.Throw(ValidateReference(value));
                reference = value;
            }
        }

        /// <summary>
        /// Gets or sets instructions for the driver.
        /// For example: "Ring when you get to the street", "The nearest cross street is High St", or "Watch out for the dog!".
        /// </summary>
        public string DeliveryInstructions
        {
            get => deliveryInstructions;
            set
            {
                Exceptions.Throw(ValidateDeliveryInstructions(value));
                deliveryInstructions = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether you require the driver to pay for items.
        /// Please arrange with us in advance if you require this service. We recommend setting this to false unless you really need it.
        /// </summary>
        public bool? ItemsRequirePurchase { get; set; }

        /// <summary>
        /// Gets the packages included in the delivery.
        /// </summary>
        public List<DeliveryBookingItem> Items { get; } = new List<DeliveryBookingItem>();

        /// <summary>
        /// Gets or sets a specific time when delivery items should be picked up for pre-order bookings.
        /// If this date is not supplied, we will assume that the delivery should take place immediately, nearby drivers will be notified straight away.
        /// </summary>
        public DateTime? PickupTime { get; set; }

        /// <summary>
        /// Gets the address and other details for the delivery origin.
        /// This is not required for service based merchants.
        /// </summary>
        public DeliveryBookingLocation PickupDetail { get; }

        /// <summary>
        /// Gets or sets the window of time required for the delivery to be completed.
        /// If not supplied, we will deliver as soon as possible.
        /// </summary>
        public TimeFrame DropoffWindow { get; set; }

        /// <summary>
        /// Gets the address and other details for the delivery destination.
        /// </summary>
        public DeliveryBookingLocation DropoffDetail { get; }

        /// <summary>
        /// Gets or sets the delivery or job fee charge to the end customer.
        /// If this value is provided it will override the calculated price (based on values set in the merchant API settings).
        /// </summary>
        public decimal? CustomerFee { get; set; }

        /// <summary>
        /// Gets or sets the external customer reference.
        /// Use this (for example) to match the origin of a job for your internal accounting.
        /// </summary>
        public string CustomerReference
        {
            get => customerReference;
            set
            {
                Exceptions.Throw(ValidateCustomerReference(value));
                customerReference = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the price includes taxes.
        /// </summary>
        public bool? TaxInclusivePrice { get; set; }

        /// <summary>
        /// Gets or sets the tip amount.
        /// </summary>
        public decimal? Tip { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the <see cref="CustomerFee"/> that the driver should be paid.
        /// </summary>
        public decimal? DriverFeePercentage { get; set; }

        /// <summary>
        /// Gets or sets a code used to notify a specific driver (see Driver/Job Match Key screen).
        /// </summary>
        public string DriverMatchCode { get; set; }

        /// <summary>
        /// Gets or sets a value used to sequence deliveries in the order they should be completed by a particular driver.
        /// This order is reflected in the driver's app.
        /// </summary>
        public int? DeliverySequence { get; set; }

        /// <summary>
        /// Gets a list of job requirement constraints so only particular drivers matching the required constraints will be notified.
        /// </summary>
        public List<JobConstraint> Constraints { get; } = new List<JobConstraint>();

        /// <summary>
        /// Gets or sets the delivery route identifier.
        /// </summary>
        public string DeliveryRouteIdentifier { get; set; }

        /// <summary>
        /// Gets a list of URLs to be called when various events occur in GetSwift (see the webhooks documentation for specific event name).
        /// </summary>
        public List<DeliveryEventWebhook> Webhooks { get; } = new List<DeliveryEventWebhook>();

        /// <summary>
        /// Gets or sets the name of a template to use.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Creates a new <see cref="DeliveryBooking"/> with the given dropoff details.
        /// </summary>
        /// <param name="dropoffDetail">The dropoff details.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBooking> Create(DeliveryBookingLocation dropoffDetail) => Create(null, dropoffDetail);

        /// <summary>
        /// Creates a new <see cref="DeliveryBooking"/> with the given pickup and dropoff details.
        /// </summary>
        /// <param name="pickupDetail">The pickup details.</param>
        /// <param name="dropoffDetail">The dropoff details.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBooking> Create(DeliveryBookingLocation pickupDetail, DeliveryBookingLocation dropoffDetail)
        {
            var errors = new[]
            {
                ValidatePickupDetail(pickupDetail),
                ValidateDropoffDetail(dropoffDetail),
            };

            if (!Exceptions.Any(errors))
            {
                return Outcomes.Success(new DeliveryBooking(pickupDetail, dropoffDetail));
            }

            return Outcomes.Failure<DeliveryBooking>(errors);
        }

        /// <summary>
        /// Determines whether the pickup detail is valid.
        /// </summary>
        /// <param name="pickupDetail">The pickup detail to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckPickupDetail(DeliveryBookingLocation pickupDetail)
        {
            return Outcomes.Determine(ValidatePickupDetail(pickupDetail));
        }

        /// <summary>
        /// Determines whether the dropoff detail is valid.
        /// </summary>
        /// <param name="dropoffDetail">The dropoff detail to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckDropoffDetail(DeliveryBookingLocation dropoffDetail)
        {
            return Outcomes.Determine(ValidateDropoffDetail(dropoffDetail));
        }

        /// <summary>
        /// Determines whether the specified reference is valid.
        /// </summary>
        /// <param name="reference">The reference to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckReference(string reference)
        {
            return Outcomes.Determine(ValidateReference(reference));
        }

        /// <summary>
        /// Determines whether the specified delivery instructions are valid.
        /// </summary>
        /// <param name="deliveryInstructions">The delivery instructions to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckDeliveryInstructions(string deliveryInstructions)
        {
            return Outcomes.Determine(ValidateDeliveryInstructions(deliveryInstructions));
        }

        /// <summary>
        /// Determines whether the specified customer reference is valid.
        /// </summary>
        /// <param name="customerReference">The customer reference to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the specified values.</returns>
        public static Outcome CheckCustomerReference(string customerReference)
        {
            return Outcomes.Determine(ValidateCustomerReference(customerReference));
        }

        private static Exception ValidateDropoffDetail(DeliveryBookingLocation dropoffDetails)
        {
            return Exceptions.WhenNull(dropoffDetails, nameof(dropoffDetails));
        }

        private static Exception ValidatePickupDetail(DeliveryBookingLocation pickupDetails)
        {
            return pickupDetails != null
                ? Exceptions.WhenNull(pickupDetails, nameof(pickupDetails))
                : null;
        }

        private static Exception ValidateReference(string reference)
        {
            return
                (reference != null ? Exceptions.WhenNullOrWhiteSpace(reference, nameof(reference)) : null) ??
                Exceptions.WhenLengthIsIncorrect(reference, 0, MaxReferenceLength, nameof(reference));
        }

        private static Exception ValidateDeliveryInstructions(string deliveryInstructions)
        {
            return
                (deliveryInstructions != null ? Exceptions.WhenNullOrWhiteSpace(deliveryInstructions, nameof(deliveryInstructions)) : null) ??
                Exceptions.WhenLengthIsIncorrect(deliveryInstructions, 0, MaxDeliveryInstructionsLength, nameof(deliveryInstructions));
        }

        private static Exception ValidateCustomerReference(string customerReference)
        {
            return
                (customerReference != null ? Exceptions.WhenNullOrWhiteSpace(customerReference, nameof(customerReference)) : null) ??
                Exceptions.WhenLengthIsIncorrect(customerReference, 0, MaxCustomerReferenceLength, nameof(customerReference));
        }

        private object DebuggerDisplay()
        {
            if (!string.IsNullOrEmpty(Reference))
            {
                return Reference;
            }

            return this;
        }
    }
}
