using Orb.Models;

namespace Orb.Tests.Models;

public class BulkTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkTier { UnitAmount = "unit_amount", MaximumUnits = 0 };

        string expectedUnitAmount = "unit_amount";
        double expectedMaximumUnits = 0;

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedMaximumUnits, model.MaximumUnits);
    }
}
