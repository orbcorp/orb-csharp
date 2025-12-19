using Orb.Models.Invoices;

namespace Orb.Tests.Models.Invoices;

public class InvoiceFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceFetchParams { InvoiceID = "invoice_id" };

        string expectedInvoiceID = "invoice_id";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
    }
}
