using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            SubscriptionID = "subscription_id",
            CancelOption = CancelOption.EndOfSubscriptionTerm,
            AllowInvoiceCreditOrVoid = true,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedSubscriptionID = "subscription_id";
        ApiEnum<string, CancelOption> expectedCancelOption = CancelOption.EndOfSubscriptionTerm;
        bool expectedAllowInvoiceCreditOrVoid = true;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCancelOption, parameters.CancelOption);
        Assert.Equal(expectedAllowInvoiceCreditOrVoid, parameters.AllowInvoiceCreditOrVoid);
        Assert.Equal(expectedCancellationDate, parameters.CancellationDate);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            SubscriptionID = "subscription_id",
            CancelOption = CancelOption.EndOfSubscriptionTerm,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.CancellationDate);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellation_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            SubscriptionID = "subscription_id",
            CancelOption = CancelOption.EndOfSubscriptionTerm,

            AllowInvoiceCreditOrVoid = null,
            CancellationDate = null,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.CancellationDate);
        Assert.True(parameters.RawBodyData.ContainsKey("cancellation_date"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCancelParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            CancelOption = CancelOption.EndOfSubscriptionTerm,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscriptions/subscription_id/cancel"),
            url
        );
    }
}

public class CancelOptionTest : TestBase
{
    [Theory]
    [InlineData(CancelOption.EndOfSubscriptionTerm)]
    [InlineData(CancelOption.Immediate)]
    [InlineData(CancelOption.RequestedDate)]
    public void Validation_Works(CancelOption rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelOption> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelOption>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancelOption.EndOfSubscriptionTerm)]
    [InlineData(CancelOption.Immediate)]
    [InlineData(CancelOption.RequestedDate)]
    public void SerializationRoundtrip_Works(CancelOption rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelOption> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelOption>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelOption>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelOption>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
