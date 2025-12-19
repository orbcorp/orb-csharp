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
}
