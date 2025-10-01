using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// Cancel a subscription change. The change can no longer be applied. A subscription
/// can only have one "pending" change at a time - use this endpoint to cancel an
/// existing change before creating a new one.
/// </summary>
public sealed record class SubscriptionChangeCancelParams : ParamsBase
{
    public required string SubscriptionChangeID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscription_changes/{0}/cancel", this.SubscriptionChangeID)
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
