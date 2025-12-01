using System.Collections.Generic;
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
}
