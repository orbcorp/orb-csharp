using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceListSummaryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponse
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
        };

        string expectedID = "id";
        string expectedAmountDue = "8.00";
        InvoiceListSummaryResponseAutoCollection expectedAutoCollection = new()
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Address expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        List<InvoiceListSummaryResponseCreditNote> expectedCreditNotes =
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
        ];
        string expectedCurrency = "USD";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        List<InvoiceListSummaryResponseCustomerBalanceTransaction> expectedCustomerBalanceTransactions =
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
        ];
        CustomerTaxID expectedCustomerTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00");
        DateTimeOffset expectedEligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedInvoiceUrl = "hosted_invoice_url";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00");
        string expectedInvoiceNumber = "JYEFHK-00001";
        string expectedInvoicePdf =
            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        ApiEnum<string, InvoiceListSummaryResponseInvoiceSource> expectedInvoiceSource =
            InvoiceListSummaryResponseInvoiceSource.Subscription;
        DateTimeOffset expectedIssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemo = "memo";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedPaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<InvoiceListSummaryResponsePaymentAttempt> expectedPaymentAttempts =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
                PaymentProviderID = "payment_provider_id",
                ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                Succeeded = true,
            },
        ];
        DateTimeOffset expectedPaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Address expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<string, InvoiceListSummaryResponseStatus> expectedStatus =
            InvoiceListSummaryResponseStatus.Issued;
        SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");
        DateTimeOffset expectedSyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTotal = "8.00";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedWillAutoIssue = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmountDue, model.AmountDue);
        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNotes.Count, model.CreditNotes.Count);
        for (int i = 0; i < expectedCreditNotes.Count; i++)
        {
            Assert.Equal(expectedCreditNotes[i], model.CreditNotes[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(
            expectedCustomerBalanceTransactions.Count,
            model.CustomerBalanceTransactions.Count
        );
        for (int i = 0; i < expectedCustomerBalanceTransactions.Count; i++)
        {
            Assert.Equal(
                expectedCustomerBalanceTransactions[i],
                model.CustomerBalanceTransactions[i]
            );
        }
        Assert.Equal(expectedCustomerTaxID, model.CustomerTaxID);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedEligibleToIssueAt, model.EligibleToIssueAt);
        Assert.Equal(expectedHostedInvoiceUrl, model.HostedInvoiceUrl);
        Assert.Equal(expectedInvoiceDate, model.InvoiceDate);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedInvoicePdf, model.InvoicePdf);
        Assert.Equal(expectedInvoiceSource, model.InvoiceSource);
        Assert.Equal(expectedIssueFailedAt, model.IssueFailedAt);
        Assert.Equal(expectedIssuedAt, model.IssuedAt);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaidAt, model.PaidAt);
        Assert.Equal(expectedPaymentAttempts.Count, model.PaymentAttempts.Count);
        for (int i = 0; i < expectedPaymentAttempts.Count; i++)
        {
            Assert.Equal(expectedPaymentAttempts[i], model.PaymentAttempts[i]);
        }
        Assert.Equal(expectedPaymentFailedAt, model.PaymentFailedAt);
        Assert.Equal(expectedPaymentStartedAt, model.PaymentStartedAt);
        Assert.Equal(expectedScheduledIssueAt, model.ScheduledIssueAt);
        Assert.Equal(expectedShippingAddress, model.ShippingAddress);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedSyncFailedAt, model.SyncFailedAt);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
        Assert.Equal(expectedWillAutoIssue, model.WillAutoIssue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmountDue = "8.00";
        InvoiceListSummaryResponseAutoCollection expectedAutoCollection = new()
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Address expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        List<InvoiceListSummaryResponseCreditNote> expectedCreditNotes =
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
        ];
        string expectedCurrency = "USD";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        List<InvoiceListSummaryResponseCustomerBalanceTransaction> expectedCustomerBalanceTransactions =
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
        ];
        CustomerTaxID expectedCustomerTaxID = new()
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00");
        DateTimeOffset expectedEligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedInvoiceUrl = "hosted_invoice_url";
        DateTimeOffset expectedInvoiceDate = DateTimeOffset.Parse("2022-05-01T07:00:00+00:00");
        string expectedInvoiceNumber = "JYEFHK-00001";
        string expectedInvoicePdf =
            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        ApiEnum<string, InvoiceListSummaryResponseInvoiceSource> expectedInvoiceSource =
            InvoiceListSummaryResponseInvoiceSource.Subscription;
        DateTimeOffset expectedIssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMemo = "memo";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedPaidAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<InvoiceListSummaryResponsePaymentAttempt> expectedPaymentAttempts =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
                PaymentProviderID = "payment_provider_id",
                ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
                Succeeded = true,
            },
        ];
        DateTimeOffset expectedPaymentFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPaymentStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedScheduledIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Address expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<string, InvoiceListSummaryResponseStatus> expectedStatus =
            InvoiceListSummaryResponseStatus.Issued;
        SubscriptionMinified expectedSubscription = new("VDGsT23osdLb84KD");
        DateTimeOffset expectedSyncFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTotal = "8.00";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedWillAutoIssue = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmountDue, deserialized.AmountDue);
        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNotes.Count, deserialized.CreditNotes.Count);
        for (int i = 0; i < expectedCreditNotes.Count; i++)
        {
            Assert.Equal(expectedCreditNotes[i], deserialized.CreditNotes[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(
            expectedCustomerBalanceTransactions.Count,
            deserialized.CustomerBalanceTransactions.Count
        );
        for (int i = 0; i < expectedCustomerBalanceTransactions.Count; i++)
        {
            Assert.Equal(
                expectedCustomerBalanceTransactions[i],
                deserialized.CustomerBalanceTransactions[i]
            );
        }
        Assert.Equal(expectedCustomerTaxID, deserialized.CustomerTaxID);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedEligibleToIssueAt, deserialized.EligibleToIssueAt);
        Assert.Equal(expectedHostedInvoiceUrl, deserialized.HostedInvoiceUrl);
        Assert.Equal(expectedInvoiceDate, deserialized.InvoiceDate);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedInvoicePdf, deserialized.InvoicePdf);
        Assert.Equal(expectedInvoiceSource, deserialized.InvoiceSource);
        Assert.Equal(expectedIssueFailedAt, deserialized.IssueFailedAt);
        Assert.Equal(expectedIssuedAt, deserialized.IssuedAt);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaidAt, deserialized.PaidAt);
        Assert.Equal(expectedPaymentAttempts.Count, deserialized.PaymentAttempts.Count);
        for (int i = 0; i < expectedPaymentAttempts.Count; i++)
        {
            Assert.Equal(expectedPaymentAttempts[i], deserialized.PaymentAttempts[i]);
        }
        Assert.Equal(expectedPaymentFailedAt, deserialized.PaymentFailedAt);
        Assert.Equal(expectedPaymentStartedAt, deserialized.PaymentStartedAt);
        Assert.Equal(expectedScheduledIssueAt, deserialized.ScheduledIssueAt);
        Assert.Equal(expectedShippingAddress, deserialized.ShippingAddress);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedSyncFailedAt, deserialized.SyncFailedAt);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
        Assert.Equal(expectedWillAutoIssue, deserialized.WillAutoIssue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListSummaryResponse
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
        };

        model.Validate();
    }
}

public class InvoiceListSummaryResponseAutoCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseAutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedEnabled = true;
        DateTimeOffset expectedNextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedNumAttempts = 0;
        DateTimeOffset expectedPreviouslyAttemptedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedNextAttemptAt, model.NextAttemptAt);
        Assert.Equal(expectedNumAttempts, model.NumAttempts);
        Assert.Equal(expectedPreviouslyAttemptedAt, model.PreviouslyAttemptedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseAutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponseAutoCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryResponseAutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponseAutoCollection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        DateTimeOffset expectedNextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedNumAttempts = 0;
        DateTimeOffset expectedPreviouslyAttemptedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedNextAttemptAt, deserialized.NextAttemptAt);
        Assert.Equal(expectedNumAttempts, deserialized.NumAttempts);
        Assert.Equal(expectedPreviouslyAttemptedAt, deserialized.PreviouslyAttemptedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListSummaryResponseAutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class InvoiceListSummaryResponseCreditNoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseCreditNote
        {
            ID = "id",
            CreditNoteNumber = "credit_note_number",
            Memo = "memo",
            Reason = "reason",
            Total = "total",
            Type = "type",
            VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
        };

        string expectedID = "id";
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedMemo = "memo";
        string expectedReason = "reason";
        string expectedTotal = "total";
        string expectedType = "type";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreditNoteNumber, model.CreditNoteNumber);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseCreditNote
        {
            ID = "id",
            CreditNoteNumber = "credit_note_number",
            Memo = "memo",
            Reason = "reason",
            Total = "total",
            Type = "type",
            VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponseCreditNote>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryResponseCreditNote
        {
            ID = "id",
            CreditNoteNumber = "credit_note_number",
            Memo = "memo",
            Reason = "reason",
            Total = "total",
            Type = "type",
            VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponseCreditNote>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedMemo = "memo";
        string expectedReason = "reason";
        string expectedTotal = "total";
        string expectedType = "type";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreditNoteNumber, deserialized.CreditNoteNumber);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListSummaryResponseCreditNote
        {
            ID = "id",
            CreditNoteNumber = "credit_note_number",
            Memo = "memo",
            Reason = "reason",
            Total = "total",
            Type = "type",
            VoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
        };

        model.Validate();
    }
}

public class InvoiceListSummaryResponseCustomerBalanceTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseCustomerBalanceTransaction
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction> expectedAction =
            InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType> expectedType =
            InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNote, model.CreditNote);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedInvoice, model.Invoice);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponseCustomerBalanceTransaction
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InvoiceListSummaryResponseCustomerBalanceTransaction>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryResponseCustomerBalanceTransaction
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InvoiceListSummaryResponseCustomerBalanceTransaction>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction> expectedAction =
            InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType> expectedType =
            InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNote, deserialized.CreditNote);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndingBalance, deserialized.EndingBalance);
        Assert.Equal(expectedInvoice, deserialized.Invoice);
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListSummaryResponseCustomerBalanceTransaction
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
        };

        model.Validate();
    }
}

public class InvoiceListSummaryResponseCustomerBalanceTransactionActionTest : TestBase
{
    [Theory]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ProratedRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ExternalPayment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover)]
    public void Validation_Works(
        InvoiceListSummaryResponseCustomerBalanceTransactionAction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ProratedRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.ExternalPayment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover)]
    public void SerializationRoundtrip_Works(
        InvoiceListSummaryResponseCustomerBalanceTransactionAction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceListSummaryResponseCustomerBalanceTransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionType.Decrement)]
    public void Validation_Works(InvoiceListSummaryResponseCustomerBalanceTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment)]
    [InlineData(InvoiceListSummaryResponseCustomerBalanceTransactionType.Decrement)]
    public void SerializationRoundtrip_Works(
        InvoiceListSummaryResponseCustomerBalanceTransactionType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceListSummaryResponseInvoiceSourceTest : TestBase
{
    [Theory]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.Subscription)]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.Partial)]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.OneOff)]
    public void Validation_Works(InvoiceListSummaryResponseInvoiceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseInvoiceSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseInvoiceSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.Subscription)]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.Partial)]
    [InlineData(InvoiceListSummaryResponseInvoiceSource.OneOff)]
    public void SerializationRoundtrip_Works(InvoiceListSummaryResponseInvoiceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseInvoiceSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseInvoiceSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseInvoiceSource>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseInvoiceSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceListSummaryResponsePaymentAttemptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponsePaymentAttempt
        {
            ID = "id",
            Amount = "amount",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            PaymentProviderID = "payment_provider_id",
            ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            Succeeded = true,
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            InvoiceListSummaryResponsePaymentAttemptPaymentProvider
        > expectedPaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedReceiptPdf =
            "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        bool expectedSucceeded = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPaymentProvider, model.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, model.PaymentProviderID);
        Assert.Equal(expectedReceiptPdf, model.ReceiptPdf);
        Assert.Equal(expectedSucceeded, model.Succeeded);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceListSummaryResponsePaymentAttempt
        {
            ID = "id",
            Amount = "amount",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            PaymentProviderID = "payment_provider_id",
            ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            Succeeded = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponsePaymentAttempt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceListSummaryResponsePaymentAttempt
        {
            ID = "id",
            Amount = "amount",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            PaymentProviderID = "payment_provider_id",
            ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            Succeeded = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceListSummaryResponsePaymentAttempt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<
            string,
            InvoiceListSummaryResponsePaymentAttemptPaymentProvider
        > expectedPaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedReceiptPdf =
            "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        bool expectedSucceeded = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, deserialized.PaymentProviderID);
        Assert.Equal(expectedReceiptPdf, deserialized.ReceiptPdf);
        Assert.Equal(expectedSucceeded, deserialized.Succeeded);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceListSummaryResponsePaymentAttempt
        {
            ID = "id",
            Amount = "amount",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PaymentProvider = InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            PaymentProviderID = "payment_provider_id",
            ReceiptPdf = "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb",
            Succeeded = true,
        };

        model.Validate();
    }
}

public class InvoiceListSummaryResponsePaymentAttemptPaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe)]
    public void Validation_Works(InvoiceListSummaryResponsePaymentAttemptPaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe)]
    public void SerializationRoundtrip_Works(
        InvoiceListSummaryResponsePaymentAttemptPaymentProvider rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceListSummaryResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(InvoiceListSummaryResponseStatus.Issued)]
    [InlineData(InvoiceListSummaryResponseStatus.Paid)]
    [InlineData(InvoiceListSummaryResponseStatus.Synced)]
    [InlineData(InvoiceListSummaryResponseStatus.Void)]
    [InlineData(InvoiceListSummaryResponseStatus.Draft)]
    public void Validation_Works(InvoiceListSummaryResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceListSummaryResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceListSummaryResponseStatus.Issued)]
    [InlineData(InvoiceListSummaryResponseStatus.Paid)]
    [InlineData(InvoiceListSummaryResponseStatus.Synced)]
    [InlineData(InvoiceListSummaryResponseStatus.Void)]
    [InlineData(InvoiceListSummaryResponseStatus.Draft)]
    public void SerializationRoundtrip_Works(InvoiceListSummaryResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceListSummaryResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceListSummaryResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InvoiceListSummaryResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
