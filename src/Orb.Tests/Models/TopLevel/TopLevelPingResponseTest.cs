using Orb.Models.TopLevel;

namespace Orb.Tests.Models.TopLevel;

public class TopLevelPingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopLevelPingResponse { Response = "response" };

        string expectedResponse = "response";

        Assert.Equal(expectedResponse, model.Response);
    }
}
