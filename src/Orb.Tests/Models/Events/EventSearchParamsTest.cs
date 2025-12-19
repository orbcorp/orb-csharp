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
            EventIDs = ["string"],
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedEventIDs = ["string"];
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEventIDs.Count, parameters.EventIDs.Count);
        for (int i = 0; i < expectedEventIDs.Count; i++)
        {
            Assert.Equal(expectedEventIDs[i], parameters.EventIDs[i]);
        }
        Assert.Equal(expectedTimeframeEnd, parameters.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, parameters.TimeframeStart);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventSearchParams { EventIDs = ["string"] };

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
            EventIDs = ["string"],

            TimeframeEnd = null,
            TimeframeStart = null,
        };

        Assert.Null(parameters.TimeframeEnd);
        Assert.False(parameters.RawBodyData.ContainsKey("timeframe_end"));
        Assert.Null(parameters.TimeframeStart);
        Assert.False(parameters.RawBodyData.ContainsKey("timeframe_start"));
    }
}
