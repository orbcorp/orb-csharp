using System.Text.Json;
using Orb.Core;
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
