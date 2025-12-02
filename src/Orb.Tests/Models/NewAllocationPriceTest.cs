using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
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
        List<Filter11> expectedFilters =
        [
            new()
            {
                Field = Filter11Field.ItemID,
                Operator = Filter11Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedItemID = "item_id";
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomExpiration, model.CustomExpiration);
        Assert.Equal(expectedExpiresAtEndOfCadence, model.ExpiresAtEndOfCadence);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedItemID, model.ItemID);
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPrice>(json);

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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewAllocationPrice>(json);
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
        List<Filter11> expectedFilters =
        [
            new()
            {
                Field = Filter11Field.ItemID,
                Operator = Filter11Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedItemID = "item_id";
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomExpiration, deserialized.CustomExpiration);
        Assert.Equal(expectedExpiresAtEndOfCadence, deserialized.ExpiresAtEndOfCadence);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedItemID, deserialized.ItemID);
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",

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
                    Field = Filter11Field.ItemID,
                    Operator = Filter11Operator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",

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
        };

        Assert.Null(model.CustomExpiration);
        Assert.True(model.RawData.ContainsKey("custom_expiration"));
        Assert.Null(model.ExpiresAtEndOfCadence);
        Assert.True(model.RawData.ContainsKey("expires_at_end_of_cadence"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.ItemID);
        Assert.True(model.RawData.ContainsKey("item_id"));
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
        };

        model.Validate();
    }
}

public class Filter11Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter11
        {
            Field = Filter11Field.ItemID,
            Operator = Filter11Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter11Field> expectedField = Filter11Field.ItemID;
        ApiEnum<string, Filter11Operator> expectedOperator = Filter11Operator.Includes;
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
        var model = new Filter11
        {
            Field = Filter11Field.ItemID,
            Operator = Filter11Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter11>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter11
        {
            Field = Filter11Field.ItemID,
            Operator = Filter11Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter11>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter11Field> expectedField = Filter11Field.ItemID;
        ApiEnum<string, Filter11Operator> expectedOperator = Filter11Operator.Includes;
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
        var model = new Filter11
        {
            Field = Filter11Field.ItemID,
            Operator = Filter11Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
