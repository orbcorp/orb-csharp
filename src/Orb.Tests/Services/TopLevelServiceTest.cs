using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class TopLevelServiceTest : TestBase
{
    [Fact]
    public async Task Ping_Works()
    {
        var response = await this.client.TopLevel.Ping(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
