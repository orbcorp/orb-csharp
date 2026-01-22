using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionPriceIntervalsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            Add =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CanDeferBilling = true,
                    Discounts = [new Subscriptions::Amount(0)],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalPriceID = "external_price_id",
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    MaximumAmount = 0,
                    MinimumAmount = 0,
                    Price = new NewFloatingUnitPrice()
                    {
                        Cadence = NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = NewFloatingUnitPriceModelType.Unit,
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
                        DimensionalPriceConfiguration = new()
                        {
                            DimensionValues = ["string"],
                            DimensionalPriceGroupID = "dimensional_price_group_id",
                            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                        },
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 0,
                        InvoiceGroupingKey = "x",
                        InvoicingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "h74gfhdjvn7ujokd",
                    UsageCustomerIds = ["string"],
                },
            ],
            AddAdjustments =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    AdjustmentID = "h74gfhdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            AllowInvoiceCreditOrVoid = true,
            CanDeferBilling = true,
            Edit =
            [
                new()
                {
                    PriceIntervalID = "sdfs6wdjvn7ujokd",
                    BillingCycleDay = 0,
                    CanDeferBilling = true,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageCustomerIds = ["string"],
                },
            ],
            EditAdjustments =
            [
                new()
                {
                    AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string expectedSubscriptionID = "subscription_id";
        List<Subscriptions::Add> expectedAdd =
        [
            new()
            {
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                CanDeferBilling = true,
                Discounts = [new Subscriptions::Amount(0)],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalPriceID = "external_price_id",
                Filter = "my_property > 100 AND my_other_property = 'bar'",
                FixedFeeQuantityTransitions =
                [
                    new()
                    {
                        EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Quantity = 5,
                    },
                ],
                MaximumAmount = 0,
                MinimumAmount = 0,
                Price = new NewFloatingUnitPrice()
                {
                    Cadence = NewFloatingUnitPriceCadence.Annual,
                    Currency = "currency",
                    ItemID = "item_id",
                    ModelType = NewFloatingUnitPriceModelType.Unit,
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
                    DimensionalPriceConfiguration = new()
                    {
                        DimensionValues = ["string"],
                        DimensionalPriceGroupID = "dimensional_price_group_id",
                        ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                    },
                    ExternalPriceID = "external_price_id",
                    FixedPriceQuantity = 0,
                    InvoiceGroupingKey = "x",
                    InvoicingCycleConfiguration = new()
                    {
                        Duration = 0,
                        DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                    },
                    Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                },
                PriceID = "h74gfhdjvn7ujokd",
                UsageCustomerIds = ["string"],
            },
        ];
        List<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment> expectedAddAdjustments =
        [
            new()
            {
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                AdjustmentID = "h74gfhdjvn7ujokd",
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedAllowInvoiceCreditOrVoid = true;
        bool expectedCanDeferBilling = true;
        List<Subscriptions::Edit> expectedEdit =
        [
            new()
            {
                PriceIntervalID = "sdfs6wdjvn7ujokd",
                BillingCycleDay = 0,
                CanDeferBilling = true,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filter = "my_property > 100 AND my_other_property = 'bar'",
                FixedFeeQuantityTransitions =
                [
                    new()
                    {
                        EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Quantity = 5,
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageCustomerIds = ["string"],
            },
        ];
        List<Subscriptions::EditAdjustment> expectedEditAdjustments =
        [
            new()
            {
                AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.NotNull(parameters.Add);
        Assert.Equal(expectedAdd.Count, parameters.Add.Count);
        for (int i = 0; i < expectedAdd.Count; i++)
        {
            Assert.Equal(expectedAdd[i], parameters.Add[i]);
        }
        Assert.NotNull(parameters.AddAdjustments);
        Assert.Equal(expectedAddAdjustments.Count, parameters.AddAdjustments.Count);
        for (int i = 0; i < expectedAddAdjustments.Count; i++)
        {
            Assert.Equal(expectedAddAdjustments[i], parameters.AddAdjustments[i]);
        }
        Assert.Equal(expectedAllowInvoiceCreditOrVoid, parameters.AllowInvoiceCreditOrVoid);
        Assert.Equal(expectedCanDeferBilling, parameters.CanDeferBilling);
        Assert.NotNull(parameters.Edit);
        Assert.Equal(expectedEdit.Count, parameters.Edit.Count);
        for (int i = 0; i < expectedEdit.Count; i++)
        {
            Assert.Equal(expectedEdit[i], parameters.Edit[i]);
        }
        Assert.NotNull(parameters.EditAdjustments);
        Assert.Equal(expectedEditAdjustments.Count, parameters.EditAdjustments.Count);
        for (int i = 0; i < expectedEditAdjustments.Count; i++)
        {
            Assert.Equal(expectedEditAdjustments[i], parameters.EditAdjustments[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            AllowInvoiceCreditOrVoid = true,
            CanDeferBilling = true,
        };

        Assert.Null(parameters.Add);
        Assert.False(parameters.RawBodyData.ContainsKey("add"));
        Assert.Null(parameters.AddAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.Edit);
        Assert.False(parameters.RawBodyData.ContainsKey("edit"));
        Assert.Null(parameters.EditAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("edit_adjustments"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            AllowInvoiceCreditOrVoid = true,
            CanDeferBilling = true,

            // Null should be interpreted as omitted for these properties
            Add = null,
            AddAdjustments = null,
            Edit = null,
            EditAdjustments = null,
        };

        Assert.Null(parameters.Add);
        Assert.False(parameters.RawBodyData.ContainsKey("add"));
        Assert.Null(parameters.AddAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.Edit);
        Assert.False(parameters.RawBodyData.ContainsKey("edit"));
        Assert.Null(parameters.EditAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("edit_adjustments"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            Add =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CanDeferBilling = true,
                    Discounts = [new Subscriptions::Amount(0)],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalPriceID = "external_price_id",
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    MaximumAmount = 0,
                    MinimumAmount = 0,
                    Price = new NewFloatingUnitPrice()
                    {
                        Cadence = NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = NewFloatingUnitPriceModelType.Unit,
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
                        DimensionalPriceConfiguration = new()
                        {
                            DimensionValues = ["string"],
                            DimensionalPriceGroupID = "dimensional_price_group_id",
                            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                        },
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 0,
                        InvoiceGroupingKey = "x",
                        InvoicingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "h74gfhdjvn7ujokd",
                    UsageCustomerIds = ["string"],
                },
            ],
            AddAdjustments =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    AdjustmentID = "h74gfhdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Edit =
            [
                new()
                {
                    PriceIntervalID = "sdfs6wdjvn7ujokd",
                    BillingCycleDay = 0,
                    CanDeferBilling = true,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageCustomerIds = ["string"],
                },
            ],
            EditAdjustments =
            [
                new()
                {
                    AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.CanDeferBilling);
        Assert.False(parameters.RawBodyData.ContainsKey("can_defer_billing"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            Add =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CanDeferBilling = true,
                    Discounts = [new Subscriptions::Amount(0)],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalPriceID = "external_price_id",
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    MaximumAmount = 0,
                    MinimumAmount = 0,
                    Price = new NewFloatingUnitPrice()
                    {
                        Cadence = NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = NewFloatingUnitPriceModelType.Unit,
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
                        DimensionalPriceConfiguration = new()
                        {
                            DimensionValues = ["string"],
                            DimensionalPriceGroupID = "dimensional_price_group_id",
                            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                        },
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 0,
                        InvoiceGroupingKey = "x",
                        InvoicingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "h74gfhdjvn7ujokd",
                    UsageCustomerIds = ["string"],
                },
            ],
            AddAdjustments =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    AdjustmentID = "h74gfhdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Edit =
            [
                new()
                {
                    PriceIntervalID = "sdfs6wdjvn7ujokd",
                    BillingCycleDay = 0,
                    CanDeferBilling = true,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageCustomerIds = ["string"],
                },
            ],
            EditAdjustments =
            [
                new()
                {
                    AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            AllowInvoiceCreditOrVoid = null,
            CanDeferBilling = null,
        };

        Assert.Null(parameters.AllowInvoiceCreditOrVoid);
        Assert.True(parameters.RawBodyData.ContainsKey("allow_invoice_credit_or_void"));
        Assert.Null(parameters.CanDeferBilling);
        Assert.True(parameters.RawBodyData.ContainsKey("can_defer_billing"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionPriceIntervalsParams parameters = new()
        {
            SubscriptionID = "subscription_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/subscriptions/subscription_id/price_intervals"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionPriceIntervalsParams
        {
            SubscriptionID = "subscription_id",
            Add =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    CanDeferBilling = true,
                    Discounts = [new Subscriptions::Amount(0)],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalPriceID = "external_price_id",
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    MaximumAmount = 0,
                    MinimumAmount = 0,
                    Price = new NewFloatingUnitPrice()
                    {
                        Cadence = NewFloatingUnitPriceCadence.Annual,
                        Currency = "currency",
                        ItemID = "item_id",
                        ModelType = NewFloatingUnitPriceModelType.Unit,
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
                        DimensionalPriceConfiguration = new()
                        {
                            DimensionValues = ["string"],
                            DimensionalPriceGroupID = "dimensional_price_group_id",
                            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                        },
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 0,
                        InvoiceGroupingKey = "x",
                        InvoicingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                        },
                        Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                    },
                    PriceID = "h74gfhdjvn7ujokd",
                    UsageCustomerIds = ["string"],
                },
            ],
            AddAdjustments =
            [
                new()
                {
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                    AdjustmentID = "h74gfhdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            AllowInvoiceCreditOrVoid = true,
            CanDeferBilling = true,
            Edit =
            [
                new()
                {
                    PriceIntervalID = "sdfs6wdjvn7ujokd",
                    BillingCycleDay = 0,
                    CanDeferBilling = true,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filter = "my_property > 100 AND my_other_property = 'bar'",
                    FixedFeeQuantityTransitions =
                    [
                        new()
                        {
                            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Quantity = 5,
                        },
                    ],
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageCustomerIds = ["string"],
                },
            ],
            EditAdjustments =
            [
                new()
                {
                    AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Subscriptions::SubscriptionPriceIntervalsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CanDeferBilling = true,
            Discounts = [new Subscriptions::Amount(0)],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            MaximumAmount = 0,
            MinimumAmount = 0,
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "h74gfhdjvn7ujokd",
            UsageCustomerIds = ["string"],
        };

        Subscriptions::StartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
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
        bool expectedCanDeferBilling = true;
        List<Subscriptions::Discount> expectedDiscounts = [new Subscriptions::Amount(0)];
        Subscriptions::EndDate expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        List<Subscriptions::FixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Quantity = 5,
            },
        ];
        double expectedMaximumAmount = 0;
        double expectedMinimumAmount = 0;
        Subscriptions::PriceModel expectedPrice = new NewFloatingUnitPrice()
        {
            Cadence = NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitPriceModelType.Unit,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string expectedPriceID = "h74gfhdjvn7ujokd";
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedAllocationPrice, model.AllocationPrice);
        Assert.Equal(expectedCanDeferBilling, model.CanDeferBilling);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.NotNull(model.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            model.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                model.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.NotNull(model.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, model.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], model.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CanDeferBilling = true,
            Discounts = [new Subscriptions::Amount(0)],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            MaximumAmount = 0,
            MinimumAmount = 0,
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "h74gfhdjvn7ujokd",
            UsageCustomerIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Add>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CanDeferBilling = true,
            Discounts = [new Subscriptions::Amount(0)],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            MaximumAmount = 0,
            MinimumAmount = 0,
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "h74gfhdjvn7ujokd",
            UsageCustomerIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Add>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::StartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
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
        bool expectedCanDeferBilling = true;
        List<Subscriptions::Discount> expectedDiscounts = [new Subscriptions::Amount(0)];
        Subscriptions::EndDate expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalPriceID = "external_price_id";
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        List<Subscriptions::FixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Quantity = 5,
            },
        ];
        double expectedMaximumAmount = 0;
        double expectedMinimumAmount = 0;
        Subscriptions::PriceModel expectedPrice = new NewFloatingUnitPrice()
        {
            Cadence = NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitPriceModelType.Unit,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string expectedPriceID = "h74gfhdjvn7ujokd";
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedAllocationPrice, deserialized.AllocationPrice);
        Assert.Equal(expectedCanDeferBilling, deserialized.CanDeferBilling);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedExternalPriceID, deserialized.ExternalPriceID);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.NotNull(deserialized.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            deserialized.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                deserialized.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
        Assert.NotNull(deserialized.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, deserialized.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], deserialized.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CanDeferBilling = true,
            Discounts = [new Subscriptions::Amount(0)],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            MaximumAmount = 0,
            MinimumAmount = 0,
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "h74gfhdjvn7ujokd",
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AllocationPrice);
        Assert.False(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.CanDeferBilling);
        Assert.False(model.RawData.ContainsKey("can_defer_billing"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
        Assert.Null(model.FixedFeeQuantityTransitions);
        Assert.False(model.RawData.ContainsKey("fixed_fee_quantity_transitions"));
        Assert.Null(model.MaximumAmount);
        Assert.False(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.False(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
        Assert.Null(model.UsageCustomerIds);
        Assert.False(model.RawData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AllocationPrice = null,
            CanDeferBilling = null,
            Discounts = null,
            EndDate = null,
            ExternalPriceID = null,
            Filter = null,
            FixedFeeQuantityTransitions = null,
            MaximumAmount = null,
            MinimumAmount = null,
            Price = null,
            PriceID = null,
            UsageCustomerIds = null,
        };

        Assert.Null(model.AllocationPrice);
        Assert.True(model.RawData.ContainsKey("allocation_price"));
        Assert.Null(model.CanDeferBilling);
        Assert.True(model.RawData.ContainsKey("can_defer_billing"));
        Assert.Null(model.Discounts);
        Assert.True(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
        Assert.Null(model.FixedFeeQuantityTransitions);
        Assert.True(model.RawData.ContainsKey("fixed_fee_quantity_transitions"));
        Assert.Null(model.MaximumAmount);
        Assert.True(model.RawData.ContainsKey("maximum_amount"));
        Assert.Null(model.MinimumAmount);
        Assert.True(model.RawData.ContainsKey("minimum_amount"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
        Assert.Null(model.UsageCustomerIds);
        Assert.True(model.RawData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AllocationPrice = null,
            CanDeferBilling = null,
            Discounts = null,
            EndDate = null,
            ExternalPriceID = null,
            Filter = null,
            FixedFeeQuantityTransitions = null,
            MaximumAmount = null,
            MinimumAmount = null,
            Price = null,
            PriceID = null,
            UsageCustomerIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Add
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CanDeferBilling = true,
            Discounts = [new Subscriptions::Amount(0)],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalPriceID = "external_price_id",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            MaximumAmount = 0,
            MinimumAmount = 0,
            Price = new NewFloatingUnitPrice()
            {
                Cadence = NewFloatingUnitPriceCadence.Annual,
                Currency = "currency",
                ItemID = "item_id",
                ModelType = NewFloatingUnitPriceModelType.Unit,
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
                DimensionalPriceConfiguration = new()
                {
                    DimensionValues = ["string"],
                    DimensionalPriceGroupID = "dimensional_price_group_id",
                    ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
                },
                ExternalPriceID = "external_price_id",
                FixedPriceQuantity = 0,
                InvoiceGroupingKey = "x",
                InvoicingCycleConfiguration = new()
                {
                    Duration = 0,
                    DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            PriceID = "h74gfhdjvn7ujokd",
            UsageCustomerIds = ["string"],
        };

        Subscriptions::Add copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StartDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::StartDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::StartDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::StartDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::StartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::StartDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::StartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DiscountTest : TestBase
{
    [Fact]
    public void AmountValidationWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Amount(0);
        value.Validate();
    }

    [Fact]
    public void PercentageValidationWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Percentage(0.15);
        value.Validate();
    }

    [Fact]
    public void UsageValidationWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Usage(2);
        value.Validate();
    }

    [Fact]
    public void AmountSerializationRoundtripWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Amount(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Discount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentageSerializationRoundtripWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Percentage(0.15);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Discount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UsageSerializationRoundtripWorks()
    {
        Subscriptions::Discount value = new Subscriptions::Usage(2);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Discount>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Amount { AmountDiscount = 0 };

        double expectedAmountDiscount = 0;
        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("amount");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Amount { AmountDiscount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Amount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Amount { AmountDiscount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Amount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmountDiscount = 0;
        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("amount");

        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Amount { AmountDiscount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Amount { AmountDiscount = 0 };

        Subscriptions::Amount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PercentageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Percentage { PercentageDiscount = 0.15 };

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("percentage");
        double expectedPercentageDiscount = 0.15;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Percentage { PercentageDiscount = 0.15 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Percentage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Percentage { PercentageDiscount = 0.15 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Percentage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("percentage");
        double expectedPercentageDiscount = 0.15;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Percentage { PercentageDiscount = 0.15 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Percentage { PercentageDiscount = 0.15 };

        Subscriptions::Percentage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Usage { UsageDiscount = 2 };

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("usage");
        double expectedUsageDiscount = 2;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, model.DiscountType));
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Usage { UsageDiscount = 2 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Usage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Usage { UsageDiscount = 2 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Usage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDiscountType = JsonSerializer.SerializeToElement("usage");
        double expectedUsageDiscount = 2;

        Assert.True(JsonElement.DeepEquals(expectedDiscountType, deserialized.DiscountType));
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Usage { UsageDiscount = 2 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Usage { UsageDiscount = 2 };

        Subscriptions::Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EndDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::EndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::EndDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::EndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::EndDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FixedFeeQuantityTransitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedQuantity = 5;

        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::FixedFeeQuantityTransition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::FixedFeeQuantityTransition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedQuantity = 5;

        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        Subscriptions::FixedFeeQuantityTransition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelTest : TestBase
{
    [Fact]
    public void NewFloatingUnitValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitPrice()
        {
            Cadence = NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitPriceModelType.Unit,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPrice()
        {
            Cadence = NewFloatingTieredPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPriceModelType.Tiered,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingBulkPrice()
        {
            BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
            Cadence = NewFloatingBulkPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = ModelType.Bulk,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void BulkWithFiltersValidationWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelBulkWithFilters()
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingPackagePrice()
        {
            Cadence = NewFloatingPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingPackagePriceModelType.Package,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixPrice()
        {
            Cadence = NewFloatingMatrixPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewFloatingMatrixPriceModelType.Matrix,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingThresholdTotalAmountPrice()
        {
            Cadence = NewFloatingThresholdTotalAmountPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPackagePrice()
        {
            Cadence = NewFloatingTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackagePriceModelType.TieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithMinimumValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredWithMinimumPrice()
        {
            Cadence = NewFloatingTieredWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedTieredPrice()
        {
            Cadence = NewFloatingGroupedTieredPriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingGroupedTieredPriceModelType.GroupedTiered,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPackageWithMinimumPrice()
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingPackageWithAllocationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingPackageWithAllocationPrice()
        {
            Cadence = NewFloatingPackageWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithPercentValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitWithPercentPrice()
        {
            Cadence = NewFloatingUnitWithPercentPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixWithAllocationPrice()
        {
            Cadence = NewFloatingMatrixWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingTieredWithProrationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredWithProrationPrice()
        {
            Cadence = NewFloatingTieredWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitWithProrationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitWithProrationPrice()
        {
            Cadence = NewFloatingUnitWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedAllocationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedAllocationPrice()
        {
            Cadence = NewFloatingGroupedAllocationPriceCadence.Annual,
            Currency = "currency",
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            ItemID = "item_id",
            ModelType = NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingBulkWithProrationValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingBulkWithProrationPrice()
        {
            BulkWithProrationConfig = new(
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ]
            ),
            Cadence = NewFloatingBulkWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedWithProratedMinimumPrice()
        {
            Cadence = NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithProratedMinimumConfig = new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            },
            ItemID = "item_id",
            ModelType =
                NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedWithMeteredMinimumPrice()
        {
            Cadence = NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsValidationWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelGroupedWithMinMaxThresholds()
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixWithDisplayNamePrice()
        {
            Cadence = NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedTieredPackagePrice()
        {
            Cadence = NewFloatingGroupedTieredPackagePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMaxGroupTieredPackagePrice()
        {
            Cadence = NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingScalableMatrixWithUnitPricingPrice()
        {
            Cadence = NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingScalableMatrixWithTieredPricingPrice()
        {
            Cadence = NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingCumulativeGroupedBulkPrice()
        {
            Cadence = NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
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
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void CumulativeGroupedAllocationValidationWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelCumulativeGroupedAllocation()
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingMinimumCompositeValidationWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMinimumCompositePrice()
        {
            Cadence = NewFloatingMinimumCompositePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            ModelType = NewFloatingMinimumCompositePriceModelType.MinimumComposite,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void PercentValidationWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelPercent()
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void EventOutputValidationWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelEventOutput()
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        value.Validate();
    }

    [Fact]
    public void NewFloatingUnitSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitPrice()
        {
            Cadence = NewFloatingUnitPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitPriceModelType.Unit,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPrice()
        {
            Cadence = NewFloatingTieredPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPriceModelType.Tiered,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingBulkPrice()
        {
            BulkConfig = new([new() { UnitAmount = "unit_amount", MaximumUnits = 0 }]),
            Cadence = NewFloatingBulkPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = ModelType.Bulk,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelBulkWithFilters()
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingPackagePrice()
        {
            Cadence = NewFloatingPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingPackagePriceModelType.Package,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixPrice()
        {
            Cadence = NewFloatingMatrixPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewFloatingMatrixPriceModelType.Matrix,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingThresholdTotalAmountSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingThresholdTotalAmountPrice()
        {
            Cadence = NewFloatingThresholdTotalAmountPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingThresholdTotalAmountPriceModelType.ThresholdTotalAmount,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPackagePrice()
        {
            Cadence = NewFloatingTieredPackagePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackagePriceModelType.TieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredWithMinimumPrice()
        {
            Cadence = NewFloatingTieredWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredWithMinimumPriceModelType.TieredWithMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedTieredPrice()
        {
            Cadence = NewFloatingGroupedTieredPriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingGroupedTieredPriceModelType.GroupedTiered,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredPackageWithMinimumPrice()
        {
            Cadence = NewFloatingTieredPackageWithMinimumPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredPackageWithMinimumPriceModelType.TieredPackageWithMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingPackageWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingPackageWithAllocationPrice()
        {
            Cadence = NewFloatingPackageWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingPackageWithAllocationPriceModelType.PackageWithAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithPercentSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitWithPercentPrice()
        {
            Cadence = NewFloatingUnitWithPercentPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitWithPercentPriceModelType.UnitWithPercent,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixWithAllocationPrice()
        {
            Cadence = NewFloatingMatrixWithAllocationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
            },
            ModelType = NewFloatingMatrixWithAllocationPriceModelType.MatrixWithAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingTieredWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingTieredWithProrationPrice()
        {
            Cadence = NewFloatingTieredWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingTieredWithProrationPriceModelType.TieredWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingUnitWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingUnitWithProrationPrice()
        {
            Cadence = NewFloatingUnitWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingUnitWithProrationPriceModelType.UnitWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedAllocationPrice()
        {
            Cadence = NewFloatingGroupedAllocationPriceCadence.Annual,
            Currency = "currency",
            GroupedAllocationConfig = new()
            {
                Allocation = "allocation",
                GroupingKey = "x",
                OverageUnitRate = "overage_unit_rate",
            },
            ItemID = "item_id",
            ModelType = NewFloatingGroupedAllocationPriceModelType.GroupedAllocation,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingBulkWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingBulkWithProrationPrice()
        {
            BulkWithProrationConfig = new(
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ]
            ),
            Cadence = NewFloatingBulkWithProrationPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingBulkWithProrationPriceModelType.BulkWithProration,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedWithProratedMinimumPrice()
        {
            Cadence = NewFloatingGroupedWithProratedMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithProratedMinimumConfig = new()
            {
                GroupingKey = "x",
                Minimum = "minimum",
                UnitRate = "unit_rate",
            },
            ItemID = "item_id",
            ModelType =
                NewFloatingGroupedWithProratedMinimumPriceModelType.GroupedWithProratedMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedWithMeteredMinimumPrice()
        {
            Cadence = NewFloatingGroupedWithMeteredMinimumPriceCadence.Annual,
            Currency = "currency",
            GroupedWithMeteredMinimumConfig = new()
            {
                GroupingKey = "x",
                MinimumUnitAmount = "minimum_unit_amount",
                PricingKey = "pricing_key",
                ScalingFactors =
                [
                    new() { ScalingFactorValue = "scaling_factor", ScalingValue = "scaling_value" },
                ],
                ScalingKey = "scaling_key",
                UnitAmounts =
                [
                    new() { PricingValue = "pricing_value", UnitAmountValue = "unit_amount" },
                ],
            },
            ItemID = "item_id",
            ModelType =
                NewFloatingGroupedWithMeteredMinimumPriceModelType.GroupedWithMeteredMinimum,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelGroupedWithMinMaxThresholds()
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMatrixWithDisplayNamePrice()
        {
            Cadence = NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingGroupedTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingGroupedTieredPackagePrice()
        {
            Cadence = NewFloatingGroupedTieredPackagePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingGroupedTieredPackagePriceModelType.GroupedTieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMaxGroupTieredPackagePrice()
        {
            Cadence = NewFloatingMaxGroupTieredPackagePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingMaxGroupTieredPackagePriceModelType.MaxGroupTieredPackage,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingScalableMatrixWithUnitPricingPrice()
        {
            Cadence = NewFloatingScalableMatrixWithUnitPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                NewFloatingScalableMatrixWithUnitPricingPriceModelType.ScalableMatrixWithUnitPricing,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingScalableMatrixWithTieredPricingPrice()
        {
            Cadence = NewFloatingScalableMatrixWithTieredPricingPriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            ModelType =
                NewFloatingScalableMatrixWithTieredPricingPriceModelType.ScalableMatrixWithTieredPricing,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingCumulativeGroupedBulkPrice()
        {
            Cadence = NewFloatingCumulativeGroupedBulkPriceCadence.Annual,
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
            Currency = "currency",
            ItemID = "item_id",
            ModelType = NewFloatingCumulativeGroupedBulkPriceModelType.CumulativeGroupedBulk,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelCumulativeGroupedAllocation()
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewFloatingMinimumCompositeSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new NewFloatingMinimumCompositePrice()
        {
            Cadence = NewFloatingMinimumCompositePriceCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            ModelType = NewFloatingMinimumCompositePriceModelType.MinimumComposite,
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelPercent()
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Subscriptions::PriceModel value = new Subscriptions::PriceModelEventOutput()
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence> expectedCadence =
            Subscriptions::PriceModelBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
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
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedBulkWithFiltersConfig, model.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFilters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFilters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence> expectedCadence =
            Subscriptions::PriceModelBulkWithFiltersCadence.Annual;
        string expectedCurrency = "currency";
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
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedBulkWithFiltersConfig, deserialized.BulkWithFiltersConfig);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFilters
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
            Cadence = Subscriptions::PriceModelBulkWithFiltersCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelBulkWithFilters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelBulkWithFiltersBulkWithFiltersConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelBulkWithFiltersBulkWithFiltersConfigFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter>(
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelBulkWithFiltersBulkWithFiltersConfigTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier>(
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
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
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",

            TierLowerBound = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        Subscriptions::PriceModelBulkWithFiltersBulkWithFiltersConfigTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelBulkWithFiltersCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Annual)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Custom)]
    public void Validation_Works(Subscriptions::PriceModelBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Annual)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelBulkWithFiltersCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::PriceModelBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelBulkWithFiltersConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig value =
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
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig value =
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
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModelBulkWithFiltersConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelGroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<
            string,
            Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence
        > expectedCadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholds>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholds>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence
        > expectedCadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual;
        string expectedCurrency = "currency";
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelGroupedWithMinMaxThresholds copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelGroupedWithMinMaxThresholdsCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
            new Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
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
            new Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        Subscriptions::PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelGroupedWithMinMaxThresholdsConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelCumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<
            string,
            Subscriptions::PriceModelCumulativeGroupedAllocationCadence
        > expectedCadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
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
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            model.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::PriceModelCumulativeGroupedAllocationCadence
        > expectedCadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
            new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };
        string expectedCurrency = "currency";
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
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(
            expectedCumulativeGroupedAllocationConfig,
            deserialized.CumulativeGroupedAllocationConfig
        );
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual,
            CumulativeGroupedAllocationConfig = new()
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            },
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelCumulativeGroupedAllocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelCumulativeGroupedAllocationCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(
        Subscriptions::PriceModelCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelCumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::PriceModelCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
            new Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
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
            new Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        Subscriptions::PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelCumulativeGroupedAllocationConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelPercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, Subscriptions::PriceModelPercentCadence> expectedCadence =
            Subscriptions::PriceModelPercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::PriceModelPercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::PriceModelPercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentConfig, model.PercentConfig);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelPercent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelPercent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::PriceModelPercentCadence> expectedCadence =
            Subscriptions::PriceModelPercentCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::PriceModelPercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::PriceModelPercentConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentConfig, deserialized.PercentConfig);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),

            BillableMetricID = null,
            BilledInAdvance = null,
            BillingCycleConfiguration = null,
            ConversionRate = null,
            ConversionRateConfig = null,
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelPercent
        {
            Cadence = Subscriptions::PriceModelPercentCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelPercent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelPercentCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceModelPercentCadence.Annual)]
    [InlineData(Subscriptions::PriceModelPercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelPercentCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Custom)]
    public void Validation_Works(Subscriptions::PriceModelPercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelPercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelPercentCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceModelPercentCadence.Annual)]
    [InlineData(Subscriptions::PriceModelPercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelPercentCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelPercentCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::PriceModelPercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelPercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelPercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelPercentCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelPercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelPercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelPercentPercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelPercentPercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelPercentPercentConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelPercentPercentConfig { Percent = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelPercentPercentConfig>(
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
        var model = new Subscriptions::PriceModelPercentPercentConfig { Percent = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelPercentPercentConfig { Percent = 0 };

        Subscriptions::PriceModelPercentPercentConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelPercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PriceModelPercentConversionRateConfig value =
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
        Subscriptions::PriceModelPercentConversionRateConfig value =
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
        Subscriptions::PriceModelPercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelPercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModelPercentConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelPercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        ApiEnum<string, Subscriptions::PriceModelEventOutputCadence> expectedCadence =
            Subscriptions::PriceModelEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        Subscriptions::PriceModelEventOutputEventOutputConfig expectedEventOutputConfig = new()
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
        Subscriptions::PriceModelEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEventOutputConfig, model.EventOutputConfig);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, model.ModelType));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::PriceModelEventOutputCadence> expectedCadence =
            Subscriptions::PriceModelEventOutputCadence.Annual;
        string expectedCurrency = "currency";
        Subscriptions::PriceModelEventOutputEventOutputConfig expectedEventOutputConfig = new()
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
        Subscriptions::PriceModelEventOutputConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEventOutputConfig, deserialized.EventOutputConfig);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.True(JsonElement.DeepEquals(expectedModelType, deserialized.ModelType));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillableMetricID, deserialized.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, deserialized.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, deserialized.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, deserialized.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, deserialized.ConversionRateConfig);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
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
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = null,
            ExternalPriceID = null,
            FixedPriceQuantity = null,
            InvoiceGroupingKey = null,
            InvoicingCycleConfiguration = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelEventOutput
        {
            Cadence = Subscriptions::PriceModelEventOutputCadence.Annual,
            Currency = "currency",
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
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Subscriptions::PriceModelEventOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelEventOutputCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Annual)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Custom)]
    public void Validation_Works(Subscriptions::PriceModelEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelEventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelEventOutputCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Annual)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Monthly)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.OneTime)]
    [InlineData(Subscriptions::PriceModelEventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::PriceModelEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PriceModelEventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelEventOutputCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PriceModelEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceModelEventOutputEventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
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
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutputEventOutputConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutputEventOutputConfig>(
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
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
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
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
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
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
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
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",

            DefaultUnitRate = null,
            GroupingKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::PriceModelEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        Subscriptions::PriceModelEventOutputEventOutputConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PriceModelEventOutputConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PriceModelEventOutputConversionRateConfig value =
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
        Subscriptions::PriceModelEventOutputConversionRateConfig value =
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
        Subscriptions::PriceModelEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PriceModelEventOutputConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::PriceModelEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceIntervalsParamsAddAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AdjustmentID = "h74gfhdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate expectedStartDate =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment expectedAdjustment =
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
        string expectedAdjustmentID = "h74gfhdjvn7ujokd";
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate expectedEndDate =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedAdjustment, model.Adjustment);
        Assert.Equal(expectedAdjustmentID, model.AdjustmentID);
        Assert.Equal(expectedEndDate, model.EndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AdjustmentID = "h74gfhdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AdjustmentID = "h74gfhdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate expectedStartDate =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment expectedAdjustment =
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
        string expectedAdjustmentID = "h74gfhdjvn7ujokd";
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate expectedEndDate =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedAdjustment, deserialized.Adjustment);
        Assert.Equal(expectedAdjustmentID, deserialized.AdjustmentID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AdjustmentID = "h74gfhdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Adjustment);
        Assert.False(model.RawData.ContainsKey("adjustment"));
        Assert.Null(model.AdjustmentID);
        Assert.False(model.RawData.ContainsKey("adjustment_id"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Adjustment = null,
            AdjustmentID = null,
            EndDate = null,
        };

        Assert.Null(model.Adjustment);
        Assert.True(model.RawData.ContainsKey("adjustment"));
        Assert.Null(model.AdjustmentID);
        Assert.True(model.RawData.ContainsKey("adjustment_id"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Adjustment = null,
            AdjustmentID = null,
            EndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AdjustmentID = "h74gfhdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPriceIntervalsParamsAddAdjustmentStartDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate value =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate value =
            BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate value =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate value =
            BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentStartDate>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment value =
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
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPriceIntervalsParamsAddAdjustmentEndDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate value =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate value =
            BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate value =
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate value =
            BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPriceIntervalsParamsAddAdjustmentEndDate>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string expectedPriceIntervalID = "sdfs6wdjvn7ujokd";
        long expectedBillingCycleDay = 0;
        bool expectedCanDeferBilling = true;
        Subscriptions::EditEndDate expectedEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        List<Subscriptions::EditFixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Quantity = 5,
            },
        ];
        Subscriptions::EditStartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedPriceIntervalID, model.PriceIntervalID);
        Assert.Equal(expectedBillingCycleDay, model.BillingCycleDay);
        Assert.Equal(expectedCanDeferBilling, model.CanDeferBilling);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.NotNull(model.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            model.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                model.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.NotNull(model.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, model.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], model.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Edit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Edit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPriceIntervalID = "sdfs6wdjvn7ujokd";
        long expectedBillingCycleDay = 0;
        bool expectedCanDeferBilling = true;
        Subscriptions::EditEndDate expectedEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        List<Subscriptions::EditFixedFeeQuantityTransition> expectedFixedFeeQuantityTransitions =
        [
            new()
            {
                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Quantity = 5,
            },
        ];
        Subscriptions::EditStartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        List<string> expectedUsageCustomerIds = ["string"];

        Assert.Equal(expectedPriceIntervalID, deserialized.PriceIntervalID);
        Assert.Equal(expectedBillingCycleDay, deserialized.BillingCycleDay);
        Assert.Equal(expectedCanDeferBilling, deserialized.CanDeferBilling);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.NotNull(deserialized.FixedFeeQuantityTransitions);
        Assert.Equal(
            expectedFixedFeeQuantityTransitions.Count,
            deserialized.FixedFeeQuantityTransitions.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantityTransitions.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantityTransitions[i],
                deserialized.FixedFeeQuantityTransitions[i]
            );
        }
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.NotNull(deserialized.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, deserialized.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], deserialized.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            UsageCustomerIds = ["string"],
        };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            UsageCustomerIds = ["string"],

            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            UsageCustomerIds = ["string"],

            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.BillingCycleDay);
        Assert.False(model.RawData.ContainsKey("billing_cycle_day"));
        Assert.Null(model.CanDeferBilling);
        Assert.False(model.RawData.ContainsKey("can_defer_billing"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
        Assert.Null(model.FixedFeeQuantityTransitions);
        Assert.False(model.RawData.ContainsKey("fixed_fee_quantity_transitions"));
        Assert.Null(model.UsageCustomerIds);
        Assert.False(model.RawData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingCycleDay = null,
            CanDeferBilling = null,
            EndDate = null,
            Filter = null,
            FixedFeeQuantityTransitions = null,
            UsageCustomerIds = null,
        };

        Assert.Null(model.BillingCycleDay);
        Assert.True(model.RawData.ContainsKey("billing_cycle_day"));
        Assert.Null(model.CanDeferBilling);
        Assert.True(model.RawData.ContainsKey("can_defer_billing"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
        Assert.Null(model.FixedFeeQuantityTransitions);
        Assert.True(model.RawData.ContainsKey("fixed_fee_quantity_transitions"));
        Assert.Null(model.UsageCustomerIds);
        Assert.True(model.RawData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingCycleDay = null,
            CanDeferBilling = null,
            EndDate = null,
            Filter = null,
            FixedFeeQuantityTransitions = null,
            UsageCustomerIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Edit
        {
            PriceIntervalID = "sdfs6wdjvn7ujokd",
            BillingCycleDay = 0,
            CanDeferBilling = true,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            FixedFeeQuantityTransitions =
            [
                new()
                {
                    EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Quantity = 5,
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageCustomerIds = ["string"],
        };

        Subscriptions::Edit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EditEndDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::EditEndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::EditEndDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::EditEndDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditEndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::EditEndDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditEndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EditFixedFeeQuantityTransitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::EditFixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedQuantity = 5;

        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::EditFixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::EditFixedFeeQuantityTransition>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::EditFixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::EditFixedFeeQuantityTransition>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedQuantity = 5;

        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::EditFixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::EditFixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Quantity = 5,
        };

        Subscriptions::EditFixedFeeQuantityTransition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EditStartDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::EditStartDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::EditStartDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::EditStartDate value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditStartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::EditStartDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditStartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EditAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAdjustmentIntervalID = "sdfs6wdjvn7ujokd";
        Subscriptions::EditAdjustmentEndDate expectedEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Subscriptions::EditAdjustmentStartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedAdjustmentIntervalID, model.AdjustmentIntervalID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAdjustmentIntervalID = "sdfs6wdjvn7ujokd";
        Subscriptions::EditAdjustmentEndDate expectedEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Subscriptions::EditAdjustmentStartDate expectedStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedAdjustmentIntervalID, deserialized.AdjustmentIntervalID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            EndDate = null,
        };

        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            EndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::EditAdjustment
        {
            AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::EditAdjustment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EditAdjustmentEndDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::EditAdjustmentEndDate value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::EditAdjustmentEndDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::EditAdjustmentEndDate value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustmentEndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::EditAdjustmentEndDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustmentEndDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EditAdjustmentStartDateTest : TestBase
{
    [Fact]
    public void DateTimeValidationWorks()
    {
        Subscriptions::EditAdjustmentStartDate value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void BillingCycleRelativeValidationWorks()
    {
        Subscriptions::EditAdjustmentStartDate value = BillingCycleRelativeDate.StartOfTerm;
        value.Validate();
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Subscriptions::EditAdjustmentStartDate value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustmentStartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BillingCycleRelativeSerializationRoundtripWorks()
    {
        Subscriptions::EditAdjustmentStartDate value = BillingCycleRelativeDate.StartOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EditAdjustmentStartDate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
