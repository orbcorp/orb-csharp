using System.Collections.Generic;
using Orb.Models;
using Orb.Models.DimensionalPriceGroups;

namespace Orb.Tests.Models.DimensionalPriceGroups;

public class DimensionalPriceGroupDimensionalPriceGroupsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DimensionalPriceGroupDimensionalPriceGroups
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillableMetricID = "billable_metric_id",
                    Dimensions = ["region", "instance_type"],
                    ExternalDimensionalPriceGroupID = "my_dimensional_price_group_id",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<DimensionalPriceGroup> expectedData =
        [
            new()
            {
                ID = "id",
                BillableMetricID = "billable_metric_id",
                Dimensions = ["region", "instance_type"],
                ExternalDimensionalPriceGroupID = "my_dimensional_price_group_id",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }
}
