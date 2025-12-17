using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ItemListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalConnections =
                    [
                        new()
                        {
                            ExternalConnectionName =
                                ItemExternalConnectionExternalConnectionName.Stripe,
                            ExternalEntityID = "external_entity_id",
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Item> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ItemListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalConnections =
                    [
                        new()
                        {
                            ExternalConnectionName =
                                ItemExternalConnectionExternalConnectionName.Stripe,
                            ExternalEntityID = "external_entity_id",
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalConnections =
                    [
                        new()
                        {
                            ExternalConnectionName =
                                ItemExternalConnectionExternalConnectionName.Stripe,
                            ExternalEntityID = "external_entity_id",
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<Item> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ItemListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalConnections =
                    [
                        new()
                        {
                            ExternalConnectionName =
                                ItemExternalConnectionExternalConnectionName.Stripe,
                            ExternalEntityID = "external_entity_id",
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
