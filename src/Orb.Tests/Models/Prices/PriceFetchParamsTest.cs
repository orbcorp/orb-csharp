using System;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PriceFetchParams { PriceID = "price_id" };

        string expectedPriceID = "price_id";

        Assert.Equal(expectedPriceID, parameters.PriceID);
    }

    [Fact]
    public void Url_Works()
    {
        PriceFetchParams parameters = new() { PriceID = "price_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/prices/price_id"), url);
    }
}
