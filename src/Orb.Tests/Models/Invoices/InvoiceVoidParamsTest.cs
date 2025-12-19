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
}
