using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta.ExternalPlanID;
using Models = Orb.Models;

namespace Orb.Tests.Models.Beta.ExternalPlanID;

public class AddAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            PlanPhaseOrder = 0,
        };

        Adjustment expectedAdjustment = new Models::NewPercentageDiscount()
        {
            AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Models::NewPercentageDiscountFilterField.PriceID,
                    Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = Models::NewPercentageDiscountPriceType.Usage,
        };
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            PlanPhaseOrder = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            PlanPhaseOrder = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddAdjustment>(json);
        Assert.NotNull(deserialized);

        Adjustment expectedAdjustment = new Models::NewPercentageDiscount()
        {
            AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Models::NewPercentageDiscountFilterField.PriceID,
                    Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = Models::NewPercentageDiscountPriceType.Usage,
        };
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            PlanPhaseOrder = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },

            PlanPhaseOrder = null,
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },

            PlanPhaseOrder = null,
        };

        model.Validate();
    }
}

public class AdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Adjustment value = new(
            new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewUsageDiscountValidationWorks()
    {
        Adjustment value = new(
            new Models::NewUsageDiscount()
            {
                AdjustmentType = Models::NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = Models::NewUsageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewUsageDiscountFilterField.PriceID,
                        Operator = Models::NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewUsageDiscountPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewAmountDiscountValidationWorks()
    {
        Adjustment value = new(
            new Models::NewAmountDiscount()
            {
                AdjustmentType = Models::NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = Models::AppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAmountDiscountFilterField.PriceID,
                        Operator = Models::NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::PriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewMinimumValidationWorks()
    {
        Adjustment value = new(
            new Models::NewMinimum()
            {
                AdjustmentType = Models::NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = Models::NewMinimumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMinimumFilterField.PriceID,
                        Operator = Models::NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMinimumPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewMaximumValidationWorks()
    {
        Adjustment value = new(
            new Models::NewMaximum()
            {
                AdjustmentType = Models::NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = Models::NewMaximumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMaximumFilterField.PriceID,
                        Operator = Models::NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMaximumPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPercentageDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new(
            new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new(
            new Models::NewUsageDiscount()
            {
                AdjustmentType = Models::NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = Models::NewUsageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewUsageDiscountFilterField.PriceID,
                        Operator = Models::NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewUsageDiscountPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Adjustment value = new(
            new Models::NewAmountDiscount()
            {
                AdjustmentType = Models::NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = Models::AppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAmountDiscountFilterField.PriceID,
                        Operator = Models::NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::PriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Adjustment value = new(
            new Models::NewMinimum()
            {
                AdjustmentType = Models::NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = Models::NewMinimumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMinimumFilterField.PriceID,
                        Operator = Models::NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMinimumPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Adjustment value = new(
            new Models::NewMaximum()
            {
                AdjustmentType = Models::NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = Models::NewMaximumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMaximumFilterField.PriceID,
                        Operator = Models::NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMaximumPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Adjustment>(json);

        Assert.Equal(value, deserialized);
    }
}

public class AddPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        Models::NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Models::Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = Models::NewAllocationPriceFilterField.ItemID,
                    Operator = Models::NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        long expectedPlanPhaseOrder = 0;
        Price expectedPrice = new Models::NewPlanUnitPrice()
        {
            Cadence = Models::NewPlanUnitPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Models::NewPlanUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        Assert.Equal(expectedAllocationPrice, model.AllocationPrice);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPrice, model.Price);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AddPrice>(json);
        Assert.NotNull(deserialized);

        Models::NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Models::Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = Models::NewAllocationPriceFilterField.ItemID,
                    Operator = Models::NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        long expectedPlanPhaseOrder = 0;
        Price expectedPrice = new Models::NewPlanUnitPrice()
        {
            Cadence = Models::NewPlanUnitPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Models::NewPlanUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        Assert.Equal(expectedAllocationPrice, deserialized.AllocationPrice);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedPrice, deserialized.Price);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddPrice { };

        Assert.Null(model.AllocationPrice);
        Assert.False(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddPrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = null,
            PlanPhaseOrder = null,
            Price = null,
        };

        Assert.Null(model.AllocationPrice);
        Assert.True(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddPrice
        {
            AllocationPrice = null,
            PlanPhaseOrder = null,
            Price = null,
        };

        model.Validate();
    }
}

public class PriceTest : TestBase
{
    [Fact]
    public void NewPlanUnitValidationWorks()
    {
        Price value = new(
            new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredValidationWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPrice()
            {
                Cadence = Models::NewPlanTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPriceModelType.Tiered,
                Name = "Annual fee",
                TieredConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ],
                    Prorated = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanBulkValidationWorks()
    {
        Price value = new(
            new Models::NewPlanBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Models::NewPlanBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkPriceModelType.Bulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        Price value = new(
            new BulkWithFilters()
            {
                BulkWithFiltersConfig = new()
                {
                    Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                    Tiers =
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                Cadence = Cadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanPackageValidationWorks()
    {
        Price value = new(
            new Models::NewPlanPackagePrice()
            {
                Cadence = Models::NewPlanPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixValidationWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixPrice()
            {
                Cadence = Models::NewPlanMatrixPriceCadence.Annual,
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixPriceModelType.Matrix,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanThresholdTotalAmountValidationWorks()
    {
        Price value = new(
            new Models::NewPlanThresholdTotalAmountPrice()
            {
                Cadence = Models::NewPlanThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
                Name = "Annual fee",
                ThresholdTotalAmountConfig = new()
                {
                    ConsumptionTable =
                    [
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    ],
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredPackageValidationWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPackagePrice()
            {
                Cadence = Models::NewPlanTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPackagePriceModelType.TieredPackage,
                Name = "Annual fee",
                TieredPackageConfig = new()
                {
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredWithMinimumValidationWorks()
    {
        Price value = new(
            new Models::NewPlanTieredWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredWithMinimumPriceModelType.TieredWithMinimum,
                Name = "Annual fee",
                TieredWithMinimumConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    HideZeroAmountTiers = true,
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedTieredValidationWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedTieredPrice()
            {
                Cadence = Models::NewPlanGroupedTieredPriceCadence.Annual,
                GroupedTieredConfig = new()
                {
                    GroupingKey = "x",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredPackageWithMinimumValidationWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPackageWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
                Name = "Annual fee",
                TieredPackageWithMinimumConfig = new()
                {
                    PackageSize = 0,
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanPackageWithAllocationValidationWorks()
    {
        Price value = new(
            new Models::NewPlanPackageWithAllocationPrice()
            {
                Cadence = Models::NewPlanPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanPackageWithAllocationPriceModelType.PackageWithAllocation,
                Name = "Annual fee",
                PackageWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    PackageAmount = "package_amount",
                    PackageSize = "package_size",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitWithPercentValidationWorks()
    {
        Price value = new(
            new Models::NewPlanUnitWithPercentPrice()
            {
                Cadence = Models::NewPlanUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixWithAllocationValidationWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixWithAllocationPrice()
            {
                Cadence = Models::NewPlanMatrixWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredWithProrationValidationWorks()
    {
        Price value = new(
            new TieredWithProration()
            {
                Cadence = TieredWithProrationCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitWithProrationValidationWorks()
    {
        Price value = new(
            new Models::NewPlanUnitWithProrationPrice()
            {
                Cadence = Models::NewPlanUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedAllocationValidationWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedAllocationPrice()
            {
                Cadence = Models::NewPlanGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanBulkWithProrationValidationWorks()
    {
        Price value = new(
            new Models::NewPlanBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Models::NewPlanBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedWithProratedMinimumValidationWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedWithProratedMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedWithMeteredMinimumValidationWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedWithMeteredMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        Price value = new(
            new GroupedWithMinMaxThresholds()
            {
                Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
                GroupedWithMinMaxThresholdsConfig = new()
                {
                    GroupingKey = "x",
                    MaximumCharge = "maximum_charge",
                    MinimumCharge = "minimum_charge",
                    PerUnitRate = "per_unit_rate",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixWithDisplayNameValidationWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixWithDisplayNamePrice()
            {
                Cadence = Models::NewPlanMatrixWithDisplayNamePriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithDisplayNameConfig = new()
                {
                    Dimension = "dimension",
                    UnitAmounts =
                    [
                        new()
                        {
                            DimensionValue = "dimension_value",
                            DisplayName = "display_name",
                            UnitAmount = "unit_amount",
                        },
                    ],
                },
                ModelType =
                    Models::NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedTieredPackageValidationWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedTieredPackagePrice()
            {
                Cadence = Models::NewPlanGroupedTieredPackagePriceCadence.Annual,
                GroupedTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMaxGroupTieredPackageValidationWorks()
    {
        Price value = new(
            new Models::NewPlanMaxGroupTieredPackagePrice()
            {
                Cadence = Models::NewPlanMaxGroupTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                MaxGroupTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ModelType =
                    Models::NewPlanMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanScalableMatrixWithUnitPricingValidationWorks()
    {
        Price value = new(
            new Models::NewPlanScalableMatrixWithUnitPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
                Name = "Annual fee",
                ScalableMatrixWithUnitPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    UnitPrice = "unit_price",
                    Prorate = true,
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanScalableMatrixWithTieredPricingValidationWorks()
    {
        Price value = new(
            new Models::NewPlanScalableMatrixWithTieredPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
                Name = "Annual fee",
                ScalableMatrixWithTieredPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanCumulativeGroupedBulkValidationWorks()
    {
        Price value = new(
            new Models::NewPlanCumulativeGroupedBulkPrice()
            {
                Cadence = Models::NewPlanCumulativeGroupedBulkPriceCadence.Annual,
                CumulativeGroupedBulkConfig = new()
                {
                    DimensionValues =
                    [
                        new()
                        {
                            GroupingKey = "x",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    Group = "group",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        Price value = new(
            new CumulativeGroupedAllocation()
            {
                Cadence = CumulativeGroupedAllocationCadence.Annual,
                CumulativeGroupedAllocationConfig = new()
                {
                    CumulativeAllocation = "cumulative_allocation",
                    GroupAllocation = "group_allocation",
                    GroupingKey = "x",
                    UnitAmount = "unit_amount",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMinimumCompositeValidationWorks()
    {
        Price value = new(
            new Models::NewPlanMinimumCompositePrice()
            {
                Cadence = Models::NewPlanMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = Models::NewPlanMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        Price value = new(
            new Percent()
            {
                Cadence = PercentCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        Price value = new(
            new EventOutput()
            {
                Cadence = EventOutputCadence.Annual,
                EventOutputConfig = new()
                {
                    UnitRatingKey = "x",
                    DefaultUnitRate = "default_unit_rate",
                    GroupingKey = "grouping_key",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPrice()
            {
                Cadence = Models::NewPlanTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPriceModelType.Tiered,
                Name = "Annual fee",
                TieredConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ],
                    Prorated = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanBulkSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Models::NewPlanBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkPriceModelType.Bulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Price value = new(
            new BulkWithFilters()
            {
                BulkWithFiltersConfig = new()
                {
                    Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                    Tiers =
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                Cadence = Cadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanPackageSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanPackagePrice()
            {
                Cadence = Models::NewPlanPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixPrice()
            {
                Cadence = Models::NewPlanMatrixPriceCadence.Annual,
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixPriceModelType.Matrix,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanThresholdTotalAmountSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanThresholdTotalAmountPrice()
            {
                Cadence = Models::NewPlanThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
                Name = "Annual fee",
                ThresholdTotalAmountConfig = new()
                {
                    ConsumptionTable =
                    [
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    ],
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredPackageSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPackagePrice()
            {
                Cadence = Models::NewPlanTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPackagePriceModelType.TieredPackage,
                Name = "Annual fee",
                TieredPackageConfig = new()
                {
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredWithMinimumSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanTieredWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredWithMinimumPriceModelType.TieredWithMinimum,
                Name = "Annual fee",
                TieredWithMinimumConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    HideZeroAmountTiers = true,
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedTieredSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedTieredPrice()
            {
                Cadence = Models::NewPlanGroupedTieredPriceCadence.Annual,
                GroupedTieredConfig = new()
                {
                    GroupingKey = "x",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanTieredPackageWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
                Name = "Annual fee",
                TieredPackageWithMinimumConfig = new()
                {
                    PackageSize = 0,
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanPackageWithAllocationSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanPackageWithAllocationPrice()
            {
                Cadence = Models::NewPlanPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanPackageWithAllocationPriceModelType.PackageWithAllocation,
                Name = "Annual fee",
                PackageWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    PackageAmount = "package_amount",
                    PackageSize = "package_size",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanUnitWithPercentSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanUnitWithPercentPrice()
            {
                Cadence = Models::NewPlanUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixWithAllocationSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixWithAllocationPrice()
            {
                Cadence = Models::NewPlanMatrixWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        Price value = new(
            new TieredWithProration()
            {
                Cadence = TieredWithProrationCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanUnitWithProrationSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanUnitWithProrationPrice()
            {
                Cadence = Models::NewPlanUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedAllocationSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedAllocationPrice()
            {
                Cadence = Models::NewPlanGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanBulkWithProrationSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Models::NewPlanBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedWithProratedMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedWithMeteredMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Price value = new(
            new GroupedWithMinMaxThresholds()
            {
                Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
                GroupedWithMinMaxThresholdsConfig = new()
                {
                    GroupingKey = "x",
                    MaximumCharge = "maximum_charge",
                    MinimumCharge = "minimum_charge",
                    PerUnitRate = "per_unit_rate",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanMatrixWithDisplayNamePrice()
            {
                Cadence = Models::NewPlanMatrixWithDisplayNamePriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithDisplayNameConfig = new()
                {
                    Dimension = "dimension",
                    UnitAmounts =
                    [
                        new()
                        {
                            DimensionValue = "dimension_value",
                            DisplayName = "display_name",
                            UnitAmount = "unit_amount",
                        },
                    ],
                },
                ModelType =
                    Models::NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedTieredPackageSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanGroupedTieredPackagePrice()
            {
                Cadence = Models::NewPlanGroupedTieredPackagePriceCadence.Annual,
                GroupedTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanMaxGroupTieredPackagePrice()
            {
                Cadence = Models::NewPlanMaxGroupTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                MaxGroupTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ModelType =
                    Models::NewPlanMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanScalableMatrixWithUnitPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
                Name = "Annual fee",
                ScalableMatrixWithUnitPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    UnitPrice = "unit_price",
                    Prorate = true,
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanScalableMatrixWithTieredPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
                Name = "Annual fee",
                ScalableMatrixWithTieredPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanCumulativeGroupedBulkPrice()
            {
                Cadence = Models::NewPlanCumulativeGroupedBulkPriceCadence.Annual,
                CumulativeGroupedBulkConfig = new()
                {
                    DimensionValues =
                    [
                        new()
                        {
                            GroupingKey = "x",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    Group = "group",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Price value = new(
            new CumulativeGroupedAllocation()
            {
                Cadence = CumulativeGroupedAllocationCadence.Annual,
                CumulativeGroupedAllocationConfig = new()
                {
                    CumulativeAllocation = "cumulative_allocation",
                    GroupAllocation = "group_allocation",
                    GroupingKey = "x",
                    UnitAmount = "unit_amount",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMinimumCompositeSerializationRoundtripWorks()
    {
        Price value = new(
            new Models::NewPlanMinimumCompositePrice()
            {
                Cadence = Models::NewPlanMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = Models::NewPlanMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Price value = new(
            new Percent()
            {
                Cadence = PercentCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Price value = new(
            new EventOutput()
            {
                Cadence = EventOutputCadence.Annual,
                EventOutputConfig = new()
                {
                    UnitRatingKey = "x",
                    DefaultUnitRate = "default_unit_rate",
                    GroupingKey = "grouping_key",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Price>(json);

        Assert.Equal(value, deserialized);
    }
}

public class BulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        BulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, Cadence> expectedCadence = Cadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkWithFilters>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkWithFilters>(json);
        Assert.NotNull(deserialized);

        BulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, Cadence> expectedCadence = Cadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedBulkWithFiltersConfig, deserialized.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class BulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Filter> expectedFilters = [new() { PropertyKey = "x", PropertyValue = "x" }];
        List<Tier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkWithFiltersConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkWithFiltersConfig>(json);
        Assert.NotNull(deserialized);

        List<Filter> expectedFilters = [new() { PropertyKey = "x", PropertyValue = "x" }];
        List<Tier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        model.Validate();
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter { PropertyKey = "x", PropertyValue = "x" };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter { PropertyKey = "x", PropertyValue = "x" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter { PropertyKey = "x", PropertyValue = "x" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Filter>(json);
        Assert.NotNull(deserialized);

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, deserialized.PropertyKey);
        Assert.Equal(expectedPropertyValue, deserialized.PropertyValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filter { PropertyKey = "x", PropertyValue = "x" };

        model.Validate();
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tier>(json);
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount" };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tier { UnitAmount = "unit_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        Assert.Null(model.TierLowerBound);
        Assert.True(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        model.Validate();
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Cadence.Annual)]
    [InlineData(Cadence.SemiAnnual)]
    [InlineData(Cadence.Monthly)]
    [InlineData(Cadence.Quarterly)]
    [InlineData(Cadence.OneTime)]
    [InlineData(Cadence.Custom)]
    public void Validation_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cadence.Annual)]
    [InlineData(Cadence.SemiAnnual)]
    [InlineData(Cadence.Monthly)]
    [InlineData(Cadence.Quarterly)]
    [InlineData(Cadence.OneTime)]
    [InlineData(Cadence.Custom)]
    public void SerializationRoundtrip_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class TieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, TieredWithProrationCadence> expectedCadence =
            TieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        TieredWithProrationConfig expectedTieredWithProrationConfig = new(
            [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
        );
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        TieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTieredWithProrationConfig, model.TieredWithProrationConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProration>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, TieredWithProrationCadence> expectedCadence =
            TieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        TieredWithProrationConfig expectedTieredWithProrationConfig = new(
            [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
        );
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        TieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTieredWithProrationConfig, deserialized.TieredWithProrationConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TieredWithProration
        {
            Cadence = TieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class TieredWithProrationCadenceTest : TestBase
{
    [Theory]
    [InlineData(TieredWithProrationCadence.Annual)]
    [InlineData(TieredWithProrationCadence.SemiAnnual)]
    [InlineData(TieredWithProrationCadence.Monthly)]
    [InlineData(TieredWithProrationCadence.Quarterly)]
    [InlineData(TieredWithProrationCadence.OneTime)]
    [InlineData(TieredWithProrationCadence.Custom)]
    public void Validation_Works(TieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredWithProrationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredWithProrationCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TieredWithProrationCadence.Annual)]
    [InlineData(TieredWithProrationCadence.SemiAnnual)]
    [InlineData(TieredWithProrationCadence.Monthly)]
    [InlineData(TieredWithProrationCadence.Quarterly)]
    [InlineData(TieredWithProrationCadence.OneTime)]
    [InlineData(TieredWithProrationCadence.Custom)]
    public void SerializationRoundtrip_Works(TieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TieredWithProrationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TieredWithProrationCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TieredWithProrationCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TieredWithProrationCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TieredWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        List<TieredWithProrationConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConfig>(json);
        Assert.NotNull(deserialized);

        List<TieredWithProrationConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        model.Validate();
    }
}

public class TieredWithProrationConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConfigTier>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConfigTier>(json);
        Assert.NotNull(deserialized);

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class TieredWithProrationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        TieredWithProrationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        TieredWithProrationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        TieredWithProrationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConversionRateConfig>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        TieredWithProrationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<TieredWithProrationConversionRateConfig>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}

public class GroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, GroupedWithMinMaxThresholdsCadence> expectedCadence =
            GroupedWithMinMaxThresholdsCadence.Annual;
        GroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig = new()
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        GroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            model.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, GroupedWithMinMaxThresholdsCadence> expectedCadence =
            GroupedWithMinMaxThresholdsCadence.Annual;
        GroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig = new()
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        GroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            deserialized.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroupedWithMinMaxThresholds
        {
            Cadence = GroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class GroupedWithMinMaxThresholdsCadenceTest : TestBase
{
    [Theory]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(GroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupedWithMinMaxThresholdsCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupedWithMinMaxThresholdsCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(GroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(GroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupedWithMinMaxThresholdsCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupedWithMinMaxThresholdsCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMaximumCharge, model.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, model.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, model.PerUnitRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfig>(json);
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedMaximumCharge, deserialized.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, deserialized.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, deserialized.PerUnitRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        model.Validate();
    }
}

public class GroupedWithMinMaxThresholdsConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        GroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        GroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        GroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        GroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class CumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, CumulativeGroupedAllocationCadence> expectedCadence =
            CumulativeGroupedAllocationCadence.Annual;
        CumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig = new()
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        CumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CumulativeGroupedAllocation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CumulativeGroupedAllocation>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, CumulativeGroupedAllocationCadence> expectedCadence =
            CumulativeGroupedAllocationCadence.Annual;
        CumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig = new()
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        CumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            deserialized.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CumulativeGroupedAllocation
        {
            Cadence = CumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class CumulativeGroupedAllocationCadenceTest : TestBase
{
    [Theory]
    [InlineData(CumulativeGroupedAllocationCadence.Annual)]
    [InlineData(CumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(CumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(CumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(CumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(CumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(CumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CumulativeGroupedAllocationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CumulativeGroupedAllocationCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CumulativeGroupedAllocationCadence.Annual)]
    [InlineData(CumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(CumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(CumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(CumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(CumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(CumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CumulativeGroupedAllocationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CumulativeGroupedAllocationCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, model.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, model.GroupAllocation);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CumulativeGroupedAllocationConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CumulativeGroupedAllocationConfig>(json);
        Assert.NotNull(deserialized);

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, deserialized.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, deserialized.GroupAllocation);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class CumulativeGroupedAllocationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        CumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        CumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        CumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<CumulativeGroupedAllocationConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        CumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<CumulativeGroupedAllocationConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class PercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, PercentCadence> expectedCadence = PercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        PercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Percent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Percent>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, PercentCadence> expectedCadence = PercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        PercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        PercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentConfig, deserialized.PercentConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Percent
        {
            Cadence = PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class PercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(PercentCadence.Annual)]
    [InlineData(PercentCadence.SemiAnnual)]
    [InlineData(PercentCadence.Monthly)]
    [InlineData(PercentCadence.Quarterly)]
    [InlineData(PercentCadence.OneTime)]
    [InlineData(PercentCadence.Custom)]
    public void Validation_Works(PercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentCadence.Annual)]
    [InlineData(PercentCadence.SemiAnnual)]
    [InlineData(PercentCadence.Monthly)]
    [InlineData(PercentCadence.Quarterly)]
    [InlineData(PercentCadence.OneTime)]
    [InlineData(PercentCadence.Custom)]
    public void SerializationRoundtrip_Works(PercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PercentCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PercentCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PercentCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentConfig>(json);
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PercentConfig { Percent = 0 };

        model.Validate();
    }
}

public class PercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        PercentConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        PercentConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        PercentConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PercentConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        PercentConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<PercentConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class EventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, EventOutputCadence> expectedCadence = EventOutputCadence.Annual;
        EventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        EventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventOutput>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventOutput>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, EventOutputCadence> expectedCadence = EventOutputCadence.Annual;
        EventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        EventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedEventOutputConfig, deserialized.EventOutputConfig);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventOutput
        {
            Cadence = EventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class EventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(EventOutputCadence.Annual)]
    [InlineData(EventOutputCadence.SemiAnnual)]
    [InlineData(EventOutputCadence.Monthly)]
    [InlineData(EventOutputCadence.Quarterly)]
    [InlineData(EventOutputCadence.OneTime)]
    [InlineData(EventOutputCadence.Custom)]
    public void Validation_Works(EventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventOutputCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventOutputCadence.Annual)]
    [InlineData(EventOutputCadence.SemiAnnual)]
    [InlineData(EventOutputCadence.Monthly)]
    [InlineData(EventOutputCadence.Quarterly)]
    [InlineData(EventOutputCadence.OneTime)]
    [InlineData(EventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(EventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventOutputCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventOutputCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventOutputCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, model.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, model.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventOutputConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EventOutputConfig>(json);
        Assert.NotNull(deserialized);

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, deserialized.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, deserialized.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventOutputConfig { UnitRatingKey = "x" };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventOutputConfig { UnitRatingKey = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        Assert.Null(model.DefaultUnitRate);
        Assert.True(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.True(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        model.Validate();
    }
}

public class EventOutputConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        EventOutputConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        EventOutputConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        EventOutputConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<EventOutputConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        EventOutputConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<EventOutputConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class RemoveAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 };

        string expectedAdjustmentID = "adjustment_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustmentID, model.AdjustmentID);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RemoveAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RemoveAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedAdjustmentID = "adjustment_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustmentID, deserialized.AdjustmentID);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id" };

        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RemoveAdjustment { AdjustmentID = "adjustment_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RemoveAdjustment
        {
            AdjustmentID = "adjustment_id",

            PlanPhaseOrder = null,
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RemoveAdjustment
        {
            AdjustmentID = "adjustment_id",

            PlanPhaseOrder = null,
        };

        model.Validate();
    }
}

public class RemovePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RemovePrice { PriceID = "price_id", PlanPhaseOrder = 0 };

        string expectedPriceID = "price_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RemovePrice { PriceID = "price_id", PlanPhaseOrder = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RemovePrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RemovePrice { PriceID = "price_id", PlanPhaseOrder = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RemovePrice>(json);
        Assert.NotNull(deserialized);

        string expectedPriceID = "price_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedPriceID, deserialized.PriceID);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RemovePrice { PriceID = "price_id", PlanPhaseOrder = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RemovePrice { PriceID = "price_id" };

        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RemovePrice { PriceID = "price_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RemovePrice
        {
            PriceID = "price_id",

            PlanPhaseOrder = null,
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RemovePrice
        {
            PriceID = "price_id",

            PlanPhaseOrder = null,
        };

        model.Validate();
    }
}

public class ReplaceAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
            PlanPhaseOrder = 0,
        };

        ReplaceAdjustmentAdjustment expectedAdjustment = new Models::NewPercentageDiscount()
        {
            AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Models::NewPercentageDiscountFilterField.PriceID,
                    Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = Models::NewPercentageDiscountPriceType.Usage,
        };
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
            PlanPhaseOrder = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
            PlanPhaseOrder = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustment>(json);
        Assert.NotNull(deserialized);

        ReplaceAdjustmentAdjustment expectedAdjustment = new Models::NewPercentageDiscount()
        {
            AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = Models::NewPercentageDiscountFilterField.PriceID,
                    Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = Models::NewPercentageDiscountPriceType.Usage,
        };
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";
        long expectedPlanPhaseOrder = 0;

        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
            PlanPhaseOrder = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",

            PlanPhaseOrder = null,
        };

        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplaceAdjustment
        {
            Adjustment = new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",

            PlanPhaseOrder = null,
        };

        model.Validate();
    }
}

public class ReplaceAdjustmentAdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewUsageDiscountValidationWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewUsageDiscount()
            {
                AdjustmentType = Models::NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = Models::NewUsageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewUsageDiscountFilterField.PriceID,
                        Operator = Models::NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewUsageDiscountPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewAmountDiscountValidationWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewAmountDiscount()
            {
                AdjustmentType = Models::NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = Models::AppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAmountDiscountFilterField.PriceID,
                        Operator = Models::NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::PriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewMinimumValidationWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewMinimum()
            {
                AdjustmentType = Models::NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = Models::NewMinimumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMinimumFilterField.PriceID,
                        Operator = Models::NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMinimumPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewMaximumValidationWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewMaximum()
            {
                AdjustmentType = Models::NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = Models::NewMaximumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMaximumFilterField.PriceID,
                        Operator = Models::NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMaximumPriceType.Usage,
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPercentageDiscountSerializationRoundtripWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewPercentageDiscount()
            {
                AdjustmentType = Models::NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = Models::NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewPercentageDiscountFilterField.PriceID,
                        Operator = Models::NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewPercentageDiscountPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewUsageDiscount()
            {
                AdjustmentType = Models::NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = Models::NewUsageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewUsageDiscountFilterField.PriceID,
                        Operator = Models::NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewUsageDiscountPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewAmountDiscount()
            {
                AdjustmentType = Models::NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = Models::AppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAmountDiscountFilterField.PriceID,
                        Operator = Models::NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::PriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewMinimum()
            {
                AdjustmentType = Models::NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = Models::NewMinimumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMinimumFilterField.PriceID,
                        Operator = Models::NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMinimumPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        ReplaceAdjustmentAdjustment value = new(
            new Models::NewMaximum()
            {
                AdjustmentType = Models::NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = Models::NewMaximumAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = Models::NewMaximumFilterField.PriceID,
                        Operator = Models::NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = Models::NewMaximumPriceType.Usage,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        string expectedReplacesPriceID = "replaces_price_id";
        Models::NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Models::Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = Models::NewAllocationPriceFilterField.ItemID,
                    Operator = Models::NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        long expectedPlanPhaseOrder = 0;
        ReplacePricePrice expectedPrice = new Models::NewPlanUnitPrice()
        {
            Cadence = Models::NewPlanUnitPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Models::NewPlanUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedAllocationPrice, model.AllocationPrice);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPrice, model.Price);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePrice>(json);
        Assert.NotNull(deserialized);

        string expectedReplacesPriceID = "replaces_price_id";
        Models::NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Models::Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = Models::CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = Models::NewAllocationPriceFilterField.ItemID,
                    Operator = Models::NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        long expectedPlanPhaseOrder = 0;
        ReplacePricePrice expectedPrice = new Models::NewPlanUnitPrice()
        {
            Cadence = Models::NewPlanUnitPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Models::NewPlanUnitPriceModelType.Unit,
            Name = "Annual fee",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        Assert.Equal(expectedReplacesPriceID, deserialized.ReplacesPriceID);
        Assert.Equal(expectedAllocationPrice, deserialized.AllocationPrice);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedPrice, deserialized.Price);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Models::Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = Models::NewAllocationPriceFilterField.ItemID,
                        Operator = Models::NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            PlanPhaseOrder = 0,
            Price = new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePrice { ReplacesPriceID = "replaces_price_id" };

        Assert.Null(model.AllocationPrice);
        Assert.False(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePrice { ReplacesPriceID = "replaces_price_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",

            AllocationPrice = null,
            PlanPhaseOrder = null,
            Price = null,
        };

        Assert.Null(model.AllocationPrice);
        Assert.True(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",

            AllocationPrice = null,
            PlanPhaseOrder = null,
            Price = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceTest : TestBase
{
    [Fact]
    public void NewPlanUnitValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPrice()
            {
                Cadence = Models::NewPlanTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPriceModelType.Tiered,
                Name = "Annual fee",
                TieredConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ],
                    Prorated = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanBulkValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Models::NewPlanBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkPriceModelType.Bulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceBulkWithFilters()
            {
                BulkWithFiltersConfig = new()
                {
                    Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                    Tiers =
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanPackageValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanPackagePrice()
            {
                Cadence = Models::NewPlanPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixPrice()
            {
                Cadence = Models::NewPlanMatrixPriceCadence.Annual,
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixPriceModelType.Matrix,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanThresholdTotalAmountValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanThresholdTotalAmountPrice()
            {
                Cadence = Models::NewPlanThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
                Name = "Annual fee",
                ThresholdTotalAmountConfig = new()
                {
                    ConsumptionTable =
                    [
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    ],
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredPackageValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPackagePrice()
            {
                Cadence = Models::NewPlanTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPackagePriceModelType.TieredPackage,
                Name = "Annual fee",
                TieredPackageConfig = new()
                {
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredWithMinimumValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredWithMinimumPriceModelType.TieredWithMinimum,
                Name = "Annual fee",
                TieredWithMinimumConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    HideZeroAmountTiers = true,
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedTieredValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedTieredPrice()
            {
                Cadence = Models::NewPlanGroupedTieredPriceCadence.Annual,
                GroupedTieredConfig = new()
                {
                    GroupingKey = "x",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanTieredPackageWithMinimumValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPackageWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
                Name = "Annual fee",
                TieredPackageWithMinimumConfig = new()
                {
                    PackageSize = 0,
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanPackageWithAllocationValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanPackageWithAllocationPrice()
            {
                Cadence = Models::NewPlanPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanPackageWithAllocationPriceModelType.PackageWithAllocation,
                Name = "Annual fee",
                PackageWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    PackageAmount = "package_amount",
                    PackageSize = "package_size",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitWithPercentValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitWithPercentPrice()
            {
                Cadence = Models::NewPlanUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixWithAllocationValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixWithAllocationPrice()
            {
                Cadence = Models::NewPlanMatrixWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredWithProrationValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceTieredWithProration()
            {
                Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitWithProrationValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitWithProrationPrice()
            {
                Cadence = Models::NewPlanUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedAllocationValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedAllocationPrice()
            {
                Cadence = Models::NewPlanGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanBulkWithProrationValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Models::NewPlanBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedWithProratedMinimumValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedWithProratedMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedWithMeteredMinimumValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedWithMeteredMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceGroupedWithMinMaxThresholds()
            {
                Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
                GroupedWithMinMaxThresholdsConfig = new()
                {
                    GroupingKey = "x",
                    MaximumCharge = "maximum_charge",
                    MinimumCharge = "minimum_charge",
                    PerUnitRate = "per_unit_rate",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMatrixWithDisplayNameValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixWithDisplayNamePrice()
            {
                Cadence = Models::NewPlanMatrixWithDisplayNamePriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithDisplayNameConfig = new()
                {
                    Dimension = "dimension",
                    UnitAmounts =
                    [
                        new()
                        {
                            DimensionValue = "dimension_value",
                            DisplayName = "display_name",
                            UnitAmount = "unit_amount",
                        },
                    ],
                },
                ModelType =
                    Models::NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanGroupedTieredPackageValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedTieredPackagePrice()
            {
                Cadence = Models::NewPlanGroupedTieredPackagePriceCadence.Annual,
                GroupedTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMaxGroupTieredPackageValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMaxGroupTieredPackagePrice()
            {
                Cadence = Models::NewPlanMaxGroupTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                MaxGroupTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ModelType =
                    Models::NewPlanMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanScalableMatrixWithUnitPricingValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanScalableMatrixWithUnitPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
                Name = "Annual fee",
                ScalableMatrixWithUnitPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    UnitPrice = "unit_price",
                    Prorate = true,
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanScalableMatrixWithTieredPricingValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanScalableMatrixWithTieredPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
                Name = "Annual fee",
                ScalableMatrixWithTieredPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanCumulativeGroupedBulkValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanCumulativeGroupedBulkPrice()
            {
                Cadence = Models::NewPlanCumulativeGroupedBulkPriceCadence.Annual,
                CumulativeGroupedBulkConfig = new()
                {
                    DimensionValues =
                    [
                        new()
                        {
                            GroupingKey = "x",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    Group = "group",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceCumulativeGroupedAllocation()
            {
                Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
                CumulativeGroupedAllocationConfig = new()
                {
                    CumulativeAllocation = "cumulative_allocation",
                    GroupAllocation = "group_allocation",
                    GroupingKey = "x",
                    UnitAmount = "unit_amount",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanMinimumCompositeValidationWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMinimumCompositePrice()
            {
                Cadence = Models::NewPlanMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = Models::NewPlanMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePricePercent()
            {
                Cadence = ReplacePricePricePercentCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceEventOutput()
            {
                Cadence = ReplacePricePriceEventOutputCadence.Annual,
                EventOutputConfig = new()
                {
                    UnitRatingKey = "x",
                    DefaultUnitRate = "default_unit_rate",
                    GroupingKey = "grouping_key",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void NewPlanUnitSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitPrice()
            {
                Cadence = Models::NewPlanUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPrice()
            {
                Cadence = Models::NewPlanTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPriceModelType.Tiered,
                Name = "Annual fee",
                TieredConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ],
                    Prorated = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanBulkSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Models::NewPlanBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkPriceModelType.Bulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceBulkWithFilters()
            {
                BulkWithFiltersConfig = new()
                {
                    Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                    Tiers =
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanPackageSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanPackagePrice()
            {
                Cadence = Models::NewPlanPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixPrice()
            {
                Cadence = Models::NewPlanMatrixPriceCadence.Annual,
                ItemID = "item_id",
                MatrixConfig = new()
                {
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixPriceModelType.Matrix,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanThresholdTotalAmountSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanThresholdTotalAmountPrice()
            {
                Cadence = Models::NewPlanThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
                Name = "Annual fee",
                ThresholdTotalAmountConfig = new()
                {
                    ConsumptionTable =
                    [
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                        new() { Threshold = "threshold", TotalAmount = "total_amount" },
                    ],
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredPackageSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPackagePrice()
            {
                Cadence = Models::NewPlanTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredPackagePriceModelType.TieredPackage,
                Name = "Annual fee",
                TieredPackageConfig = new()
                {
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredWithMinimumSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanTieredWithMinimumPriceModelType.TieredWithMinimum,
                Name = "Annual fee",
                TieredWithMinimumConfig = new()
                {
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    HideZeroAmountTiers = true,
                    Prorate = true,
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedTieredSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedTieredPrice()
            {
                Cadence = Models::NewPlanGroupedTieredPriceCadence.Annual,
                GroupedTieredConfig = new()
                {
                    GroupingKey = "x",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPriceModelType.GroupedTiered,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanTieredPackageWithMinimumPrice()
            {
                Cadence = Models::NewPlanTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
                Name = "Annual fee",
                TieredPackageWithMinimumConfig = new()
                {
                    PackageSize = 0,
                    Tiers =
                    [
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                        new()
                        {
                            MinimumAmount = "minimum_amount",
                            PerUnit = "per_unit",
                            TierLowerBound = "tier_lower_bound",
                        },
                    ],
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanPackageWithAllocationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanPackageWithAllocationPrice()
            {
                Cadence = Models::NewPlanPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanPackageWithAllocationPriceModelType.PackageWithAllocation,
                Name = "Annual fee",
                PackageWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    PackageAmount = "package_amount",
                    PackageSize = "package_size",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanUnitWithPercentSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitWithPercentPrice()
            {
                Cadence = Models::NewPlanUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixWithAllocationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixWithAllocationPrice()
            {
                Cadence = Models::NewPlanMatrixWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithAllocationConfig = new()
                {
                    Allocation = "allocation",
                    DefaultUnitAmount = "default_unit_amount",
                    Dimensions = ["string"],
                    MatrixValues =
                    [
                        new() { DimensionValues = ["string"], UnitAmount = "unit_amount" },
                    ],
                },
                ModelType = Models::NewPlanMatrixWithAllocationPriceModelType.MatrixWithAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceTieredWithProration()
            {
                Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                TieredWithProrationConfig = new(
                    [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
                ),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanUnitWithProrationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanUnitWithProrationPrice()
            {
                Cadence = Models::NewPlanUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedAllocationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedAllocationPrice()
            {
                Cadence = Models::NewPlanGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedAllocationPriceModelType.GroupedAllocation,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanBulkWithProrationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Models::NewPlanBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Models::NewPlanBulkWithProrationPriceModelType.BulkWithProration,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedWithProratedMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedWithMeteredMinimumPrice()
            {
                Cadence = Models::NewPlanGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new() { ScalingFactor = "scaling_factor", ScalingValue = "scaling_value" },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmount = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceGroupedWithMinMaxThresholds()
            {
                Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
                GroupedWithMinMaxThresholdsConfig = new()
                {
                    GroupingKey = "x",
                    MaximumCharge = "maximum_charge",
                    MinimumCharge = "minimum_charge",
                    PerUnitRate = "per_unit_rate",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMatrixWithDisplayNamePrice()
            {
                Cadence = Models::NewPlanMatrixWithDisplayNamePriceCadence.Annual,
                ItemID = "item_id",
                MatrixWithDisplayNameConfig = new()
                {
                    Dimension = "dimension",
                    UnitAmounts =
                    [
                        new()
                        {
                            DimensionValue = "dimension_value",
                            DisplayName = "display_name",
                            UnitAmount = "unit_amount",
                        },
                    ],
                },
                ModelType =
                    Models::NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanGroupedTieredPackageSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanGroupedTieredPackagePrice()
            {
                Cadence = Models::NewPlanGroupedTieredPackagePriceCadence.Annual,
                GroupedTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                        new() { PerUnit = "per_unit", TierLowerBound = "tier_lower_bound" },
                    ],
                },
                ItemID = "item_id",
                ModelType = Models::NewPlanGroupedTieredPackagePriceModelType.GroupedTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMaxGroupTieredPackagePrice()
            {
                Cadence = Models::NewPlanMaxGroupTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                MaxGroupTieredPackageConfig = new()
                {
                    GroupingKey = "x",
                    PackageSize = "package_size",
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                },
                ModelType =
                    Models::NewPlanMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanScalableMatrixWithUnitPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
                Name = "Annual fee",
                ScalableMatrixWithUnitPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    UnitPrice = "unit_price",
                    Prorate = true,
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanScalableMatrixWithTieredPricingPrice()
            {
                Cadence = Models::NewPlanScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
                Name = "Annual fee",
                ScalableMatrixWithTieredPricingConfig = new()
                {
                    FirstDimension = "first_dimension",
                    MatrixScalingFactors =
                    [
                        new()
                        {
                            FirstDimensionValue = "first_dimension_value",
                            ScalingFactor = "scaling_factor",
                            SecondDimensionValue = "second_dimension_value",
                        },
                    ],
                    Tiers =
                    [
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                        new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
                    ],
                    SecondDimension = "second_dimension",
                },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanCumulativeGroupedBulkPrice()
            {
                Cadence = Models::NewPlanCumulativeGroupedBulkPriceCadence.Annual,
                CumulativeGroupedBulkConfig = new()
                {
                    DimensionValues =
                    [
                        new()
                        {
                            GroupingKey = "x",
                            TierLowerBound = "tier_lower_bound",
                            UnitAmount = "unit_amount",
                        },
                    ],
                    Group = "group",
                },
                ItemID = "item_id",
                ModelType =
                    Models::NewPlanCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceCumulativeGroupedAllocation()
            {
                Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
                CumulativeGroupedAllocationConfig = new()
                {
                    CumulativeAllocation = "cumulative_allocation",
                    GroupAllocation = "group_allocation",
                    GroupingKey = "x",
                    UnitAmount = "unit_amount",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewPlanMinimumCompositeSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new Models::NewPlanMinimumCompositePrice()
            {
                Cadence = Models::NewPlanMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
                ModelType = Models::NewPlanMinimumCompositePriceModelType.Minimum,
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePricePercent()
            {
                Cadence = ReplacePricePricePercentCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                PercentConfig = new(0),
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        ReplacePricePrice value = new(
            new ReplacePricePriceEventOutput()
            {
                Cadence = ReplacePricePriceEventOutputCadence.Annual,
                EventOutputConfig = new()
                {
                    UnitRatingKey = "x",
                    DefaultUnitRate = "default_unit_rate",
                    GroupingKey = "grouping_key",
                },
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                {
                    ConversionRateType =
                        Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                    UnitConfig = new("unit_amount"),
                },
                Currency = "currency",
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePrice>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> expectedCadence =
            ReplacePricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceBulkWithFilters>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceBulkWithFilters>(json);
        Assert.NotNull(deserialized);

        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> expectedCadence =
            ReplacePricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedBulkWithFiltersConfig, deserialized.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceBulkWithFilters
        {
            BulkWithFiltersConfig = new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            },
            Cadence = ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(json);
        Assert.NotNull(deserialized);

        List<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
        [
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
        ];

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        model.Validate();
    }
}

public class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, deserialized.PropertyKey);
        Assert.Equal(expectedPropertyValue, deserialized.PropertyValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        model.Validate();
    }
}

public class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, model.UnitAmount);
        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedUnitAmount = "unit_amount";
        string expectedTierLowerBound = "tier_lower_bound";

        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        Assert.Null(model.TierLowerBound);
        Assert.True(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceBulkWithFiltersCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Annual)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Monthly)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.OneTime)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Custom)]
    public void Validation_Works(ReplacePricePriceBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Annual)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Monthly)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.OneTime)]
    [InlineData(ReplacePricePriceBulkWithFiltersCadence.Custom)]
    public void SerializationRoundtrip_Works(ReplacePricePriceBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceBulkWithFiltersConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePriceBulkWithFiltersConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePriceBulkWithFiltersConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePriceBulkWithFiltersConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePriceBulkWithFiltersConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceTieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> expectedCadence =
            ReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTieredWithProrationConfig, model.TieredWithProrationConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceTieredWithProration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceTieredWithProration>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> expectedCadence =
            ReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTieredWithProrationConfig, deserialized.TieredWithProrationConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceTieredWithProration
        {
            Cadence = ReplacePricePriceTieredWithProrationCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            TieredWithProrationConfig = new(
                [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
            ),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceTieredWithProrationCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Annual)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Monthly)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Quarterly)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.OneTime)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Custom)]
    public void Validation_Works(ReplacePricePriceTieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Annual)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Monthly)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Quarterly)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.OneTime)]
    [InlineData(ReplacePricePriceTieredWithProrationCadence.Custom)]
    public void SerializationRoundtrip_Works(ReplacePricePriceTieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        List<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
        [
            new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" },
        ];

        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        model.Validate();
    }
}

public class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, model.TierLowerBound);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedTierLowerBound = "tier_lower_bound";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedTierLowerBound, deserialized.TierLowerBound);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }
}

public class ReplacePricePriceTieredWithProrationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePriceTieredWithProrationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePriceTieredWithProrationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePriceTieredWithProrationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePriceTieredWithProrationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceGroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> expectedCadence =
            ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            model.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholds>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholds>(
            json
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> expectedCadence =
            ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
            new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedGroupedWithMinMaxThresholdsConfig,
            deserialized.GroupedWithMinMaxThresholdsConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            GroupedWithMinMaxThresholdsConfig = new()
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceGroupedWithMinMaxThresholdsCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(ReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(
        ReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedMaximumCharge, model.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, model.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, model.PerUnitRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedGroupingKey = "x";
        string expectedMaximumCharge = "maximum_charge";
        string expectedMinimumCharge = "minimum_charge";
        string expectedPerUnitRate = "per_unit_rate";

        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedMaximumCharge, deserialized.MaximumCharge);
        Assert.Equal(expectedMinimumCharge, deserialized.MinimumCharge);
        Assert.Equal(expectedPerUnitRate, deserialized.PerUnitRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        model.Validate();
    }
}

public class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceCumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> expectedCadence =
            ReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocation>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocation>(
            json
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> expectedCadence =
            ReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            deserialized.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceCumulativeGroupedAllocationCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(ReplacePricePriceCumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(ReplacePricePriceCumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(
        ReplacePricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, model.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, model.GroupAllocation);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedCumulativeAllocation = "cumulative_allocation";
        string expectedGroupAllocation = "group_allocation";
        string expectedGroupingKey = "x";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedCumulativeAllocation, deserialized.CumulativeAllocation);
        Assert.Equal(expectedGroupAllocation, deserialized.GroupAllocation);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedUnitAmount, deserialized.UnitAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                json
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, ReplacePricePricePercentCadence> expectedCadence =
            ReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        ReplacePricePricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercent>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ReplacePricePricePercentCadence> expectedCadence =
            ReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        ReplacePricePricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentConfig, deserialized.PercentConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePricePercent
        {
            Cadence = ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePricePercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePricePercentCadence.Annual)]
    [InlineData(ReplacePricePricePercentCadence.SemiAnnual)]
    [InlineData(ReplacePricePricePercentCadence.Monthly)]
    [InlineData(ReplacePricePricePercentCadence.Quarterly)]
    [InlineData(ReplacePricePricePercentCadence.OneTime)]
    [InlineData(ReplacePricePricePercentCadence.Custom)]
    public void Validation_Works(ReplacePricePricePercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePricePercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReplacePricePricePercentCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePricePercentCadence.Annual)]
    [InlineData(ReplacePricePricePercentCadence.SemiAnnual)]
    [InlineData(ReplacePricePricePercentCadence.Monthly)]
    [InlineData(ReplacePricePricePercentCadence.Quarterly)]
    [InlineData(ReplacePricePricePercentCadence.OneTime)]
    [InlineData(ReplacePricePricePercentCadence.Custom)]
    public void SerializationRoundtrip_Works(ReplacePricePricePercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePricePercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReplacePricePricePercentCadence>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePricePercentPercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePricePercentPercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercentPercentConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePricePercentPercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercentPercentConfig>(json);
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePricePercentPercentConfig { Percent = 0 };

        model.Validate();
    }
}

public class ReplacePricePricePercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePricePercentConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePricePercentConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePricePercentConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercentConversionRateConfig>(
            json
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePricePercentConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercentConversionRateConfig>(
            json
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, ReplacePricePriceEventOutputCadence> expectedCadence =
            ReplacePricePriceEventOutputCadence.Annual;
        ReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceEventOutput>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ReplacePricePriceEventOutput>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ReplacePricePriceEventOutputCadence> expectedCadence =
            ReplacePricePriceEventOutputCadence.Annual;
        ReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig = new()
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        Models::NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        ReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        Models::NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        Models::NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedEventOutputConfig, deserialized.EventOutputConfig);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(
            expectedDimensionalPriceConfiguration,
            deserialized.DimensionalPriceConfiguration
        );
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, deserialized.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, deserialized.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = Models::NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        Assert.Null(model.BillableMetricID);
        Assert.False(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.False(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.False(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.False(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.False(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.False(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.False(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        Assert.Null(model.BillableMetricID);
        Assert.True(model.RawData.ContainsKey("billable_metric_id"));
        Assert.Null(model.BilledInAdvance);
        Assert.True(model.RawData.ContainsKey("billed_in_advance"));
        Assert.Null(model.BillingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("billing_cycle_configuration"));
        Assert.Null(model.ConversionRate);
        Assert.True(model.RawData.ContainsKey("conversion_rate"));
        Assert.Null(model.ConversionRateConfig);
        Assert.True(model.RawData.ContainsKey("conversion_rate_config"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.DimensionalPriceConfiguration);
        Assert.True(model.RawData.ContainsKey("dimensional_price_configuration"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.InvoiceGroupingKey);
        Assert.True(model.RawData.ContainsKey("invoice_grouping_key"));
        Assert.Null(model.InvoicingCycleConfiguration);
        Assert.True(model.RawData.ContainsKey("invoicing_cycle_configuration"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("reference_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceEventOutput
        {
            Cadence = ReplacePricePriceEventOutputCadence.Annual,
            EventOutputConfig = new()
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            },
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            Currency = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
            ReferenceID = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(ReplacePricePriceEventOutputCadence.Annual)]
    [InlineData(ReplacePricePriceEventOutputCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceEventOutputCadence.Monthly)]
    [InlineData(ReplacePricePriceEventOutputCadence.Quarterly)]
    [InlineData(ReplacePricePriceEventOutputCadence.OneTime)]
    [InlineData(ReplacePricePriceEventOutputCadence.Custom)]
    public void Validation_Works(ReplacePricePriceEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceEventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceEventOutputCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReplacePricePriceEventOutputCadence.Annual)]
    [InlineData(ReplacePricePriceEventOutputCadence.SemiAnnual)]
    [InlineData(ReplacePricePriceEventOutputCadence.Monthly)]
    [InlineData(ReplacePricePriceEventOutputCadence.Quarterly)]
    [InlineData(ReplacePricePriceEventOutputCadence.OneTime)]
    [InlineData(ReplacePricePriceEventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(ReplacePricePriceEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReplacePricePriceEventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceEventOutputCadence>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ReplacePricePriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceEventOutputEventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, model.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, model.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceEventOutputEventOutputConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceEventOutputEventOutputConfig>(json);
        Assert.NotNull(deserialized);

        string expectedUnitRatingKey = "x";
        string expectedDefaultUnitRate = "default_unit_rate";
        string expectedGroupingKey = "grouping_key";

        Assert.Equal(expectedUnitRatingKey, deserialized.UnitRatingKey);
        Assert.Equal(expectedDefaultUnitRate, deserialized.DefaultUnitRate);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig { UnitRatingKey = "x" };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig { UnitRatingKey = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        Assert.Null(model.DefaultUnitRate);
        Assert.True(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.True(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceEventOutputConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        ReplacePricePriceEventOutputConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        ReplacePricePriceEventOutputConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        ReplacePricePriceEventOutputConversionRateConfig value = new(
            new Models::SharedUnitConversionRateConfig()
            {
                ConversionRateType = Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceEventOutputConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        ReplacePricePriceEventOutputConversionRateConfig value = new(
            new Models::SharedTieredConversionRateConfig()
            {
                ConversionRateType = Models::ConversionRateType.Tiered,
                TieredConfig = new(
                    [
                        new()
                        {
                            FirstUnit = 0,
                            UnitAmount = "unit_amount",
                            LastUnit = 0,
                        },
                    ]
                ),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized =
            JsonSerializer.Deserialize<ReplacePricePriceEventOutputConversionRateConfig>(json);

        Assert.Equal(value, deserialized);
    }
}
