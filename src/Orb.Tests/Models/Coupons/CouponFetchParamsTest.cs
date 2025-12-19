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
}
