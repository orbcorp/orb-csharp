using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceFetchUpcomingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceFetchUpcomingParams { SubscriptionID = "subscription_id" };

        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceFetchUpcomingParams parameters = new() { SubscriptionID = "subscription_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/invoices/upcoming?subscription_id=subscription_id"),
            url
        );
    }
}
