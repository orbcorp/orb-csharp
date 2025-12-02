using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixWithAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixWithAllocationConfig
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string expectedAllocation = "allocation";
        string expectedDefaultUnitAmount = "default_unit_amount";
        List<string?> expectedDimensions = ["string"];
        List<MatrixValue> expectedMatrixValues =
        [
            new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedAllocation, model.Allocation);
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
        var model = new MatrixWithAllocationConfig
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixWithAllocationConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixWithAllocationConfig
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixWithAllocationConfig>(json);
        Assert.NotNull(deserialized);

        string expectedAllocation = "allocation";
        string expectedDefaultUnitAmount = "default_unit_amount";
        List<string?> expectedDimensions = ["string"];
        List<MatrixValue> expectedMatrixValues =
        [
            new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedAllocation, deserialized.Allocation);
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
        var model = new MatrixWithAllocationConfig
        {
            Allocation = "allocation",
            DefaultUnitAmount = "default_unit_amount",
            Dimensions = ["string"],
            MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
        };

        model.Validate();
    }
}

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixValue>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixValue { DimensionValues = ["string"], UnitAmount = "unit_amount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixValue>(json);
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
