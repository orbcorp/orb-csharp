using System;
using System.Net.Http;
using Orb.Core;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows a coupon to be archived. Archived coupons can no longer
/// be redeemed, and will be hidden from lists of active coupons. Additionally, once
/// a coupon is archived, its redemption code can be reused for a different coupon.
/// </summary>
public sealed record class CouponArchiveParams : ParamsBase
{
    public required string CouponID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/coupons/{0}/archive", this.CouponID)
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
