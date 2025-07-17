using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Plans;

/// <summary>
/// This endpoint is used to fetch [plan](/core-concepts#plan-and-price) details given
/// a plan identifier. It returns information about the prices included in the plan
/// and their configuration, as well as the product that the plan is attached to.
///
/// ## Serialized prices Orb supports a few different pricing models out of the box.
/// Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price schema](/core-concepts#plan-and-price).
///
/// ## Phases Orb supports plan phases, also known as contract ramps. For plans with
/// phases, the serialized prices refer to all prices across all phases.
/// </summary>
public sealed record class PlanFetchParams : Orb::ParamsBase
{
    public required string PlanID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/plans/{0}", this.PlanID)
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
