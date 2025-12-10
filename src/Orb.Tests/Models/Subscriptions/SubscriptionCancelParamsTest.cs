using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

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
