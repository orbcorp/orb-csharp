using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers;
using Orb.Models.SubscriptionChanges;
using Models = Orb.Models;
using Plans = Orb.Models.Plans;

namespace Orb.Tests.Models.SubscriptionChanges;

public class SubscriptionChangeCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionChangeCancelResponse
        {
            ID = "id",
            ExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionChangeCancelResponseStatus.Pending,
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
                                    Field = Models::Filter23Field.PriceID,
                                    Operator = Models::Filter23Operator.Includes,
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
                                Field = Models::Filter1Field.PriceID,
                                Operator = Models::Filter1Operator.Includes,
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
                                Field = Models::Filter3Field.PriceID,
                                Operator = Models::Filter3Operator.Includes,
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
                                Field = Models::Filter5Field.PriceID,
                                Operator = Models::Filter5Operator.Includes,
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
                                    Field = Models::Filter23Field.PriceID,
                                    Operator = Models::Filter23Operator.Includes,
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
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Models::Filter17Field.PriceID,
                                Operator = Models::Filter17Operator.Includes,
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
                                Field = Models::Filter2Field.PriceID,
                                Operator = Models::Filter2Operator.Includes,
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
                                Field = Models::Filter4Field.PriceID,
                                Operator = Models::Filter4Operator.Includes,
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
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Filter17Field.PriceID,
                                        Operator = Models::Filter17Operator.Includes,
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
                                        Field = Models::Filter2Field.PriceID,
                                        Operator = Models::Filter2Operator.Includes,
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
                                        Field = Models::Filter4Field.PriceID,
                                        Operator = Models::Filter4Operator.Includes,
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
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Filter17Field.PriceID,
                                        Operator = Models::Filter17Operator.Includes,
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
                                        Field = Models::Filter2Field.PriceID,
                                        Operator = Models::Filter2Operator.Includes,
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
                                        Field = Models::Filter4Field.PriceID,
                                        Operator = Models::Filter4Operator.Includes,
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
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Filter17Field.PriceID,
                                        Operator = Models::Filter17Operator.Includes,
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
                                        Field = Models::Filter2Field.PriceID,
                                        Operator = Models::Filter2Operator.Includes,
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
                                        Field = Models::Filter4Field.PriceID,
                                        Operator = Models::Filter4Operator.Includes,
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
                                    DiscountType = Models::DiscountModelDiscountType.Percentage,
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
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::Filter17Field.PriceID,
                                            Operator = Models::Filter17Operator.Includes,
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
                                                    Field = Models::Filter10Field.PriceID,
                                                    Operator = Models::Filter10Operator.Includes,
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
                                            PercentageDiscount1 = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Filter17Field.PriceID,
                                                    Operator = Models::Filter17Operator.Includes,
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
                                                    Field = Models::Filter2Field.PriceID,
                                                    Operator = Models::Filter2Operator.Includes,
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
                                                    Field = Models::Filter4Field.PriceID,
                                                    Operator = Models::Filter4Operator.Includes,
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
                                        Field = Models::Filter2Field.PriceID,
                                        Operator = Models::Filter2Operator.Includes,
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
                                        Field = Models::Filter4Field.PriceID,
                                        Operator = Models::Filter4Operator.Includes,
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
                                    DiscountType = Models::DiscountModelDiscountType.Percentage,
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
                                        Models::CustomerBalanceTransactionModelAction.AppliedToInvoice,
                                    Amount = "11.00",
                                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                    CreditNote = new("id"),
                                    Description = "An optional description",
                                    EndingBalance = "22.00",
                                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                                    StartingBalance = "33.00",
                                    Type = Models::CustomerBalanceTransactionModelType.Increment,
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
                                    PercentageDiscount1 = 0.15,
                                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field = Models::Filter17Field.PriceID,
                                            Operator = Models::Filter17Operator.Includes,
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
                                                    Field = Models::Filter10Field.PriceID,
                                                    Operator = Models::Filter10Operator.Includes,
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
                                            PercentageDiscount1 = 0.15,
                                            AppliesToPriceIDs =
                                            [
                                                "h74gfhdjvn7ujokd",
                                                "7hfgtgjnbvc3ujkl",
                                            ],
                                            Filters =
                                            [
                                                new()
                                                {
                                                    Field = Models::Filter17Field.PriceID,
                                                    Operator = Models::Filter17Operator.Includes,
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
                                                    Field = Models::Filter2Field.PriceID,
                                                    Operator = Models::Filter2Operator.Includes,
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
                                                    Field = Models::Filter4Field.PriceID,
                                                    Operator = Models::Filter4Operator.Includes,
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
                                        Field = Models::Filter2Field.PriceID,
                                        Operator = Models::Filter2Operator.Includes,
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
                                        Field = Models::Filter4Field.PriceID,
                                        Operator = Models::Filter4Operator.Includes,
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
                                        Models::PaymentAttemptModelPaymentProvider.Stripe,
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
            CancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedExpirationTime = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionChangeCancelResponseStatus> expectedStatus =
            SubscriptionChangeCancelResponseStatus.Pending;
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
                                Field = Models::Filter23Field.PriceID,
                                Operator = Models::Filter23Operator.Includes,
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
                            Field = Models::Filter1Field.PriceID,
                            Operator = Models::Filter1Operator.Includes,
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
                            Field = Models::Filter3Field.PriceID,
                            Operator = Models::Filter3Operator.Includes,
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
                            Field = Models::Filter5Field.PriceID,
                            Operator = Models::Filter5Operator.Includes,
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
                                Field = Models::Filter23Field.PriceID,
                                Operator = Models::Filter23Operator.Includes,
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
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Models::Filter17Field.PriceID,
                            Operator = Models::Filter17Operator.Includes,
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
                            Field = Models::Filter2Field.PriceID,
                            Operator = Models::Filter2Operator.Includes,
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
                            Field = Models::Filter4Field.PriceID,
                            Operator = Models::Filter4Operator.Includes,
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
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Filter17Field.PriceID,
                                    Operator = Models::Filter17Operator.Includes,
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
                                    Field = Models::Filter2Field.PriceID,
                                    Operator = Models::Filter2Operator.Includes,
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
                                    Field = Models::Filter4Field.PriceID,
                                    Operator = Models::Filter4Operator.Includes,
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
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Filter17Field.PriceID,
                                    Operator = Models::Filter17Operator.Includes,
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
                                    Field = Models::Filter2Field.PriceID,
                                    Operator = Models::Filter2Operator.Includes,
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
                                    Field = Models::Filter4Field.PriceID,
                                    Operator = Models::Filter4Operator.Includes,
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
                            PercentageDiscount1 = 0.15,
                            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                            Filters =
                            [
                                new()
                                {
                                    Field = Models::Filter17Field.PriceID,
                                    Operator = Models::Filter17Operator.Includes,
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
                                    Field = Models::Filter2Field.PriceID,
                                    Operator = Models::Filter2Operator.Includes,
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
                                    Field = Models::Filter4Field.PriceID,
                                    Operator = Models::Filter4Operator.Includes,
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
                                DiscountType = Models::DiscountModelDiscountType.Percentage,
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
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Filter17Field.PriceID,
                                        Operator = Models::Filter17Operator.Includes,
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
                                                Field = Models::Filter10Field.PriceID,
                                                Operator = Models::Filter10Operator.Includes,
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
                                        PercentageDiscount1 = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Filter17Field.PriceID,
                                                Operator = Models::Filter17Operator.Includes,
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
                                                Field = Models::Filter2Field.PriceID,
                                                Operator = Models::Filter2Operator.Includes,
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
                                                Field = Models::Filter4Field.PriceID,
                                                Operator = Models::Filter4Operator.Includes,
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
                                    Field = Models::Filter2Field.PriceID,
                                    Operator = Models::Filter2Operator.Includes,
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
                                    Field = Models::Filter4Field.PriceID,
                                    Operator = Models::Filter4Operator.Includes,
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
                                DiscountType = Models::DiscountModelDiscountType.Percentage,
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
                                    Models::CustomerBalanceTransactionModelAction.AppliedToInvoice,
                                Amount = "11.00",
                                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                                CreditNote = new("id"),
                                Description = "An optional description",
                                EndingBalance = "22.00",
                                Invoice = new("gXcsPTVyC4YZa3Sc"),
                                StartingBalance = "33.00",
                                Type = Models::CustomerBalanceTransactionModelType.Increment,
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
                                PercentageDiscount1 = 0.15,
                                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = Models::Filter17Field.PriceID,
                                        Operator = Models::Filter17Operator.Includes,
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
                                                Field = Models::Filter10Field.PriceID,
                                                Operator = Models::Filter10Operator.Includes,
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
                                        PercentageDiscount1 = 0.15,
                                        AppliesToPriceIDs =
                                        [
                                            "h74gfhdjvn7ujokd",
                                            "7hfgtgjnbvc3ujkl",
                                        ],
                                        Filters =
                                        [
                                            new()
                                            {
                                                Field = Models::Filter17Field.PriceID,
                                                Operator = Models::Filter17Operator.Includes,
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
                                                Field = Models::Filter2Field.PriceID,
                                                Operator = Models::Filter2Operator.Includes,
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
                                                Field = Models::Filter4Field.PriceID,
                                                Operator = Models::Filter4Operator.Includes,
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
                                    Field = Models::Filter2Field.PriceID,
                                    Operator = Models::Filter2Operator.Includes,
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
                                    Field = Models::Filter4Field.PriceID,
                                    Operator = Models::Filter4Operator.Includes,
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
                                PaymentProvider = Models::PaymentAttemptModelPaymentProvider.Stripe,
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
        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpirationTime, model.ExpirationTime);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedAppliedAt, model.AppliedAt);
        Assert.Equal(expectedCancelledAt, model.CancelledAt);
    }
}
