﻿namespace GetSwiftNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Shouldly;

    public class QuoteCreateWithPastDeliveryWindow : AsyncTestMethod<QuoteCreateInput, GetSwiftException>
    {
        private QuoteService Service { get; set; }

        public override GetSwiftException Act()
        {
            return Should.Throw<GetSwiftException>(() => Service.Create(Input));
        }

        public override Task<GetSwiftException> ActAsync()
        {
            return Should.ThrowAsync<GetSwiftException>(() => Service.CreateAsync(Input));
        }

        public override bool Arrange()
        {
            Service = new QuoteService(TestConstants.Configuration);

            Input = new QuoteCreateInput("57 luscombe st, brunswick, melbourne", "105 collins st, 3000");
            Input.Booking.DropoffWindow = TimeFrame.Create(DateTime.Now.AddDays(-100), DateTime.Now);

            return true;
        }

        public override void Assert(GetSwiftException actual)
        {
            base.Assert(actual);

            actual.GetSwiftError.ShouldBe(GetSwiftError.PastDeliveryWindow);
        }
    }
}
