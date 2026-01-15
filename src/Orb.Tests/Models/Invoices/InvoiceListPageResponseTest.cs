using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Data =
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
                        PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type = InvoiceCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Discounts =
                    [
                        new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    ],
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                                new MonetaryUsageDiscountAdjustment()
                                {
                                    ID = "id",
                                    AdjustmentType =
                                        MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                    Amount = "amount",
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field =
                                                MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                            Operator =
                                                MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                    AppliesToPriceIds = ["string"],
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
                                    AppliesToPriceIds = ["string"],
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
                            Quantity = 1,
                            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                            SubLineItems =
                            [
                                new MatrixSubLineItem()
                                {
                                    Amount = "9.00",
                                    Grouping = new() { Key = "region", Value = "west" },
                                    MatrixConfig = new(["string"]),
                                    Name = "Tier One",
                                    Quantity = 5,
                                    Type = MatrixSubLineItemType.Matrix,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                            PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    Subtotal = "8.00",
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Invoice> expectedData =
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
                    PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                        Amount = "11.00",
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNote = new("id"),
                        Description = "An optional description",
                        EndingBalance = "22.00",
                        Invoice = new("gXcsPTVyC4YZa3Sc"),
                        StartingBalance = "33.00",
                        Type = InvoiceCustomerBalanceTransactionType.Increment,
                    },
                ],
                CustomerTaxID = new()
                {
                    Country = Country.Ad,
                    Type = CustomerTaxIDType.AdNrt,
                    Value = "value",
                },
                Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                Discounts =
                [
                    new PercentageDiscount()
                    {
                        DiscountType = PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                ],
                DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedInvoiceUrl = "hosted_invoice_url",
                InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                InvoiceNumber = "JYEFHK-00001",
                InvoicePdf = "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                            new MonetaryUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                Amount = "amount",
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                        Operator =
                                            MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                AppliesToPriceIds = ["string"],
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
                                AppliesToPriceIds = ["string"],
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
                        Quantity = 1,
                        StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                        SubLineItems =
                        [
                            new MatrixSubLineItem()
                            {
                                Amount = "9.00",
                                Grouping = new() { Key = "region", Value = "west" },
                                MatrixConfig = new(["string"]),
                                Name = "Tier One",
                                Quantity = 5,
                                Type = MatrixSubLineItemType.Matrix,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                        PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                Status = InvoiceStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
                Subtotal = "8.00",
                SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Total = "8.00",
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WillAutoIssue = true,
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
        var model = new InvoiceListPageResponse
        {
            Data =
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
                        PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type = InvoiceCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Discounts =
                    [
                        new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    ],
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                                new MonetaryUsageDiscountAdjustment()
                                {
                                    ID = "id",
                                    AdjustmentType =
                                        MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                    Amount = "amount",
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field =
                                                MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                            Operator =
                                                MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                    AppliesToPriceIds = ["string"],
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
                                    AppliesToPriceIds = ["string"],
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
                            Quantity = 1,
                            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                            SubLineItems =
                            [
                                new MatrixSubLineItem()
                                {
                                    Amount = "9.00",
                                    Grouping = new() { Key = "region", Value = "west" },
                                    MatrixConfig = new(["string"]),
                                    Name = "Tier One",
                                    Quantity = 5,
                                    Type = MatrixSubLineItemType.Matrix,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                            PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    Subtotal = "8.00",
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListPageResponse
        {
            Data =
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
                        PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type = InvoiceCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Discounts =
                    [
                        new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    ],
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                                new MonetaryUsageDiscountAdjustment()
                                {
                                    ID = "id",
                                    AdjustmentType =
                                        MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                    Amount = "amount",
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field =
                                                MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                            Operator =
                                                MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                    AppliesToPriceIds = ["string"],
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
                                    AppliesToPriceIds = ["string"],
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
                            Quantity = 1,
                            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                            SubLineItems =
                            [
                                new MatrixSubLineItem()
                                {
                                    Amount = "9.00",
                                    Grouping = new() { Key = "region", Value = "west" },
                                    MatrixConfig = new(["string"]),
                                    Name = "Tier One",
                                    Quantity = 5,
                                    Type = MatrixSubLineItemType.Matrix,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                            PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    Subtotal = "8.00",
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Invoice> expectedData =
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
                    PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                        Amount = "11.00",
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNote = new("id"),
                        Description = "An optional description",
                        EndingBalance = "22.00",
                        Invoice = new("gXcsPTVyC4YZa3Sc"),
                        StartingBalance = "33.00",
                        Type = InvoiceCustomerBalanceTransactionType.Increment,
                    },
                ],
                CustomerTaxID = new()
                {
                    Country = Country.Ad,
                    Type = CustomerTaxIDType.AdNrt,
                    Value = "value",
                },
                Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                Discounts =
                [
                    new PercentageDiscount()
                    {
                        DiscountType = PercentageDiscountDiscountType.Percentage,
                        PercentageDiscountValue = 0.15,
                        AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                ],
                DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedInvoiceUrl = "hosted_invoice_url",
                InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                InvoiceNumber = "JYEFHK-00001",
                InvoicePdf = "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                            new MonetaryUsageDiscountAdjustment()
                            {
                                ID = "id",
                                AdjustmentType =
                                    MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                Amount = "amount",
                                AppliesToPriceIds = ["string"],
                                Filters =
                                [
                                    new()
                                    {
                                        Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                        Operator =
                                            MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                AppliesToPriceIds = ["string"],
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
                                AppliesToPriceIds = ["string"],
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
                        Quantity = 1,
                        StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                        SubLineItems =
                        [
                            new MatrixSubLineItem()
                            {
                                Amount = "9.00",
                                Grouping = new() { Key = "region", Value = "west" },
                                MatrixConfig = new(["string"]),
                                Name = "Tier One",
                                Quantity = 5,
                                Type = MatrixSubLineItemType.Matrix,
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
                            Field = MaximumFilterField.PriceID,
                            Operator = MaximumFilterOperator.Includes,
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
                            Field = MinimumFilterField.PriceID,
                            Operator = MinimumFilterOperator.Includes,
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
                        PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                Status = InvoiceStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
                Subtotal = "8.00",
                SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Total = "8.00",
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WillAutoIssue = true,
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
        var model = new InvoiceListPageResponse
        {
            Data =
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
                        PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Action = InvoiceCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type = InvoiceCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    Discount = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Discounts =
                    [
                        new PercentageDiscount()
                        {
                            DiscountType = PercentageDiscountDiscountType.Percentage,
                            PercentageDiscountValue = 0.15,
                            AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                    ],
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceInvoiceSource.Subscription,
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
                                new MonetaryUsageDiscountAdjustment()
                                {
                                    ID = "id",
                                    AdjustmentType =
                                        MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                                    Amount = "amount",
                                    AppliesToPriceIds = ["string"],
                                    Filters =
                                    [
                                        new()
                                        {
                                            Field =
                                                MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                            Operator =
                                                MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                                    AppliesToPriceIds = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
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
                                    AppliesToPriceIds = ["string"],
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
                                    AppliesToPriceIds = ["string"],
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
                            Quantity = 1,
                            StartDate = DateTimeOffset.Parse("2022-02-01T08:00:00+00:00"),
                            SubLineItems =
                            [
                                new MatrixSubLineItem()
                                {
                                    Amount = "9.00",
                                    Grouping = new() { Key = "region", Value = "west" },
                                    MatrixConfig = new(["string"]),
                                    Name = "Tier One",
                                    Quantity = 5,
                                    Type = MatrixSubLineItemType.Matrix,
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
                                Field = MaximumFilterField.PriceID,
                                Operator = MaximumFilterOperator.Includes,
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
                                Field = MinimumFilterField.PriceID,
                                Operator = MinimumFilterOperator.Includes,
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
                            PaymentProvider = InvoicePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    Subtotal = "8.00",
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
