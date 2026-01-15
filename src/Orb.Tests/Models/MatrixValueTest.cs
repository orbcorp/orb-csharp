using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixValue { DimensionValues = ["string"], UnitAmount = "unit_amount" };

        List<string?> expectedDimensionValues = ["string"];
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedDimensionValues.Count, model.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], model.DimensionValues[i]);
        }
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatrixValue { DimensionValues = ["string"], UnitAmount = "unit_amount" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatrixValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixValue { DimensionValues = ["string"], UnitAmount = "unit_amount" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatrixValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string?> expectedDimensionValues = ["string"];
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedDimensionValues.Count, deserialized.DimensionValues.Count);
        for (int i = 0; i < expectedDimensionValues.Count; i++)
        {
            Assert.Equal(expectedDimensionValues[i], deserialized.DimensionValues[i]);
        }
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatrixValue { DimensionValues = ["string"], UnitAmount = "unit_amount" };

        model.Validate();
    }
}
