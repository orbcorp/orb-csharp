using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// Reverting a backfill undoes all the effects of closing the backfill. If the backfill
/// is reflected, the status will transition to `pending_revert` while the effects
/// of the backfill are undone. Once all effects are undone, the backfill will transition
/// to `reverted`.
///
/// If a backfill is reverted before its closed, no usage will be updated as a result
/// of the backfill and it will immediately transition to `reverted`.
/// </summary>
public sealed record class BackfillRevertParams : ParamsBase
{
    public required string BackfillID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}/revert", this.BackfillID)
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
