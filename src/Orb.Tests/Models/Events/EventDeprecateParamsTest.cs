using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventDeprecateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventDeprecateParams { EventID = "event_id" };

        string expectedEventID = "event_id";

        Assert.Equal(expectedEventID, parameters.EventID);
    }
}
