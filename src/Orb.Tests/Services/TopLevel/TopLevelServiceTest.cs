using System.Threading.Tasks;

namespace Orb.Tests.Services.TopLevel;

public class TopLevelServiceTest : TestBase
{
    [Fact]
    public async Task Ping_Works()
    {
        var response = await this.client.TopLevel.Ping(new() { });
        response.Validate();
    }
}
