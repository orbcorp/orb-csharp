using System;
using System.Collections.Generic;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventSearchParams
        {
            EventIds = ["string"],
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedEventIds = ["string"];
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEventIds.Count, parameters.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], parameters.EventIds[i]);
        }
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventSearchParams { EventIds = ["string"] };

        Assert.Null(parameters.TimeframeEnd);
        Assert.False(parameters.RawBodyData.ContainsKey("timeframe_end"));
        Assert.Null(parameters.TimeframeStart);
        Assert.False(parameters.RawBodyData.ContainsKey("timeframe_start"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EventSearchParams
        {
            EventIds = ["string"],

            TimeframeEnd = null,
            TimeframeStart = null,
        };

        Assert.Null(parameters.TimeframeEnd);
        Assert.True(parameters.RawBodyData.ContainsKey("timeframe_end"));
        Assert.Null(parameters.TimeframeStart);
        Assert.True(parameters.RawBodyData.ContainsKey("timeframe_start"));
    }

    [Fact]
    public void Url_Works()
    {
        EventSearchParams parameters = new() { EventIds = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/events/search"), url);
    }
}
