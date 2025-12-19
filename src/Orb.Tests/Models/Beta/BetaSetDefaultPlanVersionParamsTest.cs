using Orb.Models.Beta;

namespace Orb.Tests.Models.Beta;

public class BetaSetDefaultPlanVersionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BetaSetDefaultPlanVersionParams { PlanID = "plan_id", Version = 0 };

        string expectedPlanID = "plan_id";
        long expectedVersion = 0;

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedVersion, parameters.Version);
    }
}
