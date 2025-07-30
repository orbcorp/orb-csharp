using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.TopLevel;

public class TopLevelServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Ping_Works()
    {
        var response = await this.client.TopLevel.Ping(new() { });
        response.Validate();
    }
}
