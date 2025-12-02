using System.Text.Json;
using Orb.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomExpiration>(json);
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
