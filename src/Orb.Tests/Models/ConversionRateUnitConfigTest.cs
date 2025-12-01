using Orb.Models;

namespace Orb.Tests.Models;

public class ConversionRateUnitConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversionRateUnitConfig { UnitAmount = "unit_amount" };

        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
