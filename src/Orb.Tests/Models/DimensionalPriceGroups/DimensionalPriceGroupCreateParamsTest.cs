using System;
using System.Collections.Generic;
using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DimensionalPriceGroupCreateParams
        {
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            Name = "name",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedBillableMetricID = "billable_metric_id";
        List<string> expectedDimensions = ["region", "instance_type"];
        string expectedName = "name";
        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedBillableMetricID, parameters.BillableMetricID);
        Assert.Equal(expectedDimensions.Count, parameters.Dimensions.Count);
        for (int i = 0; i < expectedDimensions.Count; i++)
        {
            Assert.Equal(expectedDimensions[i], parameters.Dimensions[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
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
        var parameters = new DimensionalPriceGroupCreateParams
        {
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            Name = "name",
        };

        Assert.Null(parameters.ExternalDimensionalPriceGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_dimensional_price_group_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DimensionalPriceGroupCreateParams
        {
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            Name = "name",

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
        DimensionalPriceGroupCreateParams parameters = new()
        {
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/dimensional_price_groups"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DimensionalPriceGroupCreateParams
        {
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            Name = "name",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        DimensionalPriceGroupCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
