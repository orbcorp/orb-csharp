using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventDeprecateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        string expectedDeprecated = "deprecated";

        Assert.Equal(expectedDeprecated, model.Deprecated);
    }
}
