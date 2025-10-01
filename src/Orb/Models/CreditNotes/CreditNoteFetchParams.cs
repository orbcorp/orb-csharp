using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.CreditNotes;

/// <summary>
/// This endpoint is used to fetch a single [`Credit Note`](/invoicing/credit-notes)
/// given an identifier.
/// </summary>
public sealed record class CreditNoteFetchParams : ParamsBase
{
    public required string CreditNoteID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/credit_notes/{0}", this.CreditNoteID)
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
