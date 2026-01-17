using System;
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

    [Fact]
    public void Url_Works()
    {
        BetaSetDefaultPlanVersionParams parameters = new() { PlanID = "plan_id", Version = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/plans/plan_id/set_default_version"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BetaSetDefaultPlanVersionParams { PlanID = "plan_id", Version = 0 };

        BetaSetDefaultPlanVersionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
