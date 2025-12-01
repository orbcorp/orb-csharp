using System.Collections.Generic;
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
}
