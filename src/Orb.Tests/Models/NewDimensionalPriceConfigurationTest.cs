using System.Collections.Generic;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewDimensionalPriceConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewDimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };

        List<string> expectedDimensionValues = ["string"];
        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";
        string expectedExternalDimensionalPriceGroupID = "external_dimensional_price_group_id";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedDimensionalPriceGroupID, model.DimensionalPriceGroupID);
        Assert.Equal(
            expectedExternalDimensionalPriceGroupID,
            model.ExternalDimensionalPriceGroupID
        );
    }
}
