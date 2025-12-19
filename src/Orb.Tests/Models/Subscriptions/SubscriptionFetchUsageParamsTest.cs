using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class GranularityTest : TestBase
{
    [Theory]
    [InlineData(Granularity.Day)]
    public void Validation_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Granularity.Day)]
    public void SerializationRoundtrip_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionFetchUsageParamsViewModeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Periodic)]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Cumulative)]
    public void Validation_Works(SubscriptionFetchUsageParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionFetchUsageParamsViewMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Periodic)]
    [InlineData(SubscriptionFetchUsageParamsViewMode.Cumulative)]
    public void SerializationRoundtrip_Works(SubscriptionFetchUsageParamsViewMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionFetchUsageParamsViewMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionFetchUsageParamsViewMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
