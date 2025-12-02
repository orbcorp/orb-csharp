using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class ConversionRateUnitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversionRateUnitConfig { UnitAmount = "unit_amount" };

        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversionRateUnitConfig { UnitAmount = "unit_amount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateUnitConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversionRateUnitConfig { UnitAmount = "unit_amount" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateUnitConfig>(json);
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversionRateUnitConfig { UnitAmount = "unit_amount" };

        model.Validate();
    }
}
