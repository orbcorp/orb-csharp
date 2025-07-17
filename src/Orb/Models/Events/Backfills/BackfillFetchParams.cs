using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// This endpoint is used to fetch a backfill given an identifier.
/// </summary>
public sealed record class BackfillFetchParams : Orb::ParamsBase
{
    public required string BackfillID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}", this.BackfillID)
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
