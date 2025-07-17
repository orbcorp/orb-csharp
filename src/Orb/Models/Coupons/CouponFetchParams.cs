using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Coupons;

/// <summary>
/// This endpoint retrieves a coupon by its ID. To fetch coupons by their redemption
/// code, use the [List coupons](list-coupons) endpoint with the redemption_code parameter.
/// </summary>
public sealed record class CouponFetchParams : Orb::ParamsBase
{
    public required string CouponID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/coupons/{0}", this.CouponID)
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
