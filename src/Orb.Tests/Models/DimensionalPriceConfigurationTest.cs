using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DimensionalPriceConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DimensionalPriceConfiguration>(json);
        Assert.NotNull(deserialized);

        List<string> expectedDimensionValues = ["string"];
        string expectedDimensionalPriceGroupID = "dimensional_price_group_id";

        Assert.Equal(expectedDimensionValues.Count, deserialized.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], deserialized.DimensionValues[i]);
        }
        Assert.Equal(expectedDimensionalPriceGroupID, deserialized.DimensionalPriceGroupID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DimensionalPriceConfiguration
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
        };

        model.Validate();
    }
}
