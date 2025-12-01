using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryPercentageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryPercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter9Field.PriceID,
                    Operator = Filter9Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryPercentageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter9> expectedFilters =
        [
            new()
            {
                Field = Filter9Field.PriceID,
                Operator = Filter9Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }
}

public class Filter9Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter9
        {
            Field = Filter9Field.PriceID,
            Operator = Filter9Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter9Field> expectedField = Filter9Field.PriceID;
        ApiEnum<string, Filter9Operator> expectedOperator = Filter9Operator.Includes;
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
