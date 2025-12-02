using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PlanPhaseMaximumAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter20Field.PriceID,
                    Operator = Filter20Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMaximumAdjustmentAdjustmentType.Maximum;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter20> expectedFilters =
        [
            new()
            {
                Field = Filter20Field.PriceID,
                Operator = Filter20Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
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
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter20Field.PriceID,
                    Operator = Filter20Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter20Field.PriceID,
                    Operator = Filter20Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlanPhaseMaximumAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanPhaseMaximumAdjustmentAdjustmentType> expectedAdjustmentType =
            PlanPhaseMaximumAdjustmentAdjustmentType.Maximum;
        List<string> expectedAppliesToPriceIDs = ["string"];
        List<Filter20> expectedFilters =
        [
            new()
            {
                Field = Filter20Field.PriceID,
                Operator = Filter20Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        string expectedMaximumAmount = "maximum_amount";
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

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
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPhaseMaximumAdjustment
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIDs = ["string"],
            Filters =
            [
                new()
                {
                    Field = Filter20Field.PriceID,
                    Operator = Filter20Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class Filter20Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter20
        {
            Field = Filter20Field.PriceID,
            Operator = Filter20Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Filter20Field> expectedField = Filter20Field.PriceID;
        ApiEnum<string, Filter20Operator> expectedOperator = Filter20Operator.Includes;
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
        var model = new Filter20
        {
            Field = Filter20Field.PriceID,
            Operator = Filter20Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter20>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter20
        {
            Field = Filter20Field.PriceID,
            Operator = Filter20Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter20>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Filter20Field> expectedField = Filter20Field.PriceID;
        ApiEnum<string, Filter20Operator> expectedOperator = Filter20Operator.Includes;
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
        var model = new Filter20
        {
            Field = Filter20Field.PriceID,
            Operator = Filter20Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}
