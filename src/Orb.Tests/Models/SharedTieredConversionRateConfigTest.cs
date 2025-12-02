using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedTieredConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        ApiEnum<string, ConversionRateType> expectedConversionRateType = ConversionRateType.Tiered;
        ConversionRateTieredConfig expectedTieredConfig = new(
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ]
        );

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedTieredConfig, model.TieredConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ConversionRateType> expectedConversionRateType = ConversionRateType.Tiered;
        ConversionRateTieredConfig expectedTieredConfig = new(
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ]
        );

        Assert.Equal(expectedConversionRateType, deserialized.ConversionRateType);
        Assert.Equal(expectedTieredConfig, deserialized.TieredConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        model.Validate();
    }
}
