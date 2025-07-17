using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Events.Backfills;

/// <summary>
/// Closing a backfill makes the updated usage visible in Orb. Upon closing a backfill,
/// Orb will asynchronously reflect the updated usage in invoice amounts and usage
/// graphs. Once all of the updates are complete, the backfill's status will transition
/// to `reflected`.
/// </summary>
public sealed record class BackfillCloseParams : Orb::ParamsBase
{
    public required string BackfillID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/events/backfills/{0}/close", this.BackfillID)
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
