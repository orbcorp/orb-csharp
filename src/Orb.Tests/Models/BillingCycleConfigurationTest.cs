using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class BillingCycleConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingCycleConfiguration { Duration = 0, DurationUnit = DurationUnit.Day };

        long expectedDuration = 0;
        ApiEnum<string, DurationUnit> expectedDurationUnit = DurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingCycleConfiguration { Duration = 0, DurationUnit = DurationUnit.Day };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingCycleConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingCycleConfiguration { Duration = 0, DurationUnit = DurationUnit.Day };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillingCycleConfiguration>(json);
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        ApiEnum<string, DurationUnit> expectedDurationUnit = DurationUnit.Day;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedDurationUnit, deserialized.DurationUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingCycleConfiguration { Duration = 0, DurationUnit = DurationUnit.Day };

        model.Validate();
    }
}

public class DurationUnitTest : TestBase
{
    [Theory]
    [InlineData(DurationUnit.Day)]
    [InlineData(DurationUnit.Month)]
    public void Validation_Works(DurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DurationUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DurationUnit.Day)]
    [InlineData(DurationUnit.Month)]
    public void SerializationRoundtrip_Works(DurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DurationUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
