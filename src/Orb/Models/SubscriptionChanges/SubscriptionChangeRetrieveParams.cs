using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// This endpoint returns a subscription change given an identifier.
///
/// A subscription change is created by including `Create-Pending-Subscription-Change:
/// True` in the header of a subscription mutation API call (e.g. [create subscription
/// endpoint](/api-reference/subscription/create-subscription), [schedule plan change
/// endpoint](/api-reference/subscription/schedule-plan-change), ...). The subscription
/// change will be referenced by the `pending_subscription_change` field in the response.
/// </summary>
public sealed record class SubscriptionChangeRetrieveParams : Orb::ParamsBase
{
    public required string SubscriptionChangeID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}", this.SubscriptionChangeID)
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
