using CouponCreateParamsProperties = Orb.Models.Coupons.CouponCreateParamsProperties;
using DiscountProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<Percentage, DiscountProperties::Percentage>)
)]
public sealed record class Percentage(DiscountProperties::Percentage Value)
    : CouponCreateParamsProperties::Discount,
        Orb::IVariant<Percentage, DiscountProperties::Percentage>
{
    public static Percentage From(DiscountProperties::Percentage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Amount, DiscountProperties::Amount>))]
public sealed record class Amount(DiscountProperties::Amount Value)
    : CouponCreateParamsProperties::Discount,
        Orb::IVariant<Amount, DiscountProperties::Amount>
{
    public static Amount From(DiscountProperties::Amount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
