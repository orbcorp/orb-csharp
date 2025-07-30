using System.Net.Http;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an invoice's status to be set the `void` status. This can
/// only be done to invoices that are in the `issued` status.
///
/// If the associated invoice has used the customer balance to change the amount
/// due, the customer balance operation will be reverted. For example, if the invoice
/// used \$10 of customer balance, that amount will be added back to the customer
/// balance upon voiding.
///
/// If the invoice was used to purchase a credit block, but the invoice is not yet
/// paid, the credit block will be voided. If the invoice was created due to a top-up,
/// the top-up will be disabled.
/// </summary>
public sealed record class InvoiceVoidParams : ParamsBase
{
    public required string InvoiceID;

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/void", this.InvoiceID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
