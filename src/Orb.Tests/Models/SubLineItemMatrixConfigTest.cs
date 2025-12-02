using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class SubLineItemMatrixConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubLineItemMatrixConfig { DimensionValues = ["string"] };

        List<string?> expectedDimensionValues = ["string"];

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubLineItemMatrixConfig { DimensionValues = ["string"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubLineItemMatrixConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubLineItemMatrixConfig { DimensionValues = ["string"] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubLineItemMatrixConfig>(json);
        Assert.NotNull(deserialized);

        List<string?> expectedDimensionValues = ["string"];

        Assert.Equal(expectedDimensionValues.Count, deserialized.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], deserialized.DimensionValues[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubLineItemMatrixConfig { DimensionValues = ["string"] };

        model.Validate();
    }
}
