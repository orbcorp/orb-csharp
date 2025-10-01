using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint is used to fetch an [`Invoice`](/core-concepts#invoice) given an identifier.
/// </summary>
public sealed record class InvoiceFetchParams : ParamsBase
{
    public required string InvoiceID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/invoices/{0}", this.InvoiceID)
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
