using System.Text.Json;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class DiscountTest : TestBase
{
    [Fact]
    public void percentageValidation_Works()
    {
        Discount value = new(new Percentage(0));
        value.Validate();
    }

    [Fact]
    public void amountValidation_Works()
    {
        Discount value = new(new Amount("amount_discount"));
        value.Validate();
    }

    [Fact]
    public void percentageSerializationRoundtrip_Works()
    {
        Discount value = new(new Percentage(0));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Discount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void amountSerializationRoundtrip_Works()
    {
        Discount value = new(new Amount("amount_discount"));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Discount>(json);

        Assert.Equal(value, deserialized);
    }
}

public class PercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>(
            "\"percentage\""
        );
        double expectedPercentageDiscount = 0;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Percentage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Percentage>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>(
            "\"percentage\""
        );
        double expectedPercentageDiscount = 0;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        model.Validate();
    }
}

public class AmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string expectedAmountDiscount = "amount_discount";
        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Amount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Amount>(json);
        Assert.NotNull(deserialized);

        string expectedAmountDiscount = "amount_discount";
        JsonElement expectedDiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");

        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        model.Validate();
    }
}
