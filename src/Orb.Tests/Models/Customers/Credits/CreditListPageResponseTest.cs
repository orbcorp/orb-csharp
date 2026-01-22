using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers.Credits;
using Models = Orb.Models;

namespace Orb.Tests.Models.Customers.Credits;

public class CreditListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListPageResponse
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
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<CreditListResponse> expectedData =
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
                        Field = Field.ItemID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                PerUnitCostBasis = "per_unit_cost_basis",
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListPageResponse
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
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListPageResponse
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
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CreditListResponse> expectedData =
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
                        Field = Field.ItemID,
                        Operator = Operator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = Status.Active,
            },
        ];
        Models::PaginationMetadata expectedPaginationMetadata = new()
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
        var model = new CreditListPageResponse
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
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListPageResponse
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
                            Field = Field.ItemID,
                            Operator = Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = Status.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        CreditListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
