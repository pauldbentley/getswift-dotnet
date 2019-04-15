namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class QuoteCreateTest : AsyncTestMethod<QuoteCreateInput, QuoteResponse>
    {
        private QuoteService Service { get; set; }

        public override QuoteResponse Act()
        {
            return Service.Create(Input);
        }

        public override Task<QuoteResponse> ActAsync()
        {
            return Service.CreateAsync(Input);
        }

        public override bool Arrange()
        {
            Service = new QuoteService(TestConstants.ApiKey);

            Input = new QuoteCreateInput("57 luscombe st, brunswick, melbourne", "105 collins st, 3000");

            Input.Booking.DropoffDetail.Email = "getswift.net@mailinator.com";

            Input.Booking.Reference = "ABC123";
            Input.Booking.DeliveryInstructions = "Ring when you get to the street";
            Input.Booking.ItemsRequirePurchase = true;
            Input.Booking.Items.Add(DeliveryBookingItem.Create("Test item description 1", "SKU1", 1, 10));
            Input.Booking.Items.Add(DeliveryBookingItem.Create("Test item description 2", "SKU2", 1, 10));
            Input.Booking.PickupTime = DateTime.Now.AddHours(1);
            Input.Booking.DropoffWindow = TimeFrame.Create(DateTime.Now, DateTime.Now.AddDays(1));
            Input.Booking.CustomerFee = 10;
            Input.Booking.CustomerReference = "CUST123";
            Input.Booking.Tax = 20;
            Input.Booking.TaxInclusivePrice = true;
            Input.Booking.Tip = 30;
            Input.Booking.DriverFeePercentage = 0.8m;
            Input.Booking.DriverMatchCode = "MATCH123";
            Input.Booking.DeliverySequence = 40;
            Input.Booking.Constraints.Add("Constraint 1", "true");
            Input.Booking.Constraints.Add("Constraint 2", "false");
            Input.Booking.DeliveryRouteIdentifier = "ID123";
            Input.Booking.Webhooks.Add("job/created", "http://tempuri.org");
            Input.Booking.Webhooks.Add("job/updated", "http://tempuri.org");
            Input.Booking.Template = "Template 1";

            return true;
        }

        public override void Assert(QuoteResponse actual)
        {
            base.Assert(actual);

            actual.Quote.ShouldNotBeNull();
            actual.Quote.Created.ShouldBeGreaterThan(DateTime.MinValue);
            actual.Quote.Start.ShouldBeGreaterThan(DateTime.MinValue);
            actual.Quote.DistanceKm.ShouldBeGreaterThan(0);
            actual.Quote.Fee.Cost.ShouldBe(Input.Booking.CustomerFee ?? 0);
            actual.Quote.Pickup.ShouldNotBeNull();
            actual.Quote.Dropoff.ShouldNotBeNull();

            actual.Request.ShouldNotBeNull();
            actual.Request.Reference.ShouldBe(Input.Booking.Reference);
            actual.Request.DeliveryInstructions.ShouldBe(Input.Booking.DeliveryInstructions);
            actual.Request.ItemsRequirePurchase.ShouldBe(Input.Booking.ItemsRequirePurchase);
            actual.Request.Items.ShouldBe(Input.Booking.Items);
            actual.Request.PickupTime.ShouldBe(Input.Booking.PickupTime.Value.ToUniversalTime());
            actual.Request.DropoffWindow.ShouldBe(Input.Booking.DropoffWindow);
            actual.Request.CustomerFee.ShouldBe(Input.Booking.CustomerFee);
            actual.Request.CustomerReference.ShouldBe(Input.Booking.CustomerReference);
            actual.Request.Tax.ShouldBe(Input.Booking.Tax);
            actual.Request.TaxInclusivePrice.ShouldBe(Input.Booking.TaxInclusivePrice);
            actual.Request.Tip.ShouldBe(Input.Booking.Tip);
            actual.Request.DriverFeePercentage.ShouldBe(Input.Booking.DriverFeePercentage);
            actual.Request.DriverMatchCode.ShouldBe(Input.Booking.DriverMatchCode);
            actual.Request.DeliverySequence.ShouldBe(Input.Booking.DeliverySequence);
            actual.Request.Constraints.ShouldBe(Input.Booking.Constraints);
            actual.Request.DeliveryRouteIdentifier.ShouldBe(Input.Booking.DeliveryRouteIdentifier);
            actual.Request.Webhooks.ShouldBe(Input.Booking.Webhooks);
            actual.Request.Template.ShouldBe(Input.Booking.Template);
        }
    }
}
