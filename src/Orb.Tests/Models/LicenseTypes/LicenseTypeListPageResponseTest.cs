using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.LicenseTypes;

namespace Orb.Tests.Models.LicenseTypes;

public class LicenseTypeListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseTypeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<LicenseTypeListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                GroupingKey = "grouping_key",
                Name = "name",
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
        var model = new LicenseTypeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseTypeListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseTypeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseTypeListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<LicenseTypeListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                GroupingKey = "grouping_key",
                Name = "name",
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
        var model = new LicenseTypeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseTypeListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    GroupingKey = "grouping_key",
                    Name = "name",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        LicenseTypeListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
