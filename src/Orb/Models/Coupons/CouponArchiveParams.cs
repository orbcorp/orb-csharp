using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint allows a coupon to be archived. Archived coupons can no longer
/// be redeemed, and will be hidden from lists of active coupons. Additionally, once
/// a coupon is archived, its redemption code can be reused for a different coupon.
/// </summary>
public sealed record class CouponArchiveParams : Orb::ParamsBase
{
    public required string CouponID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/coupons/{0}/archive", this.CouponID)
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
