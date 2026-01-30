using System;
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

    [Fact]
    public void Url_Works()
    {
        CustomerDeleteParams parameters = new() { CustomerID = "customer_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/customers/customer_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerDeleteParams { CustomerID = "customer_id" };

        CustomerDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
