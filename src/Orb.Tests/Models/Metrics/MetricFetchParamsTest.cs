using System;
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

    [Fact]
    public void Url_Works()
    {
        MetricFetchParams parameters = new() { MetricID = "metric_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/metrics/metric_id"), url);
    }
}
