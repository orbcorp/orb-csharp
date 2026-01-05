using System;
using System.Collections.Generic;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Tests.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public class ExternalDimensionalPriceGroupIDUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalDimensionalPriceGroupIDUpdateParams
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            ExternalDimensionalPriceGroupIDValue = "external_dimensional_price_group_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";
        string expectedExternalDimensionalPriceGroupIDValue = "external_dimensional_price_group_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            parameters.ExternalDimensionalPriceGroupID
        );
        Assert.Equal(
            expectedExternalDimensionalPriceGroupIDValue,
            parameters.ExternalDimensionalPriceGroupIDValue
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
        var parameters = new ExternalDimensionalPriceGroupIDUpdateParams
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        Assert.Null(parameters.ExternalDimensionalPriceGroupIDValue);
        Assert.False(parameters.RawBodyData.ContainsKey("external_dimensional_price_group_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalDimensionalPriceGroupIDUpdateParams
        {
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",

            ExternalDimensionalPriceGroupIDValue = null,
            Metadata = null,
        };

        Assert.Null(parameters.ExternalDimensionalPriceGroupIDValue);
        Assert.True(parameters.RawBodyData.ContainsKey("external_dimensional_price_group_id"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalDimensionalPriceGroupIDUpdateParams parameters = new()
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
