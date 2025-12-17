using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixConfig
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string expectedDefaultUnitAmount = "default_unit_amount";
        List<string?> expectedDimensions = ["string"];
        List<MatrixValue> expectedMatrixValues =
        [
            new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedDefaultUnitAmount, model.DefaultUnitAmount);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        for (int i = 0; i < expectedDimensions.Count; i++)
        {
            Assert.Equal(expectedDimensions[i], model.Dimensions[i]);
        }
        Assert.Equal(expectedMatrixValues.Count, model.MatrixValues.Count);
        for (int i = 0; i < expectedMatrixValues.Count; i++)
        {
            Assert.Equal(expectedMatrixValues[i], model.MatrixValues[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatrixConfig
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixConfig
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixConfig>(element);
        Assert.NotNull(deserialized);

        string expectedDefaultUnitAmount = "default_unit_amount";
        List<string?> expectedDimensions = ["string"];
        List<MatrixValue> expectedMatrixValues =
        [
            new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedDefaultUnitAmount, deserialized.DefaultUnitAmount);
        Assert.Equal(expectedDimensions.Count, deserialized.Dimensions.Count);
        for (int i = 0; i < expectedDimensions.Count; i++)
        {
            Assert.Equal(expectedDimensions[i], deserialized.Dimensions[i]);
        }
        Assert.Equal(expectedMatrixValues.Count, deserialized.MatrixValues.Count);
        for (int i = 0; i < expectedMatrixValues.Count; i++)
        {
            Assert.Equal(expectedMatrixValues[i], deserialized.MatrixValues[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatrixConfig
        {
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        model.Validate();
    }
}
