using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionRedeemCouponParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRedeemCouponParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption = ChangeOption.RequestedDate,
            AllowInvoiceCreditOrVoid = true,
            ChangeDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),
            CouponID = "coupon_id",
            CouponRedemptionCode = "coupon_redemption_code",
        };

        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, ChangeOption> expectedChangeOption = ChangeOption.RequestedDate;
        bool expectedAllowInvoiceCreditOrVoid = true;
        DateTimeOffset expectedChangeDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z");
        string expectedCouponID = "coupon_id";
        string expectedCouponRedemptionCode = "coupon_redemption_code";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedChangeOption, parameters.ChangeOption);
        Assert.Equal(expectedAllowInvoiceCreditOrVoid, parameters.AllowInvoiceCreditOrVoid);
        Assert.Equal(expectedChangeDate, parameters.ChangeDate);
        Assert.Equal(expectedCouponID, parameters.CouponID);
        Assert.Equal(expectedCouponRedemptionCode, parameters.CouponRedemptionCode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionRedeemCouponParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption = ChangeOption.RequestedDate,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.ChangeDate);
        Assert.False(parameters.RawBodyData.ContainsKey("change_date"));
        Assert.Null(parameters.CouponID);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_id"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionRedeemCouponParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption = ChangeOption.RequestedDate,

            AllowInvoiceCreditOrVoid = null,
            ChangeDate = null,
            CouponID = null,
            CouponRedemptionCode = null,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.ChangeDate);
        Assert.True(parameters.RawBodyData.ContainsKey("change_date"));
        Assert.Null(parameters.CouponID);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_id"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRedeemCouponParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            ChangeOption = ChangeOption.RequestedDate,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscriptions/subscription_id/redeem_coupon"),
            url
        );
    }
}

public class ChangeOptionTest : TestBase
{
    [Theory]
    [InlineData(ChangeOption.RequestedDate)]
    [InlineData(ChangeOption.EndOfSubscriptionTerm)]
    [InlineData(ChangeOption.Immediate)]
    public void Validation_Works(ChangeOption rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeOption> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeOption>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChangeOption.RequestedDate)]
    [InlineData(ChangeOption.EndOfSubscriptionTerm)]
    [InlineData(ChangeOption.Immediate)]
    public void SerializationRoundtrip_Works(ChangeOption rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeOption> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeOption>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeOption>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeOption>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
