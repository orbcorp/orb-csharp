using System.Threading.Tasks;

namespace Orb.Tests.Services.Plans;

public class MigrationServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var migration = await this.client.Plans.Migrations.Retrieve(
            "migration_id",
            new() { PlanID = "plan_id" },
            TestContext.Current.CancellationToken
        );
        migration.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Plans.Migrations.List(
            "plan_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var response = await this.client.Plans.Migrations.Cancel(
            "migration_id",
            new() { PlanID = "plan_id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
