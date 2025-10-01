using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// This endpoint is used to fetch a backfill given an identifier.
/// </summary>
public sealed record class BackfillFetchParams : ParamsBase
{
    public required string BackfillID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}", this.BackfillID)
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
