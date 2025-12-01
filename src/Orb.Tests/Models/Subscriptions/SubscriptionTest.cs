using System;
using System.Collections.Generic;
using Orb.Core;
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
                            ProviderType = ProviderType.Quickbooks,
                        },
                    ],
                    Excluded = true,
                },
                AutomaticTaxEnabled = true,
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
                        ProviderType = ProviderType.Quickbooks,
                    },
                ],
                Excluded = true,
            },
            AutomaticTaxEnabled = true,
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
                        Field = Filter1Field.PriceID,
                        Operator = Filter1Operator.Includes,
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
                        Field = Filter3Field.PriceID,
                        Operator = Filter3Operator.Includes,
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
                        Field = Filter5Field.PriceID,
                        Operator = Filter5Operator.Includes,
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
}
