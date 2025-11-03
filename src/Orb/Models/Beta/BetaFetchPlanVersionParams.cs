using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Beta;

/// <summary>
/// This endpoint is used to fetch a plan version. It returns the phases, prices,
/// and adjustments present on this version of the plan.
/// </summary>
public sealed record class BetaFetchPlanVersionParams : ParamsBase
{
    public required string PlanID;

    public required string Version;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/{0}/versions/{1}", this.PlanID, this.Version)
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
