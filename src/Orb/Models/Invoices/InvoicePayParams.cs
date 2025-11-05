using System.Net.Http;
using Orb.Core;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint collects payment for an invoice using the customer's default payment
/// method. This action can only be taken on invoices with status "issued".
/// </summary>
public sealed record class InvoicePayParams : ParamsBase
{
    public required string InvoiceID;

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/pay", this.InvoiceID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
