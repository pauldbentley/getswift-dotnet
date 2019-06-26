namespace GetSwiftNet
{
    using System;
    using System.Diagnostics;
    using EnsuredOutcomes;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a delivery location.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class DeliveryBookingLocation
    {
        /// <summary>
        /// The maximum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MaxNameLength = 256;

        /// <summary>
        /// The maximum length of the <see cref="Phone"/> property.
        /// </summary>
        public const int MaxPhoneLength = 20;

        /// <summary>
        /// The maximum length of the <see cref="Description"/> property.
        /// </summary>
        public const int MaxDescriptionLength = 250;

        /// <summary>
        /// The minimum length of the <see cref="Address"/> property.
        /// </summary>
        public const int MinAddressLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="Address"/> property.
        /// </summary>
        public const int MaxAddressLength = 250;

        private string name;
        private string phone;
        private Email email;
        private string description;

        [JsonConstructor]
        private DeliveryBookingLocation(string name, string phone, Email email, string description, string address, ExtraAddressDetails additionalAddressDetails)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.description = description;
            Address = address;
            AdditionalAddressDetails = additionalAddressDetails;
        }

        /// <summary>
        /// Gets or sets the contact name.
        /// The name can be null, or it must not be empty or whitespace, and have a maximum length of <see cref="MaxNameLength"/>.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                Exceptions.Throw(ValidateName(value));
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact phone number.
        /// </summary>
        public string Phone
        {
            get => phone;
            set
            {
                Exceptions.Throw(ValidatePhone(value));
                phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        public Email Email
        {
            get => email;
            set
            {
                Exceptions.Throw(ValidateEmail(value));
                email = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the location for the driver, e.g.: business name.
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                Exceptions.Throw(ValidatePhone(value));
                description = value;
            }
        }

        /// <summary>
        /// Gets the address as a string which will be validated and geocoded on the server.
        /// The resolved address will be passed back in the quote response object so that it can be verified (if needed).
        /// To ensure geocoding is as accurate as possible, please ensure that this value includes the country and post code if possible.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets a more detailed address details.
        /// If every non-optional value is provided (including the Latitude/Longitude), we will not attempt to geocode the address and the address details you provide will flow through the system untouched.
        /// </summary>
        public ExtraAddressDetails AdditionalAddressDetails { get; }

        /// <summary>
        /// Creates a <see cref="DeliveryBookingLocation"/> with the given address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingLocation> Create(string address) => Create(address, null, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="DeliveryBookingLocation"/> with the given address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="additionalAddressDetails">Additional address details.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingLocation> Create(string address, ExtraAddressDetails additionalAddressDetails) => Create(address, null, null, null, null, additionalAddressDetails);

        /// <summary>
        /// Creates a <see cref="DeliveryBookingLocation"/> with the given address and contact details.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="name">The name.</param>
        /// <param name="phone">The phone number.</param>
        /// <param name="email">The email.</param>
        /// <param name="description">The description.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingLocation> Create(string address, string name, string phone, Email email, string description) => Create(address, name, phone, email, description);

        /// <summary>
        /// Creates a new <see cref="DeliveryBookingLocation"/> with the given address and contact details.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="name">The name.</param>
        /// <param name="phone">The phone number.</param>
        /// <param name="email">The email.</param>
        /// <param name="description">The description.</param>
        /// <param name="additionalAddressDetails">Additional address details.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<DeliveryBookingLocation> Create(string address, string name, string phone, Email email, string description, ExtraAddressDetails additionalAddressDetails)
        {
            var errors = new[]
            {
                ValidateAddress(address),
                ValidateName(name),
                ValidatePhone(phone),
                ValidateEmail(email),
                ValidateDescription(description),
                ValidateAdditionalAddressDetails(additionalAddressDetails),
            };

            if (!Exceptions.Any(errors))
            {
                return Outcomes.Success(new DeliveryBookingLocation(name, phone, email, description, address, additionalAddressDetails));
            }

            return Outcomes.Failure<DeliveryBookingLocation>(errors);
        }

        /// <summary>
        /// Determines whether the specified <paramref name="name"/> is valid.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckName(string name)
        {
            return Outcomes.Determine(ValidateName(name));
        }

        /// <summary>
        /// Determines whether the specified phone is valid.
        /// </summary>
        /// <param name="phone">The phone to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckPhone(string phone)
        {
            return Outcomes.Determine(ValidatePhone(phone));
        }

        /// <summary>
        /// Determines whether the specified email is valid.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckEmail(Email email)
        {
            return Outcomes.Determine(ValidateEmail(email));
        }

        /// <summary>
        /// Determines whether the specified description is valid.
        /// </summary>
        /// <param name="description">The description to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckDescription(string description)
        {
            return Outcomes.Determine(ValidateDescription(description));
        }

        /// <summary>
        /// Determines whether the specified address is valid.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckAddress(string address)
        {
            return Outcomes.Determine(ValidateAddress(address));
        }

        /// <summary>
        /// Determines whether the specified additional address details are valid.
        /// </summary>
        /// <param name="extraAddressDetails">The additional address details to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckAdditionalAddressDetails(ExtraAddressDetails extraAddressDetails)
        {
            return Outcomes.Determine(ValidateAdditionalAddressDetails(extraAddressDetails));
        }

        private static Exception ValidateName(string name)
        {
            return
                (name != null ? Exceptions.WhenNullOrWhiteSpace(name, nameof(name)) : null) ??
                Exceptions.WhenLengthIsIncorrect(name, 0, MaxNameLength, nameof(name));
        }

        private static Exception ValidatePhone(string phone)
        {
            return
                (phone != null ? Exceptions.WhenNullOrWhiteSpace(phone, nameof(phone)) : null) ??
                Exceptions.WhenLengthIsIncorrect(phone, 0, MaxPhoneLength, nameof(phone));
        }

        private static Exception ValidateEmail(Email email)
        {
            return email != null
                ? Exceptions.WhenNull(email, nameof(email))
                : null;
        }

        private static Exception ValidateDescription(string description)
        {
            return
                (description != null ? Exceptions.WhenNullOrWhiteSpace(description, nameof(description)) : null) ??
                Exceptions.WhenLengthIsIncorrect(description, 0, MaxDescriptionLength, nameof(description));
        }

        private static Exception ValidateAddress(string address)
        {
            return
                Exceptions.WhenNullOrWhiteSpace(address, nameof(address)) ??
                Exceptions.WhenLengthIsIncorrect(address, MinAddressLength, MaxAddressLength, nameof(address));
        }

        private static Exception ValidateAdditionalAddressDetails(ExtraAddressDetails additionalAddressDetails)
        {
            return additionalAddressDetails != null
                ? Exceptions.WhenNull(additionalAddressDetails, nameof(additionalAddressDetails))
                : null;
        }

        private string DebuggerDisplay() => Address;
    }
}
