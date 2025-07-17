using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TopLevel = Orb.Models.TopLevel;

namespace Orb.Tests.Service.TopLevel;

public class TopLevelServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Ping_Works()
    {
        var response = await this.client.TopLevel.Ping(new TopLevel::TopLevelPingParams() { });
        response.Validate();
    }
}
