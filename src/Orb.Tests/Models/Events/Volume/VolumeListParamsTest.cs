using System;
using Orb.Models.Events.Volume;

namespace Orb.Tests.Models.Events.Volume;

public class VolumeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VolumeListParams
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            Limit = 1,
            TimeframeEnd = DateTimeOffset.Parse("2024-10-11T06:00:00Z"),
        };

        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2024-10-11T06:00:00Z");

        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VolumeListParams
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TimeframeEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("timeframe_end"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VolumeListParams
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            TimeframeEnd = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TimeframeEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("timeframe_end"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VolumeListParams
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            TimeframeEnd = DateTimeOffset.Parse("2024-10-11T06:00:00Z"),
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VolumeListParams
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            TimeframeEnd = DateTimeOffset.Parse("2024-10-11T06:00:00Z"),

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        VolumeListParams parameters = new()
        {
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cursor = "cursor",
            Limit = 1,
            TimeframeEnd = DateTimeOffset.Parse("2024-10-11T06:00:00Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/events/volume?timeframe_start=2019-12-27T18%3a11%3a19.117%2b00%3a00&cursor=cursor&limit=1&timeframe_end=2024-10-11T06%3a00%3a00%2b00%3a00"
            ),
            url
        );
    }
}
