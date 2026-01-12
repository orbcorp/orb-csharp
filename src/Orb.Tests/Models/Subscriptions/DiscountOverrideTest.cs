using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class DiscountOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,
            AmountDiscount = "amount_discount",
            PercentageDiscount = 0.15,
            UsageDiscount = 0,
        };

        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Percentage;
        string expectedAmountDiscount = "amount_discount";
        double expectedPercentageDiscount = 0.15;
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,
            AmountDiscount = "amount_discount",
            PercentageDiscount = 0.15,
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DiscountOverride>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,
            AmountDiscount = "amount_discount",
            PercentageDiscount = 0.15,
            UsageDiscount = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DiscountOverride>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, DiscountType> expectedDiscountType = DiscountType.Percentage;
        string expectedAmountDiscount = "amount_discount";
        double expectedPercentageDiscount = 0.15;
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,
            AmountDiscount = "amount_discount",
            PercentageDiscount = 0.15,
            UsageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscountOverride { DiscountType = DiscountType.Percentage };

        Assert.Null(model.AmountDiscount);
        Assert.False(model.RawData.ContainsKey("amount_discount"));
        Assert.Null(model.PercentageDiscount);
        Assert.False(model.RawData.ContainsKey("percentage_discount"));
        Assert.Null(model.UsageDiscount);
        Assert.False(model.RawData.ContainsKey("usage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiscountOverride { DiscountType = DiscountType.Percentage };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,

            AmountDiscount = null,
            PercentageDiscount = null,
            UsageDiscount = null,
        };

        Assert.Null(model.AmountDiscount);
        Assert.True(model.RawData.ContainsKey("amount_discount"));
        Assert.Null(model.PercentageDiscount);
        Assert.True(model.RawData.ContainsKey("percentage_discount"));
        Assert.Null(model.UsageDiscount);
        Assert.True(model.RawData.ContainsKey("usage_discount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DiscountOverride
        {
            DiscountType = DiscountType.Percentage,

            AmountDiscount = null,
            PercentageDiscount = null,
            UsageDiscount = null,
        };

        model.Validate();
    }
}

public class DiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(DiscountType.Percentage)]
    [InlineData(DiscountType.Usage)]
    [InlineData(DiscountType.Amount)]
    public void Validation_Works(DiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountType.Percentage)]
    [InlineData(DiscountType.Usage)]
    [InlineData(DiscountType.Amount)]
    public void SerializationRoundtrip_Works(DiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
