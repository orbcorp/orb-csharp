using Http = System.Net.Http;
using Orb = Orb;
using System = System;

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
public sealed record class BackfillRevertParams : Orb::ParamsBase
{
    public required string BackfillID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}/revert", this.BackfillID)
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
