using System;
using System.Collections.Generic;
using Orb.Models.Plans;

namespace Orb.Tests.Models.Plans;

public class PlanUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanUpdateParams
        {
            PlanID = "plan_id",
            Description = "description",
            ExternalPlanID = "external_plan_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedPlanID = "plan_id";
        string expectedDescription = "description";
        string expectedExternalPlanID = "external_plan_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams { PlanID = "plan_id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PlanUpdateParams
        {
            PlanID = "plan_id",

            Description = null,
            ExternalPlanID = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        PlanUpdateParams parameters = new() { PlanID = "plan_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.withorb.com/v1/plans/plan_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanUpdateParams
        {
            PlanID = "plan_id",
            Description = "description",
            ExternalPlanID = "external_plan_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        PlanUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
