using System;
using System.Collections.Generic;
using Orb.Models.Items;
using Orb.Models.Metrics;
using Models = Orb.Models;

namespace Orb.Tests.Models.Metrics;

public class MetricListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetricListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Item = new()
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
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<BillableMetric> expectedData =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Item = new()
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                Status = Status.Active,
            },
        ];
        Models::PaginationMetadata expectedPaginationMetadata = new()
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
