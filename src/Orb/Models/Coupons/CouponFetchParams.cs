using System;
using System.Net.Http;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint retrieves a coupon by its ID. To fetch coupons by their redemption
/// code, use the [List coupons](list-coupons) endpoint with the redemption_code parameter.
/// </summary>
public sealed record class CouponFetchParams : ParamsBase
{
    public required string CouponID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/coupons/{0}", this.CouponID)
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
