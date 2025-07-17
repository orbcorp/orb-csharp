using DiscountVariants = Orb.Models.Coupons.CouponProperties.DiscountVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static DiscountVariants::PercentageDiscount Create(Models::PercentageDiscount value) =>
        new(value);

    public static DiscountVariants::AmountDiscount Create(Models::AmountDiscount value) =>
        new(value);

    public abstract void Validate();
}
