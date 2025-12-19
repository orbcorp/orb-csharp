using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionFetchSchedulePageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionFetchSchedulePageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Plan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<SubscriptionFetchScheduleResponse> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Plan = new()
                {
                    ID = "m2t5akQeh2obwxeU",
                    ExternalPlanID = "m2t5akQeh2obwxeU",
                    Name = "Example plan",
                },
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionFetchSchedulePageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Plan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionFetchSchedulePageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionFetchSchedulePageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Plan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionFetchSchedulePageResponse>(
            element
        );
        Assert.NotNull(deserialized);

        List<SubscriptionFetchScheduleResponse> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Plan = new()
                {
                    ID = "m2t5akQeh2obwxeU",
                    ExternalPlanID = "m2t5akQeh2obwxeU",
                    Name = "Example plan",
                },
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionFetchSchedulePageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Plan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
