namespace GetSwiftNet
{
    using GetSwiftNet.Infrastructure;

    /// <summary>
    /// All possible errors returned by GetSwift.
    /// </summary>
    public abstract class GetSwiftError
        : Enumeration
    {
        /// <summary>
        /// No error.
        /// </summary>
        public static readonly GetSwiftError None = new NoneErrorCode(nameof(None));

        /// <summary>
        /// We are sorry, all of our drivers nearby are busy.Please try again in a few minutes.
        /// </summary>
        public static readonly GetSwiftError AtCapacity = new AtCapacityErrorCode(nameof(AtCapacity));

        /// <summary>
        /// Delivery not found.
        /// </summary>
        public static readonly GetSwiftError DeliveryNotFound = new DeliveryNotFoundErrorCode(nameof(DeliveryNotFound));

        /// <summary>
        /// No pickup details supplied.
        /// </summary>
        public static readonly GetSwiftError NoPickupDeets = new NoPickupDeetsErrorCode(nameof(NoPickupDeets));

        /// <summary>
        /// No destination details supplied.
        /// </summary>
        public static readonly GetSwiftError NoDropoffDeets = new NoDropoffDeetsErrorCode(nameof(NoDropoffDeets));

        /// <summary>
        /// Please supply earliest AND latest time for the delivery time window.
        /// </summary>
        public static readonly GetSwiftError DeliveryWindowFullInfo = new DeliveryWindowFullInfoErrorCode(nameof(DeliveryWindowFullInfo));

        /// <summary>
        /// Earliest delivery time window should be specified.
        /// </summary>
        public static readonly GetSwiftError NoEarliestDeliveryWindow = new NoEarliestDeliveryWindowErrorCode(nameof(NoEarliestDeliveryWindow));

        /// <summary>
        /// Latest delivery time window should be specified.
        /// </summary>
        public static readonly GetSwiftError NoLatestDeliveryWindow = new NoLatestDeliveryWindowErrorCode(nameof(NoLatestDeliveryWindow));

        /// <summary>
        /// Invalid delivery time window.
        /// </summary>
        public static readonly GetSwiftError InvalidDeliveryWindow = new InvalidDeliveryWindowErrorCode(nameof(InvalidDeliveryWindow));

        /// <summary>
        /// Delivery time window is in the past.
        /// </summary>
        public static readonly GetSwiftError PastDeliveryWindow = new PastDeliveryWindowErrorCode(nameof(PastDeliveryWindow));

        /// <summary>
        /// No drop-off details supplied.
        /// </summary>
        public static readonly GetSwiftError NoDropoff = new NoDropoffErrorCode(nameof(NoDropoff));

        /// <summary>
        /// No pickup details supplied.
        /// </summary>
        public static readonly GetSwiftError NoPickup = new NoPickupErrorCode(nameof(NoPickup));

        /// <summary>
        /// Pickup address cannot be validated.
        /// </summary>
        public static readonly GetSwiftError InvalidPickupAddress = new InvalidPickupAddressErrorCode(nameof(InvalidPickupAddress));

        /// <summary>
        /// Destination address cannot be validated.
        /// </summary>
        public static readonly GetSwiftError InvalidDropoffAddress = new InvalidDropoffAddressErrorCode(nameof(InvalidDropoffAddress));

        /// <summary>
        /// No Data.
        /// </summary>
        public static readonly GetSwiftError NoData = new NoDataErrorCode(nameof(NoData));

        /// <summary>
        /// Unspecified Error.
        /// </summary>
        public static readonly GetSwiftError Unspecified = new UnspecifiedErrorCode(nameof(Unspecified));

        /// <summary>
        /// Internal Server Error.
        /// </summary>
        public static readonly GetSwiftError ServerError = new ServerErrorErrorCode(nameof(ServerError));

        /// <summary>
        /// Unauthorised.
        /// </summary>
        public static readonly GetSwiftError Unauthorised = new UnauthorisedErrorCode(nameof(Unauthorised));

        /// <summary>
        /// Job rating not found.
        /// </summary>
        public static readonly GetSwiftError RatingNotFound = new RatingNotFoundErrorCode(nameof(RatingNotFound));

        /// <summary>
        /// Job skills not found..
        /// </summary>
        public static readonly GetSwiftError SkillNotFound = new SkillNotFoundErrorCode(nameof(SkillNotFound));

        /// <summary>
        /// Unknown error.
        /// </summary>
        public static readonly GetSwiftError Unknown = new UnknownErrorCode(nameof(Unknown));

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSwiftError"/> class.
        /// </summary>
        /// <param name="name">The enumeration name.</param>
        /// <param name="value">The enumeration value.</param>
        /// <param name="displayName">The enumeration display name.</param>
        /// <param name="message">The error message.</param>
        protected GetSwiftError(string name, int value, string displayName, string message)
            : base(name, value, displayName)
        {
            Message = message;
        }

        /// <summary>
        /// Gets the message describing the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Try to parse an <see cref="GetSwiftError"/> from the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="GetSwiftError"/> to parse.</param>
        /// <param name="result">The <see cref="GetSwiftError"/> parsed, or null if the name is not found.</param>
        /// <returns>An <see cref="GetSwiftError"/>.</returns>
        public static bool TryParseFromName(string name, out GetSwiftError result)
        {
            return TryParseFromName<GetSwiftError>(name, out result);
        }

        private class NoneErrorCode : GetSwiftError
        {
            public NoneErrorCode(string name)
                : base(name, 0, "None", "No error")
            {
            }
        }

        private class AtCapacityErrorCode : GetSwiftError
        {
            public AtCapacityErrorCode(string name)
                : base(name, 1, "At Capacity", "We are sorry, all of our drivers nearby are busy.Please try again in a few minutes")
            {
            }
        }

        private class DeliveryNotFoundErrorCode : GetSwiftError
        {
            public DeliveryNotFoundErrorCode(string name)
                : base(name, 2, "Delivery Not Found", "Delivery not found")
            {
            }
        }

        private class NoPickupDeetsErrorCode : GetSwiftError
        {
            public NoPickupDeetsErrorCode(string name)
                : base(name, 3, "No Pickup Deets", "No pickup details supplied")
            {
            }
        }

        private class NoDropoffDeetsErrorCode : GetSwiftError
        {
            public NoDropoffDeetsErrorCode(string name)
                : base(name, 4, "No Dropoff Deets", "No destination details supplied")
            {
            }
        }

        private class DeliveryWindowFullInfoErrorCode : GetSwiftError
        {
            public DeliveryWindowFullInfoErrorCode(string name)
                : base(name, 5, "Delivery Window Full Info", "Please supply earliest AND latest time for the delivery time window")
            {
            }
        }

        private class NoEarliestDeliveryWindowErrorCode : GetSwiftError
        {
            public NoEarliestDeliveryWindowErrorCode(string name)
                : base(name, 6, "No Earliest Delivery Window", "Earliest delivery time window should be specified")
            {
            }
        }

        private class NoLatestDeliveryWindowErrorCode : GetSwiftError
        {
            public NoLatestDeliveryWindowErrorCode(string name)
                : base(name, 7, "No Latest Delivery Window", "Latest delivery time window should be specified")
            {
            }
        }

        private class InvalidDeliveryWindowErrorCode : GetSwiftError
        {
            public InvalidDeliveryWindowErrorCode(string name)
                : base(name, 8, "Invalid Delivery Window", "Invalid delivery time window")
            {
            }
        }

        private class PastDeliveryWindowErrorCode : GetSwiftError
        {
            public PastDeliveryWindowErrorCode(string name)
                : base(name, 9, "Past Delivery Window", "Delivery time window is in the past")
            {
            }
        }

        private class NoDropoffErrorCode : GetSwiftError
        {
            public NoDropoffErrorCode(string name)
                : base(name, 10, "No Dropoff", "No drop-off details supplied")
            {
            }
        }

        private class NoPickupErrorCode : GetSwiftError
        {
            public NoPickupErrorCode(string name)
                : base(name, 11, "No Pickup", "No pickup details supplied")
            {
            }
        }

        private class InvalidPickupAddressErrorCode : GetSwiftError
        {
            public InvalidPickupAddressErrorCode(string name)
                : base(name, 12, "Invalid Pickup Address", "Pickup address cannot be validated")
            {
            }
        }

        private class InvalidDropoffAddressErrorCode : GetSwiftError
        {
            public InvalidDropoffAddressErrorCode(string name)
                : base(name, 13, "Invalid Dropoff Address", "Destination address cannot be validated")
            {
            }
        }

        private class NoDataErrorCode : GetSwiftError
        {
            public NoDataErrorCode(string name)
                : base(name, 14, "No Data", "No Data")
            {
            }
        }

        private class UnspecifiedErrorCode : GetSwiftError
        {
            public UnspecifiedErrorCode(string name)
                : base(name, 15, "Unspecified", "Unspecified Error")
            {
            }
        }

        private class ServerErrorErrorCode : GetSwiftError
        {
            public ServerErrorErrorCode(string name)
                : base(name, 16, "Server Error", "Internal Server Error")
            {
            }
        }

        private class UnauthorisedErrorCode : GetSwiftError
        {
            public UnauthorisedErrorCode(string name)
                : base(name, 17, "Unauthorised", "Unauthorised")
            {
            }
        }

        private class RatingNotFoundErrorCode : GetSwiftError
        {
            public RatingNotFoundErrorCode(string name)
                : base(name, 18, "Rating Not Found", "Job rating not found")
            {
            }
        }

        private class SkillNotFoundErrorCode : GetSwiftError
        {
            public SkillNotFoundErrorCode(string name)
                : base(name, 19, "Skill Not Found", "Job skills not found")
            {
            }
        }

        private class UnknownErrorCode : GetSwiftError
        {
            public UnknownErrorCode(string name)
                : base(name, 20, "Unknown", "Unknown error")
            {
            }
        }
    }
}
