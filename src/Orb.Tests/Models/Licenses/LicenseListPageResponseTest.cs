using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalLicenseID = "external_license_id",
                    LicenseTypeID = "license_type_id",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = LicenseListResponseStatus.Active,
                    SubscriptionID = "subscription_id",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<LicenseListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalLicenseID = "external_license_id",
                LicenseTypeID = "license_type_id",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = LicenseListResponseStatus.Active,
                SubscriptionID = "subscription_id",
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
        var model = new LicenseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalLicenseID = "external_license_id",
                    LicenseTypeID = "license_type_id",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = LicenseListResponseStatus.Active,
                    SubscriptionID = "subscription_id",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalLicenseID = "external_license_id",
                    LicenseTypeID = "license_type_id",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = LicenseListResponseStatus.Active,
                    SubscriptionID = "subscription_id",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<LicenseListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalLicenseID = "external_license_id",
                LicenseTypeID = "license_type_id",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = LicenseListResponseStatus.Active,
                SubscriptionID = "subscription_id",
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
        var model = new LicenseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalLicenseID = "external_license_id",
                    LicenseTypeID = "license_type_id",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = LicenseListResponseStatus.Active,
                    SubscriptionID = "subscription_id",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalLicenseID = "external_license_id",
                    LicenseTypeID = "license_type_id",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = LicenseListResponseStatus.Active,
                    SubscriptionID = "subscription_id",
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        LicenseListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
