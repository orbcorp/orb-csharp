using System;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Tests.Models.Prices.ExternalPriceID;

public class ExternalPriceIDFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPriceIDFetchParams { ExternalPriceID = "external_price_id" };

        string expectedExternalPriceID = "external_price_id";

        Assert.Equal(expectedExternalPriceID, parameters.ExternalPriceID);
    }

    [Fact]
    public void Url_Works()
    {
        ExternalPriceIDFetchParams parameters = new() { ExternalPriceID = "external_price_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/prices/external_price_id/external_price_id"),
            url
        );
    }
}
