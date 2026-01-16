using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
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
            AlignBillingWithSubscriptionStartDate = true,
            AutoCollection = true,
            AwsRegion = "aws_region",
            BillingCycleAnchorConfiguration = new()
            {
                Day = 1,
                Month = 1,
                Year = 0,
            },
            CouponRedemptionCode = "coupon_redemption_code",
            CreditsOverageRate = 0,
            Currency = "currency",
            CustomerID = "customer_id",
            DefaultInvoiceMemo = "default_invoice_memo",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalCustomerID = "external_customer_id",
            ExternalMarketplace = Subscriptions::ExternalMarketplace.Google,
            ExternalMarketplaceReportingID = "external_marketplace_reporting_id",
            ExternalPlanID = "ZMwNQefe7J3ecf7W",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            InitialPhaseOrder = 2,
            InvoicingThreshold = "10.00",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialDurationDays = 0,
            UsageCustomerIds = ["string"],
        };

        List<Subscriptions::AddAdjustment> expectedAddAdjustments =
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
        List<Subscriptions::AddPrice> expectedAddPrices =
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
        bool expectedAlignBillingWithSubscriptionStartDate = true;
        bool expectedAutoCollection = true;
        string expectedAwsRegion = "aws_region";
        BillingCycleAnchorConfiguration expectedBillingCycleAnchorConfiguration = new()
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };
        string expectedCouponRedemptionCode = "coupon_redemption_code";
        double expectedCreditsOverageRate = 0;
        string expectedCurrency = "currency";
        string expectedCustomerID = "customer_id";
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalCustomerID = "external_customer_id";
        ApiEnum<string, Subscriptions::ExternalMarketplace> expectedExternalMarketplace =
            Subscriptions::ExternalMarketplace.Google;
        string expectedExternalMarketplaceReportingID = "external_marketplace_reporting_id";
        string expectedExternalPlanID = "ZMwNQefe7J3ecf7W";
        string expectedFilter = "my_property > 100 AND my_other_property = 'bar'";
        long expectedInitialPhaseOrder = 2;
        string expectedInvoicingThreshold = "10.00";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        long expectedNetTerms = 0;
        double expectedPerCreditOverageAmount = 0;
        string expectedPlanID = "ZMwNQefe7J3ecf7W";
        long expectedPlanVersionNumber = 0;
        List<JsonElement> expectedPriceOverrides = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<Subscriptions::RemoveAdjustment> expectedRemoveAdjustments = [new("h74gfhdjvn7ujokd")];
        List<Subscriptions::RemovePrice> expectedRemovePrices =
        [
            new() { ExternalPriceID = "external_price_id", PriceID = "h74gfhdjvn7ujokd" },
        ];
        List<Subscriptions::ReplaceAdjustment> expectedReplaceAdjustments =
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
        List<Subscriptions::ReplacePrice> expectedReplacePrices =
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
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedTrialDurationDays = 0;
        List<string> expectedUsageCustomerIds = ["string"];

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
            expectedAlignBillingWithSubscriptionStartDate,
            parameters.AlignBillingWithSubscriptionStartDate
        );
        Assert.Equal(expectedAutoCollection, parameters.AutoCollection);
        Assert.Equal(expectedAwsRegion, parameters.AwsRegion);
        Assert.Equal(
            expectedBillingCycleAnchorConfiguration,
            parameters.BillingCycleAnchorConfiguration
        );
        Assert.Equal(expectedCouponRedemptionCode, parameters.CouponRedemptionCode);
        Assert.Equal(expectedCreditsOverageRate, parameters.CreditsOverageRate);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDefaultInvoiceMemo, parameters.DefaultInvoiceMemo);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedExternalCustomerID, parameters.ExternalCustomerID);
        Assert.Equal(expectedExternalMarketplace, parameters.ExternalMarketplace);
        Assert.Equal(
            expectedExternalMarketplaceReportingID,
            parameters.ExternalMarketplaceReportingID
        );
        Assert.Equal(expectedExternalPlanID, parameters.ExternalPlanID);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedInitialPhaseOrder, parameters.InitialPhaseOrder);
        Assert.Equal(expectedInvoicingThreshold, parameters.InvoicingThreshold);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
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
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTrialDurationDays, parameters.TrialDurationDays);
        Assert.NotNull(parameters.UsageCustomerIds);
        Assert.Equal(expectedUsageCustomerIds.Count, parameters.UsageCustomerIds.Count);
        for (int i = 0; i < expectedUsageCustomerIds.Count; i++)
        {
            Assert.Equal(expectedUsageCustomerIds[i], parameters.UsageCustomerIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
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
            AutoCollection = true,
            AwsRegion = "aws_region",
            BillingCycleAnchorConfiguration = new()
            {
                Day = 1,
                Month = 1,
                Year = 0,
            },
            CouponRedemptionCode = "coupon_redemption_code",
            CreditsOverageRate = 0,
            Currency = "currency",
            CustomerID = "customer_id",
            DefaultInvoiceMemo = "default_invoice_memo",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalCustomerID = "external_customer_id",
            ExternalMarketplace = Subscriptions::ExternalMarketplace.Google,
            ExternalMarketplaceReportingID = "external_marketplace_reporting_id",
            ExternalPlanID = "ZMwNQefe7J3ecf7W",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            InitialPhaseOrder = 2,
            InvoicingThreshold = "10.00",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialDurationDays = 0,
            UsageCustomerIds = ["string"],
        };

        Assert.Null(parameters.AlignBillingWithSubscriptionStartDate);
        Assert.False(
            parameters.RawBodyData.ContainsKey("align_billing_with_subscription_start_date")
        );
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
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
            AutoCollection = true,
            AwsRegion = "aws_region",
            BillingCycleAnchorConfiguration = new()
            {
                Day = 1,
                Month = 1,
                Year = 0,
            },
            CouponRedemptionCode = "coupon_redemption_code",
            CreditsOverageRate = 0,
            Currency = "currency",
            CustomerID = "customer_id",
            DefaultInvoiceMemo = "default_invoice_memo",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalCustomerID = "external_customer_id",
            ExternalMarketplace = Subscriptions::ExternalMarketplace.Google,
            ExternalMarketplaceReportingID = "external_marketplace_reporting_id",
            ExternalPlanID = "ZMwNQefe7J3ecf7W",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            InitialPhaseOrder = 2,
            InvoicingThreshold = "10.00",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialDurationDays = 0,
            UsageCustomerIds = ["string"],

            // Null should be interpreted as omitted for these properties
            AlignBillingWithSubscriptionStartDate = null,
        };

        Assert.Null(parameters.AlignBillingWithSubscriptionStartDate);
        Assert.False(
            parameters.RawBodyData.ContainsKey("align_billing_with_subscription_start_date")
        );
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            AlignBillingWithSubscriptionStartDate = true,
        };

        Assert.Null(parameters.AddAdjustments);
        Assert.False(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.AddPrices);
        Assert.False(parameters.RawBodyData.ContainsKey("add_prices"));
        Assert.Null(parameters.AutoCollection);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.AwsRegion);
        Assert.False(parameters.RawBodyData.ContainsKey("aws_region"));
        Assert.Null(parameters.BillingCycleAnchorConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_cycle_anchor_configuration"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
        Assert.Null(parameters.CreditsOverageRate);
        Assert.False(parameters.RawBodyData.ContainsKey("credits_overage_rate"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.False(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.ExternalMarketplace);
        Assert.False(parameters.RawBodyData.ContainsKey("external_marketplace"));
        Assert.Null(parameters.ExternalMarketplaceReportingID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_marketplace_reporting_id"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.InitialPhaseOrder);
        Assert.False(parameters.RawBodyData.ContainsKey("initial_phase_order"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
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
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("start_date"));
        Assert.Null(parameters.TrialDurationDays);
        Assert.False(parameters.RawBodyData.ContainsKey("trial_duration_days"));
        Assert.Null(parameters.UsageCustomerIds);
        Assert.False(parameters.RawBodyData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
            AlignBillingWithSubscriptionStartDate = true,

            AddAdjustments = null,
            AddPrices = null,
            AutoCollection = null,
            AwsRegion = null,
            BillingCycleAnchorConfiguration = null,
            CouponRedemptionCode = null,
            CreditsOverageRate = null,
            Currency = null,
            CustomerID = null,
            DefaultInvoiceMemo = null,
            EndDate = null,
            ExternalCustomerID = null,
            ExternalMarketplace = null,
            ExternalMarketplaceReportingID = null,
            ExternalPlanID = null,
            Filter = null,
            InitialPhaseOrder = null,
            InvoicingThreshold = null,
            Metadata = null,
            Name = null,
            NetTerms = null,
            PerCreditOverageAmount = null,
            PlanID = null,
            PlanVersionNumber = null,
            PriceOverrides = null,
            RemoveAdjustments = null,
            RemovePrices = null,
            ReplaceAdjustments = null,
            ReplacePrices = null,
            StartDate = null,
            TrialDurationDays = null,
            UsageCustomerIds = null,
        };

        Assert.Null(parameters.AddAdjustments);
        Assert.True(parameters.RawBodyData.ContainsKey("add_adjustments"));
        Assert.Null(parameters.AddPrices);
        Assert.True(parameters.RawBodyData.ContainsKey("add_prices"));
        Assert.Null(parameters.AutoCollection);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_collection"));
        Assert.Null(parameters.AwsRegion);
        Assert.True(parameters.RawBodyData.ContainsKey("aws_region"));
        Assert.Null(parameters.BillingCycleAnchorConfiguration);
        Assert.True(parameters.RawBodyData.ContainsKey("billing_cycle_anchor_configuration"));
        Assert.Null(parameters.CouponRedemptionCode);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_redemption_code"));
        Assert.Null(parameters.CreditsOverageRate);
        Assert.True(parameters.RawBodyData.ContainsKey("credits_overage_rate"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.CustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("customer_id"));
        Assert.Null(parameters.DefaultInvoiceMemo);
        Assert.True(parameters.RawBodyData.ContainsKey("default_invoice_memo"));
        Assert.Null(parameters.EndDate);
        Assert.True(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.ExternalCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_customer_id"));
        Assert.Null(parameters.ExternalMarketplace);
        Assert.True(parameters.RawBodyData.ContainsKey("external_marketplace"));
        Assert.Null(parameters.ExternalMarketplaceReportingID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_marketplace_reporting_id"));
        Assert.Null(parameters.ExternalPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_plan_id"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.InitialPhaseOrder);
        Assert.True(parameters.RawBodyData.ContainsKey("initial_phase_order"));
        Assert.Null(parameters.InvoicingThreshold);
        Assert.True(parameters.RawBodyData.ContainsKey("invoicing_threshold"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
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
        Assert.Null(parameters.StartDate);
        Assert.True(parameters.RawBodyData.ContainsKey("start_date"));
        Assert.Null(parameters.TrialDurationDays);
        Assert.True(parameters.RawBodyData.ContainsKey("trial_duration_days"));
        Assert.Null(parameters.UsageCustomerIds);
        Assert.True(parameters.RawBodyData.ContainsKey("usage_customer_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionCreateParams
        {
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
            AlignBillingWithSubscriptionStartDate = true,
            AutoCollection = true,
            AwsRegion = "aws_region",
            BillingCycleAnchorConfiguration = new()
            {
                Day = 1,
                Month = 1,
                Year = 0,
            },
            CouponRedemptionCode = "coupon_redemption_code",
            CreditsOverageRate = 0,
            Currency = "currency",
            CustomerID = "customer_id",
            DefaultInvoiceMemo = "default_invoice_memo",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalCustomerID = "external_customer_id",
            ExternalMarketplace = Subscriptions::ExternalMarketplace.Google,
            ExternalMarketplaceReportingID = "external_marketplace_reporting_id",
            ExternalPlanID = "ZMwNQefe7J3ecf7W",
            Filter = "my_property > 100 AND my_other_property = 'bar'",
            InitialPhaseOrder = 2,
            InvoicingThreshold = "10.00",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
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
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialDurationDays = 0,
            UsageCustomerIds = ["string"],
        };

        Subscriptions::SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::AddAdjustment
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

        Subscriptions::Adjustment expectedAdjustment = new NewPercentageDiscount()
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
        var model = new Subscriptions::AddAdjustment
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AddAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::AddAdjustment
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AddAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::Adjustment expectedAdjustment = new NewPercentageDiscount()
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
        var model = new Subscriptions::AddAdjustment
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
        var model = new Subscriptions::AddAdjustment
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
        var model = new Subscriptions::AddAdjustment
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
        var model = new Subscriptions::AddAdjustment
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
        var model = new Subscriptions::AddAdjustment
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

public class AdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Subscriptions::Adjustment value = new NewPercentageDiscount()
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
        Subscriptions::Adjustment value = new NewUsageDiscount()
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
        Subscriptions::Adjustment value = new NewAmountDiscount()
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
        Subscriptions::Adjustment value = new NewMinimum()
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
        Subscriptions::Adjustment value = new NewMaximum()
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
        Subscriptions::Adjustment value = new NewPercentageDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::Adjustment value = new NewUsageDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Subscriptions::Adjustment value = new NewAmountDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Subscriptions::Adjustment value = new NewMinimum()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Subscriptions::Adjustment value = new NewMaximum()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AddPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::AddPrice
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
        Subscriptions::Price expectedPrice = new Subscriptions::NewSubscriptionUnitPrice()
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
        var model = new Subscriptions::AddPrice
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AddPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::AddPrice
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::AddPrice>(
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
        Subscriptions::Price expectedPrice = new Subscriptions::NewSubscriptionUnitPrice()
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
        var model = new Subscriptions::AddPrice
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
        var model = new Subscriptions::AddPrice { };

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
        var model = new Subscriptions::AddPrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::AddPrice
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
        var model = new Subscriptions::AddPrice
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

public class PriceTest : TestBase
{
    [Fact]
    public void NewSubscriptionUnitValidationWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionBulkPrice()
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
        Subscriptions::Price value = new Subscriptions::BulkWithFilters()
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
            Cadence = Subscriptions::Cadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionPackagePrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredPackagePrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedTieredPrice()
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
        Subscriptions::Price value =
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitWithPercentPrice()
        {
            Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        Subscriptions::Price value = new Subscriptions::TieredWithProration()
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitWithProrationPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedAllocationPrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionBulkWithProrationPrice()
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
        Subscriptions::Price value =
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
        Subscriptions::Price value =
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
        Subscriptions::Price value = new Subscriptions::GroupedWithMinMaxThresholds()
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
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
        Subscriptions::Price value =
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
        Subscriptions::Price value =
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
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
        Subscriptions::Price value = new Subscriptions::CumulativeGroupedAllocation()
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::Minimum()
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMinimumCompositePrice()
        {
            Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        Subscriptions::Price value = new Subscriptions::Percent()
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::EventOutput()
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionBulkPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::BulkWithFilters()
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionPackagePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionThresholdTotalAmountPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredPackagePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionTieredWithMinimumPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedTieredPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::Price value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionPackageWithAllocationPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitWithPercentPrice()
        {
            Cadence = Subscriptions::NewSubscriptionUnitWithPercentPriceCadence.Annual,
            ItemID = "item_id",
            ModelType = Subscriptions::NewSubscriptionUnitWithPercentPriceModelType.UnitWithPercent,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixWithAllocationPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixWithAllocationPriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithAllocationConfig = new()
            {
                Allocation = "allocation",
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::TieredWithProration()
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionUnitWithProrationPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedAllocationPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionBulkWithProrationPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Subscriptions::Price value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Subscriptions::Price value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::GroupedWithMinMaxThresholds()
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionGroupedTieredPackagePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Subscriptions::Price value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Subscriptions::Price value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::CumulativeGroupedAllocation()
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MinimumSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::Minimum()
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::NewSubscriptionMinimumCompositePrice()
        {
            Cadence = Subscriptions::NewSubscriptionMinimumCompositePriceCadence.Annual,
            ItemID = "item_id",
            MinimumCompositeConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::Percent()
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Subscriptions::Price value = new Subscriptions::EventOutput()
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Price>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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

        Subscriptions::BulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, Subscriptions::Cadence> expectedCadence = Subscriptions::Cadence.Annual;
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
        Subscriptions::ConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BulkWithFilters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BulkWithFilters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::BulkWithFiltersConfig expectedBulkWithFiltersConfig = new()
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };
        ApiEnum<string, Subscriptions::Cadence> expectedCadence = Subscriptions::Cadence.Annual;
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
        Subscriptions::ConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var model = new Subscriptions::BulkWithFilters
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
            Cadence = Subscriptions::Cadence.Annual,
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
        var model = new Subscriptions::BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Subscriptions::Filter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::Tier> expectedTiers =
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
        var model = new Subscriptions::BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BulkWithFiltersConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::BulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BulkWithFiltersConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Subscriptions::Filter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::Tier> expectedTiers =
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
        var model = new Subscriptions::BulkWithFiltersConfig
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
        var model = new Subscriptions::Filter { PropertyKey = "x", PropertyValue = "x" };

        string expectedPropertyKey = "x";
        string expectedPropertyValue = "x";

        Assert.Equal(expectedPropertyKey, model.PropertyKey);
        Assert.Equal(expectedPropertyValue, model.PropertyValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Filter { PropertyKey = "x", PropertyValue = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Filter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Filter { PropertyKey = "x", PropertyValue = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Filter>(
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
        var model = new Subscriptions::Filter { PropertyKey = "x", PropertyValue = "x" };

        model.Validate();
    }
}

public class TierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Tier
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
        var model = new Subscriptions::Tier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Tier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Tier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Tier>(
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
        var model = new Subscriptions::Tier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Tier { UnitAmount = "unit_amount" };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Tier { UnitAmount = "unit_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Tier
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
        var model = new Subscriptions::Tier
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
    [InlineData(Subscriptions::Cadence.Annual)]
    [InlineData(Subscriptions::Cadence.SemiAnnual)]
    [InlineData(Subscriptions::Cadence.Monthly)]
    [InlineData(Subscriptions::Cadence.Quarterly)]
    [InlineData(Subscriptions::Cadence.OneTime)]
    [InlineData(Subscriptions::Cadence.Custom)]
    public void Validation_Works(Subscriptions::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::Cadence.Annual)]
    [InlineData(Subscriptions::Cadence.SemiAnnual)]
    [InlineData(Subscriptions::Cadence.Monthly)]
    [InlineData(Subscriptions::Cadence.Quarterly)]
    [InlineData(Subscriptions::Cadence.OneTime)]
    [InlineData(Subscriptions::Cadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::Cadence>>(
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
        Subscriptions::ConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::ConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        Subscriptions::ConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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

        ApiEnum<string, Subscriptions::TieredWithProrationCadence> expectedCadence =
            Subscriptions::TieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
        string expectedName = "Annual fee";
        Subscriptions::TieredWithProrationConfig expectedTieredWithProrationConfig = new(
            [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
        );
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::TieredWithProrationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::TieredWithProrationCadence> expectedCadence =
            Subscriptions::TieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
        string expectedName = "Annual fee";
        Subscriptions::TieredWithProrationConfig expectedTieredWithProrationConfig = new(
            [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]
        );
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::TieredWithProrationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::TieredWithProration
        {
            Cadence = Subscriptions::TieredWithProrationCadence.Annual,
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
    [InlineData(Subscriptions::TieredWithProrationCadence.Annual)]
    [InlineData(Subscriptions::TieredWithProrationCadence.SemiAnnual)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Monthly)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Quarterly)]
    [InlineData(Subscriptions::TieredWithProrationCadence.OneTime)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Custom)]
    public void Validation_Works(Subscriptions::TieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::TieredWithProrationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TieredWithProrationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::TieredWithProrationCadence.Annual)]
    [InlineData(Subscriptions::TieredWithProrationCadence.SemiAnnual)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Monthly)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Quarterly)]
    [InlineData(Subscriptions::TieredWithProrationCadence.OneTime)]
    [InlineData(Subscriptions::TieredWithProrationCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::TieredWithProrationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::TieredWithProrationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TieredWithProrationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::TieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TieredWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        List<Subscriptions::TieredWithProrationConfigTier> expectedTiers =
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
        var model = new Subscriptions::TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Subscriptions::TieredWithProrationConfigTier> expectedTiers =
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
        var model = new Subscriptions::TieredWithProrationConfig
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
        var model = new Subscriptions::TieredWithProrationConfigTier
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
        var model = new Subscriptions::TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConfigTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::TieredWithProrationConfigTier
        {
            TierLowerBound = "tier_lower_bound",
            UnitAmount = "unit_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConfigTier>(
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
        var model = new Subscriptions::TieredWithProrationConfigTier
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
        Subscriptions::TieredWithProrationConversionRateConfig value =
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
        Subscriptions::TieredWithProrationConversionRateConfig value =
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
        Subscriptions::TieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::TieredWithProrationConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::TieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class GroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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

        ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence> expectedCadence =
            Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::GroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholds>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholds>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence> expectedCadence =
            Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::GroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::GroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual,
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
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(Subscriptions::GroupedWithMinMaxThresholdsCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::GroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::GroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::GroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GroupedWithMinMaxThresholdsConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::GroupedWithMinMaxThresholdsConfig
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
        var model = new Subscriptions::GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::GroupedWithMinMaxThresholdsConfig
        {
            GroupingKey = "x",
            MaximumCharge = "maximum_charge",
            MinimumCharge = "minimum_charge",
            PerUnitRate = "per_unit_rate",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholdsConfig>(
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
        var model = new Subscriptions::GroupedWithMinMaxThresholdsConfig
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
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::GroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class CumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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

        ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence> expectedCadence =
            Subscriptions::CumulativeGroupedAllocationCadence.Annual;
        Subscriptions::CumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence> expectedCadence =
            Subscriptions::CumulativeGroupedAllocationCadence.Annual;
        Subscriptions::CumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::CumulativeGroupedAllocation
        {
            Cadence = Subscriptions::CumulativeGroupedAllocationCadence.Annual,
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
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(Subscriptions::CumulativeGroupedAllocationCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::CumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::CumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::CumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CumulativeGroupedAllocationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::CumulativeGroupedAllocationConfig
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
        var model = new Subscriptions::CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::CumulativeGroupedAllocationConfig
        {
            CumulativeAllocation = "cumulative_allocation",
            GroupAllocation = "group_allocation",
            GroupingKey = "x",
            UnitAmount = "unit_amount",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocationConfig>(
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
        var model = new Subscriptions::CumulativeGroupedAllocationConfig
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
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::CumulativeGroupedAllocationConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::CumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class MinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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

        ApiEnum<string, Subscriptions::MinimumCadence> expectedCadence =
            Subscriptions::MinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::MinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
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
        Subscriptions::MinimumConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Minimum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Minimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::MinimumCadence> expectedCadence =
            Subscriptions::MinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::MinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
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
        Subscriptions::MinimumConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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
        var model = new Subscriptions::Minimum
        {
            Cadence = Subscriptions::MinimumCadence.Annual,
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

public class MinimumCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::MinimumCadence.Annual)]
    [InlineData(Subscriptions::MinimumCadence.SemiAnnual)]
    [InlineData(Subscriptions::MinimumCadence.Monthly)]
    [InlineData(Subscriptions::MinimumCadence.Quarterly)]
    [InlineData(Subscriptions::MinimumCadence.OneTime)]
    [InlineData(Subscriptions::MinimumCadence.Custom)]
    public void Validation_Works(Subscriptions::MinimumCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::MinimumCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::MinimumCadence.Annual)]
    [InlineData(Subscriptions::MinimumCadence.SemiAnnual)]
    [InlineData(Subscriptions::MinimumCadence.Monthly)]
    [InlineData(Subscriptions::MinimumCadence.Quarterly)]
    [InlineData(Subscriptions::MinimumCadence.OneTime)]
    [InlineData(Subscriptions::MinimumCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::MinimumCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::MinimumCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::MinimumCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::MinimumCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::MinimumConfig
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
        var model = new Subscriptions::MinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::MinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumConfig>(
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
        var model = new Subscriptions::MinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::MinimumConfig { MinimumAmount = "minimum_amount" };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::MinimumConfig { MinimumAmount = "minimum_amount" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::MinimumConfig
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
        var model = new Subscriptions::MinimumConfig
        {
            MinimumAmount = "minimum_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        model.Validate();
    }
}

public class MinimumConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::MinimumConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::MinimumConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        Subscriptions::MinimumConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::MinimumConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::MinimumConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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

        ApiEnum<string, Subscriptions::PercentCadence> expectedCadence =
            Subscriptions::PercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::PercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::PercentConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Percent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Percent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::PercentCadence> expectedCadence =
            Subscriptions::PercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::PercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::PercentConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
        var model = new Subscriptions::Percent
        {
            Cadence = Subscriptions::PercentCadence.Annual,
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
    [InlineData(Subscriptions::PercentCadence.Annual)]
    [InlineData(Subscriptions::PercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::PercentCadence.Monthly)]
    [InlineData(Subscriptions::PercentCadence.Quarterly)]
    [InlineData(Subscriptions::PercentCadence.OneTime)]
    [InlineData(Subscriptions::PercentCadence.Custom)]
    public void Validation_Works(Subscriptions::PercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::PercentCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::PercentCadence.Annual)]
    [InlineData(Subscriptions::PercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::PercentCadence.Monthly)]
    [InlineData(Subscriptions::PercentCadence.Quarterly)]
    [InlineData(Subscriptions::PercentCadence.OneTime)]
    [InlineData(Subscriptions::PercentCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::PercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::PercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::PercentCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::PercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::PercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::PercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PercentConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::PercentConfig { Percent = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PercentConfig>(
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
        var model = new Subscriptions::PercentConfig { Percent = 0 };

        model.Validate();
    }
}

public class PercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::PercentConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::PercentConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        Subscriptions::PercentConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PercentConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::PercentConversionRateConfig value = new SharedTieredConversionRateConfig()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::PercentConversionRateConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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

        ApiEnum<string, Subscriptions::EventOutputCadence> expectedCadence =
            Subscriptions::EventOutputCadence.Annual;
        Subscriptions::EventOutputConfig expectedEventOutputConfig = new()
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
        Subscriptions::EventOutputConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EventOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EventOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::EventOutputCadence> expectedCadence =
            Subscriptions::EventOutputCadence.Annual;
        Subscriptions::EventOutputConfig expectedEventOutputConfig = new()
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
        Subscriptions::EventOutputConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
        var model = new Subscriptions::EventOutput
        {
            Cadence = Subscriptions::EventOutputCadence.Annual,
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
    [InlineData(Subscriptions::EventOutputCadence.Annual)]
    [InlineData(Subscriptions::EventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::EventOutputCadence.Monthly)]
    [InlineData(Subscriptions::EventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::EventOutputCadence.OneTime)]
    [InlineData(Subscriptions::EventOutputCadence.Custom)]
    public void Validation_Works(Subscriptions::EventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::EventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EventOutputCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::EventOutputCadence.Annual)]
    [InlineData(Subscriptions::EventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::EventOutputCadence.Monthly)]
    [InlineData(Subscriptions::EventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::EventOutputCadence.OneTime)]
    [InlineData(Subscriptions::EventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(Subscriptions::EventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::EventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::EventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::EventOutputCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::EventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::EventOutputConfig
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
        var model = new Subscriptions::EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EventOutputConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::EventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::EventOutputConfig>(
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
        var model = new Subscriptions::EventOutputConfig
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
        var model = new Subscriptions::EventOutputConfig { UnitRatingKey = "x" };

        Assert.Null(model.DefaultUnitRate);
        Assert.False(model.RawData.ContainsKey("default_unit_rate"));
        Assert.Null(model.GroupingKey);
        Assert.False(model.RawData.ContainsKey("grouping_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::EventOutputConfig { UnitRatingKey = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::EventOutputConfig
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
        var model = new Subscriptions::EventOutputConfig
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
        Subscriptions::EventOutputConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        value.Validate();
    }

    [Fact]
    public void TieredValidationWorks()
    {
        Subscriptions::EventOutputConversionRateConfig value =
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
        Subscriptions::EventOutputConversionRateConfig value = new SharedUnitConversionRateConfig()
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::EventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::EventOutputConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::EventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ExternalMarketplaceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ExternalMarketplace.Google)]
    [InlineData(Subscriptions::ExternalMarketplace.Aws)]
    [InlineData(Subscriptions::ExternalMarketplace.Azure)]
    public void Validation_Works(Subscriptions::ExternalMarketplace rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ExternalMarketplace> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExternalMarketplace>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ExternalMarketplace.Google)]
    [InlineData(Subscriptions::ExternalMarketplace.Aws)]
    [InlineData(Subscriptions::ExternalMarketplace.Azure)]
    public void SerializationRoundtrip_Works(Subscriptions::ExternalMarketplace rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ExternalMarketplace> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ExternalMarketplace>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Subscriptions::ExternalMarketplace>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ExternalMarketplace>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RemoveAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::RemoveAdjustment { AdjustmentID = "h74gfhdjvn7ujokd" };

        string expectedAdjustmentID = "h74gfhdjvn7ujokd";

        Assert.Equal(expectedAdjustmentID, model.AdjustmentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::RemoveAdjustment { AdjustmentID = "h74gfhdjvn7ujokd" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::RemoveAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::RemoveAdjustment { AdjustmentID = "h74gfhdjvn7ujokd" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::RemoveAdjustment>(
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
        var model = new Subscriptions::RemoveAdjustment { AdjustmentID = "h74gfhdjvn7ujokd" };

        model.Validate();
    }
}

public class RemovePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::RemovePrice
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
        var model = new Subscriptions::RemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::RemovePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::RemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::RemovePrice>(
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
        var model = new Subscriptions::RemovePrice
        {
            ExternalPriceID = "external_price_id",
            PriceID = "h74gfhdjvn7ujokd",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::RemovePrice { };

        Assert.Null(model.ExternalPriceID);
        Assert.False(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.PriceID);
        Assert.False(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::RemovePrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::RemovePrice { ExternalPriceID = null, PriceID = null };

        Assert.Null(model.ExternalPriceID);
        Assert.True(model.RawData.ContainsKey("external_price_id"));
        Assert.Null(model.PriceID);
        Assert.True(model.RawData.ContainsKey("price_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::RemovePrice { ExternalPriceID = null, PriceID = null };

        model.Validate();
    }
}

public class ReplaceAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplaceAdjustment
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

        Subscriptions::ReplaceAdjustmentAdjustment expectedAdjustment = new NewPercentageDiscount()
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
        var model = new Subscriptions::ReplaceAdjustment
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplaceAdjustment
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Subscriptions::ReplaceAdjustmentAdjustment expectedAdjustment = new NewPercentageDiscount()
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
        var model = new Subscriptions::ReplaceAdjustment
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

public class ReplaceAdjustmentAdjustmentTest : TestBase
{
    [Fact]
    public void NewPercentageDiscountValidationWorks()
    {
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewPercentageDiscount()
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
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewUsageDiscount()
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
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewAmountDiscount()
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
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewMinimum()
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
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewMaximum()
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
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewPercentageDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustmentAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewUsageDiscountSerializationRoundtripWorks()
    {
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewUsageDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustmentAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewAmountDiscountSerializationRoundtripWorks()
    {
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewAmountDiscount()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustmentAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewMinimum()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustmentAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewMaximumSerializationRoundtripWorks()
    {
        Subscriptions::ReplaceAdjustmentAdjustment value = new NewMaximum()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplaceAdjustmentAdjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePrice
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
        Subscriptions::ReplacePricePrice expectedPrice =
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
        var model = new Subscriptions::ReplacePrice
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePrice
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePrice>(
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
        Subscriptions::ReplacePricePrice expectedPrice =
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
        var model = new Subscriptions::ReplacePrice
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
        var model = new Subscriptions::ReplacePrice { ReplacesPriceID = "replaces_price_id" };

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
        var model = new Subscriptions::ReplacePrice { ReplacesPriceID = "replaces_price_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePrice
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
        var model = new Subscriptions::ReplacePrice
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

public class ReplacePricePriceTest : TestBase
{
    [Fact]
    public void NewSubscriptionUnitValidationWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionUnitPrice()
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionTieredPrice()
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionBulkPrice()
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
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceBulkWithFilters()
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
                Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionPackagePrice()
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionMatrixPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceTieredWithProration()
            {
                Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds()
            {
                Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation()
            {
                Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePriceMinimum()
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        Subscriptions::ReplacePricePrice value =
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePricePercent()
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePriceEventOutput()
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionUnitPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionTieredPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionBulkPrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BulkWithFiltersSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceBulkWithFilters()
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
                Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionPackagePrice()
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::NewSubscriptionMatrixPrice()
        {
            Cadence = Subscriptions::NewSubscriptionMatrixPriceCadence.Annual,
            ItemID = "item_id",
            MatrixConfig = new()
            {
                DefaultUnitAmount = "default_unit_amount",
                Dimensions = ["string"],
                MatrixValues = [new() { DimensionValues = ["string"], UnitAmount = "unit_amount" }],
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionThresholdTotalAmountSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionTieredPackageWithMinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionPackageWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithPercentSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithAllocationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceTieredWithProration()
            {
                Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionUnitWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionBulkWithProrationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithProratedMinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedWithMeteredMinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GroupedWithMinMaxThresholdsSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds()
            {
                Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMatrixWithDisplayNameSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionGroupedTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMaxGroupTieredPackageSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithUnitPricingSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionScalableMatrixWithTieredPricingSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionCumulativeGroupedBulkSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CumulativeGroupedAllocationSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation()
            {
                Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MinimumSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePriceMinimum()
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewSubscriptionMinimumCompositeSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value =
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PercentSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePricePercent()
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EventOutputSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePrice value = new Subscriptions::ReplacePricePriceEventOutput()
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePrice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceBulkWithFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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

        Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence> expectedCadence =
            Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual;
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
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFilters>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFilters>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig expectedBulkWithFiltersConfig =
            new()
            {
                Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
                Tiers =
                [
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                    new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                ],
            };
        ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence> expectedCadence =
            Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual;
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
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFilters
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
            Cadence = Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
        {
            Filters = [new() { PropertyKey = "x", PropertyValue = "x" }],
            Tiers =
            [
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
                new() { UnitAmount = "unit_amount", TierLowerBound = "tier_lower_bound" },
            ],
        };

        List<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> expectedFilters =
        [
            new() { PropertyKey = "x", PropertyValue = "x" },
        ];
        List<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> expectedTiers =
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
        {
            PropertyKey = "x",
            PropertyValue = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>(
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>(
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
            TierLowerBound = "tier_lower_bound",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        Assert.Null(model.TierLowerBound);
        Assert.False(model.RawData.ContainsKey("tier_lower_bound"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
        {
            UnitAmount = "unit_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
        var model = new Subscriptions::ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
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
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Custom)]
    public void Validation_Works(Subscriptions::ReplacePricePriceBulkWithFiltersCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceBulkWithFiltersCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceBulkWithFiltersCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceBulkWithFiltersCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceBulkWithFiltersConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceBulkWithFiltersConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceTieredWithProrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
            Subscriptions::ReplacePricePriceTieredWithProrationCadence
        > expectedCadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
        string expectedName = "Annual fee";
        Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::ReplacePricePriceTieredWithProrationCadence
        > expectedCadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
        string expectedName = "Annual fee";
        Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig expectedTieredWithProrationConfig =
            new([new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }]);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProration
        {
            Cadence = Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual,
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
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Custom)]
    public void Validation_Works(
        Subscriptions::ReplacePricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceTieredWithProrationCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceTieredWithProrationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceTieredWithProrationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        List<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig
        {
            Tiers = [new() { TierLowerBound = "tier_lower_bound", UnitAmount = "unit_amount" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> expectedTiers =
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
        var model = new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfig
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
        var model =
            new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
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
            new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
            {
                TierLowerBound = "tier_lower_bound",
                UnitAmount = "unit_amount",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>(
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
            new Subscriptions::ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
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
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceTieredWithProrationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceGroupedWithMinMaxThresholdsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
            Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence
        > expectedCadence =
            Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual;
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig expectedGroupedWithMinMaxThresholdsConfig =
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
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholds
        {
            Cadence = Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
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
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void Validation_Works(
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
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
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
            {
                GroupingKey = "x",
                MaximumCharge = "maximum_charge",
                MinimumCharge = "minimum_charge",
                PerUnitRate = "per_unit_rate",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
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
            new Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceCumulativeGroupedAllocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
            Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence
        > expectedCadence =
            Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual;
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig expectedCumulativeGroupedAllocationConfig =
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
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceCumulativeGroupedAllocation
        {
            Cadence = Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
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
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Custom)]
    public void Validation_Works(
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCadence>
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
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
            {
                CumulativeAllocation = "cumulative_allocation",
                GroupAllocation = "group_allocation",
                GroupingKey = "x",
                UnitAmount = "unit_amount",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
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
            new Subscriptions::ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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

        ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence> expectedCadence =
            Subscriptions::ReplacePricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::ReplacePricePriceMinimumMinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
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
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence> expectedCadence =
            Subscriptions::ReplacePricePriceMinimumCadence.Annual;
        string expectedItemID = "item_id";
        Subscriptions::ReplacePricePriceMinimumMinimumConfig expectedMinimumConfig = new()
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };
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
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
            ItemID = "item_id",
            MinimumConfig = new() { MinimumAmount = "minimum_amount", Prorated = true },
            Name = "Annual fee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceMinimum
        {
            Cadence = Subscriptions::ReplacePricePriceMinimumCadence.Annual,
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

public class ReplacePricePriceMinimumCadenceTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Custom)]
    public void Validation_Works(Subscriptions::ReplacePricePriceMinimumCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceMinimumCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceMinimumCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceMinimumCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceMinimumMinimumConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
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
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimumMinimumConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimumMinimumConfig>(
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
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
            Prorated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
        };

        Assert.Null(model.Prorated);
        Assert.False(model.RawData.ContainsKey("prorated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
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
        var model = new Subscriptions::ReplacePricePriceMinimumMinimumConfig
        {
            MinimumAmount = "minimum_amount",

            // Null should be interpreted as omitted for these properties
            Prorated = null,
        };

        model.Validate();
    }
}

public class ReplacePricePriceMinimumConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceMinimumConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceMinimumConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePricePercentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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

        ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence> expectedCadence =
            Subscriptions::ReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::ReplacePricePricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::ReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence> expectedCadence =
            Subscriptions::ReplacePricePricePercentCadence.Annual;
        string expectedItemID = "item_id";
        JsonElement expectedModelType = JsonSerializer.SerializeToElement("percent");
        string expectedName = "Annual fee";
        Subscriptions::ReplacePricePricePercentPercentConfig expectedPercentConfig = new(0);
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        Subscriptions::ReplacePricePricePercentConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
            ItemID = "item_id",
            Name = "Annual fee",
            PercentConfig = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePricePercent
        {
            Cadence = Subscriptions::ReplacePricePricePercentCadence.Annual,
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
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Custom)]
    public void Validation_Works(Subscriptions::ReplacePricePricePercentCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePricePercentCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePricePercentCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePricePercentCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePricePercentPercentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercentPercentConfig { Percent = 0 };

        double expectedPercent = 0;

        Assert.Equal(expectedPercent, model.Percent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercentPercentConfig { Percent = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercentPercentConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePricePercentPercentConfig { Percent = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercentPercentConfig>(
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
        var model = new Subscriptions::ReplacePricePricePercentPercentConfig { Percent = 0 };

        model.Validate();
    }
}

public class ReplacePricePricePercentConversionRateConfigTest : TestBase
{
    [Fact]
    public void UnitValidationWorks()
    {
        Subscriptions::ReplacePricePricePercentConversionRateConfig value =
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
        Subscriptions::ReplacePricePricePercentConversionRateConfig value =
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
        Subscriptions::ReplacePricePricePercentConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePricePercentConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePricePercentConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceEventOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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

        ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence> expectedCadence =
            Subscriptions::ReplacePricePriceEventOutputCadence.Annual;
        Subscriptions::ReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
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
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var deserialized = JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence> expectedCadence =
            Subscriptions::ReplacePricePriceEventOutputCadence.Annual;
        Subscriptions::ReplacePricePriceEventOutputEventOutputConfig expectedEventOutputConfig =
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
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig expectedConversionRateConfig =
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
        var model = new Subscriptions::ReplacePricePriceEventOutput
        {
            Cadence = Subscriptions::ReplacePricePriceEventOutputCadence.Annual,
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
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Custom)]
    public void Validation_Works(Subscriptions::ReplacePricePriceEventOutputCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Annual)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.SemiAnnual)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Monthly)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Quarterly)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.OneTime)]
    [InlineData(Subscriptions::ReplacePricePriceEventOutputCadence.Custom)]
    public void SerializationRoundtrip_Works(
        Subscriptions::ReplacePricePriceEventOutputCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::ReplacePricePriceEventOutputCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReplacePricePriceEventOutputEventOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
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
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutputEventOutputConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
            DefaultUnitRate = "default_unit_rate",
            GroupingKey = "grouping_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutputEventOutputConfig>(
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
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
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
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
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
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
        {
            UnitRatingKey = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
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
        var model = new Subscriptions::ReplacePricePriceEventOutputEventOutputConfig
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
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig value =
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
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig value =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TieredSerializationRoundtripWorks()
    {
        Subscriptions::ReplacePricePriceEventOutputConversionRateConfig value =
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
            JsonSerializer.Deserialize<Subscriptions::ReplacePricePriceEventOutputConversionRateConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
