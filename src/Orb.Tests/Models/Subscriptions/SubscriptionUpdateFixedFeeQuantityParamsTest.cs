using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

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
