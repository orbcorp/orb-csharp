using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class TieredConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredConfig
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
            Prorated = true,
        };

        List<SharedTier> expectedTiers =
        [
            new()
            {
                FirstUnit = 0,
                UnitAmount = "unit_amount",
                LastUnit = 0,
            },
        ];
        bool expectedProrated = true;

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.Equal(expectedProrated, model.Prorated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredConfig
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
            Prorated = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredConfig
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
            Prorated = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredConfig>(element);
        Assert.NotNull(deserialized);

        List<SharedTier> expectedTiers =
        [
            new()
            {
                FirstUnit = 0,
                UnitAmount = "unit_amount",
                LastUnit = 0,
            },
        ];
        bool expectedProrated = true;

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
        Assert.Equal(expectedProrated, deserialized.Prorated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredConfig
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
            Prorated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TieredConfig
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

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TieredConfig
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

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TieredConfig
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

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TieredConfig
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

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        model.Validate();
    }
}
