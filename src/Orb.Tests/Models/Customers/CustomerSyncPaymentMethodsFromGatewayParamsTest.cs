using System;
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

    [Fact]
    public void Url_Works()
    {
        CustomerSyncPaymentMethodsFromGatewayParams parameters = new()
        {
            CustomerID = "customer_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/customer_id/sync_payment_methods_from_gateway"
            ),
            url
        );
    }
}
