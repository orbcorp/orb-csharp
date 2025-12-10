using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionSchedulePlanChangeParamsChangeOptionTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate)]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.EndOfSubscriptionTerm
    )]
    [InlineData(Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.Immediate)]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate)]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.EndOfSubscriptionTerm
    )]
    [InlineData(Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.Immediate)]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhaseOrder = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            };
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedPlanPhaseOrder = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhaseOrder = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhaseOrder = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment>(
                json
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            };
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedPlanPhaseOrder = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanPhaseOrder = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
        };

        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },

            EndDate = null,
            PlanPhaseOrder = null,
            StartDate = null,
        };

        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.StartDate);
        Assert.True(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },

            EndDate = null,
            PlanPhaseOrder = null,
            StartDate = null,
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            PlanPhaseOrder = 0,
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        List<Subscriptions::DiscountOverride> expectedDiscounts =
        [
            new()
            {
                DiscountType = Subscriptions::DiscountType.Percentage,
                AmountDiscount = "amount_discount",
                PercentageDiscount = 0.15,
                UsageDiscount = 0,
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalPriceID = "external_price_id";
        string expectedMaximumAmount = "1.23";
        string expectedMinimumAmount = "1.23";
        long expectedPlanPhaseOrder = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice expectedPrice =
            new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };
        string expectedPriceID = "h74gfhdjvn7ujokd";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAllocationPrice, model.AllocationPrice);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPlanPhaseOrder, model.PlanPhaseOrder);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            PlanPhaseOrder = 0,
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            PlanPhaseOrder = 0,
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice>(
                json
            );
        Assert.NotNull(deserialized);

        NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        List<Subscriptions::DiscountOverride> expectedDiscounts =
        [
            new()
            {
                DiscountType = Subscriptions::DiscountType.Percentage,
                AmountDiscount = "amount_discount",
                PercentageDiscount = 0.15,
                UsageDiscount = 0,
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalPriceID = "external_price_id";
        string expectedMaximumAmount = "1.23";
        string expectedMinimumAmount = "1.23";
        long expectedPlanPhaseOrder = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice expectedPrice =
            new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };
        string expectedPriceID = "h74gfhdjvn7ujokd";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAllocationPrice, deserialized.AllocationPrice);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedPlanPhaseOrder, deserialized.PlanPhaseOrder);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            PlanPhaseOrder = 0,
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice { };

        Assert.Null(model.AllocationPrice);
        Assert.False(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.MaximumAmount);
        Assert.False(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.False(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.False(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = null,
            Discounts = null,
            EndDate = null,
            ExternalPriceID = null,
            MaximumAmount = null,
            MinimumAmount = null,
            PlanPhaseOrder = null,
            Price = null,
            PriceID = null,
            StartDate = null,
        };

        Assert.Null(model.AllocationPrice);
        Assert.True(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.Discounts);
        Assert.True(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.MaximumAmount);
        Assert.True(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.True(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.PlanPhaseOrder);
        Assert.True(model.RawData.ContainsKey("plan_phase_order"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
        Assert.Null(model.StartDate);
        Assert.True(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice
        {
            AllocationPrice = null,
            Discounts = null,
            EndDate = null,
            ExternalPriceID = null,
            MaximumAmount = null,
            MinimumAmount = null,
            PlanPhaseOrder = null,
            Price = null,
            PriceID = null,
            StartDate = null,
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>(
                json
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilterTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTierTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",

                TierLowerBound = null,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTierTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
            {
                Percent = 0,
            };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
            {
                Percent = 0,
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
            {
                Percent = 0,
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>(
                json
            );
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig
            {
                Percent = 0,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>(
                json
            );
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",

                DefaultUnitRate = null,
                GroupingKey = null,
            };

        model.Validate();
    }
}

public class BillingCycleAlignmentTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::BillingCycleAlignment.Unchanged)]
    [InlineData(Subscriptions::BillingCycleAlignment.PlanChangeDate)]
    [InlineData(Subscriptions::BillingCycleAlignment.StartOfMonth)]
    public void Validation_Works(Subscriptions::BillingCycleAlignment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingCycleAlignment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAlignment>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::BillingCycleAlignment.Unchanged)]
    [InlineData(Subscriptions::BillingCycleAlignment.PlanChangeDate)]
    [InlineData(Subscriptions::BillingCycleAlignment.StartOfMonth)]
    public void SerializationRoundtrip_Works(Subscriptions::BillingCycleAlignment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::BillingCycleAlignment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAlignment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAlignment>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::BillingCycleAlignment>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsRemoveAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment
        {
            AdjustmentID = "h74gfhdjvn7ujokd",
        };

        string expectedAdjustmentID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedAdjustmentID, model.AdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment
        {
            AdjustmentID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment
        {
            AdjustmentID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedAdjustmentID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedAdjustmentID, deserialized.AdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment
        {
            AdjustmentID = "h74gfhdjvn7ujokd",
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsRemovePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        string expectedExternalPriceID = "external_price_id";
        string expectedPriceID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedPriceID, model.PriceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedExternalPriceID = "external_price_id";
        string expectedPriceID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice { };

        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = null,
            PriceID = null,
        };

        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice
        {
            ExternalPriceID = null,
            PriceID = null,
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplaceAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            };
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(expectedReplacesAdjustmentID, model.ReplacesAdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment>(
                json
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            };
        string expectedReplacesAdjustmentID = "replaces_adjustment_id";

        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(expectedReplacesAdjustmentID, deserialized.ReplacesAdjustmentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment
        {
            Adjustment = new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIDs = ["item_1", "item_2"],
                AppliesToPriceIDs = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewPercentageDiscountFilterField.PriceID,
                        Operator = NewPercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewPercentageDiscountPriceType.Usage,
            },
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 2,
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
        };

        string expectedReplacesPriceID = "replaces_price_id";
        NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        List<Subscriptions::DiscountOverride> expectedDiscounts =
        [
            new()
            {
                DiscountType = Subscriptions::DiscountType.Percentage,
                AmountDiscount = "amount_discount",
                PercentageDiscount = 0.15,
                UsageDiscount = 0,
            },
        ];
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 2;
        string expectedMaximumAmount = "1.23";
        string expectedMinimumAmount = "1.23";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice expectedPrice =
            new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };
        string expectedPriceID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedReplacesPriceID, model.ReplacesPriceID);
        Assert.Equal(expectedAllocationPrice, model.AllocationPrice);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceID, model.PriceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 2,
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 2,
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice>(
                json
            );
        Assert.NotNull(deserialized);

        string expectedReplacesPriceID = "replaces_price_id";
        NewAllocationPrice expectedAllocationPrice = new()
        {
            Amount = "10.00",
            Cadence = Cadence.Monthly,
            Currency = "USD",
            CustomExpiration = new()
            {
                Duration = 0,
                DurationUnit = CustomExpirationDurationUnit.Day,
            },
            ExpiresAtEndOfCadence = true,
            Filters =
            [
                new()
                {
                    Field = NewAllocationPriceFilterField.ItemID,
                    Operator = NewAllocationPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ItemID = "item_id",
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        List<Subscriptions::DiscountOverride> expectedDiscounts =
        [
            new()
            {
                DiscountType = Subscriptions::DiscountType.Percentage,
                AmountDiscount = "amount_discount",
                PercentageDiscount = 0.15,
                UsageDiscount = 0,
            },
        ];
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 2;
        string expectedMaximumAmount = "1.23";
        string expectedMinimumAmount = "1.23";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice expectedPrice =
            new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };
        string expectedPriceID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedReplacesPriceID, deserialized.ReplacesPriceID);
        Assert.Equal(expectedAllocationPrice, deserialized.AllocationPrice);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, deserialized.FixedPriceQuantity);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
            AllocationPrice = new()
            {
                Amount = "10.00",
                Cadence = Cadence.Monthly,
                Currency = "USD",
                CustomExpiration = new()
                {
                    Duration = 0,
                    DurationUnit = CustomExpirationDurationUnit.Day,
                },
                ExpiresAtEndOfCadence = true,
                Filters =
                [
                    new()
                    {
                        Field = NewAllocationPriceFilterField.ItemID,
                        Operator = NewAllocationPriceFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                ItemID = "item_id",
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Discounts =
            [
                new()
                {
                    DiscountType = Subscriptions::DiscountType.Percentage,
                    AmountDiscount = "amount_discount",
                    PercentageDiscount = 0.15,
                    UsageDiscount = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 2,
            MaximumAmount = "1.23",
            MinimumAmount = "1.23",
            Price = new Subscriptions::NewSubscriptionUnitPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionUnitPriceModelType.Unit,
                Name = "Annual fee",
                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            },
            PriceID = "h74gfhdjvn7ujokd",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
        };

        Assert.Null(model.AllocationPrice);
        Assert.False(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.False(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.MaximumAmount);
        Assert.False(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.False(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",

            AllocationPrice = null,
            Discounts = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            MaximumAmount = null,
            MinimumAmount = null,
            Price = null,
            PriceID = null,
        };

        Assert.Null(model.AllocationPrice);
        Assert.True(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.Discounts);
        Assert.True(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.FixedPriceQuantity);
        Assert.True(model.RawData.ContainsKey("fixed_price_quantity"));
        Assert.Null(model.MaximumAmount);
        Assert.True(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.True(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice
        {
            ReplacesPriceID = "replaces_price_id",

            AllocationPrice = null,
            Discounts = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            MaximumAmount = null,
            MinimumAmount = null,
            Price = null,
            PriceID = null,
        };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>(
                json
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"bulk_with_filters\""
        );
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
                BillableMetricID = "billable_metric_id",
                BilledInAdvance = true,
                BillingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
                ItemID = "item_id",
                Name = "Annual fee",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters
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
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
            {
                PropertyKey = "x",
                PropertyValue = "x",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
                TierLowerBound = "tier_lower_bound",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
            {
                UnitAmount = "unit_amount",

                TierLowerBound = null,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"tiered_with_proration\""
        );
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig
            {
                Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTierTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadenceTest
    : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
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
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
        string expectedName = "Annual fee";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig expectedPercentConfig =
            new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
            {
                Percent = 0,
            };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
            {
                Percent = 0,
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
            {
                Percent = 0,
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>(
                json
            );
        Assert.NotNull(deserialized);

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, deserialized.Percent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig
            {
                Percent = 0,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
            new()
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
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                ConversionRate = 0,
                ConversionRateConfig = new SharedUnitConversionRateConfig()
                {
                    ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                ReferenceID = "reference_id",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual,
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
            >
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
                DefaultUnitRate = "default_unit_rate",
                GroupingKey = "grouping_key",
            };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>(
                json
            );
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
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
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig
            {
                UnitRatingKey = "x",

                DefaultUnitRate = null,
                GroupingKey = null,
            };

        model.Validate();
    }
}
