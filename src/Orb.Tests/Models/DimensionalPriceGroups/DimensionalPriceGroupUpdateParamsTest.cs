using System;
using System.Collections.Generic;
using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DimensionalPriceGroupUpdateParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";
        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedDimensionalPriceGroupID, parameters.DimensionalPriceGroupID);
        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            parameters.ExternalDimensionalPriceGroupID
        );
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DimensionalPriceGroupUpdateParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        Assert.Null(parameters.ExternalDimensionalPriceGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_dimensional_price_group_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DimensionalPriceGroupUpdateParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",

            ExternalDimensionalPriceGroupID = null,
            Metadata = null,
        };

        Assert.Null(parameters.ExternalDimensionalPriceGroupID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_dimensional_price_group_id"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        DimensionalPriceGroupUpdateParams parameters = new()
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
        var parameters = new DimensionalPriceGroupUpdateParams
        {
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        DimensionalPriceGroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
