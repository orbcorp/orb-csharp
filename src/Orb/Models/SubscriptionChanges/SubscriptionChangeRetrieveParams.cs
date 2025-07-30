using System;
using System.Net.Http;

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
public sealed record class SubscriptionChangeRetrieveParams : ParamsBase
{
    public required string SubscriptionChangeID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}", this.SubscriptionChangeID)
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
