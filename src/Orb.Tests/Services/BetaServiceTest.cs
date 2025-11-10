using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class BetaServiceTest : TestBase
{
    [Fact]
    public async Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.CreatePlanVersion(
            new() { PlanID = "plan_id", Version = 0 }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.FetchPlanVersion(
            new() { PlanID = "plan_id", Version = "version" }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.SetDefaultPlanVersion(
            new() { PlanID = "plan_id", Version = 0 }
        );
        plan.Validate();
    }
}
