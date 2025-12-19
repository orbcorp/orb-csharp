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
}
