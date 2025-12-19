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
}
