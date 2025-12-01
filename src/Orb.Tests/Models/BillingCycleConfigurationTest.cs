using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class BillingCycleConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingCycleConfiguration { Duration = 0, DurationUnit = DurationUnit.Day };

        long expectedDuration = 0;
        ApiEnum<string, DurationUnit> expectedDurationUnit = DurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }
}
