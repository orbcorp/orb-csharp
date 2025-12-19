using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopUpDeleteParams
        {
            CustomerID = "customer_id",
            TopUpID = "top_up_id",
        };

        string expectedCustomerID = "customer_id";
        string expectedTopUpID = "top_up_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedTopUpID, parameters.TopUpID);
    }
}
