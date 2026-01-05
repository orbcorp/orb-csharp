using System;
using System.Collections.Generic;
using Orb.Models.Metrics;

namespace Orb.Tests.Models.Metrics;

public class MetricCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetricCreateParams
        {
            Description = "Sum of bytes downloaded in fast mode",
            ItemID = "item_id",
            Name = "Bytes downloaded",
            Sql = "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string expectedDescription = "Sum of bytes downloaded in fast mode";
        string expectedItemID = "item_id";
        string expectedName = "Bytes downloaded";
        string expectedSql =
            "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedItemID, parameters.ItemID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSql, parameters.Sql);
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
        var parameters = new MetricCreateParams
        {
            Description = "Sum of bytes downloaded in fast mode",
            ItemID = "item_id",
            Name = "Bytes downloaded",
            Sql = "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MetricCreateParams
        {
            Description = "Sum of bytes downloaded in fast mode",
            ItemID = "item_id",
            Name = "Bytes downloaded",
            Sql = "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'",

            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        MetricCreateParams parameters = new()
        {
            Description = "Sum of bytes downloaded in fast mode",
            ItemID = "item_id",
            Name = "Bytes downloaded",
            Sql = "SELECT sum(bytes_downloaded) FROM events WHERE download_speed = 'fast'",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/metrics"), url);
    }
}
