using System;
using System.Collections.Generic;
using System.Text.Json;
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
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
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
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDResponseStatus.Active,
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
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(json);

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
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(element);
        Assert.NotNull(deserialized);

        List<CreditListByExternalIDResponse> expectedData =
        [
            new()
            {
                ID = "id",
                Balance = 0,
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
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDResponseStatus.Active,
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
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDResponseStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
