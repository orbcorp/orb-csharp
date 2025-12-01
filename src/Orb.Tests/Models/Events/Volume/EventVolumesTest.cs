using System;
using System.Collections.Generic;
using Orb.Models.Events.Volume;

namespace Orb.Tests.Models.Events.Volume;

public class EventVolumesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventVolumes
        {
            Data =
            [
                new()
                {
                    Count = 0,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Data> expectedData =
        [
            new()
            {
                Count = 0,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Count = 0,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        long expectedCount = 0;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedTimeframeEnd, model.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, model.TimeframeStart);
    }
}
