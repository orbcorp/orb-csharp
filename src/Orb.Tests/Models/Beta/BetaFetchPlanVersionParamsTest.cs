using Orb.Models.Beta;

namespace Orb.Tests.Models.Beta;

public class BetaFetchPlanVersionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BetaFetchPlanVersionParams { PlanID = "plan_id", Version = "version" };

        string expectedPlanID = "plan_id";
        string expectedVersion = "version";

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedVersion, parameters.Version);
    }
}
