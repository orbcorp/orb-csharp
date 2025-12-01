using Orb.Models;

namespace Orb.Tests.Models;

public class UnitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitConfig { UnitAmount = "unit_amount", Prorated = true };

        string expectedUnitAmount = "unit_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }
}
