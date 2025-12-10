using System;
using System.Text.Json;
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
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Coupon
        {
            ID = "7iz2yanVjQoBZhyH",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Coupon>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupon
        {
            ID = "7iz2yanVjQoBZhyH",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Coupon>(json);
        Assert.NotNull(deserialized);

        string expectedID = "7iz2yanVjQoBZhyH";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CouponDiscount expectedDiscount = new PercentageDiscount()
        {
            DiscountType = PercentageDiscountDiscountType.Percentage,
            PercentageDiscountValue = 0.15,
            AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountFilterField.PriceID,
                    Operator = PercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            Reason = "reason",
        };
        long expectedDurationInMonths = 12;
        long expectedMaxRedemptions = 0;
        string expectedRedemptionCode = "HALFOFF";
        long expectedTimesRedeemed = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedDurationInMonths, deserialized.DurationInMonths);
        Assert.Equal(expectedMaxRedemptions, deserialized.MaxRedemptions);
        Assert.Equal(expectedRedemptionCode, deserialized.RedemptionCode);
        Assert.Equal(expectedTimesRedeemed, deserialized.TimesRedeemed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Coupon
        {
            ID = "7iz2yanVjQoBZhyH",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discount = new PercentageDiscount()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
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

        model.Validate();
    }
}

public class CouponDiscountTest : TestBase
{
    [Fact]
    public void percentageValidation_Works()
    {
        CouponDiscount value = new(
            new()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            }
        );
        value.Validate();
    }

    [Fact]
    public void amountValidation_Works()
    {
        CouponDiscount value = new(
            new()
            {
                AmountDiscountValue = "amount_discount",
                DiscountType = DiscountType.Amount,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = AmountDiscountFilterField.PriceID,
                        Operator = AmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            }
        );
        value.Validate();
    }

    [Fact]
    public void percentageSerializationRoundtrip_Works()
    {
        CouponDiscount value = new(
            new()
            {
                DiscountType = PercentageDiscountDiscountType.Percentage,
                PercentageDiscountValue = 0.15,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = PercentageDiscountFilterField.PriceID,
                        Operator = PercentageDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CouponDiscount>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void amountSerializationRoundtrip_Works()
    {
        CouponDiscount value = new(
            new()
            {
                AmountDiscountValue = "amount_discount",
                DiscountType = DiscountType.Amount,
                AppliesToPriceIDs = ["h74gfhdjvn7ujokd", "7hfgtgjnbvc3ujkl"],
                Filters =
                [
                    new()
                    {
                        Field = AmountDiscountFilterField.PriceID,
                        Operator = AmountDiscountFilterOperator.Includes,
                        Values = ["string"],
                    },
                ],
                Reason = "reason",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CouponDiscount>(json);

        Assert.Equal(value, deserialized);
    }
}
