using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewBillingCycleConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewBillingCycleConfiguration
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };

        long expectedDuration = 0;
        ApiEnum<string, NewBillingCycleConfigurationDurationUnit> expectedDurationUnit =
            NewBillingCycleConfigurationDurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }
}
