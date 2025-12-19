using Orb.Models.Beta.ExternalPlanID;

namespace Orb.Tests.Models.Beta.ExternalPlanID;

public class ExternalPlanIDFetchPlanVersionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPlanIDFetchPlanVersionParams
        {
            ExternalPlanID = "external_plan_id",
            Version = "version",
        };

        string expectedExternalPlanID = "external_plan_id";
        string expectedVersion = "version";

        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.Equal(expectedVersion, parameters.Version);
    }
}
