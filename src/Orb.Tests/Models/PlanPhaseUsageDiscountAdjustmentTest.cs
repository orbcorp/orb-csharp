using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseUsageDiscountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter23Field.PriceID,
                    Operator = Filter23Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter23> expectedFilters =
        [
            new()
            {
                Field = Filter23Field.PriceID,
                Operator = Filter23Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter23Field.PriceID,
                    Operator = Filter23Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter23Field.PriceID,
                    Operator = Filter23Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseUsageDiscountAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseUsageDiscountAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter23> expectedFilters =
        [
            new()
            {
                Field = Filter23Field.PriceID,
                Operator = Filter23Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        double expectedUsageDiscount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
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
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseUsageDiscountAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter23Field.PriceID,
                    Operator = Filter23Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };

        model.Validate();
    }
}

public class Filter23Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter23
        {
            Field = Filter23Field.PriceID,
            Operator = Filter23Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter23Field> expectedField = Filter23Field.PriceID;
        ApiEnum<string, Filter23Operator> expectedOperator = Filter23Operator.Includes;
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
        var model = new Filter23
        {
            Field = Filter23Field.PriceID,
            Operator = Filter23Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter23>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter23
        {
            Field = Filter23Field.PriceID,
            Operator = Filter23Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter23>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter23Field> expectedField = Filter23Field.PriceID;
        ApiEnum<string, Filter23Operator> expectedOperator = Filter23Operator.Includes;
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
        var model = new Filter23
        {
            Field = Filter23Field.PriceID,
            Operator = Filter23Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
