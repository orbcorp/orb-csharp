using System;
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
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new()
        {
            CouponID = "coupon_id",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/coupons/coupon_id/subscriptions?cursor=cursor&limit=1"
            ),
            url
        );
    }
}
