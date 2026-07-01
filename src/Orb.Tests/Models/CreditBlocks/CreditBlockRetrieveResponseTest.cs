using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.CreditBlocks;
using Models = Orb.Models;

namespace Orb.Tests.Models.CreditBlocks;

public class CreditBlockRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = CreditAllocationFilterField.PriceID,
                        Operator = CreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, CreditBlockSource> expectedCreditBlockSource = CreditBlockSource.Allocation;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, Status> expectedStatus = Status.Active;
        CreditAllocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCreditBlockSource, model.CreditBlockSource);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, model.MaximumInitialBalance);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCreditAllocation, model.CreditAllocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = CreditAllocationFilterField.PriceID,
                        Operator = CreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBlockRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = CreditAllocationFilterField.PriceID,
                        Operator = CreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBlockRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, CreditBlockSource> expectedCreditBlockSource = CreditBlockSource.Allocation;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, Status> expectedStatus = Status.Active;
        CreditAllocation expectedCreditAllocation = new()
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCreditBlockSource, deserialized.CreditBlockSource);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, deserialized.MaximumInitialBalance);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCreditAllocation, deserialized.CreditAllocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = CreditAllocationFilterField.PriceID,
                        Operator = CreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
        };

        Assert.Null(model.CreditAllocation);
        Assert.False(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,

            CreditAllocation = null,
        };

        Assert.Null(model.CreditAllocation);
        Assert.True(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,

            CreditAllocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBlockRetrieveResponse
        {
            ID = "id",
            Balance = 0,
            CreditBlockSource = CreditBlockSource.Allocation,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = Status.Active,
            CreditAllocation = new()
            {
                AllowsRollover = true,
                Currency = "currency",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ItemID = "item_id",
                Filters =
                [
                    new()
                    {
                        Field = CreditAllocationFilterField.PriceID,
                        Operator = CreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        CreditBlockRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditBlockSourceTest : TestBase
{
    [Theory]
    [InlineData(CreditBlockSource.Allocation)]
    [InlineData(CreditBlockSource.TopUp)]
    [InlineData(CreditBlockSource.Manual)]
    public void Validation_Works(CreditBlockSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditBlockSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditBlockSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditBlockSource.Allocation)]
    [InlineData(CreditBlockSource.TopUp)]
    [InlineData(CreditBlockSource.Manual)]
    public void SerializationRoundtrip_Works(CreditBlockSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditBlockSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditBlockSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditBlockSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditBlockSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Field> expectedField = Field.PriceID;
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
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Field> expectedField = Field.PriceID;
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
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        Filter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
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
            JsonSerializer.SerializeToElement("invalid value"),
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

public class CreditAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        Models::CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = Models::CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<CreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = CreditAllocationFilterField.PriceID,
                Operator = CreditAllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, model.AllowsRollover);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedLicenseTypeID, model.LicenseTypeID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditAllocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditAllocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        Models::CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = Models::CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<CreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = CreditAllocationFilterField.PriceID,
                Operator = CreditAllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, deserialized.AllowsRollover);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedLicenseTypeID, deserialized.LicenseTypeID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",

            // Null should be interpreted as omitted for these properties
            Filters = null,
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",

            // Null should be interpreted as omitted for these properties
            Filters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        Assert.Null(model.LicenseTypeID);
        Assert.False(model.RawData.ContainsKey("license_type_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],

            LicenseTypeID = null,
        };

        Assert.Null(model.LicenseTypeID);
        Assert.True(model.RawData.ContainsKey("license_type_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],

            LicenseTypeID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            Filters =
            [
                new()
                {
                    Field = CreditAllocationFilterField.PriceID,
                    Operator = CreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        CreditAllocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditAllocationFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditAllocationFilter
        {
            Field = CreditAllocationFilterField.PriceID,
            Operator = CreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CreditAllocationFilterField> expectedField =
            CreditAllocationFilterField.PriceID;
        ApiEnum<string, CreditAllocationFilterOperator> expectedOperator =
            CreditAllocationFilterOperator.Includes;
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
        var model = new CreditAllocationFilter
        {
            Field = CreditAllocationFilterField.PriceID,
            Operator = CreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditAllocationFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditAllocationFilter
        {
            Field = CreditAllocationFilterField.PriceID,
            Operator = CreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditAllocationFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditAllocationFilterField> expectedField =
            CreditAllocationFilterField.PriceID;
        ApiEnum<string, CreditAllocationFilterOperator> expectedOperator =
            CreditAllocationFilterOperator.Includes;
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
        var model = new CreditAllocationFilter
        {
            Field = CreditAllocationFilterField.PriceID,
            Operator = CreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditAllocationFilter
        {
            Field = CreditAllocationFilterField.PriceID,
            Operator = CreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        CreditAllocationFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditAllocationFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(CreditAllocationFilterField.PriceID)]
    [InlineData(CreditAllocationFilterField.ItemID)]
    [InlineData(CreditAllocationFilterField.PriceType)]
    [InlineData(CreditAllocationFilterField.Currency)]
    [InlineData(CreditAllocationFilterField.PricingUnitID)]
    public void Validation_Works(CreditAllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAllocationFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditAllocationFilterField.PriceID)]
    [InlineData(CreditAllocationFilterField.ItemID)]
    [InlineData(CreditAllocationFilterField.PriceType)]
    [InlineData(CreditAllocationFilterField.Currency)]
    [InlineData(CreditAllocationFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(CreditAllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAllocationFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreditAllocationFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(CreditAllocationFilterOperator.Includes)]
    [InlineData(CreditAllocationFilterOperator.Excludes)]
    public void Validation_Works(CreditAllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAllocationFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditAllocationFilterOperator.Includes)]
    [InlineData(CreditAllocationFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(CreditAllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAllocationFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAllocationFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
