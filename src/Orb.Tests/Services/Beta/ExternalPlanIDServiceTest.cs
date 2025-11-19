using System.Threading.Tasks;

namespace Orb.Tests.Services.Beta;

public class ExternalPlanIDServiceTest : TestBase
{
    [Fact]
    public async Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.CreatePlanVersion(
            "external_plan_id",
            new() { Version = 0 }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.FetchPlanVersion(
            "version",
            new() { ExternalPlanID = "external_plan_id" }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.ExternalPlanID.SetDefaultPlanVersion(
            "external_plan_id",
            new() { Version = 0 }
        );
        plan.Validate();
    }
}
