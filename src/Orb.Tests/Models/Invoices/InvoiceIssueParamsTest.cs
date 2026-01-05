using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceIssueParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceIssueParams { InvoiceID = "invoice_id", Synchronous = true };

        string expectedInvoiceID = "invoice_id";
        bool expectedSynchronous = true;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedSynchronous, parameters.Synchronous);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceIssueParams { InvoiceID = "invoice_id" };

        Assert.Null(parameters.Synchronous);
        Assert.False(parameters.RawBodyData.ContainsKey("synchronous"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceIssueParams
        {
            InvoiceID = "invoice_id",

            // Null should be interpreted as omitted for these properties
            Synchronous = null,
        };

        Assert.Null(parameters.Synchronous);
        Assert.False(parameters.RawBodyData.ContainsKey("synchronous"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceIssueParams parameters = new() { InvoiceID = "invoice_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/invoices/invoice_id/issue"), url);
    }
}
