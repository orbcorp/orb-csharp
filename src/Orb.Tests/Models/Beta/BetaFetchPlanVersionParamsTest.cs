using System;
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

    [Fact]
    public void Url_Works()
    {
        BetaFetchPlanVersionParams parameters = new() { PlanID = "plan_id", Version = "version" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/plans/plan_id/versions/version"), url);
    }
}
