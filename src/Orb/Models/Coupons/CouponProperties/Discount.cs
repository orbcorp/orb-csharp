using System.Text.Json.Serialization;
using DiscountVariants = Orb.Models.Coupons.CouponProperties.DiscountVariants;

namespace Orb.Models.Coupons.CouponProperties;

[JsonConverter(typeof(UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscountVariant(value);

    public static implicit operator Discount(AmountDiscount value) =>
        new DiscountVariants::AmountDiscountVariant(value);

    public abstract void Validate();
}
