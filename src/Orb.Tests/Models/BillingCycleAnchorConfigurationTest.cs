using Orb.Models;

namespace Orb.Tests.Models;

public class BillingCycleAnchorConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingCycleAnchorConfiguration
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };

        long expectedDay = 1;
        long expectedMonth = 1;
        long expectedYear = 0;

        Assert.Equal(expectedDay, model.Day);
        Assert.Equal(expectedMonth, model.Month);
        Assert.Equal(expectedYear, model.Year);
    }
}
