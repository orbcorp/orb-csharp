using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending cancellations for a subscription.
///
/// To be eligible, the subscription must currently be active and have a future cancellation.
/// This operation will turn on auto-renew, ensuring that the subscription does not
/// end at the currently scheduled cancellation time.
/// </summary>
public sealed record class SubscriptionUnscheduleCancellationParams : ParamsBase
{
    public required string SubscriptionID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/unschedule_cancellation", this.SubscriptionID)
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
