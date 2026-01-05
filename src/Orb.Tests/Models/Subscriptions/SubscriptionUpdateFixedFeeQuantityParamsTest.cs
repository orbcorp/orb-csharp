using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionUpdateFixedFeeQuantityParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionUpdateFixedFeeQuantityParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
            AllowInvoiceCreditOrVoid = true,
            ChangeOption = SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate,
            EffectiveDate = "2022-12-21",
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedPriceID = "price_id";
        double expectedQuantity = 0;
        bool expectedAllowInvoiceCreditOrVoid = true;
        ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption> expectedChangeOption =
            SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate;
        string expectedEffectiveDate = "2022-12-21";

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedPriceID, parameters.PriceID);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedAllowInvoiceCreditOrVoid, parameters.AllowInvoiceCreditOrVoid);
        Assert.Equal(expectedChangeOption, parameters.ChangeOption);
        Assert.Equal(expectedEffectiveDate, parameters.EffectiveDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateFixedFeeQuantityParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
            AllowInvoiceCreditOrVoid = true,
            EffectiveDate = "2022-12-21",
        };

        Assert.Null(parameters.ChangeOption);
        Assert.False(parameters.RawBodyData.ContainsKey("change_option"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateFixedFeeQuantityParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
            AllowInvoiceCreditOrVoid = true,
            EffectiveDate = "2022-12-21",

            // Null should be interpreted as omitted for these properties
            ChangeOption = null,
        };

        Assert.Null(parameters.ChangeOption);
        Assert.False(parameters.RawBodyData.ContainsKey("change_option"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionUpdateFixedFeeQuantityParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
            ChangeOption = SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.EffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("effective_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionUpdateFixedFeeQuantityParams
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
            ChangeOption = SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate,

            AllowInvoiceCreditOrVoid = null,
            EffectiveDate = null,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.EffectiveDate);
        Assert.True(parameters.RawBodyData.ContainsKey("effective_date"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionUpdateFixedFeeQuantityParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            PriceID = "price_id",
            Quantity = 0,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/update_fixed_fee_quantity"
            ),
            url
        );
    }
}

public class SubscriptionUpdateFixedFeeQuantityParamsChangeOptionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate)]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.UpcomingInvoice)]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.EffectiveDate)]
    public void Validation_Works(SubscriptionUpdateFixedFeeQuantityParamsChangeOption rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.Immediate)]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.UpcomingInvoice)]
    [InlineData(SubscriptionUpdateFixedFeeQuantityParamsChangeOption.EffectiveDate)]
    public void SerializationRoundtrip_Works(
        SubscriptionUpdateFixedFeeQuantityParamsChangeOption rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionUpdateFixedFeeQuantityParamsChangeOption>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
