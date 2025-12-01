using Orb.Models;

namespace Orb.Tests.Models;

public class SharedTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedTier
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
}
