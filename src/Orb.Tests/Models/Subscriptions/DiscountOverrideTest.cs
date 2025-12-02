using System.Text.Json;
using Orb.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DiscountOverride>(json);
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
