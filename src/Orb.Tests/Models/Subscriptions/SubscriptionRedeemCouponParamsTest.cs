using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

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
