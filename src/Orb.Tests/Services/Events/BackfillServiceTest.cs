using System;
using System.Threading.Tasks;

namespace Orb.Tests.Services.Events;

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
            }
        );
        backfill.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Events.Backfills.List();
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
