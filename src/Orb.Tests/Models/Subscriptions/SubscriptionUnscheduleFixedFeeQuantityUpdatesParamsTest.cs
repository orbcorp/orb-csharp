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
}
