using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Customers.Credits;

namespace Orb.Tests.Models.Customers.Credits;

public class CreditListByExternalIDPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Balance = 0,
                    CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = CreditListByExternalIDResponseFilterField.ItemID,
                            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                    CreditAllocation = new()
                    {
                        AllowsRollover = true,
                        Currency = "currency",
                        CustomExpiration = new()
                        {
                            Duration = 0,
                            DurationUnit = CustomExpirationDurationUnit.Day,
                        },
                        ItemID = "item_id",
                        Filters =
                        [
                            new()
                            {
                                Field =
                                    CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                                Operator =
                                    CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<CreditListByExternalIDResponse> expectedData =
        [
            new()
            {
                ID = "id",
                Balance = 0,
                CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = CreditListByExternalIDResponseFilterField.ItemID,
                        Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDResponseStatus.Active,
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field =
                                CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                            Operator =
                                CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
        var model = new CreditListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Balance = 0,
                    CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = CreditListByExternalIDResponseFilterField.ItemID,
                            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                    CreditAllocation = new()
                    {
                        AllowsRollover = true,
                        Currency = "currency",
                        CustomExpiration = new()
                        {
                            Duration = 0,
                            DurationUnit = CustomExpirationDurationUnit.Day,
                        },
                        ItemID = "item_id",
                        Filters =
                        [
                            new()
                            {
                                Field =
                                    CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                                Operator =
                                    CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Balance = 0,
                    CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = CreditListByExternalIDResponseFilterField.ItemID,
                            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                    CreditAllocation = new()
                    {
                        AllowsRollover = true,
                        Currency = "currency",
                        CustomExpiration = new()
                        {
                            Duration = 0,
                            DurationUnit = CustomExpirationDurationUnit.Day,
                        },
                        ItemID = "item_id",
                        Filters =
                        [
                            new()
                            {
                                Field =
                                    CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                                Operator =
                                    CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CreditListByExternalIDResponse> expectedData =
        [
            new()
            {
                ID = "id",
                Balance = 0,
                CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = CreditListByExternalIDResponseFilterField.ItemID,
                        Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDResponseStatus.Active,
                CreditAllocation = new()
                {
                    AllowsRollover = true,
                    Currency = "currency",
                    CustomExpiration = new()
                    {
                        Duration = 0,
                        DurationUnit = CustomExpirationDurationUnit.Day,
                    },
                    ItemID = "item_id",
                    Filters =
                    [
                        new()
                        {
                            Field =
                                CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                            Operator =
                                CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    LicenseTypeID = "license_type_id",
                },
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
        var model = new CreditListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Balance = 0,
                    CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = CreditListByExternalIDResponseFilterField.ItemID,
                            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                    CreditAllocation = new()
                    {
                        AllowsRollover = true,
                        Currency = "currency",
                        CustomExpiration = new()
                        {
                            Duration = 0,
                            DurationUnit = CustomExpirationDurationUnit.Day,
                        },
                        ItemID = "item_id",
                        Filters =
                        [
                            new()
                            {
                                Field =
                                    CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                                Operator =
                                    CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Balance = 0,
                    CreditBlockSource = CreditListByExternalIDResponseCreditBlockSource.Allocation,
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = CreditListByExternalIDResponseFilterField.ItemID,
                            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                    CreditAllocation = new()
                    {
                        AllowsRollover = true,
                        Currency = "currency",
                        CustomExpiration = new()
                        {
                            Duration = 0,
                            DurationUnit = CustomExpirationDurationUnit.Day,
                        },
                        ItemID = "item_id",
                        Filters =
                        [
                            new()
                            {
                                Field =
                                    CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                                Operator =
                                    CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        LicenseTypeID = "license_type_id",
                    },
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        CreditListByExternalIDPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
