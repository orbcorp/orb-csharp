using System;
using System.Collections.Generic;
using Orb.Models;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "7iz2yanVjQoBZhyH",
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Discount = new PercentageDiscount()
                    {
                        DiscountType = PercentageDiscountDiscountType.Percentage,
                        PercentageDiscount1 = 0.15,
                        AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                        Filters =
                        [
                            new()
                            {
                                Field = Filter17Field.PriceID,
                                Operator = Filter17Operator.Includes,
                                Values = ["string"],
                            },
                        ],
                        Reason = "reason",
                    },
                    DurationInMonths = 12,
                    MaxRedemptions = 0,
                    RedemptionCode = "HALFOFF",
                    TimesRedeemed = 0,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Coupon> expectedData =
        [
            new()
            {
                ID = "7iz2yanVjQoBZhyH",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Discount = new PercentageDiscount()
                {
                    DiscountType = PercentageDiscountDiscountType.Percentage,
                    PercentageDiscount1 = 0.15,
                    AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                    Filters =
                    [
                        new()
                        {
                            Field = Filter17Field.PriceID,
                            Operator = Filter17Operator.Includes,
                            Values = ["string"],
                        },
                    ],
                    Reason = "reason",
                },
                DurationInMonths = 12,
                MaxRedemptions = 0,
                RedemptionCode = "HALFOFF",
                TimesRedeemed = 0,
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
        {
            HasMore = true,
            NextCursor = "next_cursor",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPaginationMetadata, model.PaginationMetadata);
    }
}
