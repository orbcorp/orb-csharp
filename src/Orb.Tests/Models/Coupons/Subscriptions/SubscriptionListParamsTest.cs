using Orb.Models.Coupons.Subscriptions;

namespace Orb.Tests.Models.Coupons.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CouponID = "coupon_id",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedCouponID = "coupon_id";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedCouponID, parameters.CouponID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { CouponID = "coupon_id", Cursor = "cursor" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CouponID = "coupon_id",
            Cursor = "cursor",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { CouponID = "coupon_id", Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CouponID = "coupon_id",
            Limit = 1,

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }
}
