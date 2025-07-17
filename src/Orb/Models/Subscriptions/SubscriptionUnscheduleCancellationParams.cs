using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to unschedule any pending cancellations for a subscription.
///
/// To be eligible, the subscription must currently be active and have a future cancellation.
/// This operation will turn on auto-renew, ensuring that the subscription does not
/// end at the currently scheduled cancellation time.
/// </summary>
public sealed record class SubscriptionUnscheduleCancellationParams : Orb::ParamsBase
{
    public required string SubscriptionID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/unschedule_cancellation", this.SubscriptionID)
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
