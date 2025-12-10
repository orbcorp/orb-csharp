using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Customers;
using Orb.Models.Subscriptions;
using Plans = Orb.Models.Plans;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
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
                    Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                            ProviderType =
                                CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
                            Field = AmountDiscountIntervalFilterField.PriceID,
                            Operator = AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = MaximumIntervalFilterField.PriceID,
                            Operator = MaximumIntervalFilterOperator.Includes,
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
                            Field = MinimumIntervalFilterField.PriceID,
                            Operator = MinimumIntervalFilterOperator.Includes,
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = PercentageDiscountFilterField.PriceID,
                            Operator = PercentageDiscountFilterOperator.Includes,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        Duration = 0,
                        DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
        };

        string expectedID = "id";
        long expectedActivePlanPhaseOrder = 0;
        List<AdjustmentInterval> expectedAdjustmentIntervals =
        [
            new()
            {
                ID = "id",
                Adjustment = new PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedAutoCollection = true;
        BillingCycleAnchorConfiguration expectedBillingCycleAnchorConfiguration = new()
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };
        long expectedBillingCycleDay = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCurrentBillingPeriodEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Customer expectedCustomer = new()
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
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        List<DiscountInterval> expectedDiscountIntervals =
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
                        Field = AmountDiscountIntervalFilterField.PriceID,
                        Operator = AmountDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<FixedFeeQuantityScheduleEntry> expectedFixedFeeQuantitySchedule =
        [
            new()
            {
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PriceID = "price_id",
                Quantity = 0,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedInvoicingThreshold = "invoicing_threshold";
        List<MaximumInterval> expectedMaximumIntervals =
        [
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = MaximumIntervalFilterField.PriceID,
                        Operator = MaximumIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<MinimumInterval> expectedMinimumIntervals =
        [
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = MinimumIntervalFilterField.PriceID,
                        Operator = MinimumIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedName = "name";
        long expectedNetTerms = 0;
        SubscriptionChangeMinified expectedPendingSubscriptionChange = new("id");
        Plans::Plan expectedPlan = new()
        {
            ID = "id",
            Adjustments =
            [
                new PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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
                        Field = MaximumFilterField.PriceID,
                        Operator = MaximumFilterOperator.Includes,
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
                        Field = MinimumFilterField.PriceID,
                        Operator = MinimumFilterOperator.Includes,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    Duration = 0,
                    DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                        ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
            TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = Plans::TrialPeriodUnit.Days },
            Version = 0,
        };
        List<PriceInterval> expectedPriceIntervals =
        [
            new()
            {
                ID = "id",
                BillingCycleDay = 0,
                CanDeferBilling = true,
                CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
        ];
        CouponRedemption expectedRedeemedCoupon = new()
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.Active;
        SubscriptionTrialInfo expectedTrialInfo = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActivePlanPhaseOrder, model.ActivePlanPhaseOrder);
        Assert.Equal(expectedAdjustmentIntervals.Count, model.AdjustmentIntervals.Count);
        for (int i = 0; i < expectedAdjustmentIntervals.Count; i++)
        {
            Assert.Equal(expectedAdjustmentIntervals[i], model.AdjustmentIntervals[i]);
        }
        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(
            expectedBillingCycleAnchorConfiguration,
            model.BillingCycleAnchorConfiguration
        );
        Assert.Equal(expectedBillingCycleDay, model.BillingCycleDay);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrentBillingPeriodEndDate, model.CurrentBillingPeriodEndDate);
        Assert.Equal(expectedCurrentBillingPeriodStartDate, model.CurrentBillingPeriodStartDate);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDefaultInvoiceMemo, model.DefaultInvoiceMemo);
        Assert.Equal(expectedDiscountIntervals.Count, model.DiscountIntervals.Count);
        for (int i = 0; i < expectedDiscountIntervals.Count; i++)
        {
            Assert.Equal(expectedDiscountIntervals[i], model.DiscountIntervals[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFixedFeeQuantitySchedule.Count, model.FixedFeeQuantitySchedule.Count);
        for (int i = 0; i < expectedFixedFeeQuantitySchedule.Count; i++)
        {
            Assert.Equal(expectedFixedFeeQuantitySchedule[i], model.FixedFeeQuantitySchedule[i]);
        }
        Assert.Equal(expectedInvoicingThreshold, model.InvoicingThreshold);
        Assert.Equal(expectedMaximumIntervals.Count, model.MaximumIntervals.Count);
        for (int i = 0; i < expectedMaximumIntervals.Count; i++)
        {
            Assert.Equal(expectedMaximumIntervals[i], model.MaximumIntervals[i]);
        }
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimumIntervals.Count, model.MinimumIntervals.Count);
        for (int i = 0; i < expectedMinimumIntervals.Count; i++)
        {
            Assert.Equal(expectedMinimumIntervals[i], model.MinimumIntervals[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNetTerms, model.NetTerms);
        Assert.Equal(expectedPendingSubscriptionChange, model.PendingSubscriptionChange);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedPriceIntervals.Count, model.PriceIntervals.Count);
        for (int i = 0; i < expectedPriceIntervals.Count; i++)
        {
            Assert.Equal(expectedPriceIntervals[i], model.PriceIntervals[i]);
        }
        Assert.Equal(expectedRedeemedCoupon, model.RedeemedCoupon);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTrialInfo, model.TrialInfo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
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
                    Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                            ProviderType =
                                CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
                            Field = AmountDiscountIntervalFilterField.PriceID,
                            Operator = AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = MaximumIntervalFilterField.PriceID,
                            Operator = MaximumIntervalFilterOperator.Includes,
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
                            Field = MinimumIntervalFilterField.PriceID,
                            Operator = MinimumIntervalFilterOperator.Includes,
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = PercentageDiscountFilterField.PriceID,
                            Operator = PercentageDiscountFilterOperator.Includes,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        Duration = 0,
                        DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscription>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription
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
                    Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                            ProviderType =
                                CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
                            Field = AmountDiscountIntervalFilterField.PriceID,
                            Operator = AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = MaximumIntervalFilterField.PriceID,
                            Operator = MaximumIntervalFilterOperator.Includes,
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
                            Field = MinimumIntervalFilterField.PriceID,
                            Operator = MinimumIntervalFilterOperator.Includes,
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = PercentageDiscountFilterField.PriceID,
                            Operator = PercentageDiscountFilterOperator.Includes,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        Duration = 0,
                        DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscription>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedActivePlanPhaseOrder = 0;
        List<AdjustmentInterval> expectedAdjustmentIntervals =
        [
            new()
            {
                ID = "id",
                Adjustment = new PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
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
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedAutoCollection = true;
        BillingCycleAnchorConfiguration expectedBillingCycleAnchorConfiguration = new()
        {
            Day = 1,
            Month = 1,
            Year = 0,
        };
        long expectedBillingCycleDay = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCurrentBillingPeriodEndDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        Customer expectedCustomer = new()
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
                Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                        ProviderType =
                            CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
                        ExcludedPaymentMethodTypes = ["string"],
                    },
                ],
            },
            ReportingConfiguration = new(true),
        };
        string expectedDefaultInvoiceMemo = "default_invoice_memo";
        List<DiscountInterval> expectedDiscountIntervals =
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
                        Field = AmountDiscountIntervalFilterField.PriceID,
                        Operator = AmountDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<FixedFeeQuantityScheduleEntry> expectedFixedFeeQuantitySchedule =
        [
            new()
            {
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PriceID = "price_id",
                Quantity = 0,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedInvoicingThreshold = "invoicing_threshold";
        List<MaximumInterval> expectedMaximumIntervals =
        [
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = MaximumIntervalFilterField.PriceID,
                        Operator = MaximumIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MaximumAmount = "maximum_amount",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<MinimumInterval> expectedMinimumIntervals =
        [
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = MinimumIntervalFilterField.PriceID,
                        Operator = MinimumIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                MinimumAmount = "minimum_amount",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedName = "name";
        long expectedNetTerms = 0;
        SubscriptionChangeMinified expectedPendingSubscriptionChange = new("id");
        Plans::Plan expectedPlan = new()
        {
            ID = "id",
            Adjustments =
            [
                new PlanPhaseUsageDiscountAdjustment()
                {
                    ID = "id",
                    AdjustmentType = PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                    AppliesToPriceIDs = ["string"],
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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
                        Field = MaximumFilterField.PriceID,
                        Operator = MaximumFilterOperator.Includes,
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
                        Field = MinimumFilterField.PriceID,
                        Operator = MinimumFilterOperator.Includes,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    Duration = 0,
                    DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                    Maximum = new()
                    {
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                        ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
            TrialConfig = new() { TrialPeriod = 0, TrialPeriodUnit = Plans::TrialPeriodUnit.Days },
            Version = 0,
        };
        List<PriceInterval> expectedPriceIntervals =
        [
            new()
            {
                ID = "id",
                BillingCycleDay = 0,
                CanDeferBilling = true,
                CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
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
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = PercentageDiscountFilterField.PriceID,
                                Operator = PercentageDiscountFilterOperator.Includes,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
        ];
        CouponRedemption expectedRedeemedCoupon = new()
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.Active;
        SubscriptionTrialInfo expectedTrialInfo = new(
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActivePlanPhaseOrder, deserialized.ActivePlanPhaseOrder);
        Assert.Equal(expectedAdjustmentIntervals.Count, deserialized.AdjustmentIntervals.Count);
        for (int i = 0; i < expectedAdjustmentIntervals.Count; i++)
        {
            Assert.Equal(expectedAdjustmentIntervals[i], deserialized.AdjustmentIntervals[i]);
        }
        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(
            expectedBillingCycleAnchorConfiguration,
            deserialized.BillingCycleAnchorConfiguration
        );
        Assert.Equal(expectedBillingCycleDay, deserialized.BillingCycleDay);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrentBillingPeriodEndDate, deserialized.CurrentBillingPeriodEndDate);
        Assert.Equal(
            expectedCurrentBillingPeriodStartDate,
            deserialized.CurrentBillingPeriodStartDate
        );
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedDefaultInvoiceMemo, deserialized.DefaultInvoiceMemo);
        Assert.Equal(expectedDiscountIntervals.Count, deserialized.DiscountIntervals.Count);
        for (int i = 0; i < expectedDiscountIntervals.Count; i++)
        {
            Assert.Equal(expectedDiscountIntervals[i], deserialized.DiscountIntervals[i]);
        }
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(
            expectedFixedFeeQuantitySchedule.Count,
            deserialized.FixedFeeQuantitySchedule.Count
        );
        for (int i = 0; i < expectedFixedFeeQuantitySchedule.Count; i++)
        {
            Assert.Equal(
                expectedFixedFeeQuantitySchedule[i],
                deserialized.FixedFeeQuantitySchedule[i]
            );
        }
        Assert.Equal(expectedInvoicingThreshold, deserialized.InvoicingThreshold);
        Assert.Equal(expectedMaximumIntervals.Count, deserialized.MaximumIntervals.Count);
        for (int i = 0; i < expectedMaximumIntervals.Count; i++)
        {
            Assert.Equal(expectedMaximumIntervals[i], deserialized.MaximumIntervals[i]);
        }
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimumIntervals.Count, deserialized.MinimumIntervals.Count);
        for (int i = 0; i < expectedMinimumIntervals.Count; i++)
        {
            Assert.Equal(expectedMinimumIntervals[i], deserialized.MinimumIntervals[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNetTerms, deserialized.NetTerms);
        Assert.Equal(expectedPendingSubscriptionChange, deserialized.PendingSubscriptionChange);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedPriceIntervals.Count, deserialized.PriceIntervals.Count);
        for (int i = 0; i < expectedPriceIntervals.Count; i++)
        {
            Assert.Equal(expectedPriceIntervals[i], deserialized.PriceIntervals[i]);
        }
        Assert.Equal(expectedRedeemedCoupon, deserialized.RedeemedCoupon);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTrialInfo, deserialized.TrialInfo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
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
                    Children = [new() { ID = "id", ExternalCustomerID = "external_customer_id" }],
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
                            ProviderType =
                                CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
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
                            Field = AmountDiscountIntervalFilterField.PriceID,
                            Operator = AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = MaximumIntervalFilterField.PriceID,
                            Operator = MaximumIntervalFilterOperator.Includes,
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
                            Field = MinimumIntervalFilterField.PriceID,
                            Operator = MinimumIntervalFilterOperator.Includes,
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
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = PercentageDiscountFilterField.PriceID,
                            Operator = PercentageDiscountFilterOperator.Includes,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            Reason = "reason",
                        },
                        Duration = 0,
                        DurationUnit = Plans::PlanPlanPhaseDurationUnit.Daily,
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
                    CurrentBillingPeriodEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = PercentageDiscountFilterField.PriceID,
                                    Operator = PercentageDiscountFilterOperator.Includes,
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
                                    Field = MaximumFilterField.PriceID,
                                    Operator = MaximumFilterOperator.Includes,
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
                                    Field = MinimumFilterField.PriceID,
                                    Operator = MinimumFilterOperator.Includes,
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
        };

        model.Validate();
    }
}

public class DiscountIntervalTest : TestBase
{
    [Fact]
    public void amountValidation_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AmountDiscount = "amount_discount",
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = AmountDiscountIntervalDiscountType.Amount,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AmountDiscountIntervalFilterField.PriceID,
                        Operator = AmountDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void percentageValidation_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountIntervalFilterField.PriceID,
                        Operator = PercentageDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PercentageDiscount = 0.15,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        value.Validate();
    }

    [Fact]
    public void usageValidation_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = UsageDiscountIntervalDiscountType.Usage,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = UsageDiscountIntervalFilterField.PriceID,
                        Operator = UsageDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageDiscount = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void amountSerializationRoundtrip_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AmountDiscount = "amount_discount",
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = AmountDiscountIntervalDiscountType.Amount,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = AmountDiscountIntervalFilterField.PriceID,
                        Operator = AmountDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<DiscountInterval>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void percentageSerializationRoundtrip_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountIntervalFilterField.PriceID,
                        Operator = PercentageDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                PercentageDiscount = 0.15,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<DiscountInterval>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void usageSerializationRoundtrip_Works()
    {
        DiscountInterval value = new(
            new()
            {
                AppliesToPriceIntervalIDs = ["string"],
                DiscountType = UsageDiscountIntervalDiscountType.Usage,
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = UsageDiscountIntervalFilterField.PriceID,
                        Operator = UsageDiscountIntervalFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageDiscount = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<DiscountInterval>(json);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Ended)]
    [InlineData(SubscriptionStatus.Upcoming)]
    public void Validation_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Ended)]
    [InlineData(SubscriptionStatus.Upcoming)]
    public void SerializationRoundtrip_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
