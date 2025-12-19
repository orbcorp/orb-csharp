using Orb.Models.Plans;

namespace Orb.Tests.Models.Plans;

public class PlanFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanFetchParams { PlanID = "plan_id" };

        string expectedPlanID = "plan_id";

        Assert.Equal(expectedPlanID, parameters.PlanID);
    }
}
