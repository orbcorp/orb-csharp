using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class OtherSubLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OtherSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        ApiEnum<string, OtherSubLineItemType> expectedType = OtherSubLineItemType.Null;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OtherSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OtherSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        ApiEnum<string, OtherSubLineItemType> expectedType = OtherSubLineItemType.Null;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedGrouping, deserialized.Grouping);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OtherSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };

        model.Validate();
    }
}

public class OtherSubLineItemTypeTest : TestBase
{
    [Theory]
    [InlineData(OtherSubLineItemType.Null)]
    public void Validation_Works(OtherSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OtherSubLineItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OtherSubLineItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OtherSubLineItemType.Null)]
    public void SerializationRoundtrip_Works(OtherSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OtherSubLineItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OtherSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OtherSubLineItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OtherSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
