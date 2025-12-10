using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForSubscriptionParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void Validation_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void SerializationRoundtrip_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
