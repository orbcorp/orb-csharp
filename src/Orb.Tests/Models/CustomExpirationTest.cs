using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class CustomExpirationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomExpiration
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };

        long expectedDuration = 0;
        ApiEnum<string, CustomExpirationDurationUnit> expectedDurationUnit =
            CustomExpirationDurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomExpiration
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomExpiration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomExpiration
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomExpiration>(element);
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        ApiEnum<string, CustomExpirationDurationUnit> expectedDurationUnit =
            CustomExpirationDurationUnit.Day;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedDurationUnit, deserialized.DurationUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomExpiration
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };

        model.Validate();
    }
}

public class CustomExpirationDurationUnitTest : TestBase
{
    [Theory]
    [InlineData(CustomExpirationDurationUnit.Day)]
    [InlineData(CustomExpirationDurationUnit.Month)]
    public void Validation_Works(CustomExpirationDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomExpirationDurationUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomExpirationDurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomExpirationDurationUnit.Day)]
    [InlineData(CustomExpirationDurationUnit.Month)]
    public void SerializationRoundtrip_Works(CustomExpirationDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomExpirationDurationUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomExpirationDurationUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomExpirationDurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomExpirationDurationUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
