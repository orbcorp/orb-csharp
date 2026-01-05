using System;
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

    [Fact]
    public void Url_Works()
    {
        ExternalPlanIDFetchParams parameters = new() { ExternalPlanID = "external_plan_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/plans/external_plan_id/external_plan_id"),
            url
        );
    }
}
