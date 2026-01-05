using System;
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

    [Fact]
    public void Url_Works()
    {
        SubscriptionUnschedulePendingPlanChangesParams parameters = new()
        {
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/unschedule_pending_plan_changes"
            ),
            url
        );
    }
}
