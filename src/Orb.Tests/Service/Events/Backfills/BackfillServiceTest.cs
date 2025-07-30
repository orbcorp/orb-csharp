using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Events.Backfills;

public class BackfillServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var backfill = await this.client.Events.Backfills.Create(
            new()
            {
                TimeframeEnd = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CloseTime = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                ExternalCustomerID = "external_customer_id",
                ReplaceExistingEvents = true,
            }
        );
        backfill.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Events.Backfills.List(new() { Cursor = "cursor", Limit = 1 });
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Close_Works()
    {
        var response = await this.client.Events.Backfills.Close(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var response = await this.client.Events.Backfills.Fetch(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Revert_Works()
    {
        var response = await this.client.Events.Backfills.Revert(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }
}
