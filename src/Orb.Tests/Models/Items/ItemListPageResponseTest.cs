using System;
using System.Collections.Generic;
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
                                ExternalConnectionModelExternalConnectionName.Stripe,
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
                            ExternalConnectionModelExternalConnectionName.Stripe,
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
}
