namespace GetSwiftNet
{
    using System;

    /// <summary>
    /// Defines the input required to create a quote.
    /// </summary>
    public class QuoteCreateInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteCreateInput"/> class with a dropoff address.  This would be for service-based merchants.
        /// </summary>
        /// <param name="dropoffAddress">The dropoff address.</param>
        public QuoteCreateInput(string dropoffAddress)
        {
            var dropoffDetail = DeliveryBookingLocation.Create(dropoffAddress);
            Booking = DeliveryBooking.Create(dropoffDetail);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteCreateInput"/> class with a pickup and dropoff address.
        /// </summary>
        /// <param name="pickUpAddress">The pickup address.</param>
        /// <param name="dropoffAddress">The dropoff address.</param>
        public QuoteCreateInput(string pickUpAddress, string dropoffAddress)
        {
            var pickupDetail = DeliveryBookingLocation.Create(pickUpAddress);
            var dropoffDetail = DeliveryBookingLocation.Create(dropoffAddress);

            Booking = DeliveryBooking.Create(pickupDetail, dropoffDetail);
        }

        /// <summary>
        /// Gets or sets the API key for the merchant.
        /// This key will take priority over the key defined on the service or the <see cref="GetSwiftConfiguration.ApiKey"/>.
        /// </summary>
        public Guid? ApiKey { get; set; }

        /// <summary>
        /// Gets the details of the delivery booking.
        /// </summary>
        public DeliveryBooking Booking { get; }
    }
}