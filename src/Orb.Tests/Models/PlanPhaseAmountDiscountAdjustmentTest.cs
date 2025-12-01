using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseAmountDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseAmountDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter19Field.PriceID,
                    Operator = Filter19Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseAmountDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount;
        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter19> expectedFilters =
        [
            new()
            {
                Field = Filter19Field.PriceID,
                Operator = Filter19Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }
}

public class Filter19Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter19
        {
            Field = Filter19Field.PriceID,
            Operator = Filter19Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter19Field> expectedField = Filter19Field.PriceID;
        ApiEnum<string, Filter19Operator> expectedOperator = Filter19Operator.Includes;
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
