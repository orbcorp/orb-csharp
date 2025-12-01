using Orb.Models;

namespace Orb.Tests.Models;

public class SubscriptionMinifiedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionMinified { ID = "VDGsT23osdLb84KD" };

        string expectedID = "VDGsT23osdLb84KD";

        Assert.Equal(expectedID, model.ID);
    }
}
