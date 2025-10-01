using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// Closing a backfill makes the updated usage visible in Orb. Upon closing a backfill,
/// Orb will asynchronously reflect the updated usage in invoice amounts and usage
/// graphs. Once all of the updates are complete, the backfill's status will transition
/// to `reflected`.
/// </summary>
public sealed record class BackfillCloseParams : ParamsBase
{
    public required string BackfillID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}/close", this.BackfillID)
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
