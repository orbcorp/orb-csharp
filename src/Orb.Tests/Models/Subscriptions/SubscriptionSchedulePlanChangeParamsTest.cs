using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionSchedulePlanChangeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionSchedulePlanChangeParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption =
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate,
            AddAdjustments =
            [
                new()
                {
                    Adjustment = new NewPercentageDiscount()
                    {
                        AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                        PercentageDiscount = 0,
                        AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                        AppliesToItemIds = ["item_1", "item_2"],
                        AppliesToPriceIds = ["price_1", "price_2"],
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
                },
            ],
            AddPrices =
            [
                new()
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
                            ConversionRateType =
                                SharedUnitConversionRateConfigConversionRateType.Unit,
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
                },
            ],
            AlignBillingWithPlanChangeDate = true,
            AutoCollection = true,
            BillingCycleAlignment = Subscriptions::BillingCycleAlignment.Unchanged,
            BillingCycleAnchorConfiguration = new()
            {
                Day = 1,
                Month = 1,
                Year = 0,
            },
            ChangeDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z"),
            CouponRedemptionCode = "coupon_redemption_code",
            CreditsOverageRate = 0,
            DefaultInvoiceMemo = "default_invoice_memo",
            ExternalPlanID = "ZMwNQefe7J3ecf7W",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            InitialPhaseOrder = 2,
            InvoicingThreshold = "10.00",
            NetTerms = 0,
            PerCreditOverageAmount = 0,
            PlanID = "ZMwNQefe7J3ecf7W",
            PlanVersionNumber = 0,
            PriceOverrides = [JsonSerializer.Deserialize<JsonElement>("{}")],
            RemoveAdjustments = [new("h74gfhdjvn7ujokd")],
            RemovePrices =
            [
                new() { ExternalPriceID = "external_price_id", PriceID = "h74gfhdjvn7ujokd" },
            ],
            ReplaceAdjustments =
            [
                new()
                {
                    Adjustment = new NewPercentageDiscount()
                    {
                        AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                        PercentageDiscount = 0,
                        AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                        AppliesToItemIds = ["item_1", "item_2"],
                        AppliesToPriceIds = ["price_1", "price_2"],
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
                },
            ],
            ReplacePrices =
            [
                new()
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
                            ConversionRateType =
                                SharedUnitConversionRateConfigConversionRateType.Unit,
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
                },
            ],
            TrialDurationDays = 0,
            UsageCustomerIds = ["string"],
        };

        string expectedSubscriptionID = "subscription_id";
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption
        > expectedChangeOption =
            Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate;
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment> expectedAddAdjustments =
        [
            new()
            {
                Adjustment = new NewPercentageDiscount()
                {
                    AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                    PercentageDiscount = 0,
                    AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                    AppliesToItemIds = ["item_1", "item_2"],
                    AppliesToPriceIds = ["price_1", "price_2"],
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
            },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice> expectedAddPrices =
        [
            new()
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
            },
        ];
        bool expectedAlignBillingWithPlanChangeDate = true;
        bool expectedAutoCollection = true;
        ApiEnum<string, Subscriptions::BillingCycleAlignment> expectedBillingCycleAlignment =
            Subscriptions::BillingCycleAlignment.Unchanged;
        BillingCycleAnchorConfiguration expectedBillingCycleAnchorConfiguration = new()
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };
        DateTimeOffset expectedChangeDate = DateTimeOffset.Parse("2017-07-21T17:32:28Z");
        string expectedCouponRedemptionCode = "coupon_redemption_code";
        double expectedCreditsOverageRate = 0;
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        string expectedExternalPlanID = "ZMwNQefe7J3ecf7W";
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        long expectedInitialPhaseOrder = 2;
        string expectedInvoicingThreshold = "10.00";
        long expectedNetTerms = 0;
        double expectedPerCreditOverageAmount = 0;
        string expectedPlanID = "ZMwNQefe7J3ecf7W";
        long expectedPlanVersionNumber = 0;
        List<JsonElement> expectedPriceOverrides = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment> expectedRemoveAdjustments =
        [
            new("h74gfhdjvn7ujokd"),
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice> expectedRemovePrices =
        [
            new() { ExternalPriceID = "external_price_id", PriceID = "h74gfhdjvn7ujokd" },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment> expectedReplaceAdjustments =
        [
            new()
            {
                Adjustment = new NewPercentageDiscount()
                {
                    AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                    PercentageDiscount = 0,
                    AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                    AppliesToItemIds = ["item_1", "item_2"],
                    AppliesToPriceIds = ["price_1", "price_2"],
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
            },
        ];
        List<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice> expectedReplacePrices =
        [
            new()
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
            },
        ];
        long expectedTrialDurationDays = 0;
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedChangeOption, parameters.ChangeOption);
        Assert.NotNull(parameters.AddAdjustments);
        Assert.Equal(expectedAddAdjustments.Count, parameters.AddAdjustments.Count);
        for (int i = 0; i < expectedAddAdjustments.Count; i++)
        {
            Assert.Equal(expectedAddAdjustments[i], parameters.AddAdjustments[i]);
        }
        Assert.NotNull(parameters.AddPrices);
        Assert.Equal(expectedAddPrices.Count, parameters.AddPrices.Count);
        for (int i = 0; i < expectedAddPrices.Count; i++)
        {
            Assert.Equal(expectedAddPrices[i], parameters.AddPrices[i]);
        }
        Assert.Equal(
            expectedAlignBillingWithPlanChangeDate,
            parameters.AlignBillingWithPlanChangeDate
        );
        Assert.Equal(expectedAutoCollection, parameters.AutoCollection);
        Assert.Equal(expectedBillingCycleAlignment, parameters.BillingCycleAlignment);
        Assert.Equal(
            expectedBillingCycleAnchorConfiguration,
            parameters.BillingCycleAnchorConfiguration
        );
        Assert.Equal(expectedChangeDate, parameters.ChangeDate);
        Assert.Equal(expectedCouponRedemptionCode, parameters.CouponRedemptionCode);
        Assert.Equal(expectedCreditsOverageRate, parameters.CreditsOverageRate);
        Assert.Equal(expectedDefaultInvoiceMemo, parameters.DefaultInvoiceMemo);
        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedInitialPhaseOrder, parameters.InitialPhaseOrder);
        Assert.Equal(expectedInvoicingThreshold, parameters.InvoicingThreshold);
        Assert.Equal(expectedNetTerms, parameters.NetTerms);
        Assert.Equal(expectedPerCreditOverageAmount, parameters.PerCreditOverageAmount);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedPlanVersionNumber, parameters.PlanVersionNumber);
        Assert.NotNull(parameters.PriceOverrides);
        Assert.Equal(expectedPriceOverrides.Count, parameters.PriceOverrides.Count);
        for (int i = 0; i < expectedPriceOverrides.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedPriceOverrides[i], parameters.PriceOverrides[i])
            );
        }
        Assert.NotNull(parameters.RemoveAdjustments);
        Assert.Equal(expectedRemoveAdjustments.Count, parameters.RemoveAdjustments.Count);
        for (int i = 0; i < expectedRemoveAdjustments.Count; i++)
        {
            Assert.Equal(expectedRemoveAdjustments[i], parameters.RemoveAdjustments[i]);
        }
        Assert.NotNull(parameters.RemovePrices);
        Assert.Equal(expectedRemovePrices.Count, parameters.RemovePrices.Count);
        for (int i = 0; i < expectedRemovePrices.Count; i++)
        {
            Assert.Equal(expectedRemovePrices[i], parameters.RemovePrices[i]);
        }
        Assert.NotNull(parameters.ReplaceAdjustments);
        Assert.Equal(expectedReplaceAdjustments.Count, parameters.ReplaceAdjustments.Count);
        for (int i = 0; i < expectedReplaceAdjustments.Count; i++)
        {
            Assert.Equal(expectedReplaceAdjustments[i], parameters.ReplaceAdjustments[i]);
        }
        Assert.NotNull(parameters.ReplacePrices);
        Assert.Equal(expectedReplacePrices.Count, parameters.ReplacePrices.Count);
        for (int i = 0; i < expectedReplacePrices.Count; i++)
        {
            Assert.Equal(expectedReplacePrices[i], parameters.ReplacePrices[i]);
        }
        Assert.Equal(expectedTrialDurationDays, parameters.TrialDurationDays);
        Assert.NotNull(parameters.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, parameters.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], parameters.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionSchedulePlanChangeParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption =
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate,
        };

        Assert.Null(parameters.AddAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.AddPrices);
        Assert.False(parameters.RawBodyData.ContainsKey("add_prices"));
        Assert.Null(parameters.AlignBillingWithPlanChangeDate);
        Assert.False(parameters.RawBodyData.ContainsKey("align_billing_with_plan_change_date"));
        Assert.Null(parameters.AutoCollection);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.BillingCycleAlignment);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_cycle_alignment"));
        Assert.Null(parameters.BillingCycleAnchorConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_cycle_anchor_configuration"));
        Assert.Null(parameters.ChangeDate);
        Assert.False(parameters.RawBodyData.ContainsKey("change_date"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
        Assert.Null(parameters.CreditsOverageRate);
        Assert.False(parameters.RawBodyData.ContainsKey("credits_overage_rate"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.False(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.InitialPhaseOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_phase_order"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.NetTerms);
        Assert.False(parameters.RawBodyData.ContainsKey("net_terms"));
        Assert.Null(parameters.PerCreditOverageAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("per_credit_overage_amount"));
        Assert.Null(parameters.PlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("plan_id"));
        Assert.Null(parameters.PlanVersionNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("plan_version_number"));
        Assert.Null(parameters.PriceOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("price_overrides"));
        Assert.Null(parameters.RemoveAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("remove_adjustments"));
        Assert.Null(parameters.RemovePrices);
        Assert.False(parameters.RawBodyData.ContainsKey("remove_prices"));
        Assert.Null(parameters.ReplaceAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("replace_adjustments"));
        Assert.Null(parameters.ReplacePrices);
        Assert.False(parameters.RawBodyData.ContainsKey("replace_prices"));
        Assert.Null(parameters.TrialDurationDays);
        Assert.False(parameters.RawBodyData.ContainsKey("trial_duration_days"));
        Assert.Null(parameters.UsageCustomerIds);
        Assert.False(parameters.RawBodyData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Subscriptions::SubscriptionSchedulePlanChangeParams
        {
            SubscriptionID = "subscription_id",
            ChangeOption =
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate,

            AddAdjustments = null,
            AddPrices = null,
            AlignBillingWithPlanChangeDate = null,
            AutoCollection = null,
            BillingCycleAlignment = null,
            BillingCycleAnchorConfiguration = null,
            ChangeDate = null,
            CouponRedemptionCode = null,
            CreditsOverageRate = null,
            DefaultInvoiceMemo = null,
            ExternalPlanID = null,
            Filter = null,
            InitialPhaseOrder = null,
            InvoicingThreshold = null,
            NetTerms = null,
            PerCreditOverageAmount = null,
            PlanID = null,
            PlanVersionNumber = null,
            PriceOverrides = null,
            RemoveAdjustments = null,
            RemovePrices = null,
            ReplaceAdjustments = null,
            ReplacePrices = null,
            TrialDurationDays = null,
            UsageCustomerIds = null,
        };

        Assert.Null(parameters.AddAdjustments);
        Assert.True(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.AddPrices);
        Assert.True(parameters.RawBodyData.ContainsKey("add_prices"));
        Assert.Null(parameters.AlignBillingWithPlanChangeDate);
        Assert.True(parameters.RawBodyData.ContainsKey("align_billing_with_plan_change_date"));
        Assert.Null(parameters.AutoCollection);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.BillingCycleAlignment);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_cycle_alignment"));
        Assert.Null(parameters.BillingCycleAnchorConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_cycle_anchor_configuration"));
        Assert.Null(parameters.ChangeDate);
        Assert.True(parameters.RawBodyData.ContainsKey("change_date"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
        Assert.Null(parameters.CreditsOverageRate);
        Assert.True(parameters.RawBodyData.ContainsKey("credits_overage_rate"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.True(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.InitialPhaseOrder);
        Assert.True(parameters.RawBodyData.ContainsKey("initial_phase_order"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.True(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.NetTerms);
        Assert.True(parameters.RawBodyData.ContainsKey("net_terms"));
        Assert.Null(parameters.PerCreditOverageAmount);
        Assert.True(parameters.RawBodyData.ContainsKey("per_credit_overage_amount"));
        Assert.Null(parameters.PlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("plan_id"));
        Assert.Null(parameters.PlanVersionNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("plan_version_number"));
        Assert.Null(parameters.PriceOverrides);
        Assert.True(parameters.RawBodyData.ContainsKey("price_overrides"));
        Assert.Null(parameters.RemoveAdjustments);
        Assert.True(parameters.RawBodyData.ContainsKey("remove_adjustments"));
        Assert.Null(parameters.RemovePrices);
        Assert.True(parameters.RawBodyData.ContainsKey("remove_prices"));
        Assert.Null(parameters.ReplaceAdjustments);
        Assert.True(parameters.RawBodyData.ContainsKey("replace_adjustments"));
        Assert.Null(parameters.ReplacePrices);
        Assert.True(parameters.RawBodyData.ContainsKey("replace_prices"));
        Assert.Null(parameters.TrialDurationDays);
        Assert.True(parameters.RawBodyData.ContainsKey("trial_duration_days"));
        Assert.Null(parameters.UsageCustomerIds);
        Assert.True(parameters.RawBodyData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            ChangeOption =
                Subscriptions::SubscriptionSchedulePlanChangeParamsChangeOption.RequestedDate,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/subscriptions/subscription_id/schedule_plan_change"
            ),
            url
        );
    }
}

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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment>(
                json,
                ModelBase.SerializerOptions
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

public class SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
        value.Validate();
    }

    [Fact]
    public void NewUsageDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewUsageDiscount()
            {
                AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = NewUsageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewUsageDiscountFilterField.PriceID,
                        Operator = NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewUsageDiscountPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewAmountDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewAmountDiscount()
            {
                AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = AppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewAmountDiscountFilterField.PriceID,
                        Operator = NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = PriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewMinimum()
            {
                AdjustmentType = NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = NewMinimumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMinimumFilterField.PriceID,
                        Operator = NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMinimumPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewMaximumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewMaximum()
            {
                AdjustmentType = NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = NewMaximumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMaximumFilterField.PriceID,
                        Operator = NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMaximumPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewPercentageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewUsageDiscount()
            {
                AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = NewUsageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewUsageDiscountFilterField.PriceID,
                        Operator = NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewUsageDiscountPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewAmountDiscount()
            {
                AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = AppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewAmountDiscountFilterField.PriceID,
                        Operator = NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = PriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewMinimum()
            {
                AdjustmentType = NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = NewMinimumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMinimumFilterField.PriceID,
                        Operator = NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMinimumPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment value =
            new NewMaximum()
            {
                AdjustmentType = NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = NewMaximumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMaximumFilterField.PriceID,
                        Operator = NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMaximumPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        Assert.NotNull(model.Discounts);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPrice>(
                element,
                ModelBase.SerializerOptions
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
        Assert.NotNull(deserialized.Discounts);
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTest : TestBase
{
    [Fact]
    public void NewSubscriptionUnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPriceModelType.Tiered,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionBulkValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Subscriptions::NewSubscriptionBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::ModelType.Bulk,
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
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionMatrixPriceModelType.Matrix,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
            {
                Cadence = Subscriptions::NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedTieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionGroupedTieredPriceModelType.GroupedTiered,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionPackageWithAllocationPriceModelType.PackageWithAllocation,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionUnitWithPercentPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        value.Validate();
    }

    [Fact]
    public void TieredWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionUnitWithProrationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedAllocationPriceModelType.GroupedAllocation,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Subscriptions::NewSubscriptionBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionBulkWithProrationPriceModelType.BulkWithProration,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPackagePriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
            {
                Cadence = Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation()
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
        value.Validate();
    }

    [Fact]
    public void MinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum()
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMinimumCompositePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumCompositeConfig = new()
                {
                    MinimumAmount = "minimum_amount",
                    Prorated = true,
                },
                ModelType =
                    Subscriptions::NewSubscriptionMinimumCompositePriceModelType.MinimumComposite,
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
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent()
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
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPriceModelType.Tiered,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Subscriptions::NewSubscriptionBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::ModelType.Bulk,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionMatrixPriceModelType.Matrix,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
            {
                Cadence = Subscriptions::NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionGroupedTieredPriceModelType.GroupedTiered,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionPackageWithAllocationPriceModelType.PackageWithAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionUnitWithPercentPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionUnitWithProrationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedAllocationPriceModelType.GroupedAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Subscriptions::NewSubscriptionBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionBulkWithProrationPriceModelType.BulkWithProration,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPackagePriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
            {
                Cadence = Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum()
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::NewSubscriptionMinimumCompositePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumCompositeConfig = new()
                {
                    MinimumAmount = "minimum_amount",
                    Prorated = true,
                },
                ModelType =
                    Subscriptions::NewSubscriptionMinimumCompositePriceModelType.MinimumComposite,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFilters>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
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
        Assert.NotNull(deserialized.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfig>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                element,
                ModelBase.SerializerOptions
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfig>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationTieredWithProrationConfigTier>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholds>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocation>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig expectedMinimumConfig =
            new() { MinimumAmount = "minimum_amount", Prorated = true };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMinimumConfig, model.MinimumConfig);
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
        Assert.NotNull(model.Metadata);
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig expectedMinimumConfig =
            new() { MinimumAmount = "minimum_amount", Prorated = true };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMinimumConfig, deserialized.MinimumConfig);
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
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
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
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedProrated, deserialized.Prorated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
            };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",

                // Null should be interpreted as omitted for these properties
                Prorated = null,
            };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",

                // Null should be interpreted as omitted for these properties
                Prorated = null,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentPercentConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutput>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputEventOutputConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsAddPricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemoveAdjustment>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsRemovePrice>(
                element,
                ModelBase.SerializerOptions
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment>(
                json,
                ModelBase.SerializerOptions
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment expectedAdjustment =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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

public class SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
        value.Validate();
    }

    [Fact]
    public void NewUsageDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewUsageDiscount()
            {
                AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = NewUsageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewUsageDiscountFilterField.PriceID,
                        Operator = NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewUsageDiscountPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewAmountDiscountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewAmountDiscount()
            {
                AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = AppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewAmountDiscountFilterField.PriceID,
                        Operator = NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = PriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewMinimum()
            {
                AdjustmentType = NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = NewMinimumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMinimumFilterField.PriceID,
                        Operator = NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMinimumPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewMaximumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewMaximum()
            {
                AdjustmentType = NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = NewMaximumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMaximumFilterField.PriceID,
                        Operator = NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMaximumPriceType.Usage,
            };
        value.Validate();
    }

    [Fact]
    public void NewPercentageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewPercentageDiscount()
            {
                AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
                PercentageDiscount = 0,
                AppliesToAll = NewPercentageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewUsageDiscount()
            {
                AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
                UsageDiscount = 0,
                AppliesToAll = NewUsageDiscountAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewUsageDiscountFilterField.PriceID,
                        Operator = NewUsageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewUsageDiscountPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewAmountDiscount()
            {
                AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
                AmountDiscount = "amount_discount",
                AppliesToAll = AppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewAmountDiscountFilterField.PriceID,
                        Operator = NewAmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = PriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewMinimum()
            {
                AdjustmentType = NewMinimumAdjustmentType.Minimum,
                ItemID = "item_id",
                MinimumAmount = "minimum_amount",
                AppliesToAll = NewMinimumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMinimumFilterField.PriceID,
                        Operator = NewMinimumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMinimumPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment value =
            new NewMaximum()
            {
                AdjustmentType = NewMaximumAdjustmentType.Maximum,
                MaximumAmount = "maximum_amount",
                AppliesToAll = NewMaximumAppliesToAll.True,
                AppliesToItemIds = ["item_1", "item_2"],
                AppliesToPriceIds = ["price_1", "price_2"],
                Currency = "currency",
                Filters =
                [
                    new()
                    {
                        Field = NewMaximumFilterField.PriceID,
                        Operator = NewMaximumFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                IsInvoiceLevel = true,
                PriceType = NewMaximumPriceType.Usage,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplaceAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        Assert.NotNull(model.Discounts);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePrice>(
                element,
                ModelBase.SerializerOptions
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
        Assert.NotNull(deserialized.Discounts);
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTest : TestBase
{
    [Fact]
    public void NewSubscriptionUnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPriceModelType.Tiered,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionBulkValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Subscriptions::NewSubscriptionBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::ModelType.Bulk,
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
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionMatrixPriceModelType.Matrix,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
            {
                Cadence = Subscriptions::NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedTieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionGroupedTieredPriceModelType.GroupedTiered,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionPackageWithAllocationPriceModelType.PackageWithAllocation,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionUnitWithPercentPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        value.Validate();
    }

    [Fact]
    public void TieredWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionUnitWithProrationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedAllocationPriceModelType.GroupedAllocation,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Subscriptions::NewSubscriptionBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionBulkWithProrationPriceModelType.BulkWithProration,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPackagePriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
            {
                Cadence = Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation()
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
        value.Validate();
    }

    [Fact]
    public void MinimumValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum()
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMinimumCompositePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumCompositeConfig = new()
                {
                    MinimumAmount = "minimum_amount",
                    Prorated = true,
                },
                ModelType =
                    Subscriptions::NewSubscriptionMinimumCompositePriceModelType.MinimumComposite,
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
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent()
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
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput()
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
        value.Validate();
    }

    [Fact]
    public void NewSubscriptionUnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPriceModelType.Tiered,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionBulkPrice()
            {
                BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
                Cadence = Subscriptions::NewSubscriptionBulkPriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::ModelType.Bulk,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionPackagePriceModelType.Package,
                Name = "Annual fee",
                PackageConfig = new() { PackageAmount = "package_amount", PackageSize = 1 },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionMatrixPriceModelType.Matrix,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
            {
                Cadence = Subscriptions::NewSubscriptionThresholdTotalAmountPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackagePriceCadence.Annual,
                ItemID = "item_id",
                ModelType = Subscriptions::NewSubscriptionTieredPackagePriceModelType.TieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredWithMinimumPriceModelType.TieredWithMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPriceCadence.Annual,
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
                ModelType = Subscriptions::NewSubscriptionGroupedTieredPriceModelType.GroupedTiered,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice()
            {
                Cadence = Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionPackageWithAllocationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionPackageWithAllocationPriceModelType.PackageWithAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionUnitWithPercentPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
                Name = "Annual fee",
                UnitWithPercentConfig = new() { Percent = "percent", UnitAmount = "unit_amount" },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionUnitWithProrationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionUnitWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionUnitWithProrationPriceModelType.UnitWithProration,
                Name = "Annual fee",
                UnitWithProrationConfig = new("unit_amount"),
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedAllocationPrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedAllocationPriceCadence.Annual,
                GroupedAllocationConfig = new()
                {
                    Allocation = "allocation",
                    GroupingKey = "x",
                    OverageUnitRate = "overage_unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedAllocationPriceModelType.GroupedAllocation,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionBulkWithProrationPrice()
            {
                BulkWithProrationConfig = new(
                    [
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                        new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    ]
                ),
                Cadence = Subscriptions::NewSubscriptionBulkWithProrationPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionBulkWithProrationPriceModelType.BulkWithProration,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceCadence.Annual,
                GroupedWithProratedMinimumConfig = new()
                {
                    GroupingKey = "x",
                    Minimum = "minimum",
                    UnitRate = "unit_rate",
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceCadence.Annual,
                GroupedWithMeteredMinimumConfig = new()
                {
                    GroupingKey = "x",
                    MinimumUnitAmount = "minimum_unit_amount",
                    PricingKey = "pricing_key",
                    ScalingFactors =
                    [
                        new()
                        {
                            ScalingFactorValue = "scaling_factor",
                            ScalingValue = "scaling_value",
                        },
                    ],
                    ScalingKey = "scaling_key",
                    UnitAmounts =
                    [
                        new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                    ],
                },
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionGroupedTieredPackagePriceCadence.Annual,
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
                ModelType =
                    Subscriptions::NewSubscriptionGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice()
            {
                Cadence =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceCadence.Annual,
                ItemID = "item_id",
                ModelType =
                    Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
            {
                Cadence = Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceCadence.Annual,
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
                    Subscriptions::NewSubscriptionCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum()
            {
                Cadence =
                    Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
                ItemID = "item_id",
                MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::NewSubscriptionMinimumCompositePrice()
            {
                Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
                ItemID = "item_id",
                MinimumCompositeConfig = new()
                {
                    MinimumAmount = "minimum_amount",
                    Prorated = true,
                },
                ModelType =
                    Subscriptions::NewSubscriptionMinimumCompositePriceModelType.MinimumComposite,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice value =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePrice>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFilters>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
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
        Assert.NotNull(deserialized.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                element,
                ModelBase.SerializerOptions
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                element,
                ModelBase.SerializerOptions
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholds>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "grouped_with_min_max_thresholds"
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocation>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement(
            "cumulative_grouped_allocation"
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig expectedMinimumConfig =
            new() { MinimumAmount = "minimum_amount", Prorated = true };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMinimumConfig, model.MinimumConfig);
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
        Assert.NotNull(model.Metadata);
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig expectedMinimumConfig =
            new() { MinimumAmount = "minimum_amount", Prorated = true };
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("minimum");
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        Assert.Equal(expectedMinimumConfig, deserialized.MinimumConfig);
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
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var model = new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimum
        {
            Cadence =
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadenceTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Custom
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Annual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.SemiAnnual
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Monthly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Quarterly
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.OneTime
    )]
    [InlineData(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence.Custom
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
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
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumCadence
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedProrated, model.Prorated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMinimumAmount = "minimum_amount";
        bool expectedProrated = true;

        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedProrated, deserialized.Prorated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
                Prorated = true,
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
            };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",
            };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",

                // Null should be interpreted as omitted for these properties
                Prorated = null,
            };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model =
            new Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumMinimumConfig
            {
                MinimumAmount = "minimum_amount",

                // Null should be interpreted as omitted for these properties
                Prorated = null,
            };

        model.Validate();
    }
}

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence
        > expectedCadence =
            Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentPercentConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
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
        Assert.NotNull(model.Metadata);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutput>(
                element,
                ModelBase.SerializerOptions
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
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("event_output");
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
        Assert.NotNull(deserialized.Metadata);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
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
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>(
                json,
                ModelBase.SerializerOptions
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputEventOutputConfig>(
                element,
                ModelBase.SerializerOptions
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

public class SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfigTest
    : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        value.Validate();
    }

    [Fact]
    public void UnitSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig value =
            new SharedTieredConversionRateConfig()
            {
                ConversionRateType = ConversionRateType.Tiered,
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
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionSchedulePlanChangeParamsReplacePricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
