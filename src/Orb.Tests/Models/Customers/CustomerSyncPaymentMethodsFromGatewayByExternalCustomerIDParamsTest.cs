using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams
        {
            ExternalCustomerID = "external_customer_id",
        };

        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
    }
}
