using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.SubscriptionChanges;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionChangeListResponseStatus.Pending,
                    SubscriptionID = "subscription_id",
                    AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<SubscriptionChangeListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionChangeListResponseStatus.Pending,
                SubscriptionID = "subscription_id",
                AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionChangeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionChangeListResponseStatus.Pending,
                    SubscriptionID = "subscription_id",
                    AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionChangeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionChangeListResponseStatus.Pending,
                    SubscriptionID = "subscription_id",
                    AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<SubscriptionChangeListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionChangeListResponseStatus.Pending,
                SubscriptionID = "subscription_id",
                AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new SubscriptionChangeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionChangeListResponseStatus.Pending,
                    SubscriptionID = "subscription_id",
                    AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
