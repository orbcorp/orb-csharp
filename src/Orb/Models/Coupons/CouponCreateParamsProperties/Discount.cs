using System.Text.Json.Serialization;
using DiscountProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountVariants;

namespace Orb.Models.Coupons.CouponCreateParamsProperties;

[JsonConverter(typeof(UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(DiscountProperties::Percentage value) =>
        new DiscountVariants::Percentage(value);

    public static implicit operator Discount(DiscountProperties::Amount value) =>
        new DiscountVariants::Amount(value);

    public abstract void Validate();
}
