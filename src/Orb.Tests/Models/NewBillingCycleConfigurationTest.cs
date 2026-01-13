using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewBillingCycleConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewBillingCycleConfiguration
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };

        long expectedDuration = 0;
        ApiEnum<string, NewBillingCycleConfigurationDurationUnit> expectedDurationUnit =
            NewBillingCycleConfigurationDurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewBillingCycleConfiguration
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewBillingCycleConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewBillingCycleConfiguration
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewBillingCycleConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        ApiEnum<string, NewBillingCycleConfigurationDurationUnit> expectedDurationUnit =
            NewBillingCycleConfigurationDurationUnit.Day;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedDurationUnit, deserialized.DurationUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewBillingCycleConfiguration
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };

        model.Validate();
    }
}

public class NewBillingCycleConfigurationDurationUnitTest : TestBase
{
    [Theory]
    [InlineData(NewBillingCycleConfigurationDurationUnit.Day)]
    [InlineData(NewBillingCycleConfigurationDurationUnit.Month)]
    public void Validation_Works(NewBillingCycleConfigurationDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewBillingCycleConfigurationDurationUnit> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewBillingCycleConfigurationDurationUnit.Day)]
    [InlineData(NewBillingCycleConfigurationDurationUnit.Month)]
    public void SerializationRoundtrip_Works(NewBillingCycleConfigurationDurationUnit rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewBillingCycleConfigurationDurationUnit> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
