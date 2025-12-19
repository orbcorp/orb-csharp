using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerDeleteParams { CustomerID = "customer_id" };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }
}
