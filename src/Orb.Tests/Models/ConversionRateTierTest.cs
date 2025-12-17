using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class ConversionRateTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",
            LastUnit = 0,
        };

        double expectedFirstUnit = 0;
        string expectedUnitAmount = "unit_amount";
        double expectedLastUnit = 0;

        Assert.Equal(expectedFirstUnit, model.FirstUnit);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedLastUnit, model.LastUnit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",
            LastUnit = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",
            LastUnit = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateTier>(element);
        Assert.NotNull(deserialized);

        double expectedFirstUnit = 0;
        string expectedUnitAmount = "unit_amount";
        double expectedLastUnit = 0;

        Assert.Equal(expectedFirstUnit, deserialized.FirstUnit);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedLastUnit, deserialized.LastUnit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",
            LastUnit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversionRateTier { FirstUnit = 0, UnitAmount = "unit_amount" };

        Assert.Null(model.LastUnit);
        Assert.False(model.RawData.ContainsKey("last_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversionRateTier { FirstUnit = 0, UnitAmount = "unit_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",

            LastUnit = null,
        };

        Assert.Null(model.LastUnit);
        Assert.True(model.RawData.ContainsKey("last_unit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversionRateTier
        {
            FirstUnit = 0,
            UnitAmount = "unit_amount",

            LastUnit = null,
        };

        model.Validate();
    }
}
