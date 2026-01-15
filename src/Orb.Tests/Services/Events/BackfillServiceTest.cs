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
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            TestContext.Current.CancellationToken
        );
        backfill.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Events.Backfills.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Close_Works()
    {
        var response = await this.client.Events.Backfills.Close(
            "backfill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var response = await this.client.Events.Backfills.Fetch(
            "backfill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Revert_Works()
    {
        var response = await this.client.Events.Backfills.Revert(
            "backfill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
