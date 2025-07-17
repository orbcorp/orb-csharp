using Metrics = Orb.Models.Metrics;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Metrics;

public class MetricServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var billableMetric = await this.client.Metrics.Create(
            new Metrics::MetricCreateParams()
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
    public async Tasks::Task Update_Works()
    {
        var billableMetric = await this.client.Metrics.Update(
            new Metrics::MetricUpdateParams()
            {
                MetricID = "metric_id",
                Metadata = new() { { "foo", "string" } },
            }
        );
        billableMetric.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Metrics.List(
            new Metrics::MetricListParams()
            {
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var billableMetric = await this.client.Metrics.Fetch(
            new Metrics::MetricFetchParams() { MetricID = "metric_id" }
        );
        billableMetric.Validate();
    }
}
