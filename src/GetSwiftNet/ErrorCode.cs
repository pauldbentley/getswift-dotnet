namespace GetSwiftNet
{
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// All possible error codes returned by GetSwift.
    /// </summary>
    public abstract class ErrorCode
        : Enumeration
    {
        /// <summary>
        /// No error.
        /// </summary>
        public static readonly ErrorCode None = new NoneErrorCode(nameof(None));

        /// <summary>
        /// We are sorry, all of our drivers nearby are busy.Please try again in a few minutes.
        /// </summary>
        public static readonly ErrorCode AtCapacity = new AtCapacityErrorCode(nameof(AtCapacity));

        /// <summary>
        /// Delivery not found.
        /// </summary>
        public static readonly ErrorCode DeliveryNotFound = new DeliveryNotFoundErrorCode(nameof(DeliveryNotFound));

        /// <summary>
        /// No pickup details supplied.
        /// </summary>
        public static readonly ErrorCode NoPickupDeets = new NoPickupDeetsErrorCode(nameof(NoPickupDeets));

        /// <summary>
        /// No destination details supplied.
        /// </summary>
        public static readonly ErrorCode NoDropoffDeets = new NoDropoffDeetsErrorCode(nameof(NoDropoffDeets));

        /// <summary>
        /// Please supply earliest AND latest time for the delivery time window.
        /// </summary>
        public static readonly ErrorCode DeliveryWindowFullInfo = new DeliveryWindowFullInfoErrorCode(nameof(DeliveryWindowFullInfo));

        /// <summary>
        /// Earliest delivery time window should be specified.
        /// </summary>
        public static readonly ErrorCode NoEarliestDeliveryWindow = new NoEarliestDeliveryWindowErrorCode(nameof(NoEarliestDeliveryWindow));

        /// <summary>
        /// Latest delivery time window should be specified.
        /// </summary>
        public static readonly ErrorCode NoLatestDeliveryWindow = new NoLatestDeliveryWindowErrorCode(nameof(NoLatestDeliveryWindow));

        /// <summary>
        /// Invalid delivery time window.
        /// </summary>
        public static readonly ErrorCode InvalidDeliveryWindow = new InvalidDeliveryWindowErrorCode(nameof(InvalidDeliveryWindow));

        /// <summary>
        /// Delivery time window is in the past.
        /// </summary>
        public static readonly ErrorCode PastDeliveryWindow = new PastDeliveryWindowErrorCode(nameof(PastDeliveryWindow));

        /// <summary>
        /// No drop-off details supplied.
        /// </summary>
        public static readonly ErrorCode NoDropoff = new NoDropoffErrorCode(nameof(NoDropoff));

        /// <summary>
        /// No pickup details supplied.
        /// </summary>
        public static readonly ErrorCode NoPickup = new NoPickupErrorCode(nameof(NoPickup));

        /// <summary>
        /// Pickup address cannot be validated.
        /// </summary>
        public static readonly ErrorCode InvalidPickupAddress = new InvalidPickupAddressErrorCode(nameof(InvalidPickupAddress));

        /// <summary>
        /// Destination address cannot be validated.
        /// </summary>
        public static readonly ErrorCode InvalidDropoffAddress = new InvalidDropoffAddressErrorCode(nameof(InvalidDropoffAddress));

        /// <summary>
        /// No Data.
        /// </summary>
        public static readonly ErrorCode NoData = new NoDataErrorCode(nameof(NoData));

        /// <summary>
        /// Unspecified Error.
        /// </summary>
        public static readonly ErrorCode Unspecified = new UnspecifiedErrorCode(nameof(Unspecified));

        /// <summary>
        /// Internal Server Error.
        /// </summary>
        public static readonly ErrorCode ServerError = new ServerErrorErrorCode(nameof(ServerError));

        /// <summary>
        /// Unauthorised.
        /// </summary>
        public static readonly ErrorCode Unauthorised = new UnauthorisedErrorCode(nameof(Unauthorised));

        /// <summary>
        /// Job rating not found.
        /// </summary>
        public static readonly ErrorCode RatingNotFound = new RatingNotFoundErrorCode(nameof(RatingNotFound));

        /// <summary>
        /// Job skills not found..
        /// </summary>
        public static readonly ErrorCode SkillNotFound = new SkillNotFoundErrorCode(nameof(SkillNotFound));

        /// <summary>
        /// Unknown error.
        /// </summary>
        public static readonly ErrorCode Unknown = new UnknownErrorCode(nameof(Unknown));

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCode"/> class.
        /// </summary>
        /// <param name="name">The enumeration name.</param>
        /// <param name="value">The enumeration value.</param>
        /// <param name="displayName">The enumeration display name.</param>
        /// <param name="message">The error message.</param>
        protected ErrorCode(string name, int value, string displayName, string message)
            : base(name, value, displayName)
        {
            Message = message;
        }

        /// <summary>
        /// Gets the message describing the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Try to parse an <see cref="ErrorCode"/> from the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="ErrorCode"/> to parse.</param>
        /// <param name="result">The <see cref="ErrorCode"/> parsed, or null if the name is not found.</param>
        /// <returns>An <see cref="ErrorCode"/>.</returns>
        public static bool TryParseFromName(string name, out ErrorCode result)
        {
            return TryParseFromName<ErrorCode>(name, out result);
        }

        private class NoneErrorCode : ErrorCode
        {
            public NoneErrorCode(string name)
                : base(name, 0, "None", "No error")
            {
            }
        }

        private class AtCapacityErrorCode : ErrorCode
        {
            public AtCapacityErrorCode(string name)
                : base(name, 1, "At Capacity", "We are sorry, all of our drivers nearby are busy.Please try again in a few minutes")
            {
            }
        }

        private class DeliveryNotFoundErrorCode : ErrorCode
        {
            public DeliveryNotFoundErrorCode(string name)
                : base(name, 2, "Delivery Not Found", "Delivery not found")
            {
            }
        }

        private class NoPickupDeetsErrorCode : ErrorCode
        {
            public NoPickupDeetsErrorCode(string name)
                : base(name, 3, "No Pickup Deets", "No pickup details supplied")
            {
            }
        }

        private class NoDropoffDeetsErrorCode : ErrorCode
        {
            public NoDropoffDeetsErrorCode(string name)
                : base(name, 4, "No Dropoff Deets", "No destination details supplied")
            {
            }
        }

        private class DeliveryWindowFullInfoErrorCode : ErrorCode
        {
            public DeliveryWindowFullInfoErrorCode(string name)
                : base(name, 5, "Delivery Window Full Info", "Please supply earliest AND latest time for the delivery time window")
            {
            }
        }

        private class NoEarliestDeliveryWindowErrorCode : ErrorCode
        {
            public NoEarliestDeliveryWindowErrorCode(string name)
                : base(name, 6, "No Earliest Delivery Window", "Earliest delivery time window should be specified")
            {
            }
        }

        private class NoLatestDeliveryWindowErrorCode : ErrorCode
        {
            public NoLatestDeliveryWindowErrorCode(string name)
                : base(name, 7, "No Latest Delivery Window", "Latest delivery time window should be specified")
            {
            }
        }

        private class InvalidDeliveryWindowErrorCode : ErrorCode
        {
            public InvalidDeliveryWindowErrorCode(string name)
                : base(name, 8, "Invalid Delivery Window", "Invalid delivery time window")
            {
            }
        }

        private class PastDeliveryWindowErrorCode : ErrorCode
        {
            public PastDeliveryWindowErrorCode(string name)
                : base(name, 9, "Past Delivery Window", "Delivery time window is in the past")
            {
            }
        }

        private class NoDropoffErrorCode : ErrorCode
        {
            public NoDropoffErrorCode(string name)
                : base(name, 10, "No Dropoff", "No drop-off details supplied")
            {
            }
        }

        private class NoPickupErrorCode : ErrorCode
        {
            public NoPickupErrorCode(string name)
                : base(name, 11, "No Pickup", "No pickup details supplied")
            {
            }
        }

        private class InvalidPickupAddressErrorCode : ErrorCode
        {
            public InvalidPickupAddressErrorCode(string name)
                : base(name, 12, "Invalid Pickup Address", "Pickup address cannot be validated")
            {
            }
        }

        private class InvalidDropoffAddressErrorCode : ErrorCode
        {
            public InvalidDropoffAddressErrorCode(string name)
                : base(name, 13, "Invalid Dropoff Address", "Destination address cannot be validated")
            {
            }
        }

        private class NoDataErrorCode : ErrorCode
        {
            public NoDataErrorCode(string name)
                : base(name, 14, "No Data", "No Data")
            {
            }
        }

        private class UnspecifiedErrorCode : ErrorCode
        {
            public UnspecifiedErrorCode(string name)
                : base(name, 15, "Unspecified", "Unspecified Error")
            {
            }
        }

        private class ServerErrorErrorCode : ErrorCode
        {
            public ServerErrorErrorCode(string name)
                : base(name, 16, "Server Error", "Internal Server Error")
            {
            }
        }

        private class UnauthorisedErrorCode : ErrorCode
        {
            public UnauthorisedErrorCode(string name)
                : base(name, 17, "Unauthorised", "Unauthorised")
            {
            }
        }

        private class RatingNotFoundErrorCode : ErrorCode
        {
            public RatingNotFoundErrorCode(string name)
                : base(name, 18, "Rating Not Found", "Job rating not found")
            {
            }
        }

        private class SkillNotFoundErrorCode : ErrorCode
        {
            public SkillNotFoundErrorCode(string name)
                : base(name, 19, "Skill Not Found", "Job skills not found")
            {
            }
        }

        private class UnknownErrorCode : ErrorCode
        {
            public UnknownErrorCode(string name)
                : base(name, 20, "Unknown", "Unknown error")
            {
            }
        }
    }
}
