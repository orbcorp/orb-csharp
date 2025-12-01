using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhasePercentageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhasePercentageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter22Field.PriceID,
                    Operator = Filter22Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<
            string,
            PlanPhasePercentageDiscountAdjustmentAdjustmentType
        > expectedAdjustmentType =
            PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter22> expectedFilters =
        [
            new()
            {
                Field = Filter22Field.PriceID,
                Operator = Filter22Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        double expectedPercentageDiscount = 0;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }
}

public class Filter22Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter22
        {
            Field = Filter22Field.PriceID,
            Operator = Filter22Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter22Field> expectedField = Filter22Field.PriceID;
        ApiEnum<string, Filter22Operator> expectedOperator = Filter22Operator.Includes;
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
