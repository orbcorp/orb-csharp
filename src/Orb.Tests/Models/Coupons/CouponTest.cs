using System;
using Orb.Models;
using Orb.Models.Coupons;

namespace Orb.Tests.Models.Coupons;

public class CouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupon
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
        };

        string expectedID = "7iz2yanVjQoBZhyH";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CouponDiscount expectedDiscount = new PercentageDiscount()
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
        };
        long expectedDurationInMonths = 12;
        long expectedMaxRedemptions = 0;
        string expectedRedemptionCode = "HALFOFF";
        long expectedTimesRedeemed = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedDurationInMonths, model.DurationInMonths);
        Assert.Equal(expectedMaxRedemptions, model.MaxRedemptions);
        Assert.Equal(expectedRedemptionCode, model.RedemptionCode);
        Assert.Equal(expectedTimesRedeemed, model.TimesRedeemed);
    }
}
