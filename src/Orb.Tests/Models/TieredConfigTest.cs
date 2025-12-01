using System.Collections.Generic;
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
}
