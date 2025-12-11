using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class BetaServiceTest : TestBase
{
    [Fact]
    public async Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.CreatePlanVersion(
            "plan_id",
            new() { Version = 0 },
            TestContext.Current.CancellationToken
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.FetchPlanVersion(
            "version",
            new() { PlanID = "plan_id" },
            TestContext.Current.CancellationToken
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.SetDefaultPlanVersion(
            "plan_id",
            new() { Version = 0 },
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }
}
