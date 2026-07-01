using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers.Credits;

namespace Orb.Tests.Models.Customers.Credits;

public class CreditListByExternalIDResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponse
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
                        Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                        Operator =
                            CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource> expectedCreditBlockSource =
            CreditListByExternalIDResponseCreditBlockSource.Allocation;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDResponseFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseFilterField.ItemID,
                Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDResponseStatus> expectedStatus =
            CreditListByExternalIDResponseStatus.Active;
        CreditListByExternalIDResponseCreditAllocation expectedCreditAllocation = new()
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponse
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
                        Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                        Operator =
                            CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponse
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
                        Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                        Operator =
                            CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource> expectedCreditBlockSource =
            CreditListByExternalIDResponseCreditBlockSource.Allocation;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDResponseFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseFilterField.ItemID,
                Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDResponseStatus> expectedStatus =
            CreditListByExternalIDResponseStatus.Active;
        CreditListByExternalIDResponseCreditAllocation expectedCreditAllocation = new()
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponse
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
                        Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                        Operator =
                            CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponse
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
        };

        Assert.Null(model.CreditAllocation);
        Assert.False(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditListByExternalIDResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditListByExternalIDResponse
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

            CreditAllocation = null,
        };

        Assert.Null(model.CreditAllocation);
        Assert.True(model.RawData.ContainsKey("credit_allocation"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditListByExternalIDResponse
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

            CreditAllocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListByExternalIDResponse
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
                        Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                        Operator =
                            CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                LicenseTypeID = "license_type_id",
            },
        };

        CreditListByExternalIDResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditListByExternalIDResponseCreditBlockSourceTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.Allocation)]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.TopUp)]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.Manual)]
    public void Validation_Works(CreditListByExternalIDResponseCreditBlockSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.Allocation)]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.TopUp)]
    [InlineData(CreditListByExternalIDResponseCreditBlockSource.Manual)]
    public void SerializationRoundtrip_Works(
        CreditListByExternalIDResponseCreditBlockSource rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CreditListByExternalIDResponseFilterField> expectedField =
            CreditListByExternalIDResponseFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> expectedOperator =
            CreditListByExternalIDResponseFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponseFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponseFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditListByExternalIDResponseFilterField> expectedField =
            CreditListByExternalIDResponseFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> expectedOperator =
            CreditListByExternalIDResponseFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        CreditListByExternalIDResponseFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditListByExternalIDResponseFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterField.ItemID)]
    public void Validation_Works(CreditListByExternalIDResponseFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterField.ItemID)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Excludes)]
    public void Validation_Works(CreditListByExternalIDResponseFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseStatus.Active)]
    [InlineData(CreditListByExternalIDResponseStatus.PendingPayment)]
    public void Validation_Works(CreditListByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseStatus.Active)]
    [InlineData(CreditListByExternalIDResponseStatus.PendingPayment)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseCreditAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<CreditListByExternalIDResponseCreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CreditListByExternalIDResponseCreditAllocation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CreditListByExternalIDResponseCreditAllocation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        string expectedItemID = "item_id";
        List<CreditListByExternalIDResponseCreditAllocationFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
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
        var model = new CreditListByExternalIDResponseCreditAllocation
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
                    Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
                    Operator =
                        CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        CreditListByExternalIDResponseCreditAllocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditListByExternalIDResponseCreditAllocationFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocationFilter
        {
            Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField> expectedField =
            CreditListByExternalIDResponseCreditAllocationFilterField.PriceID;
        ApiEnum<
            string,
            CreditListByExternalIDResponseCreditAllocationFilterOperator
        > expectedOperator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseCreditAllocationFilter
        {
            Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CreditListByExternalIDResponseCreditAllocationFilter>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocationFilter
        {
            Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CreditListByExternalIDResponseCreditAllocationFilter>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField> expectedField =
            CreditListByExternalIDResponseCreditAllocationFilterField.PriceID;
        ApiEnum<
            string,
            CreditListByExternalIDResponseCreditAllocationFilterOperator
        > expectedOperator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseCreditAllocationFilter
        {
            Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListByExternalIDResponseCreditAllocationFilter
        {
            Field = CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            Operator = CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            Values = ["string"],
        };

        CreditListByExternalIDResponseCreditAllocationFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditListByExternalIDResponseCreditAllocationFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PriceID)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.ItemID)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PriceType)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.Currency)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PricingUnitID)]
    public void Validation_Works(CreditListByExternalIDResponseCreditAllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PriceID)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.ItemID)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PriceType)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.Currency)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        CreditListByExternalIDResponseCreditAllocationFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseCreditAllocationFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterOperator.Excludes)]
    public void Validation_Works(
        CreditListByExternalIDResponseCreditAllocationFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseCreditAllocationFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        CreditListByExternalIDResponseCreditAllocationFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
