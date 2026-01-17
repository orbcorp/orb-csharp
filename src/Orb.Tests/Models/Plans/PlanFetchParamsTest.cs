using System;
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

    [Fact]
    public void Url_Works()
    {
        PlanFetchParams parameters = new() { PlanID = "plan_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/plans/plan_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanFetchParams { PlanID = "plan_id" };

        PlanFetchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
