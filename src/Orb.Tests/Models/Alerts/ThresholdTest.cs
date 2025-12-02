using System.Text.Json;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class ThresholdTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Threshold { Value = 0 };

        double expectedValue = 0;

        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Threshold { Value = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Threshold>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Threshold { Value = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Threshold>(json);
        Assert.NotNull(deserialized);

        double expectedValue = 0;

        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Threshold { Value = 0 };

        model.Validate();
    }
}
