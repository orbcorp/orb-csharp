using System;
using System.Net.Http;
using System.Text.Json;

namespace Orb.Models.Coupons.Subscriptions;

/// <summary>
/// This endpoint returns a list of all subscriptions that have redeemed a given
/// coupon as a [paginated](/api-reference/pagination) list, ordered starting from
/// the most recently created subscription. For a full discussion of the subscription
/// resource, see [Subscription](/core-concepts#subscription).
/// </summary>
public sealed record class SubscriptionListParams : ParamsBase
{
    public required string CouponID;

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/coupons/{0}/subscriptions", this.CouponID)
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
