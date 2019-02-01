namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class QuoteCreateTest : AsyncTestMethod<QuoteCreateInput, QuoteResponse>
    {
        private QuoteService Service { get; set; }

        public override QuoteResponse Act(QuoteCreateInput input)
        {
            return Service.Create(input);
        }

        public override Task<QuoteResponse> ActAsync(QuoteCreateInput input)
        {
            return Service.CreateAsync(input);
        }

        public override QuoteCreateInput Arrange()
        {
            Service = new QuoteService(TestConstants.ApiKey);

            var input = new QuoteCreateInput("57 luscombe st, brunswick, melbourne", "105 collins st, 3000");

            input.Booking.DropoffDetail.Email = "getswift.net@mailinator.com";

            input.Booking.Reference = "ABC123";
            input.Booking.DeliveryInstructions = "Ring when you get to the street";
            input.Booking.ItemsRequirePurchase = true;
            input.Booking.Items.Add(DeliveryBookingItem.Create("Test item description 1", "SKU1", 1, 10));
            input.Booking.Items.Add(DeliveryBookingItem.Create("Test item description 2", "SKU2", 1, 10));
            input.Booking.PickupTime = DateTime.Now.AddHours(1);
            input.Booking.DropoffWindow = TimeFrame.Create(DateTime.Now, DateTime.Now.AddDays(1));
            input.Booking.CustomerFee = 10;
            input.Booking.CustomerReference = "CUST123";
            input.Booking.Tax = 20;
            input.Booking.TaxInclusivePrice = true;
            input.Booking.Tip = 30;
            input.Booking.DriverFeePercentage = 0.8m;
            input.Booking.DriverMatchCode = "MATCH123";
            input.Booking.DeliverySequence = 40;
            input.Booking.Constraints.Add(JobConstraint.Create("Constraint 1", "true"));
            input.Booking.Constraints.Add(JobConstraint.Create("Constraint 2", "false"));
            input.Booking.DeliveryRouteIdentifier = "ID123";
            input.Booking.Webhooks.Add(DeliveryEventWebhook.Create("job/created", new Uri("http://tempuri.org")));
            input.Booking.Webhooks.Add(DeliveryEventWebhook.Create("job/updated", new Uri("http://tempuri.org")));
            input.Booking.Template = "Template 1";

            return input;
        }

        public override void Assert(QuoteCreateInput input, QuoteResponse actual)
        {
            base.Assert(input, actual);

            actual.Quote.ShouldNotBeNull();
            actual.Quote.Created.ShouldBeGreaterThan(DateTime.MinValue);
            actual.Quote.Start.ShouldBeGreaterThan(DateTime.MinValue);
            actual.Quote.DistanceKm.ShouldBeGreaterThan(0);
            actual.Quote.Fee.Cost.ShouldBe(input.Booking.CustomerFee ?? 0);
            actual.Quote.Pickup.ShouldNotBeNull();
            actual.Quote.Dropoff.ShouldNotBeNull();

            actual.Request.ShouldNotBeNull();
            actual.Request.Reference.ShouldBe(input.Booking.Reference);
            actual.Request.DeliveryInstructions.ShouldBe(input.Booking.DeliveryInstructions);
            actual.Request.ItemsRequirePurchase.ShouldBe(input.Booking.ItemsRequirePurchase);
            actual.Request.Items.ShouldBe(input.Booking.Items);
            actual.Request.PickupTime.ShouldBe(input.Booking.PickupTime.Value.ToUniversalTime());
            actual.Request.DropoffWindow.ShouldBe(input.Booking.DropoffWindow);
            actual.Request.CustomerFee.ShouldBe(input.Booking.CustomerFee);
            actual.Request.CustomerReference.ShouldBe(input.Booking.CustomerReference);
            actual.Request.Tax.ShouldBe(input.Booking.Tax);
            actual.Request.TaxInclusivePrice.ShouldBe(input.Booking.TaxInclusivePrice);
            actual.Request.Tip.ShouldBe(input.Booking.Tip);
            actual.Request.DriverFeePercentage.ShouldBe(input.Booking.DriverFeePercentage);
            actual.Request.DriverMatchCode.ShouldBe(input.Booking.DriverMatchCode);
            actual.Request.DeliverySequence.ShouldBe(input.Booking.DeliverySequence);
            actual.Request.Constraints.ShouldBe(input.Booking.Constraints);
            actual.Request.DeliveryRouteIdentifier.ShouldBe(input.Booking.DeliveryRouteIdentifier);
            actual.Request.Webhooks.ShouldBe(input.Booking.Webhooks);
            actual.Request.Template.ShouldBe(input.Booking.Template);
        }
    }
}
