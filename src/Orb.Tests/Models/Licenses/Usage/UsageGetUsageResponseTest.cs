using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Licenses.Usage;

namespace Orb.Tests.Models.Licenses.Usage;

public class UsageGetUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageGetUsageResponse
        {
            Data =
            [
                new()
                {
                    AllocatedCredits = 0,
                    ConsumedCredits = 0,
                    EndDate = "2019-12-27",
                    LicenseTypeID = "license_type_id",
                    PricingUnit = "pricing_unit",
                    RemainingCredits = 0,
                    StartDate = "2019-12-27",
                    SubscriptionID = "subscription_id",
                    AllocationEligibleCredits = 0,
                    ExternalLicenseID = "external_license_id",
                    LicenseID = "license_id",
                    SharedPoolCredits = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<UsageGetUsageResponseData> expectedData =
        [
            new()
            {
                AllocatedCredits = 0,
                ConsumedCredits = 0,
                EndDate = "2019-12-27",
                LicenseTypeID = "license_type_id",
                PricingUnit = "pricing_unit",
                RemainingCredits = 0,
                StartDate = "2019-12-27",
                SubscriptionID = "subscription_id",
                AllocationEligibleCredits = 0,
                ExternalLicenseID = "external_license_id",
                LicenseID = "license_id",
                SharedPoolCredits = 0,
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
        var model = new UsageGetUsageResponse
        {
            Data =
            [
                new()
                {
                    AllocatedCredits = 0,
                    ConsumedCredits = 0,
                    EndDate = "2019-12-27",
                    LicenseTypeID = "license_type_id",
                    PricingUnit = "pricing_unit",
                    RemainingCredits = 0,
                    StartDate = "2019-12-27",
                    SubscriptionID = "subscription_id",
                    AllocationEligibleCredits = 0,
                    ExternalLicenseID = "external_license_id",
                    LicenseID = "license_id",
                    SharedPoolCredits = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageGetUsageResponse
        {
            Data =
            [
                new()
                {
                    AllocatedCredits = 0,
                    ConsumedCredits = 0,
                    EndDate = "2019-12-27",
                    LicenseTypeID = "license_type_id",
                    PricingUnit = "pricing_unit",
                    RemainingCredits = 0,
                    StartDate = "2019-12-27",
                    SubscriptionID = "subscription_id",
                    AllocationEligibleCredits = 0,
                    ExternalLicenseID = "external_license_id",
                    LicenseID = "license_id",
                    SharedPoolCredits = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UsageGetUsageResponseData> expectedData =
        [
            new()
            {
                AllocatedCredits = 0,
                ConsumedCredits = 0,
                EndDate = "2019-12-27",
                LicenseTypeID = "license_type_id",
                PricingUnit = "pricing_unit",
                RemainingCredits = 0,
                StartDate = "2019-12-27",
                SubscriptionID = "subscription_id",
                AllocationEligibleCredits = 0,
                ExternalLicenseID = "external_license_id",
                LicenseID = "license_id",
                SharedPoolCredits = 0,
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
        var model = new UsageGetUsageResponse
        {
            Data =
            [
                new()
                {
                    AllocatedCredits = 0,
                    ConsumedCredits = 0,
                    EndDate = "2019-12-27",
                    LicenseTypeID = "license_type_id",
                    PricingUnit = "pricing_unit",
                    RemainingCredits = 0,
                    StartDate = "2019-12-27",
                    SubscriptionID = "subscription_id",
                    AllocationEligibleCredits = 0,
                    ExternalLicenseID = "external_license_id",
                    LicenseID = "license_id",
                    SharedPoolCredits = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageGetUsageResponse
        {
            Data =
            [
                new()
                {
                    AllocatedCredits = 0,
                    ConsumedCredits = 0,
                    EndDate = "2019-12-27",
                    LicenseTypeID = "license_type_id",
                    PricingUnit = "pricing_unit",
                    RemainingCredits = 0,
                    StartDate = "2019-12-27",
                    SubscriptionID = "subscription_id",
                    AllocationEligibleCredits = 0,
                    ExternalLicenseID = "external_license_id",
                    LicenseID = "license_id",
                    SharedPoolCredits = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        UsageGetUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageGetUsageResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
            AllocationEligibleCredits = 0,
            ExternalLicenseID = "external_license_id",
            LicenseID = "license_id",
            SharedPoolCredits = 0,
        };

        double expectedAllocatedCredits = 0;
        double expectedConsumedCredits = 0;
        string expectedEndDate = "2019-12-27";
        string expectedLicenseTypeID = "license_type_id";
        string expectedPricingUnit = "pricing_unit";
        double expectedRemainingCredits = 0;
        string expectedStartDate = "2019-12-27";
        string expectedSubscriptionID = "subscription_id";
        double expectedAllocationEligibleCredits = 0;
        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseID = "license_id";
        double expectedSharedPoolCredits = 0;

        Assert.Equal(expectedAllocatedCredits, model.AllocatedCredits);
        Assert.Equal(expectedConsumedCredits, model.ConsumedCredits);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedLicenseTypeID, model.LicenseTypeID);
        Assert.Equal(expectedPricingUnit, model.PricingUnit);
        Assert.Equal(expectedRemainingCredits, model.RemainingCredits);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedAllocationEligibleCredits, model.AllocationEligibleCredits);
        Assert.Equal(expectedExternalLicenseID, model.ExternalLicenseID);
        Assert.Equal(expectedLicenseID, model.LicenseID);
        Assert.Equal(expectedSharedPoolCredits, model.SharedPoolCredits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
            AllocationEligibleCredits = 0,
            ExternalLicenseID = "external_license_id",
            LicenseID = "license_id",
            SharedPoolCredits = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetUsageResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
            AllocationEligibleCredits = 0,
            ExternalLicenseID = "external_license_id",
            LicenseID = "license_id",
            SharedPoolCredits = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageGetUsageResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAllocatedCredits = 0;
        double expectedConsumedCredits = 0;
        string expectedEndDate = "2019-12-27";
        string expectedLicenseTypeID = "license_type_id";
        string expectedPricingUnit = "pricing_unit";
        double expectedRemainingCredits = 0;
        string expectedStartDate = "2019-12-27";
        string expectedSubscriptionID = "subscription_id";
        double expectedAllocationEligibleCredits = 0;
        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseID = "license_id";
        double expectedSharedPoolCredits = 0;

        Assert.Equal(expectedAllocatedCredits, deserialized.AllocatedCredits);
        Assert.Equal(expectedConsumedCredits, deserialized.ConsumedCredits);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedLicenseTypeID, deserialized.LicenseTypeID);
        Assert.Equal(expectedPricingUnit, deserialized.PricingUnit);
        Assert.Equal(expectedRemainingCredits, deserialized.RemainingCredits);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedAllocationEligibleCredits, deserialized.AllocationEligibleCredits);
        Assert.Equal(expectedExternalLicenseID, deserialized.ExternalLicenseID);
        Assert.Equal(expectedLicenseID, deserialized.LicenseID);
        Assert.Equal(expectedSharedPoolCredits, deserialized.SharedPoolCredits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
            AllocationEligibleCredits = 0,
            ExternalLicenseID = "external_license_id",
            LicenseID = "license_id",
            SharedPoolCredits = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
        };

        Assert.Null(model.AllocationEligibleCredits);
        Assert.False(model.RawData.ContainsKey("allocation_eligible_credits"));
        Assert.Null(model.ExternalLicenseID);
        Assert.False(model.RawData.ContainsKey("external_license_id"));
        Assert.Null(model.LicenseID);
        Assert.False(model.RawData.ContainsKey("license_id"));
        Assert.Null(model.SharedPoolCredits);
        Assert.False(model.RawData.ContainsKey("shared_pool_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",

            AllocationEligibleCredits = null,
            ExternalLicenseID = null,
            LicenseID = null,
            SharedPoolCredits = null,
        };

        Assert.Null(model.AllocationEligibleCredits);
        Assert.True(model.RawData.ContainsKey("allocation_eligible_credits"));
        Assert.Null(model.ExternalLicenseID);
        Assert.True(model.RawData.ContainsKey("external_license_id"));
        Assert.Null(model.LicenseID);
        Assert.True(model.RawData.ContainsKey("license_id"));
        Assert.Null(model.SharedPoolCredits);
        Assert.True(model.RawData.ContainsKey("shared_pool_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",

            AllocationEligibleCredits = null,
            ExternalLicenseID = null,
            LicenseID = null,
            SharedPoolCredits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageGetUsageResponseData
        {
            AllocatedCredits = 0,
            ConsumedCredits = 0,
            EndDate = "2019-12-27",
            LicenseTypeID = "license_type_id",
            PricingUnit = "pricing_unit",
            RemainingCredits = 0,
            StartDate = "2019-12-27",
            SubscriptionID = "subscription_id",
            AllocationEligibleCredits = 0,
            ExternalLicenseID = "external_license_id",
            LicenseID = "license_id",
            SharedPoolCredits = 0,
        };

        UsageGetUsageResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
