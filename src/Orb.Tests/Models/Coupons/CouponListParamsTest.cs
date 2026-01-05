using System;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponListParams
        {
            Cursor = "cursor",
            Limit = 1,
            RedemptionCode = "redemption_code",
            ShowArchived = true,
        };

        string expectedCursor = "cursor";
        long expectedLimit = 1;
        string expectedRedemptionCode = "redemption_code";
        bool expectedShowArchived = true;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedRedemptionCode, parameters.RedemptionCode);
        Assert.Equal(expectedShowArchived, parameters.ShowArchived);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CouponListParams
        {
            Cursor = "cursor",
            RedemptionCode = "redemption_code",
            ShowArchived = true,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CouponListParams
        {
            Cursor = "cursor",
            RedemptionCode = "redemption_code",
            ShowArchived = true,

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CouponListParams { Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.RedemptionCode);
        Assert.False(parameters.RawQueryData.ContainsKey("redemption_code"));
        Assert.Null(parameters.ShowArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("show_archived"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CouponListParams
        {
            Limit = 1,

            Cursor = null,
            RedemptionCode = null,
            ShowArchived = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.RedemptionCode);
        Assert.True(parameters.RawQueryData.ContainsKey("redemption_code"));
        Assert.Null(parameters.ShowArchived);
        Assert.True(parameters.RawQueryData.ContainsKey("show_archived"));
    }

    [Fact]
    public void Url_Works()
    {
        CouponListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 1,
            RedemptionCode = "redemption_code",
            ShowArchived = true,
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.withorb.com/v1/coupons?cursor=cursor&limit=1&redemption_code=redemption_code&show_archived=true"
            ),
            url
        );
    }
}
