using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceVoidParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceVoidParams { InvoiceID = "invoice_id" };

        string expectedInvoiceID = "invoice_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceVoidParams parameters = new() { InvoiceID = "invoice_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices/invoice_id/void"), url);
    }
}
