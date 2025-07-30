using System.Threading.Tasks;

namespace Orb.Tests.Service.Plans.ExternalPlanID;

public class ExternalPlanIDServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Update(
            new()
            {
                OtherExternalPlanID = "external_plan_id",
                ExternalPlanID = "external_plan_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        plan.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Fetch(
            new() { ExternalPlanID = "external_plan_id" }
        );
        plan.Validate();
    }
}
