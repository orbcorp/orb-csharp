using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
                            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                            Operator =
                                CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDPageResponseDataStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<CreditListByExternalIDPageResponseData> expectedData =
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
                        Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                        Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDPageResponseDataStatus.Active,
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
                            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                            Operator =
                                CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDPageResponseDataStatus.Active,
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
                            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                            Operator =
                                CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDPageResponseDataStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(element);
        Assert.NotNull(deserialized);

        List<CreditListByExternalIDPageResponseData> expectedData =
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
                        Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                        Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumInitialBalance = 0,
                PerUnitCostBasis = "per_unit_cost_basis",
                Status = CreditListByExternalIDPageResponseDataStatus.Active,
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
                            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                            Operator =
                                CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    MaximumInitialBalance = 0,
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Status = CreditListByExternalIDPageResponseDataStatus.Active,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}

public class CreditListByExternalIDPageResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDPageResponseData
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                    Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDPageResponseDataStatus.Active,
        };

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDPageResponseDataFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDPageResponseDataStatus> expectedStatus =
            CreditListByExternalIDPageResponseDataStatus.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, model.MaximumInitialBalance);
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListByExternalIDPageResponseData
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                    Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDPageResponseDataStatus.Active,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponseData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDPageResponseData
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                    Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDPageResponseDataStatus.Active,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponseData>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDPageResponseDataFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDPageResponseDataStatus> expectedStatus =
            CreditListByExternalIDPageResponseDataStatus.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, deserialized.MaximumInitialBalance);
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditListByExternalIDPageResponseData
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
                    Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDPageResponseDataStatus.Active,
        };

        model.Validate();
    }
}

public class CreditListByExternalIDPageResponseDataFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDPageResponseDataFilter
        {
            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
            Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField> expectedField =
            CreditListByExternalIDPageResponseDataFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator> expectedOperator =
            CreditListByExternalIDPageResponseDataFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListByExternalIDPageResponseDataFilter
        {
            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
            Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponseDataFilter>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDPageResponseDataFilter
        {
            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
            Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDPageResponseDataFilter>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField> expectedField =
            CreditListByExternalIDPageResponseDataFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator> expectedOperator =
            CreditListByExternalIDPageResponseDataFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditListByExternalIDPageResponseDataFilter
        {
            Field = CreditListByExternalIDPageResponseDataFilterField.ItemID,
            Operator = CreditListByExternalIDPageResponseDataFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class CreditListByExternalIDPageResponseDataFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataFilterField.ItemID)]
    public void Validation_Works(CreditListByExternalIDPageResponseDataFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataFilterField.ItemID)]
    public void SerializationRoundtrip_Works(
        CreditListByExternalIDPageResponseDataFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDPageResponseDataFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDPageResponseDataFilterOperator.Excludes)]
    public void Validation_Works(CreditListByExternalIDPageResponseDataFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDPageResponseDataFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        CreditListByExternalIDPageResponseDataFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDPageResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataStatus.Active)]
    [InlineData(CreditListByExternalIDPageResponseDataStatus.PendingPayment)]
    public void Validation_Works(CreditListByExternalIDPageResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDPageResponseDataStatus.Active)]
    [InlineData(CreditListByExternalIDPageResponseDataStatus.PendingPayment)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDPageResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDPageResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDPageResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
