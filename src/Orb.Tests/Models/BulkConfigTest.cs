using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class BulkConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkConfig
        {
            Tiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }],
        };

        List<BulkTier> expectedTiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkConfig
        {
            Tiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkConfig
        {
            Tiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkConfig>(element);
        Assert.NotNull(deserialized);

        List<BulkTier> expectedTiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }];

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkConfig
        {
            Tiers = [new() { UnitAmount = "unit_amount", MaximumUnits = 0 }],
        };

        model.Validate();
    }
}
