using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Beta;

/// <summary>
/// This API endpoint is in beta and its interface may change. It is recommended for
/// use only in test mode.
///
/// This endpoint is used to fetch a plan version. It returns the phases, prices,
/// and adjustments present on this version of the plan.
/// </summary>
public sealed record class BetaFetchPlanVersionParams : Orb::ParamsBase
{
    public required string PlanID;

    public required string Version;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/{0}/versions/{1}", this.PlanID, this.Version)
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
