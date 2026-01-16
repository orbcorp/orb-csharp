using System;
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

    [Fact]
    public void Url_Works()
    {
        ExternalPlanIDFetchPlanVersionParams parameters = new()
        {
            ExternalPlanID = "external_plan_id",
            Version = "version",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/plans/external_plan_id/external_plan_id/versions/version"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalPlanIDFetchPlanVersionParams
        {
            ExternalPlanID = "external_plan_id",
            Version = "version",
        };

        ExternalPlanIDFetchPlanVersionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
