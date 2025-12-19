using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Tests.Models.Plans.ExternalPlanID;

public class ExternalPlanIDFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPlanIDFetchParams { ExternalPlanID = "external_plan_id" };

        string expectedExternalPlanID = "external_plan_id";

        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
    }
}
