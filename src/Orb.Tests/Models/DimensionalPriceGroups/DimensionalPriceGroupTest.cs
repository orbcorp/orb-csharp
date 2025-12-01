using System.Collections.Generic;
using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DimensionalPriceGroup
        {
            ID = "id",
            BillableMetricID = "billable_metric_id",
            Dimensions = ["region", "instance_type"],
            ExternalDimensionalPriceGroupID = "my_dimensional_price_group_id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "id";
        string expectedBillableMetricID = "billable_metric_id";
        List<string> expectedDimensions = ["region", "instance_type"];
        string expectedExternalDimensionalPriceGroupID = "my_dimensional_price_group_id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        for (int i = 0; i < expectedDimensions.Count; i++)
        {
            Assert.Equal(expectedDimensions[i], model.Dimensions[i]);
        }
        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            model.ExternalDimensionalPriceGroupID
        );
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
    }
}
