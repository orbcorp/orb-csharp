using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// Cancel a subscription change. The change can no longer be applied. A subscription
/// can only have one "pending" change at a time - use this endpoint to cancel an
/// existing change before creating a new one.
/// </summary>
public sealed record class SubscriptionChangeCancelParams : Orb::ParamsBase
{
    public required string SubscriptionChangeID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}/cancel", this.SubscriptionChangeID)
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
