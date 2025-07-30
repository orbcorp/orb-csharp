using System.Net.Http;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending plan changes on an existing
/// subscription. When called, all upcoming plan changes will be unscheduled.
/// </summary>
public sealed record class SubscriptionUnschedulePendingPlanChangesParams : ParamsBase
{
    public required string SubscriptionID;

    public override System::Uri Url(IOrbClient client)
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

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
