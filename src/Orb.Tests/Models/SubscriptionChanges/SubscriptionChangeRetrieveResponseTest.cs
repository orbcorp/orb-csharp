using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Orb.Models.SubscriptionChanges;
using Models = Orb.Models;
using Plans = Orb.Models.Plans;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCycleAlignment = "billing_cycle_alignment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ChangeOption = "change_option",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanID = "plan_id",
        };

        string expectedID = "id";
        string expectedChangeType = "change_type";
        DateTimeOffset expectedExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionChangeRetrieveResponseStatus> expectedStatus =
            SubscriptionChangeRetrieveResponseStatus.Pending;
        MutatedSubscription expectedSubscription = new()
        {
            ID = "id",
            ActivePlanPhaseOrder = 0,
            AdjustmentIntervals =
            [
                new()
                {
                    ID = "id",
                    Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                    {
                        ID = "id",
                        AdjustmentType =
                            Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                Operator =
                                    Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Country = Models::Country.Ad,
                    Type = Models::CustomerTaxIDType.AdNrt,
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
                new Models::AmountDiscountInterval()
                {
                    AmountDiscount = "amount_discount",
                    AppliesToPriceIntervalIDs = ["string"],
                    DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = Models::AmountDiscountIntervalFilterField.PriceID,
                            Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = Models::MaximumIntervalFilterField.PriceID,
                            Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                            Field = Models::MinimumIntervalFilterField.PriceID,
                            Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                    new Models::PlanPhaseUsageDiscountAdjustment()
                    {
                        ID = "id",
                        AdjustmentType =
                            Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                Operator =
                                    Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PercentageDiscountFilterField.PriceID,
                            Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            Field = Models::MaximumFilterField.PriceID,
                            Operator = Models::MaximumFilterOperator.Includes,
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
                            Field = Models::MinimumFilterField.PriceID,
                            Operator = Models::MinimumFilterOperator.Includes,
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
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
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
                    new Models::Unit()
                    {
                        ID = "id",
                        BillableMetric = new("id"),
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        BillingMode = Models::BillingMode.InAdvance,
                        Cadence = Models::UnitCadence.OneTime,
                        CompositePriceFilters =
                        [
                            new()
                            {
                                Field = Models::CompositePriceFilterField.PriceID,
                                Operator = Models::CompositePriceFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                DurationUnit = Models::CustomExpirationDurationUnit.Day,
                            },
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Field.PriceID,
                                    Operator = Models::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                        },
                        Currency = "currency",
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        Item = new() { ID = "id", Name = "name" },
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        PlanPhaseOrder = 0,
                        PriceType = Models::UnitPriceType.UsagePrice,
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
                    Price = new Models::Unit()
                    {
                        ID = "id",
                        BillableMetric = new("id"),
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        BillingMode = Models::BillingMode.InAdvance,
                        Cadence = Models::UnitCadence.OneTime,
                        CompositePriceFilters =
                        [
                            new()
                            {
                                Field = Models::CompositePriceFilterField.PriceID,
                                Operator = Models::CompositePriceFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                DurationUnit = Models::CustomExpirationDurationUnit.Day,
                            },
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Field.PriceID,
                                    Operator = Models::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                        },
                        Currency = "currency",
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        Item = new() { ID = "id", Name = "name" },
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        PlanPhaseOrder = 0,
                        PriceType = Models::UnitPriceType.UsagePrice,
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
            Status = Status.Active,
            TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            ChangedResources = new()
            {
                CreatedCreditNotes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CreditNoteNumber = "credit_note_number",
                        CreditNotePdf = "credit_note_pdf",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        InvoiceID = "invoice_id",
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                ItemID = "item_id",
                                Name = "name",
                                Quantity = 0,
                                Subtotal = "subtotal",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                Discounts =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        AmountApplied = "amount_applied",
                                        AppliesToPriceIDs = ["string"],
                                        DiscountType = Models::DiscountDiscountType.Percentage,
                                        PercentageDiscount = 0,
                                        AmountDiscount = "amount_discount",
                                        Reason = "reason",
                                    },
                                ],
                                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                StartTimeInclusive = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                        ],
                        MaximumAmountAdjustment = new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                        Memo = "memo",
                        MinimumAmountRefunded = "minimum_amount_refunded",
                        Reason = Models::Reason.Duplicate,
                        Subtotal = "subtotal",
                        Total = "total",
                        Type = Models::SharedCreditNoteType.Refund,
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Discounts =
                        [
                            new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                        ],
                    },
                ],
                CreatedInvoices =
                [
                    new()
                    {
                        ID = "id",
                        AmountDue = "8.00",
                        AutoCollection = new()
                        {
                            Enabled = true,
                            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            NumAttempts = 0,
                            PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                        },
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNotes =
                        [
                            new()
                            {
                                ID = "id",
                                CreditNoteNumber = "credit_note_number",
                                Memo = "memo",
                                Reason = "reason",
                                Total = "total",
                                Type = "type",
                                VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            },
                        ],
                        Currency = "USD",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        CustomerBalanceTransactions =
                        [
                            new()
                            {
                                ID = "cgZa3SXcsPTVyC4Y",
                                Action = Models::Action.AppliedToInvoice,
                                Amount = "11.00",
                                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                CreditNote = new("id"),
                                Description = "An optional description",
                                EndingBalance = "22.00",
                                Invoice = new("gXcsPTVyC4YZa3Sc"),
                                StartingBalance = "33.00",
                                Type = Models::Type.Increment,
                            },
                        ],
                        CustomerTaxID = new()
                        {
                            Country = Models::Country.Ad,
                            Type = Models::CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Discounts =
                        [
                            new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                        ],
                        DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                        EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        HostedInvoiceURL = "hosted_invoice_url",
                        InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                        InvoiceNumber = "JYEFHK-00001",
                        InvoicePdf =
                            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                        InvoiceSource = Models::InvoiceSource.Subscription,
                        IsPayableNow = true,
                        IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                AdjustedSubtotal = "5.00",
                                Adjustments =
                                [
                                    new Models::MonetaryUsageDiscountAdjustment()
                                    {
                                        ID = "id",
                                        AdjustmentType =
                                            Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                        Amount = "amount",
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                Operator =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        IsInvoiceLevel = true,
                                        Reason = "reason",
                                        ReplacesAdjustmentID = "replaces_adjustment_id",
                                        UsageDiscount = 0,
                                    },
                                ],
                                Amount = "7.00",
                                CreditsApplied = "6.00",
                                EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                Filter = "filter",
                                Grouping = "grouping",
                                Name = "Fixed Fee",
                                PartiallyInvoicedAmount = "4.00",
                                Price = new Models::Unit()
                                {
                                    ID = "id",
                                    BillableMetric = new("id"),
                                    BillingCycleConfiguration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    BillingMode = Models::BillingMode.InAdvance,
                                    Cadence = Models::UnitCadence.OneTime,
                                    CompositePriceFilters =
                                    [
                                        new()
                                        {
                                            Field = Models::CompositePriceFilterField.PriceID,
                                            Operator =
                                                Models::CompositePriceFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    ConversionRate = 0,
                                    ConversionRateConfig =
                                        new Models::SharedUnitConversionRateConfig()
                                        {
                                            ConversionRateType =
                                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                        },
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Field.PriceID,
                                                Operator = Models::Operator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                    },
                                    Currency = "currency",
                                    Discount = new Models::PercentageDiscount()
                                    {
                                        DiscountType =
                                            Models::PercentageDiscountDiscountType.Percentage,
                                        PercentageDiscountValue = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::PercentageDiscountFilterField.PriceID,
                                                Operator =
                                                    Models::PercentageDiscountFilterOperator.Includes,
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
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    Item = new() { ID = "id", Name = "name" },
                                    Maximum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MaximumFilterField.PriceID,
                                                Operator = Models::MaximumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MaximumAmount = "maximum_amount",
                                    },
                                    MaximumAmount = "maximum_amount",
                                    Metadata = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
                                    Minimum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MinimumFilterField.PriceID,
                                                Operator = Models::MinimumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MinimumAmount = "minimum_amount",
                                    },
                                    MinimumAmount = "minimum_amount",
                                    Name = "name",
                                    PlanPhaseOrder = 0,
                                    PriceType = Models::UnitPriceType.UsagePrice,
                                    ReplacesPriceID = "replaces_price_id",
                                    UnitConfig = new()
                                    {
                                        UnitAmount = "unit_amount",
                                        Prorated = true,
                                    },
                                    DimensionalPriceConfiguration = new()
                                    {
                                        DimensionValues = ["string"],
                                        DimensionalPriceGroupID = "dimensional_price_group_id",
                                    },
                                },
                                Quantity = 1,
                                StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                SubLineItems =
                                [
                                    new Models::MatrixSubLineItem()
                                    {
                                        Amount = "9.00",
                                        Grouping = new() { Key = "region", Value = "west" },
                                        MatrixConfig = new(["string"]),
                                        Name = "Tier One",
                                        Quantity = 5,
                                        Type = Models::MatrixSubLineItemType.Matrix,
                                        ScaledQuantity = 0,
                                    },
                                ],
                                Subtotal = "9.00",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                UsageCustomerIDs = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Memo = "memo",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentAttempts =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PaymentProvider = Models::PaymentProvider.Stripe,
                                PaymentProviderID = "payment_provider_id",
                                ReceiptPdf =
                                    "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                Succeeded = true,
                            },
                        ],
                        PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        Status = Models::Status.Issued,
                        Subscription = new("VDGsT23osdLb84KD"),
                        Subtotal = "8.00",
                        SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Total = "8.00",
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        WillAutoIssue = true,
                    },
                ],
                VoidedCreditNotes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CreditNoteNumber = "credit_note_number",
                        CreditNotePdf = "credit_note_pdf",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        InvoiceID = "invoice_id",
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                ItemID = "item_id",
                                Name = "name",
                                Quantity = 0,
                                Subtotal = "subtotal",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                Discounts =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        AmountApplied = "amount_applied",
                                        AppliesToPriceIDs = ["string"],
                                        DiscountType = Models::DiscountDiscountType.Percentage,
                                        PercentageDiscount = 0,
                                        AmountDiscount = "amount_discount",
                                        Reason = "reason",
                                    },
                                ],
                                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                StartTimeInclusive = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                        ],
                        MaximumAmountAdjustment = new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                        Memo = "memo",
                        MinimumAmountRefunded = "minimum_amount_refunded",
                        Reason = Models::Reason.Duplicate,
                        Subtotal = "subtotal",
                        Total = "total",
                        Type = Models::SharedCreditNoteType.Refund,
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Discounts =
                        [
                            new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                        ],
                    },
                ],
                VoidedInvoices =
                [
                    new()
                    {
                        ID = "id",
                        AmountDue = "8.00",
                        AutoCollection = new()
                        {
                            Enabled = true,
                            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            NumAttempts = 0,
                            PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                        },
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNotes =
                        [
                            new()
                            {
                                ID = "id",
                                CreditNoteNumber = "credit_note_number",
                                Memo = "memo",
                                Reason = "reason",
                                Total = "total",
                                Type = "type",
                                VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            },
                        ],
                        Currency = "USD",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        CustomerBalanceTransactions =
                        [
                            new()
                            {
                                ID = "cgZa3SXcsPTVyC4Y",
                                Action =
                                    Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                Amount = "11.00",
                                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                CreditNote = new("id"),
                                Description = "An optional description",
                                EndingBalance = "22.00",
                                Invoice = new("gXcsPTVyC4YZa3Sc"),
                                StartingBalance = "33.00",
                                Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                            },
                        ],
                        CustomerTaxID = new()
                        {
                            Country = Models::Country.Ad,
                            Type = Models::CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Discounts =
                        [
                            new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                        ],
                        DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                        EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        HostedInvoiceURL = "hosted_invoice_url",
                        InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                        InvoiceNumber = "JYEFHK-00001",
                        InvoicePdf =
                            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                        InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                        IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                AdjustedSubtotal = "5.00",
                                Adjustments =
                                [
                                    new Models::MonetaryUsageDiscountAdjustment()
                                    {
                                        ID = "id",
                                        AdjustmentType =
                                            Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                        Amount = "amount",
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                Operator =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        IsInvoiceLevel = true,
                                        Reason = "reason",
                                        ReplacesAdjustmentID = "replaces_adjustment_id",
                                        UsageDiscount = 0,
                                    },
                                ],
                                Amount = "7.00",
                                CreditsApplied = "6.00",
                                EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                Filter = "filter",
                                Grouping = "grouping",
                                Name = "Fixed Fee",
                                PartiallyInvoicedAmount = "4.00",
                                Price = new Models::Unit()
                                {
                                    ID = "id",
                                    BillableMetric = new("id"),
                                    BillingCycleConfiguration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    BillingMode = Models::BillingMode.InAdvance,
                                    Cadence = Models::UnitCadence.OneTime,
                                    CompositePriceFilters =
                                    [
                                        new()
                                        {
                                            Field = Models::CompositePriceFilterField.PriceID,
                                            Operator =
                                                Models::CompositePriceFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    ConversionRate = 0,
                                    ConversionRateConfig =
                                        new Models::SharedUnitConversionRateConfig()
                                        {
                                            ConversionRateType =
                                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                        },
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Field.PriceID,
                                                Operator = Models::Operator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                    },
                                    Currency = "currency",
                                    Discount = new Models::PercentageDiscount()
                                    {
                                        DiscountType =
                                            Models::PercentageDiscountDiscountType.Percentage,
                                        PercentageDiscountValue = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::PercentageDiscountFilterField.PriceID,
                                                Operator =
                                                    Models::PercentageDiscountFilterOperator.Includes,
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
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    Item = new() { ID = "id", Name = "name" },
                                    Maximum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MaximumFilterField.PriceID,
                                                Operator = Models::MaximumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MaximumAmount = "maximum_amount",
                                    },
                                    MaximumAmount = "maximum_amount",
                                    Metadata = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
                                    Minimum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MinimumFilterField.PriceID,
                                                Operator = Models::MinimumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MinimumAmount = "minimum_amount",
                                    },
                                    MinimumAmount = "minimum_amount",
                                    Name = "name",
                                    PlanPhaseOrder = 0,
                                    PriceType = Models::UnitPriceType.UsagePrice,
                                    ReplacesPriceID = "replaces_price_id",
                                    UnitConfig = new()
                                    {
                                        UnitAmount = "unit_amount",
                                        Prorated = true,
                                    },
                                    DimensionalPriceConfiguration = new()
                                    {
                                        DimensionValues = ["string"],
                                        DimensionalPriceGroupID = "dimensional_price_group_id",
                                    },
                                },
                                Quantity = 1,
                                StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                SubLineItems =
                                [
                                    new Models::MatrixSubLineItem()
                                    {
                                        Amount = "9.00",
                                        Grouping = new() { Key = "region", Value = "west" },
                                        MatrixConfig = new(["string"]),
                                        Name = "Tier One",
                                        Quantity = 5,
                                        Type = Models::MatrixSubLineItemType.Matrix,
                                        ScaledQuantity = 0,
                                    },
                                ],
                                Subtotal = "9.00",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                UsageCustomerIDs = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Memo = "memo",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentAttempts =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PaymentProvider =
                                    Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                PaymentProviderID = "payment_provider_id",
                                ReceiptPdf =
                                    "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                Succeeded = true,
                            },
                        ],
                        PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        Status = Models::InvoiceStatus.Issued,
                        Subscription = new("VDGsT23osdLb84KD"),
                        Subtotal = "8.00",
                        SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Total = "8.00",
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        WillAutoIssue = true,
                    },
                ],
            },
        };
        DateTimeOffset expectedAppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCycleAlignment = "billing_cycle_alignment";
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedChangeOption = "change_option";
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPlanID = "plan_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChangeType, model.ChangeType);
        Assert.Equal(expectedExpirationTime, model.ExpirationTime);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedAppliedAt, model.AppliedAt);
        Assert.Equal(expectedBillingCycleAlignment, model.BillingCycleAlignment);
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
        Assert.Equal(expectedChangeOption, model.ChangeOption);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedPlanID, model.PlanID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCycleAlignment = "billing_cycle_alignment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ChangeOption = "change_option",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanID = "plan_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCycleAlignment = "billing_cycle_alignment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ChangeOption = "change_option",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanID = "plan_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionChangeRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedChangeType = "change_type";
        DateTimeOffset expectedExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionChangeRetrieveResponseStatus> expectedStatus =
            SubscriptionChangeRetrieveResponseStatus.Pending;
        MutatedSubscription expectedSubscription = new()
        {
            ID = "id",
            ActivePlanPhaseOrder = 0,
            AdjustmentIntervals =
            [
                new()
                {
                    ID = "id",
                    Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                    {
                        ID = "id",
                        AdjustmentType =
                            Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                Operator =
                                    Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Country = Models::Country.Ad,
                    Type = Models::CustomerTaxIDType.AdNrt,
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
                new Models::AmountDiscountInterval()
                {
                    AmountDiscount = "amount_discount",
                    AppliesToPriceIntervalIDs = ["string"],
                    DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = Models::AmountDiscountIntervalFilterField.PriceID,
                            Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                            Field = Models::MaximumIntervalFilterField.PriceID,
                            Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                            Field = Models::MinimumIntervalFilterField.PriceID,
                            Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                    new Models::PlanPhaseUsageDiscountAdjustment()
                    {
                        ID = "id",
                        AdjustmentType =
                            Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                        AppliesToPriceIDs = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                Operator =
                                    Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                Discount = new Models::PercentageDiscount()
                {
                    DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                    PercentageDiscountValue = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::PercentageDiscountFilterField.PriceID,
                            Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            Field = Models::MaximumFilterField.PriceID,
                            Operator = Models::MaximumFilterOperator.Includes,
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
                            Field = Models::MinimumFilterField.PriceID,
                            Operator = Models::MinimumFilterOperator.Includes,
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
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
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
                    new Models::Unit()
                    {
                        ID = "id",
                        BillableMetric = new("id"),
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        BillingMode = Models::BillingMode.InAdvance,
                        Cadence = Models::UnitCadence.OneTime,
                        CompositePriceFilters =
                        [
                            new()
                            {
                                Field = Models::CompositePriceFilterField.PriceID,
                                Operator = Models::CompositePriceFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                DurationUnit = Models::CustomExpirationDurationUnit.Day,
                            },
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Field.PriceID,
                                    Operator = Models::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                        },
                        Currency = "currency",
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        Item = new() { ID = "id", Name = "name" },
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        PlanPhaseOrder = 0,
                        PriceType = Models::UnitPriceType.UsagePrice,
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
                    Price = new Models::Unit()
                    {
                        ID = "id",
                        BillableMetric = new("id"),
                        BillingCycleConfiguration = new()
                        {
                            Duration = 0,
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        BillingMode = Models::BillingMode.InAdvance,
                        Cadence = Models::UnitCadence.OneTime,
                        CompositePriceFilters =
                        [
                            new()
                            {
                                Field = Models::CompositePriceFilterField.PriceID,
                                Operator = Models::CompositePriceFilterOperator.Includes,
                                Values = ["string"],
                            },
                        ],
                        ConversionRate = 0,
                        ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                        {
                            ConversionRateType =
                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                DurationUnit = Models::CustomExpirationDurationUnit.Day,
                            },
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Field.PriceID,
                                    Operator = Models::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                        },
                        Currency = "currency",
                        Discount = new Models::PercentageDiscount()
                        {
                            DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::PercentageDiscountFilterField.PriceID,
                                    Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                            DurationUnit = Models::DurationUnit.Day,
                        },
                        Item = new() { ID = "id", Name = "name" },
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
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
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        Name = "name",
                        PlanPhaseOrder = 0,
                        PriceType = Models::UnitPriceType.UsagePrice,
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
            Status = Status.Active,
            TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
            ChangedResources = new()
            {
                CreatedCreditNotes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CreditNoteNumber = "credit_note_number",
                        CreditNotePdf = "credit_note_pdf",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        InvoiceID = "invoice_id",
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                ItemID = "item_id",
                                Name = "name",
                                Quantity = 0,
                                Subtotal = "subtotal",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                Discounts =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        AmountApplied = "amount_applied",
                                        AppliesToPriceIDs = ["string"],
                                        DiscountType = Models::DiscountDiscountType.Percentage,
                                        PercentageDiscount = 0,
                                        AmountDiscount = "amount_discount",
                                        Reason = "reason",
                                    },
                                ],
                                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                StartTimeInclusive = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                        ],
                        MaximumAmountAdjustment = new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                        Memo = "memo",
                        MinimumAmountRefunded = "minimum_amount_refunded",
                        Reason = Models::Reason.Duplicate,
                        Subtotal = "subtotal",
                        Total = "total",
                        Type = Models::SharedCreditNoteType.Refund,
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Discounts =
                        [
                            new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                        ],
                    },
                ],
                CreatedInvoices =
                [
                    new()
                    {
                        ID = "id",
                        AmountDue = "8.00",
                        AutoCollection = new()
                        {
                            Enabled = true,
                            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            NumAttempts = 0,
                            PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                        },
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNotes =
                        [
                            new()
                            {
                                ID = "id",
                                CreditNoteNumber = "credit_note_number",
                                Memo = "memo",
                                Reason = "reason",
                                Total = "total",
                                Type = "type",
                                VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            },
                        ],
                        Currency = "USD",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        CustomerBalanceTransactions =
                        [
                            new()
                            {
                                ID = "cgZa3SXcsPTVyC4Y",
                                Action = Models::Action.AppliedToInvoice,
                                Amount = "11.00",
                                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                CreditNote = new("id"),
                                Description = "An optional description",
                                EndingBalance = "22.00",
                                Invoice = new("gXcsPTVyC4YZa3Sc"),
                                StartingBalance = "33.00",
                                Type = Models::Type.Increment,
                            },
                        ],
                        CustomerTaxID = new()
                        {
                            Country = Models::Country.Ad,
                            Type = Models::CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Discounts =
                        [
                            new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                        ],
                        DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                        EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        HostedInvoiceURL = "hosted_invoice_url",
                        InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                        InvoiceNumber = "JYEFHK-00001",
                        InvoicePdf =
                            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                        InvoiceSource = Models::InvoiceSource.Subscription,
                        IsPayableNow = true,
                        IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                AdjustedSubtotal = "5.00",
                                Adjustments =
                                [
                                    new Models::MonetaryUsageDiscountAdjustment()
                                    {
                                        ID = "id",
                                        AdjustmentType =
                                            Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                        Amount = "amount",
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                Operator =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        IsInvoiceLevel = true,
                                        Reason = "reason",
                                        ReplacesAdjustmentID = "replaces_adjustment_id",
                                        UsageDiscount = 0,
                                    },
                                ],
                                Amount = "7.00",
                                CreditsApplied = "6.00",
                                EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                Filter = "filter",
                                Grouping = "grouping",
                                Name = "Fixed Fee",
                                PartiallyInvoicedAmount = "4.00",
                                Price = new Models::Unit()
                                {
                                    ID = "id",
                                    BillableMetric = new("id"),
                                    BillingCycleConfiguration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    BillingMode = Models::BillingMode.InAdvance,
                                    Cadence = Models::UnitCadence.OneTime,
                                    CompositePriceFilters =
                                    [
                                        new()
                                        {
                                            Field = Models::CompositePriceFilterField.PriceID,
                                            Operator =
                                                Models::CompositePriceFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    ConversionRate = 0,
                                    ConversionRateConfig =
                                        new Models::SharedUnitConversionRateConfig()
                                        {
                                            ConversionRateType =
                                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                        },
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Field.PriceID,
                                                Operator = Models::Operator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                    },
                                    Currency = "currency",
                                    Discount = new Models::PercentageDiscount()
                                    {
                                        DiscountType =
                                            Models::PercentageDiscountDiscountType.Percentage,
                                        PercentageDiscountValue = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::PercentageDiscountFilterField.PriceID,
                                                Operator =
                                                    Models::PercentageDiscountFilterOperator.Includes,
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
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    Item = new() { ID = "id", Name = "name" },
                                    Maximum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MaximumFilterField.PriceID,
                                                Operator = Models::MaximumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MaximumAmount = "maximum_amount",
                                    },
                                    MaximumAmount = "maximum_amount",
                                    Metadata = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
                                    Minimum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MinimumFilterField.PriceID,
                                                Operator = Models::MinimumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MinimumAmount = "minimum_amount",
                                    },
                                    MinimumAmount = "minimum_amount",
                                    Name = "name",
                                    PlanPhaseOrder = 0,
                                    PriceType = Models::UnitPriceType.UsagePrice,
                                    ReplacesPriceID = "replaces_price_id",
                                    UnitConfig = new()
                                    {
                                        UnitAmount = "unit_amount",
                                        Prorated = true,
                                    },
                                    DimensionalPriceConfiguration = new()
                                    {
                                        DimensionValues = ["string"],
                                        DimensionalPriceGroupID = "dimensional_price_group_id",
                                    },
                                },
                                Quantity = 1,
                                StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                SubLineItems =
                                [
                                    new Models::MatrixSubLineItem()
                                    {
                                        Amount = "9.00",
                                        Grouping = new() { Key = "region", Value = "west" },
                                        MatrixConfig = new(["string"]),
                                        Name = "Tier One",
                                        Quantity = 5,
                                        Type = Models::MatrixSubLineItemType.Matrix,
                                        ScaledQuantity = 0,
                                    },
                                ],
                                Subtotal = "9.00",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                UsageCustomerIDs = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Memo = "memo",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentAttempts =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PaymentProvider = Models::PaymentProvider.Stripe,
                                PaymentProviderID = "payment_provider_id",
                                ReceiptPdf =
                                    "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                Succeeded = true,
                            },
                        ],
                        PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        Status = Models::Status.Issued,
                        Subscription = new("VDGsT23osdLb84KD"),
                        Subtotal = "8.00",
                        SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Total = "8.00",
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        WillAutoIssue = true,
                    },
                ],
                VoidedCreditNotes =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CreditNoteNumber = "credit_note_number",
                        CreditNotePdf = "credit_note_pdf",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        InvoiceID = "invoice_id",
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                ItemID = "item_id",
                                Name = "name",
                                Quantity = 0,
                                Subtotal = "subtotal",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                Discounts =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        AmountApplied = "amount_applied",
                                        AppliesToPriceIDs = ["string"],
                                        DiscountType = Models::DiscountDiscountType.Percentage,
                                        PercentageDiscount = 0,
                                        AmountDiscount = "amount_discount",
                                        Reason = "reason",
                                    },
                                ],
                                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                StartTimeInclusive = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                        ],
                        MaximumAmountAdjustment = new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                        Memo = "memo",
                        MinimumAmountRefunded = "minimum_amount_refunded",
                        Reason = Models::Reason.Duplicate,
                        Subtotal = "subtotal",
                        Total = "total",
                        Type = Models::SharedCreditNoteType.Refund,
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Discounts =
                        [
                            new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                        ],
                    },
                ],
                VoidedInvoices =
                [
                    new()
                    {
                        ID = "id",
                        AmountDue = "8.00",
                        AutoCollection = new()
                        {
                            Enabled = true,
                            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            NumAttempts = 0,
                            PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                "2019-12-27T18:11:19.117Z"
                            ),
                        },
                        BillingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNotes =
                        [
                            new()
                            {
                                ID = "id",
                                CreditNoteNumber = "credit_note_number",
                                Memo = "memo",
                                Reason = "reason",
                                Total = "total",
                                Type = "type",
                                VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            },
                        ],
                        Currency = "USD",
                        Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                        CustomerBalanceTransactions =
                        [
                            new()
                            {
                                ID = "cgZa3SXcsPTVyC4Y",
                                Action =
                                    Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                Amount = "11.00",
                                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                CreditNote = new("id"),
                                Description = "An optional description",
                                EndingBalance = "22.00",
                                Invoice = new("gXcsPTVyC4YZa3Sc"),
                                StartingBalance = "33.00",
                                Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                            },
                        ],
                        CustomerTaxID = new()
                        {
                            Country = Models::Country.Ad,
                            Type = Models::CustomerTaxIDType.AdNrt,
                            Value = "value",
                        },
                        Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Discounts =
                        [
                            new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                Reason = "reason",
                            },
                        ],
                        DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                        EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        HostedInvoiceURL = "hosted_invoice_url",
                        InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                        InvoiceNumber = "JYEFHK-00001",
                        InvoicePdf =
                            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                        InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                        IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        LineItems =
                        [
                            new()
                            {
                                ID = "id",
                                AdjustedSubtotal = "5.00",
                                Adjustments =
                                [
                                    new Models::MonetaryUsageDiscountAdjustment()
                                    {
                                        ID = "id",
                                        AdjustmentType =
                                            Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                        Amount = "amount",
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                Operator =
                                                    Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        IsInvoiceLevel = true,
                                        Reason = "reason",
                                        ReplacesAdjustmentID = "replaces_adjustment_id",
                                        UsageDiscount = 0,
                                    },
                                ],
                                Amount = "7.00",
                                CreditsApplied = "6.00",
                                EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                Filter = "filter",
                                Grouping = "grouping",
                                Name = "Fixed Fee",
                                PartiallyInvoicedAmount = "4.00",
                                Price = new Models::Unit()
                                {
                                    ID = "id",
                                    BillableMetric = new("id"),
                                    BillingCycleConfiguration = new()
                                    {
                                        Duration = 0,
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    BillingMode = Models::BillingMode.InAdvance,
                                    Cadence = Models::UnitCadence.OneTime,
                                    CompositePriceFilters =
                                    [
                                        new()
                                        {
                                            Field = Models::CompositePriceFilterField.PriceID,
                                            Operator =
                                                Models::CompositePriceFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    ConversionRate = 0,
                                    ConversionRateConfig =
                                        new Models::SharedUnitConversionRateConfig()
                                        {
                                            ConversionRateType =
                                                Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                            DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                        },
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Field.PriceID,
                                                Operator = Models::Operator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                    },
                                    Currency = "currency",
                                    Discount = new Models::PercentageDiscount()
                                    {
                                        DiscountType =
                                            Models::PercentageDiscountDiscountType.Percentage,
                                        PercentageDiscountValue = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field =
                                                    Models::PercentageDiscountFilterField.PriceID,
                                                Operator =
                                                    Models::PercentageDiscountFilterOperator.Includes,
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
                                        DurationUnit = Models::DurationUnit.Day,
                                    },
                                    Item = new() { ID = "id", Name = "name" },
                                    Maximum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MaximumFilterField.PriceID,
                                                Operator = Models::MaximumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MaximumAmount = "maximum_amount",
                                    },
                                    MaximumAmount = "maximum_amount",
                                    Metadata = new Dictionary<string, string>()
                                    {
                                        { "foo", "string" },
                                    },
                                    Minimum = new()
                                    {
                                        AppliesToPriceIDs = ["string"],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::MinimumFilterField.PriceID,
                                                Operator = Models::MinimumFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        MinimumAmount = "minimum_amount",
                                    },
                                    MinimumAmount = "minimum_amount",
                                    Name = "name",
                                    PlanPhaseOrder = 0,
                                    PriceType = Models::UnitPriceType.UsagePrice,
                                    ReplacesPriceID = "replaces_price_id",
                                    UnitConfig = new()
                                    {
                                        UnitAmount = "unit_amount",
                                        Prorated = true,
                                    },
                                    DimensionalPriceConfiguration = new()
                                    {
                                        DimensionValues = ["string"],
                                        DimensionalPriceGroupID = "dimensional_price_group_id",
                                    },
                                },
                                Quantity = 1,
                                StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                SubLineItems =
                                [
                                    new Models::MatrixSubLineItem()
                                    {
                                        Amount = "9.00",
                                        Grouping = new() { Key = "region", Value = "west" },
                                        MatrixConfig = new(["string"]),
                                        Name = "Tier One",
                                        Quantity = 5,
                                        Type = Models::MatrixSubLineItemType.Matrix,
                                        ScaledQuantity = 0,
                                    },
                                ],
                                Subtotal = "9.00",
                                TaxAmounts =
                                [
                                    new()
                                    {
                                        Amount = "amount",
                                        TaxRateDescription = "tax_rate_description",
                                        TaxRatePercentage = "tax_rate_percentage",
                                    },
                                ],
                                UsageCustomerIDs = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MaximumFilterField.PriceID,
                                    Operator = Models::MaximumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MaximumAmount = "maximum_amount",
                        },
                        MaximumAmount = "maximum_amount",
                        Memo = "memo",
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        Minimum = new()
                        {
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::MinimumFilterField.PriceID,
                                    Operator = Models::MinimumFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            MinimumAmount = "minimum_amount",
                        },
                        MinimumAmount = "minimum_amount",
                        PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentAttempts =
                        [
                            new()
                            {
                                ID = "id",
                                Amount = "amount",
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PaymentProvider =
                                    Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                PaymentProviderID = "payment_provider_id",
                                ReceiptPdf =
                                    "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                Succeeded = true,
                            },
                        ],
                        PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ShippingAddress = new()
                        {
                            City = "city",
                            Country = "country",
                            Line1 = "line1",
                            Line2 = "line2",
                            PostalCode = "postal_code",
                            State = "state",
                        },
                        Status = Models::InvoiceStatus.Issued,
                        Subscription = new("VDGsT23osdLb84KD"),
                        Subtotal = "8.00",
                        SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Total = "8.00",
                        VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        WillAutoIssue = true,
                    },
                ],
            },
        };
        DateTimeOffset expectedAppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCycleAlignment = "billing_cycle_alignment";
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedChangeOption = "change_option";
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPlanID = "plan_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChangeType, deserialized.ChangeType);
        Assert.Equal(expectedExpirationTime, deserialized.ExpirationTime);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedAppliedAt, deserialized.AppliedAt);
        Assert.Equal(expectedBillingCycleAlignment, deserialized.BillingCycleAlignment);
        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
        Assert.Equal(expectedChangeOption, deserialized.ChangeOption);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
            AppliedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCycleAlignment = "billing_cycle_alignment",
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ChangeOption = "change_option",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PlanID = "plan_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
        };

        Assert.Null(model.AppliedAt);
        Assert.False(model.RawData.ContainsKey("applied_at"));
        Assert.Null(model.BillingCycleAlignment);
        Assert.False(model.RawData.ContainsKey("billing_cycle_alignment"));
        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.ChangeOption);
        Assert.False(model.RawData.ContainsKey("change_option"));
        Assert.Null(model.EffectiveDate);
        Assert.False(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.PlanID);
        Assert.False(model.RawData.ContainsKey("plan_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },

            AppliedAt = null,
            BillingCycleAlignment = null,
            CancelledAt = null,
            ChangeOption = null,
            EffectiveDate = null,
            PlanID = null,
        };

        Assert.Null(model.AppliedAt);
        Assert.True(model.RawData.ContainsKey("applied_at"));
        Assert.Null(model.BillingCycleAlignment);
        Assert.True(model.RawData.ContainsKey("billing_cycle_alignment"));
        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.ChangeOption);
        Assert.True(model.RawData.ContainsKey("change_option"));
        Assert.Null(model.EffectiveDate);
        Assert.True(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.PlanID);
        Assert.True(model.RawData.ContainsKey("plan_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionChangeRetrieveResponse
        {
            ID = "id",
            ChangeType = "change_type",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeRetrieveResponseStatus.Pending,
            Subscription = new()
            {
                ID = "id",
                ActivePlanPhaseOrder = 0,
                AdjustmentIntervals =
                [
                    new()
                    {
                        ID = "id",
                        Adjustment = new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                        Country = Models::Country.Ad,
                        Type = Models::CustomerTaxIDType.AdNrt,
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
                    new Models::AmountDiscountInterval()
                    {
                        AmountDiscount = "amount_discount",
                        AppliesToPriceIntervalIDs = ["string"],
                        DiscountType = Models::AmountDiscountIntervalDiscountType.Amount,
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Filters =
                        [
                            new()
                            {
                                Field = Models::AmountDiscountIntervalFilterField.PriceID,
                                Operator = Models::AmountDiscountIntervalFilterOperator.Includes,
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
                                Field = Models::MaximumIntervalFilterField.PriceID,
                                Operator = Models::MaximumIntervalFilterOperator.Includes,
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
                                Field = Models::MinimumIntervalFilterField.PriceID,
                                Operator = Models::MinimumIntervalFilterOperator.Includes,
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
                        new Models::PlanPhaseUsageDiscountAdjustment()
                        {
                            ID = "id",
                            AdjustmentType =
                                Models::PlanPhaseUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                            AppliesToPriceIDs = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        Models::PlanPhaseUsageDiscountAdjustmentFilterOperator.Includes,
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
                    Discount = new Models::PercentageDiscount()
                    {
                        DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::PercentageDiscountFilterField.PriceID,
                                Operator = Models::PercentageDiscountFilterOperator.Includes,
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
                                Field = Models::MaximumFilterField.PriceID,
                                Operator = Models::MaximumFilterOperator.Includes,
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
                                Field = Models::MinimumFilterField.PriceID,
                                Operator = Models::MinimumFilterOperator.Includes,
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
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
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
                        new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                        Price = new Models::Unit()
                        {
                            ID = "id",
                            BillableMetric = new("id"),
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            BillingMode = Models::BillingMode.InAdvance,
                            Cadence = Models::UnitCadence.OneTime,
                            CompositePriceFilters =
                            [
                                new()
                                {
                                    Field = Models::CompositePriceFilterField.PriceID,
                                    Operator = Models::CompositePriceFilterOperator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::SharedUnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
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
                                    DurationUnit = Models::CustomExpirationDurationUnit.Day,
                                },
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Field.PriceID,
                                        Operator = Models::Operator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                            },
                            Currency = "currency",
                            Discount = new Models::PercentageDiscount()
                            {
                                DiscountType = Models::PercentageDiscountDiscountType.Percentage,
                                PercentageDiscountValue = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::PercentageDiscountFilterField.PriceID,
                                        Operator =
                                            Models::PercentageDiscountFilterOperator.Includes,
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
                                DurationUnit = Models::DurationUnit.Day,
                            },
                            Item = new() { ID = "id", Name = "name" },
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
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
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            Name = "name",
                            PlanPhaseOrder = 0,
                            PriceType = Models::UnitPriceType.UsagePrice,
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
                Status = Status.Active,
                TrialInfo = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")),
                ChangedResources = new()
                {
                    CreatedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    CreatedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action = Models::Action.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::Type.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceSource.Subscription,
                            IsPayableNow = true,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider = Models::PaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::Status.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                    VoidedCreditNotes =
                    [
                        new()
                        {
                            ID = "id",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            CreditNoteNumber = "credit_note_number",
                            CreditNotePdf = "credit_note_pdf",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            InvoiceID = "invoice_id",
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    ItemID = "item_id",
                                    Name = "name",
                                    Quantity = 0,
                                    Subtotal = "subtotal",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    Discounts =
                                    [
                                        new()
                                        {
                                            ID = "id",
                                            AmountApplied = "amount_applied",
                                            AppliesToPriceIDs = ["string"],
                                            DiscountType = Models::DiscountDiscountType.Percentage,
                                            PercentageDiscount = 0,
                                            AmountDiscount = "amount_discount",
                                            Reason = "reason",
                                        },
                                    ],
                                    EndTimeExclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                    StartTimeInclusive = DateTimeOffset.Parse(
                                        "2019-12-27T18:11:19.117Z"
                                    ),
                                },
                            ],
                            MaximumAmountAdjustment = new()
                            {
                                AmountApplied = "amount_applied",
                                DiscountType =
                                    Models::MaximumAmountAdjustmentDiscountType.Percentage,
                                PercentageDiscount = 0,
                                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                Reason = "reason",
                            },
                            Memo = "memo",
                            MinimumAmountRefunded = "minimum_amount_refunded",
                            Reason = Models::Reason.Duplicate,
                            Subtotal = "subtotal",
                            Total = "total",
                            Type = Models::SharedCreditNoteType.Refund,
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Discounts =
                            [
                                new()
                                {
                                    AmountApplied = "amount_applied",
                                    DiscountType =
                                        Models::SharedCreditNoteDiscountDiscountType.Percentage,
                                    PercentageDiscount = 0,
                                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                                    Reason = "reason",
                                },
                            ],
                        },
                    ],
                    VoidedInvoices =
                    [
                        new()
                        {
                            ID = "id",
                            AmountDue = "8.00",
                            AutoCollection = new()
                            {
                                Enabled = true,
                                NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                NumAttempts = 0,
                                PreviouslyAttemptedAt = DateTimeOffset.Parse(
                                    "2019-12-27T18:11:19.117Z"
                                ),
                            },
                            BillingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNotes =
                            [
                                new()
                                {
                                    ID = "id",
                                    CreditNoteNumber = "credit_note_number",
                                    Memo = "memo",
                                    Reason = "reason",
                                    Total = "total",
                                    Type = "type",
                                    VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                },
                            ],
                            Currency = "USD",
                            Customer = new()
                            {
                                ID = "id",
                                ExternalCustomerID = "external_customer_id",
                            },
                            CustomerBalanceTransactions =
                            [
                                new()
                                {
                                    ID = "cgZa3SXcsPTVyC4Y",
                                    Action =
                                        Models::InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::InvoiceCustomerBalanceTransactionType.Increment,
                                },
                            ],
                            CustomerTaxID = new()
                            {
                                Country = Models::Country.Ad,
                                Type = Models::CustomerTaxIDType.AdNrt,
                                Value = "value",
                            },
                            Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                            Discounts =
                            [
                                new Models::PercentageDiscount()
                                {
                                    DiscountType =
                                        Models::PercentageDiscountDiscountType.Percentage,
                                    PercentageDiscountValue = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::PercentageDiscountFilterField.PriceID,
                                            Operator =
                                                Models::PercentageDiscountFilterOperator.Includes,
                                            Values = ["string"],
                                        },
                                    ],
                                    Reason = "reason",
                                },
                            ],
                            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            HostedInvoiceURL = "hosted_invoice_url",
                            InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                            InvoiceNumber = "JYEFHK-00001",
                            InvoicePdf =
                                "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                            InvoiceSource = Models::InvoiceInvoiceSource.Subscription,
                            IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            LineItems =
                            [
                                new()
                                {
                                    ID = "id",
                                    AdjustedSubtotal = "5.00",
                                    Adjustments =
                                    [
                                        new Models::MonetaryUsageDiscountAdjustment()
                                        {
                                            ID = "id",
                                            AdjustmentType =
                                                Models::MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                            Amount = "amount",
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                                    Operator =
                                                        Models::MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            IsInvoiceLevel = true,
                                            Reason = "reason",
                                            ReplacesAdjustmentID = "replaces_adjustment_id",
                                            UsageDiscount = 0,
                                        },
                                    ],
                                    Amount = "7.00",
                                    CreditsApplied = "6.00",
                                    EndDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    Filter = "filter",
                                    Grouping = "grouping",
                                    Name = "Fixed Fee",
                                    PartiallyInvoicedAmount = "4.00",
                                    Price = new Models::Unit()
                                    {
                                        ID = "id",
                                        BillableMetric = new("id"),
                                        BillingCycleConfiguration = new()
                                        {
                                            Duration = 0,
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        BillingMode = Models::BillingMode.InAdvance,
                                        Cadence = Models::UnitCadence.OneTime,
                                        CompositePriceFilters =
                                        [
                                            new()
                                            {
                                                Field = Models::CompositePriceFilterField.PriceID,
                                                Operator =
                                                    Models::CompositePriceFilterOperator.Includes,
                                                Values = ["string"],
                                            },
                                        ],
                                        ConversionRate = 0,
                                        ConversionRateConfig =
                                            new Models::SharedUnitConversionRateConfig()
                                            {
                                                ConversionRateType =
                                                    Models::SharedUnitConversionRateConfigConversionRateType.Unit,
                                                UnitConfig = new("unit_amount"),
                                            },
                                        CreatedAt = DateTimeOffset.Parse(
                                            "2019-12-27T18:11:19.117Z"
                                        ),
                                        CreditAllocation = new()
                                        {
                                            AllowsRollover = true,
                                            Currency = "currency",
                                            CustomExpiration = new()
                                            {
                                                Duration = 0,
                                                DurationUnit =
                                                    Models::CustomExpirationDurationUnit.Day,
                                            },
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Field.PriceID,
                                                    Operator = Models::Operator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                        },
                                        Currency = "currency",
                                        Discount = new Models::PercentageDiscount()
                                        {
                                            DiscountType =
                                                Models::PercentageDiscountDiscountType.Percentage,
                                            PercentageDiscountValue = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field =
                                                        Models::PercentageDiscountFilterField.PriceID,
                                                    Operator =
                                                        Models::PercentageDiscountFilterOperator.Includes,
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
                                            DurationUnit = Models::DurationUnit.Day,
                                        },
                                        Item = new() { ID = "id", Name = "name" },
                                        Maximum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MaximumFilterField.PriceID,
                                                    Operator =
                                                        Models::MaximumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MaximumAmount = "maximum_amount",
                                        },
                                        MaximumAmount = "maximum_amount",
                                        Metadata = new Dictionary<string, string>()
                                        {
                                            { "foo", "string" },
                                        },
                                        Minimum = new()
                                        {
                                            AppliesToPriceIDs = ["string"],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::MinimumFilterField.PriceID,
                                                    Operator =
                                                        Models::MinimumFilterOperator.Includes,
                                                    Values = ["string"],
                                                },
                                            ],
                                            MinimumAmount = "minimum_amount",
                                        },
                                        MinimumAmount = "minimum_amount",
                                        Name = "name",
                                        PlanPhaseOrder = 0,
                                        PriceType = Models::UnitPriceType.UsagePrice,
                                        ReplacesPriceID = "replaces_price_id",
                                        UnitConfig = new()
                                        {
                                            UnitAmount = "unit_amount",
                                            Prorated = true,
                                        },
                                        DimensionalPriceConfiguration = new()
                                        {
                                            DimensionValues = ["string"],
                                            DimensionalPriceGroupID = "dimensional_price_group_id",
                                        },
                                    },
                                    Quantity = 1,
                                    StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                                    SubLineItems =
                                    [
                                        new Models::MatrixSubLineItem()
                                        {
                                            Amount = "9.00",
                                            Grouping = new() { Key = "region", Value = "west" },
                                            MatrixConfig = new(["string"]),
                                            Name = "Tier One",
                                            Quantity = 5,
                                            Type = Models::MatrixSubLineItemType.Matrix,
                                            ScaledQuantity = 0,
                                        },
                                    ],
                                    Subtotal = "9.00",
                                    TaxAmounts =
                                    [
                                        new()
                                        {
                                            Amount = "amount",
                                            TaxRateDescription = "tax_rate_description",
                                            TaxRatePercentage = "tax_rate_percentage",
                                        },
                                    ],
                                    UsageCustomerIDs = ["string"],
                                },
                            ],
                            Maximum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MaximumFilterField.PriceID,
                                        Operator = Models::MaximumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MaximumAmount = "maximum_amount",
                            },
                            MaximumAmount = "maximum_amount",
                            Memo = "memo",
                            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                            Minimum = new()
                            {
                                AppliesToPriceIDs = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::MinimumFilterField.PriceID,
                                        Operator = Models::MinimumFilterOperator.Includes,
                                        Values = ["string"],
                                    },
                                ],
                                MinimumAmount = "minimum_amount",
                            },
                            MinimumAmount = "minimum_amount",
                            PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentAttempts =
                            [
                                new()
                                {
                                    ID = "id",
                                    Amount = "amount",
                                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                    PaymentProvider =
                                        Models::InvoicePaymentAttemptPaymentProvider.Stripe,
                                    PaymentProviderID = "payment_provider_id",
                                    ReceiptPdf =
                                        "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                                    Succeeded = true,
                                },
                            ],
                            PaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            ShippingAddress = new()
                            {
                                City = "city",
                                Country = "country",
                                Line1 = "line1",
                                Line2 = "line2",
                                PostalCode = "postal_code",
                                State = "state",
                            },
                            Status = Models::InvoiceStatus.Issued,
                            Subscription = new("VDGsT23osdLb84KD"),
                            Subtotal = "8.00",
                            SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Total = "8.00",
                            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            WillAutoIssue = true,
                        },
                    ],
                },
            },

            AppliedAt = null,
            BillingCycleAlignment = null,
            CancelledAt = null,
            ChangeOption = null,
            EffectiveDate = null,
            PlanID = null,
        };

        model.Validate();
    }
}

public class SubscriptionChangeRetrieveResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Pending)]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Applied)]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Cancelled)]
    public void Validation_Works(SubscriptionChangeRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChangeRetrieveResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeRetrieveResponseStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Pending)]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Applied)]
    [InlineData(SubscriptionChangeRetrieveResponseStatus.Cancelled)]
    public void SerializationRoundtrip_Works(SubscriptionChangeRetrieveResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChangeRetrieveResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeRetrieveResponseStatus>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionChangeRetrieveResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
