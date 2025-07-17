using DiscountProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static DiscountVariants::Percentage Create(DiscountProperties::Percentage value) =>
        new(value);

    public static DiscountVariants::Amount Create(DiscountProperties::Amount value) => new(value);

    public abstract void Validate();
}
