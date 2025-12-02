using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedUnitConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        ApiEnum<
            string,
            SharedUnitConversionRateConfigConversionRateType
        > expectedConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit;
        ConversionRateUnitConfig expectedUnitConfig = new("unit_amount");

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(json);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SharedUnitConversionRateConfigConversionRateType
        > expectedConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit;
        ConversionRateUnitConfig expectedUnitConfig = new("unit_amount");

        Assert.Equal(expectedConversionRateType, deserialized.ConversionRateType);
        Assert.Equal(expectedUnitConfig, deserialized.UnitConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        model.Validate();
    }
}
