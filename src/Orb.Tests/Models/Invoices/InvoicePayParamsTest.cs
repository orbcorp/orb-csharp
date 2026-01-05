using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoicePayParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoicePayParams { InvoiceID = "invoice_id" };

        string expectedInvoiceID = "invoice_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoicePayParams parameters = new() { InvoiceID = "invoice_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices/invoice_id/pay"), url);
    }
}
