using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustment>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter19
        {
            Field = Filter19Field.PriceID,
            Operator = Filter19Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter19>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter19
        {
            Field = Filter19Field.PriceID,
            Operator = Filter19Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter19>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter19Field> expectedField = Filter19Field.PriceID;
        ApiEnum<string, Filter19Operator> expectedOperator = Filter19Operator.Includes;
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
        var model = new Filter19
        {
            Field = Filter19Field.PriceID,
            Operator = Filter19Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
