using System;
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

    [Fact]
    public void Url_Works()
    {
        ExternalPlanIDSetDefaultPlanVersionParams parameters = new()
        {
            ExternalPlanID = "external_plan_id",
            Version = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/plans/external_plan_id/external_plan_id/set_default_version"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalPlanIDSetDefaultPlanVersionParams
        {
            ExternalPlanID = "external_plan_id",
            Version = 0,
        };

        ExternalPlanIDSetDefaultPlanVersionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
