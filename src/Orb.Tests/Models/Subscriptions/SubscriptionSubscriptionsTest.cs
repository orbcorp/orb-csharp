using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models;
using Orb.Models.Customers;
using Orb.Models.Subscriptions;
using Plans = Orb.Models.Plans;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionSubscriptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionSubscriptions
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivePlanPhaseOrder = 0,
                    AdjustmentIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            Adjustment = new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    AutoCollection = true,
                    BillingCycleAnchorConfiguration = new()
                    {
                        Day = 1,
                        Month = 1,
                        Year = 0,
                    },
                    BillingCycleDay = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                        "2019-12-27T18:11:19.117Z"
                    ),
                    Customer = new()
                    {
                        ID = "id",
                        AdditionalEmails = ["string"],
                        AutoCollection = true,
                        AutoIssuance = true,
                        Balance = "balance",
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        Email = "email",
                        EmailDelivery = true,
                        ExemptFromAutomatedTax = true,
                        ExternalCustomerID = "external_customer_id",
                        Hierarchy = new()
                        {
                            Children =
                            [
                                new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                            ],
                            Parent = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                        },
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Name = "name",
                        PaymentProvider = CustomerPaymentProvider.Quickbooks,
                        PaymentProviderID = "payment_provider_id",
                        PortalURL = "portal_url",
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        TaxID = new()
                        {
                            Country = Country.Ad,
                            Type = CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Timezone = "timezone",
                        AccountingSyncConfiguration = new()
                        {
                            AccountingProviders =
                            [
                                new()
                                {
                                    ExternalProviderID = "external_provider_id",
                                    ProviderType = AccountingProviderProviderType.Quickbooks,
                                },
                            ],
                            Excluded = true,
                        },
                        AutomaticTaxEnabled = true,
                        PaymentConfiguration = new()
                        {
                            PaymentProviders =
                            [
                                new()
                                {
                                    ProviderType = PaymentProvider5ProviderType.Stripe,
                                    ExcludedPaymentMethodTypes = ["string"],
                                },
                            ],
                        },
                        ReportingConfiguration = new(true),
                    },
                    DefaultInvoiceMemo = "default_invoice_memo",
                    DiscountIntervals =
                    [
                        new AmountDiscountInterval()
                        {
                            AmountDiscount = "amount_discount",
                            AppliesToPriceIntervalIDs = ["string"],
                            DiscountType = AmountDiscountIntervalDiscountType.Amount,
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter1Field.PriceID,
                                    Operator = Filter1Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FixedFeeQuantitySchedule =
                    [
                        new()
                        {
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PriceID = "price_id",
                            Quantity = 0,
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    InvoicingThreshold = "invoicing_threshold",
                    MaximumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter3Field.PriceID,
                                    Operator = Filter3Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter5Field.PriceID,
                                    Operator = Filter5Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Name = "name",
                    NetTerms = 0,
                    PendingSubscriptionChange = new("id"),
                    Plan = new()
                    {
                        ID = "id",
                        Adjustments =
                        [
                            new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                        ],
                        BasePlan = new()
                        {
                            ID = "m2t5akQeh2obwxeU",
                            ExternalPlanID = "m2t5akQeh2obwxeU",
                            Name = "Example plan",
                        },
                        BasePlanID = "base_plan_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DefaultInvoiceMemo = "default_invoice_memo",
                        Description = "description",
                        Discount = new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter17Field.PriceID,
                                    Operator = Filter17Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        ExternalPlanID = "external_plan_id",
                        InvoicingCurrency = "invoicing_currency",
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter2Field.PriceID,
                                    Operator = Filter2Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter4Field.PriceID,
                                    Operator = Filter4Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        NetTerms = 0,
                        PlanPhases =
                        [
                            new()
                            {
                                ID = "id",
                                Description = "description",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                Duration = 0,
                                DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                Order = 0,
                            },
                        ],
                        Prices =
                        [
                            new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                        ],
                        Product = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Name = "name",
                        },
                        Status = Plans::PlanStatus.Active,
                        TrialConfig = new()
                        {
                            TrialPeriod = 0,
                            TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                        },
                        Version = 0,
                    },
                    PriceIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            BillingCycleDay = 0,
                            CanDeferBilling = true,
                            CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filter = "filter",
                            FixedFeeQuantityTransitions =
                            [
                                new()
                                {
                                    EffectiveDate = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    PriceID = "price_id",
                                    Quantity = 0,
                                },
                            ],
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UsageCustomerIDs = ["string"],
                        },
                    ],
                    RedeemedCoupon = new()
                    {
                        CouponID = "coupon_id",
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.Active,
                    TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Subscription> expectedData =
        [
            new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                        },
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AutoCollection = true,
                BillingCycleAnchorConfiguration = new()
                {
                    Day = 1,
                    Month = 1,
                    Year = 0,
                },
                BillingCycleDay = 1,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    ID = "id",
                    AdditionalEmails = ["string"],
                    AutoCollection = true,
                    AutoIssuance = true,
                    Balance = "balance",
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    Email = "email",
                    EmailDelivery = true,
                    ExemptFromAutomatedTax = true,
                    ExternalCustomerID = "external_customer_id",
                    Hierarchy = new()
                    {
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
                        Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PaymentProvider = CustomerPaymentProvider.Quickbooks,
                    PaymentProviderID = "payment_provider_id",
                    PortalURL = "portal_url",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                    TaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Timezone = "timezone",
                    AccountingSyncConfiguration = new()
                    {
                        AccountingProviders =
                        [
                            new()
                            {
                                ExternalProviderID = "external_provider_id",
                                ProviderType = AccountingProviderProviderType.Quickbooks,
                            },
                        ],
                        Excluded = true,
                    },
                    AutomaticTaxEnabled = true,
                    PaymentConfiguration = new()
                    {
                        PaymentProviders =
                        [
                            new()
                            {
                                ProviderType = PaymentProvider5ProviderType.Stripe,
                                ExcludedPaymentMethodTypes = ["string"],
                            },
                        ],
                    },
                    ReportingConfiguration = new(true),
                },
                DefaultInvoiceMemo = "default_invoice_memo",
                DiscountIntervals =
                [
                    new AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter1Field.PriceID,
                                Operator = Filter1Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FixedFeeQuantitySchedule =
                [
                    new()
                    {
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PriceID = "price_id",
                        Quantity = 0,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                InvoicingThreshold = "invoicing_threshold",
                MaximumIntervals =
                [
                    new()
                    {
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter3Field.PriceID,
                                Operator = Filter3Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MaximumAmount = "maximum_amount",
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumIntervals =
                [
                    new()
                    {
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter5Field.PriceID,
                                Operator = Filter5Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Name = "name",
                NetTerms = 0,
                PendingSubscriptionChange = new("id"),
                Plan = new()
                {
                    ID = "id",
                    Adjustments =
                    [
                        new PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                        },
                    ],
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
                    Discount = new PercentageDiscount()
                    {
                        DiscountType = PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter17Field.PriceID,
                                Operator = Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter2Field.PriceID,
                                Operator = Filter2Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MaximumAmount = "maximum_amount",
                    },
                    MaximumAmount = "maximum_amount",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter4Field.PriceID,
                                Operator = Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            Duration = 0,
                            DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            Order = 0,
                        },
                    ],
                    Prices =
                    [
                        new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            BillingMode = BillingMode.InAdvance,
                            Cadence = UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = CompositePriceFilterField.PriceID,
                                    Operator = CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
                                UnitConfig = new("unit_amount"),
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditAllocation = new()
                            {
                                AllowsRollover = true,
                                Currency = "currency",
                                CustomExpiration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Field.PriceID,
                                        Operator = Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = UnitPriceType.UsagePrice,
                            ReplacesPriceID = "replaces_price_id",
                            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                            },
                        },
                    ],
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = Plans::PlanStatus.Active,
                    TrialConfig = new()
                    {
                        TrialPeriod = 0,
                        TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                    },
                    Version = 0,
                },
                PriceIntervals =
                [
                    new()
                    {
                        ID = "id",
                        BillingCycleDay = 0,
                        CanDeferBilling = true,
                        CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filter = "filter",
                        FixedFeeQuantityTransitions =
                        [
                            new()
                            {
                                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PriceID = "price_id",
                                Quantity = 0,
                            },
                        ],
                        Price = new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            BillingMode = BillingMode.InAdvance,
                            Cadence = UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = CompositePriceFilterField.PriceID,
                                    Operator = CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
                                UnitConfig = new("unit_amount"),
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditAllocation = new()
                            {
                                AllowsRollover = true,
                                Currency = "currency",
                                CustomExpiration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Field.PriceID,
                                        Operator = Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = UnitPriceType.UsagePrice,
                            ReplacesPriceID = "replaces_price_id",
                            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                            },
                        },
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageCustomerIDs = ["string"],
                    },
                ],
                RedeemedCoupon = new()
                {
                    CouponID = "coupon_id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionSubscriptions
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivePlanPhaseOrder = 0,
                    AdjustmentIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            Adjustment = new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    AutoCollection = true,
                    BillingCycleAnchorConfiguration = new()
                    {
                        Day = 1,
                        Month = 1,
                        Year = 0,
                    },
                    BillingCycleDay = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                        "2019-12-27T18:11:19.117Z"
                    ),
                    Customer = new()
                    {
                        ID = "id",
                        AdditionalEmails = ["string"],
                        AutoCollection = true,
                        AutoIssuance = true,
                        Balance = "balance",
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        Email = "email",
                        EmailDelivery = true,
                        ExemptFromAutomatedTax = true,
                        ExternalCustomerID = "external_customer_id",
                        Hierarchy = new()
                        {
                            Children =
                            [
                                new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                            ],
                            Parent = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                        },
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Name = "name",
                        PaymentProvider = CustomerPaymentProvider.Quickbooks,
                        PaymentProviderID = "payment_provider_id",
                        PortalURL = "portal_url",
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        TaxID = new()
                        {
                            Country = Country.Ad,
                            Type = CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Timezone = "timezone",
                        AccountingSyncConfiguration = new()
                        {
                            AccountingProviders =
                            [
                                new()
                                {
                                    ExternalProviderID = "external_provider_id",
                                    ProviderType = AccountingProviderProviderType.Quickbooks,
                                },
                            ],
                            Excluded = true,
                        },
                        AutomaticTaxEnabled = true,
                        PaymentConfiguration = new()
                        {
                            PaymentProviders =
                            [
                                new()
                                {
                                    ProviderType = PaymentProvider5ProviderType.Stripe,
                                    ExcludedPaymentMethodTypes = ["string"],
                                },
                            ],
                        },
                        ReportingConfiguration = new(true),
                    },
                    DefaultInvoiceMemo = "default_invoice_memo",
                    DiscountIntervals =
                    [
                        new AmountDiscountInterval()
                        {
                            AmountDiscount = "amount_discount",
                            AppliesToPriceIntervalIDs = ["string"],
                            DiscountType = AmountDiscountIntervalDiscountType.Amount,
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter1Field.PriceID,
                                    Operator = Filter1Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FixedFeeQuantitySchedule =
                    [
                        new()
                        {
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PriceID = "price_id",
                            Quantity = 0,
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    InvoicingThreshold = "invoicing_threshold",
                    MaximumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter3Field.PriceID,
                                    Operator = Filter3Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter5Field.PriceID,
                                    Operator = Filter5Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Name = "name",
                    NetTerms = 0,
                    PendingSubscriptionChange = new("id"),
                    Plan = new()
                    {
                        ID = "id",
                        Adjustments =
                        [
                            new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                        ],
                        BasePlan = new()
                        {
                            ID = "m2t5akQeh2obwxeU",
                            ExternalPlanID = "m2t5akQeh2obwxeU",
                            Name = "Example plan",
                        },
                        BasePlanID = "base_plan_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DefaultInvoiceMemo = "default_invoice_memo",
                        Description = "description",
                        Discount = new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter17Field.PriceID,
                                    Operator = Filter17Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        ExternalPlanID = "external_plan_id",
                        InvoicingCurrency = "invoicing_currency",
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter2Field.PriceID,
                                    Operator = Filter2Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter4Field.PriceID,
                                    Operator = Filter4Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        NetTerms = 0,
                        PlanPhases =
                        [
                            new()
                            {
                                ID = "id",
                                Description = "description",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                Duration = 0,
                                DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                Order = 0,
                            },
                        ],
                        Prices =
                        [
                            new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                        ],
                        Product = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Name = "name",
                        },
                        Status = Plans::PlanStatus.Active,
                        TrialConfig = new()
                        {
                            TrialPeriod = 0,
                            TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                        },
                        Version = 0,
                    },
                    PriceIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            BillingCycleDay = 0,
                            CanDeferBilling = true,
                            CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filter = "filter",
                            FixedFeeQuantityTransitions =
                            [
                                new()
                                {
                                    EffectiveDate = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    PriceID = "price_id",
                                    Quantity = 0,
                                },
                            ],
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UsageCustomerIDs = ["string"],
                        },
                    ],
                    RedeemedCoupon = new()
                    {
                        CouponID = "coupon_id",
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.Active,
                    TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionSubscriptions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionSubscriptions
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivePlanPhaseOrder = 0,
                    AdjustmentIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            Adjustment = new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    AutoCollection = true,
                    BillingCycleAnchorConfiguration = new()
                    {
                        Day = 1,
                        Month = 1,
                        Year = 0,
                    },
                    BillingCycleDay = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                        "2019-12-27T18:11:19.117Z"
                    ),
                    Customer = new()
                    {
                        ID = "id",
                        AdditionalEmails = ["string"],
                        AutoCollection = true,
                        AutoIssuance = true,
                        Balance = "balance",
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        Email = "email",
                        EmailDelivery = true,
                        ExemptFromAutomatedTax = true,
                        ExternalCustomerID = "external_customer_id",
                        Hierarchy = new()
                        {
                            Children =
                            [
                                new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                            ],
                            Parent = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                        },
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Name = "name",
                        PaymentProvider = CustomerPaymentProvider.Quickbooks,
                        PaymentProviderID = "payment_provider_id",
                        PortalURL = "portal_url",
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        TaxID = new()
                        {
                            Country = Country.Ad,
                            Type = CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Timezone = "timezone",
                        AccountingSyncConfiguration = new()
                        {
                            AccountingProviders =
                            [
                                new()
                                {
                                    ExternalProviderID = "external_provider_id",
                                    ProviderType = AccountingProviderProviderType.Quickbooks,
                                },
                            ],
                            Excluded = true,
                        },
                        AutomaticTaxEnabled = true,
                        PaymentConfiguration = new()
                        {
                            PaymentProviders =
                            [
                                new()
                                {
                                    ProviderType = PaymentProvider5ProviderType.Stripe,
                                    ExcludedPaymentMethodTypes = ["string"],
                                },
                            ],
                        },
                        ReportingConfiguration = new(true),
                    },
                    DefaultInvoiceMemo = "default_invoice_memo",
                    DiscountIntervals =
                    [
                        new AmountDiscountInterval()
                        {
                            AmountDiscount = "amount_discount",
                            AppliesToPriceIntervalIDs = ["string"],
                            DiscountType = AmountDiscountIntervalDiscountType.Amount,
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter1Field.PriceID,
                                    Operator = Filter1Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FixedFeeQuantitySchedule =
                    [
                        new()
                        {
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PriceID = "price_id",
                            Quantity = 0,
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    InvoicingThreshold = "invoicing_threshold",
                    MaximumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter3Field.PriceID,
                                    Operator = Filter3Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter5Field.PriceID,
                                    Operator = Filter5Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Name = "name",
                    NetTerms = 0,
                    PendingSubscriptionChange = new("id"),
                    Plan = new()
                    {
                        ID = "id",
                        Adjustments =
                        [
                            new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                        ],
                        BasePlan = new()
                        {
                            ID = "m2t5akQeh2obwxeU",
                            ExternalPlanID = "m2t5akQeh2obwxeU",
                            Name = "Example plan",
                        },
                        BasePlanID = "base_plan_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DefaultInvoiceMemo = "default_invoice_memo",
                        Description = "description",
                        Discount = new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter17Field.PriceID,
                                    Operator = Filter17Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        ExternalPlanID = "external_plan_id",
                        InvoicingCurrency = "invoicing_currency",
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter2Field.PriceID,
                                    Operator = Filter2Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter4Field.PriceID,
                                    Operator = Filter4Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        NetTerms = 0,
                        PlanPhases =
                        [
                            new()
                            {
                                ID = "id",
                                Description = "description",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                Duration = 0,
                                DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                Order = 0,
                            },
                        ],
                        Prices =
                        [
                            new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                        ],
                        Product = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Name = "name",
                        },
                        Status = Plans::PlanStatus.Active,
                        TrialConfig = new()
                        {
                            TrialPeriod = 0,
                            TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                        },
                        Version = 0,
                    },
                    PriceIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            BillingCycleDay = 0,
                            CanDeferBilling = true,
                            CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filter = "filter",
                            FixedFeeQuantityTransitions =
                            [
                                new()
                                {
                                    EffectiveDate = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    PriceID = "price_id",
                                    Quantity = 0,
                                },
                            ],
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UsageCustomerIDs = ["string"],
                        },
                    ],
                    RedeemedCoupon = new()
                    {
                        CouponID = "coupon_id",
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.Active,
                    TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionSubscriptions>(json);
        Assert.NotNull(deserialized);

        List<Subscription> expectedData =
        [
            new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                        },
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AutoCollection = true,
                BillingCycleAnchorConfiguration = new()
                {
                    Day = 1,
                    Month = 1,
                    Year = 0,
                },
                BillingCycleDay = 1,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Customer = new()
                {
                    ID = "id",
                    AdditionalEmails = ["string"],
                    AutoCollection = true,
                    AutoIssuance = true,
                    Balance = "balance",
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    Email = "email",
                    EmailDelivery = true,
                    ExemptFromAutomatedTax = true,
                    ExternalCustomerID = "external_customer_id",
                    Hierarchy = new()
                    {
                        Children =
                        [
                            new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        ],
                        Parent = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Name = "name",
                    PaymentProvider = CustomerPaymentProvider.Quickbooks,
                    PaymentProviderID = "payment_provider_id",
                    PortalURL = "portal_url",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                    TaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Timezone = "timezone",
                    AccountingSyncConfiguration = new()
                    {
                        AccountingProviders =
                        [
                            new()
                            {
                                ExternalProviderID = "external_provider_id",
                                ProviderType = AccountingProviderProviderType.Quickbooks,
                            },
                        ],
                        Excluded = true,
                    },
                    AutomaticTaxEnabled = true,
                    PaymentConfiguration = new()
                    {
                        PaymentProviders =
                        [
                            new()
                            {
                                ProviderType = PaymentProvider5ProviderType.Stripe,
                                ExcludedPaymentMethodTypes = ["string"],
                            },
                        ],
                    },
                    ReportingConfiguration = new(true),
                },
                DefaultInvoiceMemo = "default_invoice_memo",
                DiscountIntervals =
                [
                    new AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter1Field.PriceID,
                                Operator = Filter1Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FixedFeeQuantitySchedule =
                [
                    new()
                    {
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PriceID = "price_id",
                        Quantity = 0,
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                InvoicingThreshold = "invoicing_threshold",
                MaximumIntervals =
                [
                    new()
                    {
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter3Field.PriceID,
                                Operator = Filter3Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MaximumAmount = "maximum_amount",
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MinimumIntervals =
                [
                    new()
                    {
                        AppliesToPriceIntervalIDs = ["string"],
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Filter5Field.PriceID,
                                Operator = Filter5Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Name = "name",
                NetTerms = 0,
                PendingSubscriptionChange = new("id"),
                Plan = new()
                {
                    ID = "id",
                    Adjustments =
                    [
                        new PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                        },
                    ],
                    BasePlan = new()
                    {
                        ID = "m2t5akQeh2obwxeU",
                        ExternalPlanID = "m2t5akQeh2obwxeU",
                        Name = "Example plan",
                    },
                    BasePlanID = "base_plan_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DefaultInvoiceMemo = "default_invoice_memo",
                    Description = "description",
                    Discount = new PercentageDiscount()
                    {
                        DiscountType = PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter17Field.PriceID,
                                Operator = Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    ExternalPlanID = "external_plan_id",
                    InvoicingCurrency = "invoicing_currency",
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter2Field.PriceID,
                                Operator = Filter2Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MaximumAmount = "maximum_amount",
                    },
                    MaximumAmount = "maximum_amount",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Minimum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter4Field.PriceID,
                                Operator = Filter4Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        MinimumAmount = "minimum_amount",
                    },
                    MinimumAmount = "minimum_amount",
                    Name = "name",
                    NetTerms = 0,
                    PlanPhases =
                    [
                        new()
                        {
                            ID = "id",
                            Description = "description",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            Duration = 0,
                            DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            Order = 0,
                        },
                    ],
                    Prices =
                    [
                        new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            BillingMode = BillingMode.InAdvance,
                            Cadence = UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = CompositePriceFilterField.PriceID,
                                    Operator = CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
                                UnitConfig = new("unit_amount"),
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditAllocation = new()
                            {
                                AllowsRollover = true,
                                Currency = "currency",
                                CustomExpiration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Field.PriceID,
                                        Operator = Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = UnitPriceType.UsagePrice,
                            ReplacesPriceID = "replaces_price_id",
                            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                            },
                        },
                    ],
                    Product = new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Name = "name",
                    },
                    Status = Plans::PlanStatus.Active,
                    TrialConfig = new()
                    {
                        TrialPeriod = 0,
                        TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                    },
                    Version = 0,
                },
                PriceIntervals =
                [
                    new()
                    {
                        ID = "id",
                        BillingCycleDay = 0,
                        CanDeferBilling = true,
                        CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filter = "filter",
                        FixedFeeQuantityTransitions =
                        [
                            new()
                            {
                                EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PriceID = "price_id",
                                Quantity = 0,
                            },
                        ],
                        Price = new Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            BillingMode = BillingMode.InAdvance,
                            Cadence = UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = CompositePriceFilterField.PriceID,
                                    Operator = CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    SharedUnitConversionRateConfigConversionRateType.Unit,
                                UnitConfig = new("unit_amount"),
                            },
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditAllocation = new()
                            {
                                AllowsRollover = true,
                                Currency = "currency",
                                CustomExpiration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Field.PriceID,
                                        Operator = Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new PercentageDiscount()
                            {
                                DiscountType = PercentageDiscountDiscountType.Percentage,
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter17Field.PriceID,
                                        Operator = Filter17Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter2Field.PriceID,
                                        Operator = Filter2Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Filter4Field.PriceID,
                                        Operator = Filter4Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = UnitPriceType.UsagePrice,
                            ReplacesPriceID = "replaces_price_id",
                            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                            },
                        },
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageCustomerIDs = ["string"],
                    },
                ],
                RedeemedCoupon = new()
                {
                    CouponID = "coupon_id",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, deserialized.PaginationMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionSubscriptions
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivePlanPhaseOrder = 0,
                    AdjustmentIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            Adjustment = new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    AutoCollection = true,
                    BillingCycleAnchorConfiguration = new()
                    {
                        Day = 1,
                        Month = 1,
                        Year = 0,
                    },
                    BillingCycleDay = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                        "2019-12-27T18:11:19.117Z"
                    ),
                    Customer = new()
                    {
                        ID = "id",
                        AdditionalEmails = ["string"],
                        AutoCollection = true,
                        AutoIssuance = true,
                        Balance = "balance",
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        Email = "email",
                        EmailDelivery = true,
                        ExemptFromAutomatedTax = true,
                        ExternalCustomerID = "external_customer_id",
                        Hierarchy = new()
                        {
                            Children =
                            [
                                new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                            ],
                            Parent = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                        },
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Name = "name",
                        PaymentProvider = CustomerPaymentProvider.Quickbooks,
                        PaymentProviderID = "payment_provider_id",
                        PortalURL = "portal_url",
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        TaxID = new()
                        {
                            Country = Country.Ad,
                            Type = CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Timezone = "timezone",
                        AccountingSyncConfiguration = new()
                        {
                            AccountingProviders =
                            [
                                new()
                                {
                                    ExternalProviderID = "external_provider_id",
                                    ProviderType = AccountingProviderProviderType.Quickbooks,
                                },
                            ],
                            Excluded = true,
                        },
                        AutomaticTaxEnabled = true,
                        PaymentConfiguration = new()
                        {
                            PaymentProviders =
                            [
                                new()
                                {
                                    ProviderType = PaymentProvider5ProviderType.Stripe,
                                    ExcludedPaymentMethodTypes = ["string"],
                                },
                            ],
                        },
                        ReportingConfiguration = new(true),
                    },
                    DefaultInvoiceMemo = "default_invoice_memo",
                    DiscountIntervals =
                    [
                        new AmountDiscountInterval()
                        {
                            AmountDiscount = "amount_discount",
                            AppliesToPriceIntervalIDs = ["string"],
                            DiscountType = AmountDiscountIntervalDiscountType.Amount,
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter1Field.PriceID,
                                    Operator = Filter1Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FixedFeeQuantitySchedule =
                    [
                        new()
                        {
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PriceID = "price_id",
                            Quantity = 0,
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    InvoicingThreshold = "invoicing_threshold",
                    MaximumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter3Field.PriceID,
                                    Operator = Filter3Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MinimumIntervals =
                    [
                        new()
                        {
                            AppliesToPriceIntervalIDs = ["string"],
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter5Field.PriceID,
                                    Operator = Filter5Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        },
                    ],
                    Name = "name",
                    NetTerms = 0,
                    PendingSubscriptionChange = new("id"),
                    Plan = new()
                    {
                        ID = "id",
                        Adjustments =
                        [
                            new PlanPhaseUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
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
                            },
                        ],
                        BasePlan = new()
                        {
                            ID = "m2t5akQeh2obwxeU",
                            ExternalPlanID = "m2t5akQeh2obwxeU",
                            Name = "Example plan",
                        },
                        BasePlanID = "base_plan_id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DefaultInvoiceMemo = "default_invoice_memo",
                        Description = "description",
                        Discount = new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter17Field.PriceID,
                                    Operator = Filter17Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        ExternalPlanID = "external_plan_id",
                        InvoicingCurrency = "invoicing_currency",
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter2Field.PriceID,
                                    Operator = Filter2Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Filter4Field.PriceID,
                                    Operator = Filter4Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        NetTerms = 0,
                        PlanPhases =
                        [
                            new()
                            {
                                ID = "id",
                                Description = "description",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                Duration = 0,
                                DurationUnit = Plans::PlanPhaseModelDurationUnit.Daily,
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                Order = 0,
                            },
                        ],
                        Prices =
                        [
                            new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                        ],
                        Product = new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Name = "name",
                        },
                        Status = Plans::PlanStatus.Active,
                        TrialConfig = new()
                        {
                            TrialPeriod = 0,
                            TrialPeriodUnit = Plans::TrialPeriodUnit.Days,
                        },
                        Version = 0,
                    },
                    PriceIntervals =
                    [
                        new()
                        {
                            ID = "id",
                            BillingCycleDay = 0,
                            CanDeferBilling = true,
                            CurrentBillingPeriodEndDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            CurrentBillingPeriodStartDate = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Filter = "filter",
                            FixedFeeQuantityTransitions =
                            [
                                new()
                                {
                                    EffectiveDate = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    PriceID = "price_id",
                                    Quantity = 0,
                                },
                            ],
                            Price = new Unit()
                            {
                                ID = "id",
                                BillableMetric = new("id"),
                                BillingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                BillingMode = BillingMode.InAdvance,
                                Cadence = UnitCadence.OneTime,
                                CompositePriceFilters =
                                [
                                    new()
                                    {
                                        Field = CompositePriceFilterField.PriceID,
                                        Operator = CompositePriceFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                ConversionRate = 0,
                                ConversionRateConfig = new SharedUnitConversionRateConfig()
                                {
                                    ConversionRateType =
                                        SharedUnitConversionRateConfigConversionRateType.Unit,
                                    UnitConfig = new("unit_amount"),
                                },
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                CreditAllocation = new()
                                {
                                    AllowsRollover = true,
                                    Currency = "currency",
                                    CustomExpiration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = CustomExpirationDurationUnit.Day,
                                    },
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Field.PriceID,
                                            Operator = Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                },
                                Currency = "currency",
                                Discount = new PercentageDiscount()
                                {
                                    DiscountType = PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter17Field.PriceID,
                                            Operator = Filter17Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                                ExternalPriceID = "external_price_id",
                                FixedPriceQuantity = 0,
                                InvoicingCycleConfiguration = new()
                                {
                                    Duration = 0,
                                    DurationUnit = DurationUnit.Day,
                                },
                                Item = new() { ID = "id", Name = "name" },
                                Maximum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter2Field.PriceID,
                                            Operator = Filter2Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MaximumAmount = "maximum_amount",
                                },
                                MaximumAmount = "maximum_amount",
                                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                                Minimum = new()
                                {
                                    AppliesToPriceIDs = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Filter4Field.PriceID,
                                            Operator = Filter4Operator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    MinimumAmount = "minimum_amount",
                                },
                                MinimumAmount = "minimum_amount",
                                Name = "name",
                                PlanPhaseOrder = 0,
                                PriceType = UnitPriceType.UsagePrice,
                                ReplacesPriceID = "replaces_price_id",
                                UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
                                DimensionalPriceConfiguration = new()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                },
                            },
                            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            UsageCustomerIDs = ["string"],
                        },
                    ],
                    RedeemedCoupon = new()
                    {
                        CouponID = "coupon_id",
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.Active,
                    TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
