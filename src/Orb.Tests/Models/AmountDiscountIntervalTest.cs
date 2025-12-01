using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class AmountDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscountInterval
        {
            AmountDiscount = "amount_discount",
            AppliesToPriceIntervalIDs = ["string"],
            DiscountType = AmountDiscountIntervalDiscountType.Amount,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter1Field.PriceID,
                    Operator = Filter1Operator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIntervalIDs = ["string"];
        ApiEnum<string, AmountDiscountIntervalDiscountType> expectedDiscountType =
            AmountDiscountIntervalDiscountType.Amount;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Filter1> expectedFilters =
        [
            new()
            {
                Field = Filter1Field.PriceID,
                Operator = Filter1Operator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.Equal(
            expectedAppliesToPriceIntervalIDs.Count,
            model.AppliesToPriceIntervalIDs.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIDs[i], model.AppliesToPriceIntervalIDs[i]);
        }
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedStartDate, model.StartDate);
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
