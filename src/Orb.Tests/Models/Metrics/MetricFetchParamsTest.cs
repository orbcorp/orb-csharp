using Orb.Models.Metrics;

namespace Orb.Tests.Models.Metrics;

public class MetricFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetricFetchParams { MetricID = "metric_id" };

        string expectedMetricID = "metric_id";

        Assert.Equal(expectedMetricID, parameters.MetricID);
    }
}
