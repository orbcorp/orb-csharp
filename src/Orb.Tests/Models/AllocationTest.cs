using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class AllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
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
        List<AllocationFilter> expectedFilters =
        [
            new()
            {
                Field = AllocationFilterField.PriceID,
                Operator = AllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, model.AllowsRollover);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Allocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Allocation>(
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
        List<AllocationFilter> expectedFilters =
        [
            new()
            {
                Field = AllocationFilterField.PriceID,
                Operator = AllocationFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedLicenseTypeID = "license_type_id";

        Assert.Equal(expectedAllowsRollover, deserialized.AllowsRollover);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            LicenseTypeID = "license_type_id",
        };

        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            LicenseTypeID = "license_type_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            LicenseTypeID = "license_type_id",

            // Null should be interpreted as omitted for these properties
            Filters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
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
        var model = new Allocation
        {
            AllowsRollover = true,
            Currency = "currency",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            Filters =
            [
                new()
                {
                    Field = AllocationFilterField.PriceID,
                    Operator = AllocationFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            LicenseTypeID = "license_type_id",
        };

        Allocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllocationFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AllocationFilter
        {
            Field = AllocationFilterField.PriceID,
            Operator = AllocationFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, AllocationFilterField> expectedField = AllocationFilterField.PriceID;
        ApiEnum<string, AllocationFilterOperator> expectedOperator =
            AllocationFilterOperator.Includes;
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
        var model = new AllocationFilter
        {
            Field = AllocationFilterField.PriceID,
            Operator = AllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllocationFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AllocationFilter
        {
            Field = AllocationFilterField.PriceID,
            Operator = AllocationFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllocationFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AllocationFilterField> expectedField = AllocationFilterField.PriceID;
        ApiEnum<string, AllocationFilterOperator> expectedOperator =
            AllocationFilterOperator.Includes;
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
        var model = new AllocationFilter
        {
            Field = AllocationFilterField.PriceID,
            Operator = AllocationFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AllocationFilter
        {
            Field = AllocationFilterField.PriceID,
            Operator = AllocationFilterOperator.Includes,
            Values = ["string"],
        };

        AllocationFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllocationFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(AllocationFilterField.PriceID)]
    [InlineData(AllocationFilterField.ItemID)]
    [InlineData(AllocationFilterField.PriceType)]
    [InlineData(AllocationFilterField.Currency)]
    [InlineData(AllocationFilterField.PricingUnitID)]
    public void Validation_Works(AllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllocationFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllocationFilterField.PriceID)]
    [InlineData(AllocationFilterField.ItemID)]
    [InlineData(AllocationFilterField.PriceType)]
    [InlineData(AllocationFilterField.Currency)]
    [InlineData(AllocationFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(AllocationFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllocationFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AllocationFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(AllocationFilterOperator.Includes)]
    [InlineData(AllocationFilterOperator.Excludes)]
    public void Validation_Works(AllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllocationFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllocationFilterOperator.Includes)]
    [InlineData(AllocationFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(AllocationFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllocationFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllocationFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
