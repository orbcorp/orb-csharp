using System;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponCreateParams
        {
            Discount = new Percentage(0),
            RedemptionCode = "HALFOFF",
            DurationInMonths = 12,
            MaxRedemptions = 1,
        };

        Discount expectedDiscount = new Percentage(0);
        string expectedRedemptionCode = "HALFOFF";
        long expectedDurationInMonths = 12;
        long expectedMaxRedemptions = 1;

        Assert.Equal(expectedDiscount, parameters.Discount);
        Assert.Equal(expectedRedemptionCode, parameters.RedemptionCode);
        Assert.Equal(expectedDurationInMonths, parameters.DurationInMonths);
        Assert.Equal(expectedMaxRedemptions, parameters.MaxRedemptions);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CouponCreateParams
        {
            Discount = new Percentage(0),
            RedemptionCode = "HALFOFF",
        };

        Assert.Null(parameters.DurationInMonths);
        Assert.False(parameters.RawBodyData.ContainsKey("duration_in_months"));
        Assert.Null(parameters.MaxRedemptions);
        Assert.False(parameters.RawBodyData.ContainsKey("max_redemptions"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CouponCreateParams
        {
            Discount = new Percentage(0),
            RedemptionCode = "HALFOFF",

            DurationInMonths = null,
            MaxRedemptions = null,
        };

        Assert.Null(parameters.DurationInMonths);
        Assert.True(parameters.RawBodyData.ContainsKey("duration_in_months"));
        Assert.Null(parameters.MaxRedemptions);
        Assert.True(parameters.RawBodyData.ContainsKey("max_redemptions"));
    }

    [Fact]
    public void Url_Works()
    {
        CouponCreateParams parameters = new()
        {
            Discount = new Percentage(0),
            RedemptionCode = "HALFOFF",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/coupons"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponCreateParams
        {
            Discount = new Percentage(0),
            RedemptionCode = "HALFOFF",
            DurationInMonths = 12,
            MaxRedemptions = 1,
        };

        CouponCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DiscountTest : TestBase
{
    [Fact]
    public void PercentageValidationWorks()
    {
        Discount value = new Percentage(0);
        value.Validate();
    }

    [Fact]
    public void AmountValidationWorks()
    {
        Discount value = new Amount("amount_discount");
        value.Validate();
    }

    [Fact]
    public void PercentageSerializationRoundtripWorks()
    {
        Discount value = new Percentage(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Discount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        Discount value = new Amount("amount_discount");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Discount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("percentage");
        double expectedPercentageDiscount = 0;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Percentage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Percentage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("percentage");
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Percentage { PercentageDiscount = 0 };

        Percentage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string expectedAmountDiscount = "amount_discount";
        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("amount");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Amount>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Amount>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAmountDiscount = "amount_discount";
        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("amount");

        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Amount { AmountDiscount = "amount_discount" };

        Amount copied = new(model);

        Assert.Equal(model, copied);
    }
}
