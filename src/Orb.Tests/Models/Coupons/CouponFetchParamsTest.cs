using System;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponFetchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponFetchParams { CouponID = "coupon_id" };

        string expectedCouponID = "coupon_id";

        Assert.Equal(expectedCouponID, parameters.CouponID);
    }

    [Fact]
    public void Url_Works()
    {
        CouponFetchParams parameters = new() { CouponID = "coupon_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/coupons/coupon_id"), url);
    }
}
