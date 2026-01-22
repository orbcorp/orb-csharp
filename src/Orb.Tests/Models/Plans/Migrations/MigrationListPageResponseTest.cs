using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MigrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EffectiveTime = "2019-12-27",
                    PlanID = "plan_id",
                    Status = MigrationListResponseStatus.NotStarted,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<MigrationListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                EffectiveTime = "2019-12-27",
                PlanID = "plan_id",
                Status = MigrationListResponseStatus.NotStarted,
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
        var model = new MigrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EffectiveTime = "2019-12-27",
                    PlanID = "plan_id",
                    Status = MigrationListResponseStatus.NotStarted,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MigrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EffectiveTime = "2019-12-27",
                    PlanID = "plan_id",
                    Status = MigrationListResponseStatus.NotStarted,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MigrationListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                EffectiveTime = "2019-12-27",
                PlanID = "plan_id",
                Status = MigrationListResponseStatus.NotStarted,
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
        var model = new MigrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EffectiveTime = "2019-12-27",
                    PlanID = "plan_id",
                    Status = MigrationListResponseStatus.NotStarted,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MigrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EffectiveTime = "2019-12-27",
                    PlanID = "plan_id",
                    Status = MigrationListResponseStatus.NotStarted,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        MigrationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
