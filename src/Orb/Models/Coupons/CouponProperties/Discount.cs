using DiscountVariants = Orb.Models.Coupons.CouponProperties.DiscountVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(Models::PercentageDiscount value) =>
        new DiscountVariants::PercentageDiscount(value);

    public static implicit operator Discount(Models::AmountDiscount value) =>
        new DiscountVariants::AmountDiscount(value);

    public abstract void Validate();
}
