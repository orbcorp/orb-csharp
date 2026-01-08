using System;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MigrationCancelParams
        {
            PlanID = "plan_id",
            MigrationID = "migration_id",
        };

        string expectedPlanID = "plan_id";
        string expectedMigrationID = "migration_id";

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedMigrationID, parameters.MigrationID);
    }

    [Fact]
    public void Url_Works()
    {
        MigrationCancelParams parameters = new()
        {
            PlanID = "plan_id",
            MigrationID = "migration_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/plans/plan_id/migrations/migration_id/cancel"),
            url
        );
    }
}
