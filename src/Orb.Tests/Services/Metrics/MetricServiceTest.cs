using System.Threading.Tasks;

namespace Orb.Tests.Services.Metrics;

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
            }
        );
        billableMetric.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var billableMetric = await this.client.Metrics.Update(new() { MetricID = "metric_id" });
        billableMetric.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Metrics.List();
        page.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var billableMetric = await this.client.Metrics.Fetch(new() { MetricID = "metric_id" });
        billableMetric.Validate();
    }
}
