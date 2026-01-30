using System;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUnscheduleFixedFeeQuantityUpdatesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUnscheduleFixedFeeQuantityUpdatesParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedPriceID = "price_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedPriceID, parameters.PriceID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/unschedule_fixed_fee_quantity_updates"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionUnscheduleFixedFeeQuantityUpdatesParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
        };

        SubscriptionUnscheduleFixedFeeQuantityUpdatesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
