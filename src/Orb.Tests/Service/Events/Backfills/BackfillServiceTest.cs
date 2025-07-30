using System;
using System.Threading.Tasks;

namespace Orb.Tests.Service.Events.Backfills;

public class BackfillServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var backfill = await this.client.Events.Backfills.Create(
            new()
            {
                TimeframeEnd = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CloseTime = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                ExternalCustomerID = "external_customer_id",
                ReplaceExistingEvents = true,
            }
        );
        backfill.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Events.Backfills.List(new() { Cursor = "cursor", Limit = 1 });
        page.Validate();
    }

    [Fact]
    public async Task Close_Works()
    {
        var response = await this.client.Events.Backfills.Close(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var response = await this.client.Events.Backfills.Fetch(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }

    [Fact]
    public async Task Revert_Works()
    {
        var response = await this.client.Events.Backfills.Revert(
            new() { BackfillID = "backfill_id" }
        );
        response.Validate();
    }
}
