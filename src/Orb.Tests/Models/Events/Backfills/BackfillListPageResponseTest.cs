using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;
using Orb.Models.Events.Backfills;

namespace Orb.Tests.Models.Events.Backfills;

public class BackfillListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BackfillListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customer_id",
                    EventsIngested = 0,
                    ReplaceExistingEvents = true,
                    RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = DataStatus.Pending,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "id",
                CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customer_id",
                EventsIngested = 0,
                ReplaceExistingEvents = true,
                RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = DataStatus.Pending,
                TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            CloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customer_id",
            EventsIngested = 0,
            ReplaceExistingEvents = true,
            RevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = DataStatus.Pending,
            TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
        };

        string expectedID = "id";
        DateTimeOffset expectedCloseTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customer_id";
        long expectedEventsIngested = 0;
        bool expectedReplaceExistingEvents = true;
        DateTimeOffset expectedRevertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DataStatus> expectedStatus = DataStatus.Pending;
        DateTimeOffset expectedTimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedTimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeprecationFilter =
            "my_numeric_property > 100 AND my_other_property = 'bar'";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCloseTime, model.CloseTime);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventsIngested, model.EventsIngested);
        Assert.Equal(expectedReplaceExistingEvents, model.ReplaceExistingEvents);
        Assert.Equal(expectedRevertedAt, model.RevertedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimeframeEnd, model.TimeframeEnd);
        Assert.Equal(expectedTimeframeStart, model.TimeframeStart);
        Assert.Equal(expectedDeprecationFilter, model.DeprecationFilter);
    }
}
