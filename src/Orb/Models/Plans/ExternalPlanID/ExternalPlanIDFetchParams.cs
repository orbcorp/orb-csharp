using System;
using System.Net.Http;

namespace Orb.Models.Plans.ExternalPlanID;

/// <summary>
/// This endpoint is used to fetch [plan](/core-concepts##plan-and-price) details
/// given an external_plan_id identifier. It returns information about the prices
/// included in the plan and their configuration, as well as the product that the
/// plan is attached to.
///
/// If multiple plans are found to contain the specified external_plan_id, the active
/// plans will take priority over archived ones, and among those, the endpoint will
/// return the most recently created plan.
///
/// ## Serialized prices Orb supports a few different pricing models out of the box.
/// Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
/// object. The `model_type` field determines the key for the configuration object
/// that is present. A detailed explanation of price types can be found in the [Price
/// schema](/core-concepts#plan-and-price). "
/// </summary>
public sealed record class ExternalPlanIDFetchParams : ParamsBase
{
    public required string ExternalPlanID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/external_plan_id/{0}", this.ExternalPlanID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
