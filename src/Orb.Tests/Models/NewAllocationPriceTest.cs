using System.Collections.Generic;
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
}
