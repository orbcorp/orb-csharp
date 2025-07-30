using System;
using System.Threading.Tasks;

namespace Orb.Tests.Service.Metrics;

public class MetricServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var billableMetric = await this.client.Metrics.Create(
            new()
            {
                Description = "Sum of bytes downloaded in fast mode",
                ItemID = "item_id",
                Name = "Bytes downloaded",
                Sql = "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'",
                Metadata = new() { { "foo", "string" } },
            }
        );
        billableMetric.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var billableMetric = await this.client.Metrics.Update(
            new()
            {
                MetricID = "metric_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        billableMetric.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Metrics.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var billableMetric = await this.client.Metrics.Fetch(new() { MetricID = "metric_id" });
        billableMetric.Validate();
    }
}
