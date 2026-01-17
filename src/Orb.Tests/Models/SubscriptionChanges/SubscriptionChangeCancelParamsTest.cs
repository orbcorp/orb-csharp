using System;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChangeCancelParams
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        string expectedSubscriptionChangeID = "subscription_change_id";

        Assert.Equal(expectedSubscriptionChangeID, parameters.SubscriptionChangeID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChangeCancelParams parameters = new()
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscription_changes/subscription_change_id/cancel"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionChangeCancelParams
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        SubscriptionChangeCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
