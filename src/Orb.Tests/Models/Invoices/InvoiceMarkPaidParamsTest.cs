using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceMarkPaidParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceMarkPaidParams
        {
            InvoiceID = "invoice_id",
            PaymentReceivedDate = "2023-09-22",
            ExternalID = "external_payment_id_123",
            Notes = "notes",
        };

        string expectedInvoiceID = "invoice_id";
        string expectedPaymentReceivedDate = "2023-09-22";
        string expectedExternalID = "external_payment_id_123";
        string expectedNotes = "notes";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedPaymentReceivedDate, parameters.PaymentReceivedDate);
        Assert.Equal(expectedExternalID, parameters.ExternalID);
        Assert.Equal(expectedNotes, parameters.Notes);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceMarkPaidParams
        {
            InvoiceID = "invoice_id",
            PaymentReceivedDate = "2023-09-22",
        };

        Assert.Null(parameters.ExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_id"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvoiceMarkPaidParams
        {
            InvoiceID = "invoice_id",
            PaymentReceivedDate = "2023-09-22",

            ExternalID = null,
            Notes = null,
        };

        Assert.Null(parameters.ExternalID);
        Assert.True(parameters.RawBodyData.ContainsKey("external_id"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceMarkPaidParams parameters = new()
        {
            InvoiceID = "invoice_id",
            PaymentReceivedDate = "2023-09-22",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices/invoice_id/mark_paid"), url);
    }
}
