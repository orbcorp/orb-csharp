using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceListSummaryPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryPageResponse
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
                            Action =
                                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type =
                                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                    IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memo = "memo",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentAttempts =
                    [
                        new()
                        {
                            ID = "id",
                            Amount = "amount",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentProvider =
                                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceListSummaryResponseStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<InvoiceListSummaryResponse> expectedData =
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
                        Action =
                            InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                        Amount = "11.00",
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNote = new("id"),
                        Description = "An optional description",
                        EndingBalance = "22.00",
                        Invoice = new("gXcsPTVyC4YZa3Sc"),
                        StartingBalance = "33.00",
                        Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                    },
                ],
                CustomerTaxID = new()
                {
                    Country = Country.Ad,
                    Type = CustomerTaxIDType.AdNrt,
                    Value = "value",
                },
                DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedInvoiceUrl = "hosted_invoice_url",
                InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                InvoiceNumber = "JYEFHK-00001",
                InvoicePdf = "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memo = "memo",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentAttempts =
                [
                    new()
                    {
                        ID = "id",
                        Amount = "amount",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentProvider =
                            InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                Status = InvoiceListSummaryResponseStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
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
        var model = new InvoiceListSummaryPageResponse
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
                            Action =
                                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type =
                                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                    IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memo = "memo",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentAttempts =
                    [
                        new()
                        {
                            ID = "id",
                            Amount = "amount",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentProvider =
                                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceListSummaryResponseStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryPageResponse
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
                            Action =
                                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type =
                                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                    IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memo = "memo",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentAttempts =
                    [
                        new()
                        {
                            ID = "id",
                            Amount = "amount",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentProvider =
                                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceListSummaryResponseStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<InvoiceListSummaryResponse> expectedData =
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
                        Action =
                            InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                        Amount = "11.00",
                        CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                        CreditNote = new("id"),
                        Description = "An optional description",
                        EndingBalance = "22.00",
                        Invoice = new("gXcsPTVyC4YZa3Sc"),
                        StartingBalance = "33.00",
                        Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                    },
                ],
                CustomerTaxID = new()
                {
                    Country = Country.Ad,
                    Type = CustomerTaxIDType.AdNrt,
                    Value = "value",
                },
                DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HostedInvoiceUrl = "hosted_invoice_url",
                InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                InvoiceNumber = "JYEFHK-00001",
                InvoicePdf = "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Memo = "memo",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentAttempts =
                [
                    new()
                    {
                        ID = "id",
                        Amount = "amount",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PaymentProvider =
                            InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                Status = InvoiceListSummaryResponseStatus.Issued,
                Subscription = new("VDGsT23osdLb84KD"),
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
        var model = new InvoiceListSummaryPageResponse
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
                            Action =
                                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type =
                                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                    IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memo = "memo",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentAttempts =
                    [
                        new()
                        {
                            ID = "id",
                            Amount = "amount",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentProvider =
                                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceListSummaryResponseStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceListSummaryPageResponse
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
                            Action =
                                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
                            Amount = "11.00",
                            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                            CreditNote = new("id"),
                            Description = "An optional description",
                            EndingBalance = "22.00",
                            Invoice = new("gXcsPTVyC4YZa3Sc"),
                            StartingBalance = "33.00",
                            Type =
                                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
                        },
                    ],
                    CustomerTaxID = new()
                    {
                        Country = Country.Ad,
                        Type = CustomerTaxIDType.AdNrt,
                        Value = "value",
                    },
                    DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
                    EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HostedInvoiceUrl = "hosted_invoice_url",
                    InvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00"),
                    InvoiceNumber = "JYEFHK-00001",
                    InvoicePdf =
                        "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                    InvoiceSource = InvoiceListSummaryResponseInvoiceSource.Subscription,
                    IssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Memo = "memo",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PaymentAttempts =
                    [
                        new()
                        {
                            ID = "id",
                            Amount = "amount",
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PaymentProvider =
                                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
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
                    Status = InvoiceListSummaryResponseStatus.Issued,
                    Subscription = new("VDGsT23osdLb84KD"),
                    SyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Total = "8.00",
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WillAutoIssue = true,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        InvoiceListSummaryPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
