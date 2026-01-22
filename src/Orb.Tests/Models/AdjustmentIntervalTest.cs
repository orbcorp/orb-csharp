using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class AdjustmentIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AdjustmentInterval
        {
            ID = "id",
            Adjustment = new PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        Adjustment expectedAdjustment = new PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(
            expectedAppliesToPriceIntervalIds.Count,
            model.AppliesToPriceIntervalIds.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIds[i], model.AppliesToPriceIntervalIds[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AdjustmentInterval
        {
            ID = "id",
            Adjustment = new PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AdjustmentInterval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AdjustmentInterval
        {
            ID = "id",
            Adjustment = new PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AdjustmentInterval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Adjustment expectedAdjustment = new PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(
            expectedAppliesToPriceIntervalIds.Count,
            deserialized.AppliesToPriceIntervalIds.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIds.Count; i++)
        {
            Assert.Equal(
                expectedAppliesToPriceIntervalIds[i],
                deserialized.AppliesToPriceIntervalIds[i]
            );
        }
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AdjustmentInterval
        {
            ID = "id",
            Adjustment = new PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AdjustmentInterval
        {
            ID = "id",
            Adjustment = new PlanPhaseUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PlanPhaseOrder = 0,
                Reason = "reason",
                ReplacesAdjustmentID = "replaces_adjustment_id",
                UsageDiscount = 0,
            },
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AdjustmentInterval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AdjustmentTest : TestBase
{
    [Fact]
    public void PlanPhaseUsageDiscountValidationWorks()
    {
        Adjustment value = new PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseAmountDiscountValidationWorks()
    {
        Adjustment value = new PlanPhaseAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhasePercentageDiscountValidationWorks()
    {
        Adjustment value = new PlanPhasePercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseMinimumValidationWorks()
    {
        Adjustment value = new PlanPhaseMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseMaximumValidationWorks()
    {
        Adjustment value = new PlanPhaseMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void PlanPhaseUsageDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new PlanPhaseUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseAmountDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new PlanPhaseAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseAmountDiscountAdjustmentAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhasePercentageDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new PlanPhasePercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhasePercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhasePercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = PlanPhasePercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseMinimumSerializationRoundtripWorks()
    {
        Adjustment value = new PlanPhaseMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseMinimumAdjustmentAdjustmentType.Minimum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMinimumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlanPhaseMaximumSerializationRoundtripWorks()
    {
        Adjustment value = new PlanPhaseMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = PlanPhaseMaximumAdjustmentAdjustmentType.Maximum,
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = PlanPhaseMaximumAdjustmentFilterField.PriceID,
                    Operator = PlanPhaseMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
