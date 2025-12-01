using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class ThresholdTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Threshold { Value = 0 };

        double expectedValue = 0;

        Assert.Equal(expectedValue, model.Value);
    }
}
