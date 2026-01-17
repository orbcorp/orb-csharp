using System;
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

    [Fact]
    public void Url_Works()
    {
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters = new()
        {
            ExternalCustomerID = "external_customer_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/external_customer_id/external_customer_id/sync_payment_methods_from_gateway"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams
        {
            ExternalCustomerID = "external_customer_id",
        };

        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
