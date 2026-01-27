using System;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponArchiveParams { CouponID = "coupon_id" };

        string expectedCouponID = "coupon_id";

        Assert.Equal(expectedCouponID, parameters.CouponID);
    }

    [Fact]
    public void Url_Works()
    {
        CouponArchiveParams parameters = new() { CouponID = "coupon_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/coupons/coupon_id/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponArchiveParams { CouponID = "coupon_id" };

        CouponArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
