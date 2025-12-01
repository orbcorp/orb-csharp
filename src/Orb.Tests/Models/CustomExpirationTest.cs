using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class CustomExpirationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomExpiration
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };

        long expectedDuration = 0;
        ApiEnum<string, CustomExpirationDurationUnit> expectedDurationUnit =
            CustomExpirationDurationUnit.Day;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedDurationUnit, model.DurationUnit);
    }
}
