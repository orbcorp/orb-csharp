using System;
using System.Net.Http;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to fetch a [Subscription](/core-concepts##subscription)
/// given an identifier.
/// </summary>
public sealed record class SubscriptionFetchParams : ParamsBase
{
    public required string SubscriptionID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}", this.SubscriptionID)
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
