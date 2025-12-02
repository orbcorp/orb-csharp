using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
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
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];

        Assert.Equal(expectedAllowsRollover, model.AllowsRollover);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
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
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Allocation>(json);

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
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Allocation>(json);
        Assert.NotNull(deserialized);

        bool expectedAllowsRollover = true;
        string expectedCurrency = "currency";
        CustomExpiration expectedCustomExpiration = new()
        {
            Duration = 0,
            DurationUnit = CustomExpirationDurationUnit.Day,
        };
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];

        Assert.Equal(expectedAllowsRollover, deserialized.AllowsRollover);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
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
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
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

            // Null should be interpreted as omitted for these properties
            Filters = null,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);
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
}
