using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
    public void TieredPercentageDiscountValidationWorks()
    {
        Adjustment value = new TieredPercentageDiscount()
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
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
    public void TieredPercentageDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new TieredPercentageDiscount()
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
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

public class TieredPercentageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string expectedID = "id";
        JsonElement expectedAdjustmentType = JsonSerializer.SerializeToElement(
            "tiered_percentage_discount"
        );
        List<string> expectedAppliesToPriceIds = ["string"];
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        List<Tier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedAdjustmentType, model.AdjustmentType));
        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
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
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TieredPercentageDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedAdjustmentType = JsonSerializer.SerializeToElement(
            "tiered_percentage_discount"
        );
        List<string> expectedAppliesToPriceIds = ["string"];
        List<Filter> expectedFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        long expectedPlanPhaseOrder = 0;
        string expectedReason = "reason";
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        List<Tier> expectedTiers =
        [
            new()
            {
                LowerBound = 0,
                Percentage = 0,
                UpperBound = 0,
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedAdjustmentType, deserialized.AdjustmentType));
        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
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
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TieredPercentageDiscount
        {
            ID = "id",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PlanPhaseOrder = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            Tiers =
            [
                new()
                {
                    LowerBound = 0,
                    Percentage = 0,
                    UpperBound = 0,
                },
            ],
        };

        TieredPercentageDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Field> expectedField = Field.PriceID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, Field> expectedField = Field.PriceID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Filter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        Filter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, model.LowerBound);
        Assert.Equal(expectedPercentage, model.Percentage);
        Assert.Equal(expectedUpperBound, model.UpperBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tier>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tier>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedLowerBound = 0;
        double expectedPercentage = 0;
        double expectedUpperBound = 0;

        Assert.Equal(expectedLowerBound, deserialized.LowerBound);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
        Assert.Equal(expectedUpperBound, deserialized.UpperBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tier { LowerBound = 0, Percentage = 0 };

        Assert.Null(model.UpperBound);
        Assert.False(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tier { LowerBound = 0, Percentage = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        Assert.Null(model.UpperBound);
        Assert.True(model.RawData.ContainsKey("upper_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,

            UpperBound = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tier
        {
            LowerBound = 0,
            Percentage = 0,
            UpperBound = 0,
        };

        Tier copied = new(model);

        Assert.Equal(model, copied);
    }
}
