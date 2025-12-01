using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class AffectedBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AffectedBlock
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter1Field.PriceID,
                    Operator = Filter1Operator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string expectedID = "id";
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter1> expectedFilters =
        [
            new()
            {
                Field = Filter1Field.PriceID,
                Operator = Filter1Operator.Includes,
                Values = ["string"],
            },
        ];
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
    }
}

public class Filter1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter1
        {
            Field = Filter1Field.PriceID,
            Operator = Filter1Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter1Field> expectedField = Filter1Field.PriceID;
        ApiEnum<string, Filter1Operator> expectedOperator = Filter1Operator.Includes;
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
