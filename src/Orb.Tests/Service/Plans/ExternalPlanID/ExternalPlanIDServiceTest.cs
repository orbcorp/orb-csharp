using ExternalPlanID = Orb.Models.Plans.ExternalPlanID;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Plans.ExternalPlanID;

public class ExternalPlanIDServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Update_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Update(
            new ExternalPlanID::ExternalPlanIDUpdateParams()
            {
                OtherExternalPlanID = "external_plan_id",
                ExternalPlanID = "external_plan_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        plan.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Fetch(
            new ExternalPlanID::ExternalPlanIDFetchParams() { ExternalPlanID = "external_plan_id" }
        );
        plan.Validate();
    }
}
