using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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

        List<Data> expectedData =
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListPageResponse>(json);

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<Data> expectedData =
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
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
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
        };

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.ItemID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, Status> expectedStatus = Status.Active;

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
        var model = new Data
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.ItemID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, Status> expectedStatus = Status.Active;

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
        var model = new Data
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
        };

        model.Validate();
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Field = Field.ItemID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Field> expectedField = Field.ItemID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new Filter
        {
            Field = Field.ItemID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            Field = Field.ItemID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Field> expectedField = Field.ItemID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new Filter
        {
            Field = Field.ItemID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.ItemID)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.ItemID)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.PendingPayment)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.PendingPayment)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
