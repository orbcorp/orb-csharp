using Orb.Models;

namespace Orb.Tests.Models;

public class SubscriptionChangeMinifiedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangeMinified { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }
}
