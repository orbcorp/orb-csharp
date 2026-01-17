using System;
using System.Collections.Generic;
using Orb.Models.Metrics;

namespace Orb.Tests.Models.Metrics;

public class MetricUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetricUpdateParams
        {
            MetricID = "metric_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedMetricID = "metric_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedMetricID, parameters.MetricID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MetricUpdateParams { MetricID = "metric_id" };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MetricUpdateParams
        {
            MetricID = "metric_id",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        MetricUpdateParams parameters = new() { MetricID = "metric_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/metrics/metric_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MetricUpdateParams
        {
            MetricID = "metric_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        MetricUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
