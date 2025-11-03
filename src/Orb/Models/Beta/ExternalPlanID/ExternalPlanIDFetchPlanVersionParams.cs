using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Beta.ExternalPlanID;

/// <summary>
/// This endpoint is used to fetch a plan version. It returns the phases, prices,
/// and adjustments present on this version of the plan.
/// </summary>
public sealed record class ExternalPlanIDFetchPlanVersionParams : ParamsBase
{
    public required string ExternalPlanID;

    public required string Version;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/plans/external_plan_id/{0}/versions/{1}",
                    this.ExternalPlanID,
                    this.Version
                )
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
