using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class MonetaryMinimumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonetaryMinimumAdjustment
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter8Field.PriceID,
                    Operator = Filter8Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, MonetaryMinimumAdjustmentAdjustmentType> expectedAdjustmentType =
            MonetaryMinimumAdjustmentAdjustmentType.Minimum;
        string expectedAmount = "amount";
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter8> expectedFilters =
        [
            new()
            {
                Field = Filter8Field.PriceID,
                Operator = Filter8Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
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
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }
}

public class Filter8Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter8
        {
            Field = Filter8Field.PriceID,
            Operator = Filter8Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter8Field> expectedField = Filter8Field.PriceID;
        ApiEnum<string, Filter8Operator> expectedOperator = Filter8Operator.Includes;
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
