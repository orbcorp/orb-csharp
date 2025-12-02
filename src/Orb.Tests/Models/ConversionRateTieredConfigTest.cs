using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class ConversionRateTieredConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversionRateTieredConfig
        {
            Tiers =
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ],
        };

        List<ConversionRateTier> expectedTiers =
        [
            new()
            {
                FirstUnit = 0,
                UnitAmount = "unit_amount",
                LastUnit = 0,
            },
        ];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversionRateTieredConfig
        {
            Tiers =
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateTieredConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversionRateTieredConfig
        {
            Tiers =
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ConversionRateTieredConfig>(json);
        Assert.NotNull(deserialized);

        List<ConversionRateTier> expectedTiers =
        [
            new()
            {
                FirstUnit = 0,
                UnitAmount = "unit_amount",
                LastUnit = 0,
            },
        ];

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversionRateTieredConfig
        {
            Tiers =
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ],
        };

        model.Validate();
    }
}
