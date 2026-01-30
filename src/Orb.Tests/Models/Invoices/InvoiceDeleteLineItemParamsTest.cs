using System;
using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceDeleteLineItemParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceDeleteLineItemParams
        {
            InvoiceID = "invoice_id",
            LineItemID = "line_item_id",
        };

        string expectedInvoiceID = "invoice_id";
        string expectedLineItemID = "line_item_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedLineItemID, parameters.LineItemID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceDeleteLineItemParams parameters = new()
        {
            InvoiceID = "invoice_id",
            LineItemID = "line_item_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/invoices/invoice_id/invoice_line_items/line_item_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceDeleteLineItemParams
        {
            InvoiceID = "invoice_id",
            LineItemID = "line_item_id",
        };

        InvoiceDeleteLineItemParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
