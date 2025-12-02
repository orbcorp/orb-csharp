using System.Text.Json;
using Orb.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewBillingCycleConfiguration>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewBillingCycleConfiguration>(json);
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
