using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpDeleteByExternalIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopUpDeleteByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
            TopUpID = "top_up_id",
        };

        string expectedExternalCustomerID = "external_customer_id";
        string expectedTopUpID = "top_up_id";

        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedTopUpID, parameters.TopUpID);
    }
}
