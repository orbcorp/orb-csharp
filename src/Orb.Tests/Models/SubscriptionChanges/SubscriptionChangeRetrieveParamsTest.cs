using System;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionChangeRetrieveParams
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        string expectedSubscriptionChangeID = "subscription_change_id";

        Assert.Equal(expectedSubscriptionChangeID, parameters.SubscriptionChangeID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionChangeRetrieveParams parameters = new()
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscription_changes/subscription_change_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionChangeRetrieveParams
        {
            SubscriptionChangeID = "subscription_change_id",
        };

        SubscriptionChangeRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
