using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MatrixSubLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        SubLineItemMatrixConfig expectedMatrixConfig = new(["string"]);
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        ApiEnum<string, MatrixSubLineItemType> expectedType = MatrixSubLineItemType.Matrix;
        double expectedScaledQuantity = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedMatrixConfig, model.MatrixConfig);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedScaledQuantity, model.ScaledQuantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(element);
        Assert.NotNull(deserialized);

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        SubLineItemMatrixConfig expectedMatrixConfig = new(["string"]);
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        ApiEnum<string, MatrixSubLineItemType> expectedType = MatrixSubLineItemType.Matrix;
        double expectedScaledQuantity = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedGrouping, deserialized.Grouping);
        Assert.Equal(expectedMatrixConfig, deserialized.MatrixConfig);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedScaledQuantity, deserialized.ScaledQuantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
        };

        Assert.Null(model.ScaledQuantity);
        Assert.False(model.RawData.ContainsKey("scaled_quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,

            ScaledQuantity = null,
        };

        Assert.Null(model.ScaledQuantity);
        Assert.True(model.RawData.ContainsKey("scaled_quantity"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MatrixSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,

            ScaledQuantity = null,
        };

        model.Validate();
    }
}

public class MatrixSubLineItemTypeTest : TestBase
{
    [Theory]
    [InlineData(MatrixSubLineItemType.Matrix)]
    public void Validation_Works(MatrixSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatrixSubLineItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MatrixSubLineItemType.Matrix)]
    public void SerializationRoundtrip_Works(MatrixSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatrixSubLineItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
