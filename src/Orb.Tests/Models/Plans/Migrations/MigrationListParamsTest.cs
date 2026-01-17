using System;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MigrationListParams
        {
            PlanID = "plan_id",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedPlanID = "plan_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MigrationListParams { PlanID = "plan_id", Cursor = "cursor" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MigrationListParams
        {
            PlanID = "plan_id",
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MigrationListParams { PlanID = "plan_id", Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MigrationListParams
        {
            PlanID = "plan_id",
            Limit = 1,

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        MigrationListParams parameters = new()
        {
            PlanID = "plan_id",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/plans/plan_id/migrations?cursor=cursor&limit=1"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MigrationListParams
        {
            PlanID = "plan_id",
            Cursor = "cursor",
            Limit = 1,
        };

        MigrationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
