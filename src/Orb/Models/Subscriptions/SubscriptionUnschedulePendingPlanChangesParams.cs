using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending plan changes on an existing
/// subscription. When called, all upcoming plan changes will be unscheduled.
/// </summary>
public sealed record class SubscriptionUnschedulePendingPlanChangesParams : Orb::ParamsBase
{
    public required string SubscriptionID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/subscriptions/{0}/unschedule_pending_plan_changes",
                    this.SubscriptionID
                )
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
