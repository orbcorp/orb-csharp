using System;
using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DimensionalPriceGroupRetrieveParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";

        Assert.Equal(expectedDimensionalPriceGroupID, parameters.DimensionalPriceGroupID);
    }

    [Fact]
    public void Url_Works()
    {
        DimensionalPriceGroupRetrieveParams parameters = new()
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/dimensional_price_groups/dimensional_price_group_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DimensionalPriceGroupRetrieveParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        DimensionalPriceGroupRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
