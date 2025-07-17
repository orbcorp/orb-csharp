using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.CreditNotes;

/// <summary>
/// This endpoint is used to fetch a single [`Credit Note`](/invoicing/credit-notes)
/// given an identifier.
/// </summary>
public sealed record class CreditNoteFetchParams : Orb::ParamsBase
{
    public required string CreditNoteID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/credit_notes/{0}", this.CreditNoteID)
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
