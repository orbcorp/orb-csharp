using System.Collections.Generic;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Tests.Models.Plans.ExternalPlanID;

public class ExternalPlanIDUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalPlanIDUpdateParams
        {
            OtherExternalPlanID = "external_plan_id",
            ExternalPlanID = "external_plan_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedOtherExternalPlanID = "external_plan_id";
        string expectedExternalPlanID = "external_plan_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedOtherExternalPlanID, parameters.OtherExternalPlanID);
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
        var parameters = new ExternalPlanIDUpdateParams
        {
            OtherExternalPlanID = "external_plan_id",
        };

        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExternalPlanIDUpdateParams
        {
            OtherExternalPlanID = "external_plan_id",

            ExternalPlanID = null,
            Metadata = null,
        };

        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }
}
