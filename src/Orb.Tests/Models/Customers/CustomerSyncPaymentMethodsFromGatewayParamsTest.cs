using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerSyncPaymentMethodsFromGatewayParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerSyncPaymentMethodsFromGatewayParams
        {
            CustomerID = "customer_id",
        };

        string expectedCustomerID = "customer_id";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }
}
