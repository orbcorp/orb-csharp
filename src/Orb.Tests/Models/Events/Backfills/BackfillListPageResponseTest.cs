using System;
using System.Collections.Generic;
using System.Text.Json;
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
                    Status = BackfillListResponseStatus.Pending,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<BackfillListResponse> expectedData =
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
                Status = BackfillListResponseStatus.Pending,
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

    [Fact]
    public void SerializationRoundtrip_Works()
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
                    Status = BackfillListResponseStatus.Pending,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BackfillListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                    Status = BackfillListResponseStatus.Pending,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BackfillListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BackfillListResponse> expectedData =
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
                Status = BackfillListResponseStatus.Pending,
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

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
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
                    Status = BackfillListResponseStatus.Pending,
                    TimeframeEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TimeframeStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeprecationFilter = "my_numeric_property > 100 AND my_other_property = 'bar'",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
