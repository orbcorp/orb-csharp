using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryAmountDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter6Field.PriceID,
                    Operator = Filter6Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, AdjustmentType> expectedAdjustmentType = AdjustmentType.AmountDiscount;
        string expectedAmount = "amount";
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter6> expectedFilters =
        [
            new()
            {
                Field = Filter6Field.PriceID,
                Operator = Filter6Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
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
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }
}

public class Filter6Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter6
        {
            Field = Filter6Field.PriceID,
            Operator = Filter6Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter6Field> expectedField = Filter6Field.PriceID;
        ApiEnum<string, Filter6Operator> expectedOperator = Filter6Operator.Includes;
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
