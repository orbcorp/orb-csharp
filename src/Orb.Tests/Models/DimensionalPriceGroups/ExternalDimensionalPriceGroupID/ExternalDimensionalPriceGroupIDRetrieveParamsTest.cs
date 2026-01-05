using System;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Tests.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public class ExternalDimensionalPriceGroupIDRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalDimensionalPriceGroupIDRetrieveParams
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";

        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            parameters.ExternalDimensionalPriceGroupID
        );
    }

    [Fact]
    public void Url_Works()
    {
        ExternalDimensionalPriceGroupIDRetrieveParams parameters = new()
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/dimensional_price_groups/external_dimensional_price_group_id/external_dimensional_price_group_id"
            ),
            url
        );
    }
}
