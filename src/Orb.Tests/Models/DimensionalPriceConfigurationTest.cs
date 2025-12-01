using System.Collections.Generic;
using Orb.Models;

namespace Orb.Tests.Models;

public class DimensionalPriceConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        List<string> expectedDimensionValues = ["string"];
        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedDimensionalPriceGroupID, model.DimensionalPriceGroupID);
    }
}
