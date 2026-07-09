using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewAllocationPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string expectedAmount = "10.00";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Monthly;
        string expectedCurrency = "USD";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        bool expectedExpiresAtEndOfCadence = true;
        List<NewAllocationPriceFilter> expectedFilters =
        [
            new()
            {
                Field = NewAllocationPriceFilterField.ItemID,
                Operator = NewAllocationPriceFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedItemID = "item_id";
        string expectedLicenseTypeID = "license_type_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
        Assert.Equal(expectedExpiresAtEndOfCadence, model.ExpiresAtEndOfCadence);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedLicenseTypeID, model.LicenseTypeID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "10.00";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Monthly;
        string expectedCurrency = "USD";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        bool expectedExpiresAtEndOfCadence = true;
        List<NewAllocationPriceFilter> expectedFilters =
        [
            new()
            {
                Field = NewAllocationPriceFilterField.ItemID,
                Operator = NewAllocationPriceFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedItemID = "item_id";
        string expectedLicenseTypeID = "license_type_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
        Assert.Equal(expectedExpiresAtEndOfCadence, deserialized.ExpiresAtEndOfCadence);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedLicenseTypeID, deserialized.LicenseTypeID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Assert.Null(model.PerUnitCostBasis);
        Assert.False(model.RawData.ContainsKey("per_unit_cost_basis"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            PerUnitCostBasis = null,
        };

        Assert.Null(model.PerUnitCostBasis);
        Assert.False(model.RawData.ContainsKey("per_unit_cost_basis"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            PerUnitCostBasis = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        Assert.Null(model.CustomExpiration);
        Assert.False(model.RawData.ContainsKey("custom_expiration"));
        Assert.Null(model.ExpiresAtEndOfCadence);
        Assert.False(model.RawData.ContainsKey("expires_at_end_of_cadence"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.ItemID);
        Assert.False(model.RawData.ContainsKey("item_id"));
        Assert.Null(model.LicenseTypeID);
        Assert.False(model.RawData.ContainsKey("license_type_id"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            PerUnitCostBasis = "per_unit_cost_basis",

            CustomExpiration = null,
            ExpiresAtEndOfCadence = null,
            Filters = null,
            ItemID = null,
            LicenseTypeID = null,
            Metadata = null,
        };

        Assert.Null(model.CustomExpiration);
        Assert.True(model.RawData.ContainsKey("custom_expiration"));
        Assert.Null(model.ExpiresAtEndOfCadence);
        Assert.True(model.RawData.ContainsKey("expires_at_end_of_cadence"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.ItemID);
        Assert.True(model.RawData.ContainsKey("item_id"));
        Assert.Null(model.LicenseTypeID);
        Assert.True(model.RawData.ContainsKey("license_type_id"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            PerUnitCostBasis = "per_unit_cost_basis",

            CustomExpiration = null,
            ExpiresAtEndOfCadence = null,
            Filters = null,
            ItemID = null,
            LicenseTypeID = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewAllocationPrice
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            LicenseTypeID = "license_type_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        NewAllocationPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Cadence.OneTime)]
    [InlineData(Cadence.Monthly)]
    [InlineData(Cadence.Quarterly)]
    [InlineData(Cadence.SemiAnnual)]
    [InlineData(Cadence.Annual)]
    public void Validation_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cadence.OneTime)]
    [InlineData(Cadence.Monthly)]
    [InlineData(Cadence.Quarterly)]
    [InlineData(Cadence.SemiAnnual)]
    [InlineData(Cadence.Annual)]
    public void SerializationRoundtrip_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewAllocationPriceFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAllocationPriceFilter
        {
            Field = NewAllocationPriceFilterField.ItemID,
            Operator = NewAllocationPriceFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewAllocationPriceFilterField> expectedField =
            NewAllocationPriceFilterField.ItemID;
        ApiEnum<string, NewAllocationPriceFilterOperator> expectedOperator =
            NewAllocationPriceFilterOperator.Includes;
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
        var model = new NewAllocationPriceFilter
        {
            Field = NewAllocationPriceFilterField.ItemID,
            Operator = NewAllocationPriceFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPriceFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAllocationPriceFilter
        {
            Field = NewAllocationPriceFilterField.ItemID,
            Operator = NewAllocationPriceFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPriceFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewAllocationPriceFilterField> expectedField =
            NewAllocationPriceFilterField.ItemID;
        ApiEnum<string, NewAllocationPriceFilterOperator> expectedOperator =
            NewAllocationPriceFilterOperator.Includes;
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
        var model = new NewAllocationPriceFilter
        {
            Field = NewAllocationPriceFilterField.ItemID,
            Operator = NewAllocationPriceFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewAllocationPriceFilter
        {
            Field = NewAllocationPriceFilterField.ItemID,
            Operator = NewAllocationPriceFilterOperator.Includes,
            Values = ["string"],
        };

        NewAllocationPriceFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewAllocationPriceFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewAllocationPriceFilterField.ItemID)]
    public void Validation_Works(NewAllocationPriceFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAllocationPriceFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAllocationPriceFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewAllocationPriceFilterField.ItemID)]
    public void SerializationRoundtrip_Works(NewAllocationPriceFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAllocationPriceFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAllocationPriceFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAllocationPriceFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAllocationPriceFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewAllocationPriceFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewAllocationPriceFilterOperator.Includes)]
    [InlineData(NewAllocationPriceFilterOperator.Excludes)]
    public void Validation_Works(NewAllocationPriceFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAllocationPriceFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAllocationPriceFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewAllocationPriceFilterOperator.Includes)]
    [InlineData(NewAllocationPriceFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewAllocationPriceFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAllocationPriceFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAllocationPriceFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAllocationPriceFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAllocationPriceFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
