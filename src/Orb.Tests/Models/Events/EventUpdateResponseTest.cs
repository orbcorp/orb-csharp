using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        string expectedAmended = "amended";

        Assert.Equal(expectedAmended, model.Amended);
    }
}
