using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class TierSubLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TierSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            TierConfig = new()
            {
                FirstUnit = 1,
                LastUnit = 1000,
                UnitAmount = "3.00",
            },
            Type = TierSubLineItemType.Tier,
        };

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        TierConfig expectedTierConfig = new()
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };
        ApiEnum<string, TierSubLineItemType> expectedType = TierSubLineItemType.Tier;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGrouping, model.Grouping);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedTierConfig, model.TierConfig);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TierSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            TierConfig = new()
            {
                FirstUnit = 1,
                LastUnit = 1000,
                UnitAmount = "3.00",
            },
            Type = TierSubLineItemType.Tier,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TierSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            TierConfig = new()
            {
                FirstUnit = 1,
                LastUnit = 1000,
                UnitAmount = "3.00",
            },
            Type = TierSubLineItemType.Tier,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(element);
        Assert.NotNull(deserialized);

        string expectedAmount = "9.00";
        SubLineItemGrouping expectedGrouping = new() { Key = "region", Value = "west" };
        string expectedName = "Tier One";
        double expectedQuantity = 5;
        TierConfig expectedTierConfig = new()
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };
        ApiEnum<string, TierSubLineItemType> expectedType = TierSubLineItemType.Tier;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedGrouping, deserialized.Grouping);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedTierConfig, deserialized.TierConfig);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TierSubLineItem
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            TierConfig = new()
            {
                FirstUnit = 1,
                LastUnit = 1000,
                UnitAmount = "3.00",
            },
            Type = TierSubLineItemType.Tier,
        };

        model.Validate();
    }
}

public class TierConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TierConfig
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };

        double expectedFirstUnit = 1;
        double expectedLastUnit = 1000;
        string expectedUnitAmount = "3.00";

        Assert.Equal(expectedFirstUnit, model.FirstUnit);
        Assert.Equal(expectedLastUnit, model.LastUnit);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TierConfig
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TierConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TierConfig
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TierConfig>(element);
        Assert.NotNull(deserialized);

        double expectedFirstUnit = 1;
        double expectedLastUnit = 1000;
        string expectedUnitAmount = "3.00";

        Assert.Equal(expectedFirstUnit, deserialized.FirstUnit);
        Assert.Equal(expectedLastUnit, deserialized.LastUnit);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TierConfig
        {
            FirstUnit = 1,
            LastUnit = 1000,
            UnitAmount = "3.00",
        };

        model.Validate();
    }
}

public class TierSubLineItemTypeTest : TestBase
{
    [Theory]
    [InlineData(TierSubLineItemType.Tier)]
    public void Validation_Works(TierSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TierSubLineItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TierSubLineItemType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TierSubLineItemType.Tier)]
    public void SerializationRoundtrip_Works(TierSubLineItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TierSubLineItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TierSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TierSubLineItemType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TierSubLineItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
