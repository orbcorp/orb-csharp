using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint is used to fetch an [`Invoice`](/core-concepts#invoice) given an identifier.
/// </summary>
public sealed record class InvoiceFetchParams : Orb::ParamsBase
{
    public required string InvoiceID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/invoices/{0}", this.InvoiceID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
