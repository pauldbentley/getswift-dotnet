namespace GetSwiftNet.Tests
{
    using System;

    public static partial class TestConstants
    {
        /// <summary>
        /// Gets the merchant API key to test.
        /// </summary>
        public static Guid ApiKey { get; }

        public static GetSwiftConfiguration Configuration { get; } = new GetSwiftConfiguration(ApiKey);

        /// <summary>
        /// Gets a value indicating whether the merchant defined by <see cref="ApiKey"/> is a service based marchant.
        /// </summary>
        public static bool ServiceBasedMarchant { get; }

        /// <summary>
        /// Gets the identifier for a valid driver.
        /// </summary>
        public static Guid? DriverId { get; }

        /// <summary>
        /// Gets the identifier for a valid delivery.
        /// </summary>
        public static Guid? DeliveryId { get; }

        /// <summary>
        /// Gets a value indicating whether the delivery defined by <see cref=" DeliveryId"/> has contraints.
        /// </summary>
        public static bool DeliveryHasContraints { get; }

        /// <summary>
        /// Gets a value indicating whether the delivery defined by <see cref=" DeliveryId"/> has items.
        /// </summary>
        public static bool DeliveryHasItems { get; }

        /// <summary>
        /// Gets the identifier for a finished delivery.
        /// </summary>
        public static Guid? FinishedDeliveryId { get; }

        /// <summary>
        /// Gets a value indicating whether there are drivers in the system.
        /// </summary>
        public static bool HasDrivers { get; }

        /// <summary>
        /// Gets a value indicating whether there are activated drivers in the system.
        /// </summary>
        public static bool HasActivatedDrivers { get; }

        /// <summary>
        /// Gets a value indicating whether there are deactivated drivers in the system.
        /// </summary>
        public static bool HasDeactivatedDrivers { get; }

        /// <summary>
        /// Gets a value indicating whether there are invited drivers in the system.
        /// </summary>
        public static bool HasInvitedDrivers { get; }

        /// <summary>
        /// Gets a value indicating whether there are online drivers in the system.
        /// </summary>
        public static bool HasOnlineDrivers { get; }

        /// <summary>
        /// Gets a value indicating whether there are deliveries in the system.
        /// </summary>
        public static bool HasDeliveries { get; }

        /// <summary>
        /// Gets a value indicating whether there are active deliveries in the system.
        /// </summary>
        public static bool HasActiveDeliveries { get; }

        /// <summary>
        /// Gets a value indicating whether there are successful deliveries in the system.
        /// </summary>
        public static bool HasSuccessfulDeliveries { get; }

        /// <summary>
        /// Gets a value indicating whether there are cancelled deliveries in the system.
        /// </summary>
        public static bool HasCancelledDeliveries { get; }
    }
}
