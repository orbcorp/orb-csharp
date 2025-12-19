using Orb.Models.Beta.ExternalPlanID;

namespace Orb.Tests.Models.Beta.ExternalPlanID;

public class ExternalPlanIDSetDefaultPlanVersionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPlanIDSetDefaultPlanVersionParams
        {
            ExternalPlanID = "external_plan_id",
            Version = 0,
        };

        string expectedExternalPlanID = "external_plan_id";
        long expectedVersion = 0;

        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.Equal(expectedVersion, parameters.Version);
    }
}
