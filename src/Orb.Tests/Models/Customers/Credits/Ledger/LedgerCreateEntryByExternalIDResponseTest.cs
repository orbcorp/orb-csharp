using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Customers.Credits.Ledger;
using Models = Orb.Models;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class LedgerCreateEntryByExternalIDResponseTest : TestBase
{
    [Fact]
    public void IncrementLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new IncrementLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = IncrementLedgerEntryEntryStatus.Committed,
                EntryType = IncrementLedgerEntryEntryType.Increment,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
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
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        HostedInvoiceUrl = "hosted_invoice_url",
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
                                        AppliesToPriceIds = ["string"],
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
                                        AppliesToPriceIds =
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
                                        AppliesToPriceIds = ["string"],
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
                                        AppliesToPriceIds = ["string"],
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
                                UsageCustomerIds = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIds = ["string"],
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
                            AppliesToPriceIds = ["string"],
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void DecrementLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new DecrementLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
                EntryType = DecrementLedgerEntryEntryType.Decrement,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
                EventID = "event_id",
                InvoiceID = "invoice_id",
                PriceID = "price_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ExpirationChangeLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new ExpirationChangeLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
                EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartingBalance = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void CreditBlockExpiryLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new CreditBlockExpiryLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = CreditBlockExpiryLedgerEntryEntryStatus.Committed,
                EntryType = CreditBlockExpiryLedgerEntryEntryType.CreditBlockExpiry,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void VoidLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new VoidLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = VoidLedgerEntryEntryStatus.Committed,
                EntryType = VoidLedgerEntryEntryType.Void,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
                VoidAmount = 0,
                VoidReason = "void_reason",
            }
        );
        value.Validate();
    }

    [Fact]
    public void VoidInitiatedLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new VoidInitiatedLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = VoidInitiatedLedgerEntryEntryStatus.Committed,
                EntryType = VoidInitiatedLedgerEntryEntryType.VoidInitiated,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartingBalance = 0,
                VoidAmount = 0,
                VoidReason = "void_reason",
            }
        );
        value.Validate();
    }

    [Fact]
    public void AmendmentLedgerEntryValidationWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new AmendmentLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = AmendmentLedgerEntryEntryStatus.Committed,
                EntryType = AmendmentLedgerEntryEntryType.Amendment,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void IncrementLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new IncrementLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = IncrementLedgerEntryEntryStatus.Committed,
                EntryType = IncrementLedgerEntryEntryType.Increment,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
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
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                        HostedInvoiceUrl = "hosted_invoice_url",
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
                                        AppliesToPriceIds = ["string"],
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
                                        AppliesToPriceIds =
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
                                        AppliesToPriceIds = ["string"],
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
                                        AppliesToPriceIds = ["string"],
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
                                UsageCustomerIds = ["string"],
                            },
                        ],
                        Maximum = new()
                        {
                            AppliesToPriceIds = ["string"],
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
                            AppliesToPriceIds = ["string"],
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DecrementLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new DecrementLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = DecrementLedgerEntryEntryStatus.Committed,
                EntryType = DecrementLedgerEntryEntryType.Decrement,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
                EventID = "event_id",
                InvoiceID = "invoice_id",
                PriceID = "price_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExpirationChangeLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new ExpirationChangeLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = ExpirationChangeLedgerEntryEntryStatus.Committed,
                EntryType = ExpirationChangeLedgerEntryEntryType.ExpirationChange,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartingBalance = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditBlockExpiryLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new CreditBlockExpiryLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = CreditBlockExpiryLedgerEntryEntryStatus.Committed,
                EntryType = CreditBlockExpiryLedgerEntryEntryType.CreditBlockExpiry,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VoidLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new VoidLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = VoidLedgerEntryEntryStatus.Committed,
                EntryType = VoidLedgerEntryEntryType.Void,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
                VoidAmount = 0,
                VoidReason = "void_reason",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VoidInitiatedLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new VoidInitiatedLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = VoidInitiatedLedgerEntryEntryStatus.Committed,
                EntryType = VoidInitiatedLedgerEntryEntryType.VoidInitiated,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartingBalance = 0,
                VoidAmount = 0,
                VoidReason = "void_reason",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmendmentLedgerEntrySerializationRoundtripWorks()
    {
        LedgerCreateEntryByExternalIDResponse value = new(
            new AmendmentLedgerEntry()
            {
                ID = "id",
                Amount = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreditBlock = new()
                {
                    ID = "id",
                    ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Filters =
                    [
                        new()
                        {
                            Field = AffectedBlockFilterField.PriceID,
                            Operator = AffectedBlockFilterOperator.Includes,
                            Values = ["string"],
                        },
                    ],
                    PerUnitCostBasis = "per_unit_cost_basis",
                },
                Currency = "currency",
                Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
                Description = "description",
                EndingBalance = 0,
                EntryStatus = AmendmentLedgerEntryEntryStatus.Committed,
                EntryType = AmendmentLedgerEntryEntryType.Amendment,
                LedgerSequenceNumber = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                StartingBalance = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDResponse>(
            element
        );

        Assert.Equal(value, deserialized);
    }
}
