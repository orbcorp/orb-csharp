using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUnschedulePendingPlanChangesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUnschedulePendingPlanChangesParams
        {
            SubscriptionID = "subscription_id",
        };

        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
    }
}
