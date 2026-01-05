using System;
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

    [Fact]
    public void Url_Works()
    {
        TopUpDeleteParams parameters = new() { CustomerID = "customer_id", TopUpID = "top_up_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/customers/customer_id/credits/top_ups/top_up_id"),
            url
        );
    }
}
