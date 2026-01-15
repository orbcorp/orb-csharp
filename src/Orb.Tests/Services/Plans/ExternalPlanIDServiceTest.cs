using System.Threading.Tasks;

namespace Orb.Tests.Services.Plans;

public class ExternalPlanIDServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Update(
            "external_plan_id",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var plan = await this.client.Plans.ExternalPlanID.Fetch(
            "external_plan_id",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }
}
