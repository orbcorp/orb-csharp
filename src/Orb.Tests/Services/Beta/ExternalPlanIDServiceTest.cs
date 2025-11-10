using System.Threading.Tasks;

namespace Orb.Tests.Services.Beta;

public class ExternalPlanIDServiceTest : TestBase
{
    [Fact]
    public async Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.CreatePlanVersion(
            new() { ExternalPlanID = "external_plan_id", Version = 0 }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.FetchPlanVersion(
            new() { ExternalPlanID = "external_plan_id", Version = "version" }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.ExternalPlanID.SetDefaultPlanVersion(
            new() { ExternalPlanID = "external_plan_id", Version = 0 }
        );
        plan.Validate();
    }
}
