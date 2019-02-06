namespace GetSwiftNet
{
    using System;
    using GetSwiftNet.Infrastructure;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines extra address details.
    /// </summary>
    public sealed class ExtraAddressDetails
    {
        /// <summary>
        /// The minimum length of the <see cref="StateProvince"/> property.
        /// </summary>
        public const int MinStateProvinceLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="StateProvince"/> property.
        /// </summary>
        public const int MaxStateProvinceLength = 40;

        /// <summary>
        /// The minimum length of the <see cref="Country"/> property.
        /// </summary>
        public const int MinCountryLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="Country"/> property.
        /// </summary>
        public const int MaxCountryLength = 30;

        /// <summary>
        /// The minimum length of the <see cref="SuburbLocality"/> property.
        /// </summary>
        public const int MinSuburbLocalityLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="SuburbLocality"/> property.
        /// </summary>
        public const int MaxSuburbLocalityLength = 35;

        /// <summary>
        /// The minimum length of the <see cref="Postcode"/> property.
        /// </summary>
        public const int MinPostcodeLength = 1;

        /// <summary>
        /// The maximum length of the <see cref="Postcode"/> property.
        /// </summary>
        public const int MaxPostcodeLength = 10;

        [JsonConstructor]
        private ExtraAddressDetails(string stateProvince, string country, string suburbLocality, string postcode, decimal latitude, decimal longitude)
        {
            StateProvince = stateProvince;
            Country = country;
            SuburbLocality = suburbLocality;
            Postcode = postcode;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets the state or province.
        /// </summary>
        public string StateProvince { get; }

        /// <summary>
        /// Gets the country.
        /// Please note that the country name should be the full name of the country and not an abbreviation.
        /// This will mean that services such as the SMS alerts will function correctly.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Gets the suburb locality.
        /// </summary>
        public string SuburbLocality { get; }

        /// <summary>
        /// Gets the postcode.
        /// </summary>
        public string Postcode { get; }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        public decimal Latitude { get; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        public decimal Longitude { get; }

        /// <summary>
        /// Creates a new <see cref="ExtraAddressDetails"/> instance with a specified values.
        /// </summary>
        /// <param name="stateProvince">The state or province.</param>
        /// <param name="country">The country.</param>
        /// <param name="suburbLocality">The suburb locality.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>An <see cref="Outcome"/> indicating the outcome of the create method.</returns>
        public static Outcome<ExtraAddressDetails> Create(string stateProvince, string country, string suburbLocality, string postcode, decimal latitude, decimal longitude)
        {
            var errors = new[]
            {
                ValidateStateProvince(stateProvince),
                ValidateCountry(country),
                ValidateSuburbLocality(suburbLocality),
                ValidatePostcode(postcode)
            };

            return !Exceptions.Any(errors)
                ? Outcomes.Success(new ExtraAddressDetails(stateProvince, country, suburbLocality, postcode, latitude, longitude))
                : Outcomes.Failure<ExtraAddressDetails>(errors);
        }

        /// <summary>
        /// Determines whether the state or province is valid.
        /// </summary>
        /// <param name="stateProvince">The state or province to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckStateProvince(string stateProvince)
        {
            return Outcomes.Create(ValidateStateProvince(stateProvince));
        }

        /// <summary>
        /// Determines whether the country is valid.
        /// </summary>
        /// <param name="country">The country to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckCountry(string country)
        {
            return Outcomes.Create(ValidateCountry(country));
        }

        /// <summary>
        /// Determines whether the suburb locality is valid.
        /// </summary>
        /// <param name="suburbLocality">The suburb locality to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckSuburbLocality(string suburbLocality)
        {
            return Outcomes.Create(ValidateSuburbLocality(suburbLocality));
        }

        /// <summary>
        /// Determines whether the postcode is valid.
        /// </summary>
        /// <param name="postcode">The postcode to validate.</param>
        /// <returns>An <see cref="Outcome"/> with the outcome of the validation.</returns>
        public static Outcome CheckPostcode(string postcode)
        {
            return Outcomes.Create(ValidatePostcode(postcode));
        }

        private static Exception ValidateStateProvince(string stateProvince)
        {
            return
                Exceptions.WhenNullOrWhitespace(stateProvince, nameof(stateProvince)) ??
                Exceptions.WhenLengthIsIncorrect(stateProvince, MinStateProvinceLength, MaxStateProvinceLength, nameof(stateProvince));
        }

        private static Exception ValidateCountry(string country)
        {
            return
                Exceptions.WhenNullOrWhitespace(country, nameof(country)) ??
                Exceptions.WhenLengthIsIncorrect(country, MinCountryLength, MaxCountryLength, nameof(country));
        }

        private static Exception ValidateSuburbLocality(string suburbLocality)
        {
            return
                Exceptions.WhenNullOrWhitespace(suburbLocality, nameof(suburbLocality)) ??
                Exceptions.WhenLengthIsIncorrect(suburbLocality, MinSuburbLocalityLength, MaxSuburbLocalityLength, nameof(suburbLocality));
        }

        private static Exception ValidatePostcode(string postcode)
        {
            return
                Exceptions.WhenNullOrWhitespace(postcode, nameof(postcode)) ??
                Exceptions.WhenLengthIsIncorrect(postcode, MinPostcodeLength, MaxPostcodeLength, nameof(postcode));
        }
    }
}
