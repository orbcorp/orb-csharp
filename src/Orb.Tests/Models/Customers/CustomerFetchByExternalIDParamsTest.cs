using System;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class CustomerFetchByExternalIDParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerFetchByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
        };

        string expectedExternalCustomerID = "external_customer_id";

        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerFetchByExternalIDParams parameters = new()
        {
            ExternalCustomerID = "external_customer_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/customers/external_customer_id/external_customer_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerFetchByExternalIDParams
        {
            ExternalCustomerID = "external_customer_id",
        };

        CustomerFetchByExternalIDParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
