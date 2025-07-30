using System.Text.Json.Serialization;
using DiscountProperties = Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountVariants;

[JsonConverter(typeof(VariantConverter<Percentage, DiscountProperties::Percentage>))]
public sealed record class Percentage(DiscountProperties::Percentage Value)
    : Discount,
        IVariant<Percentage, DiscountProperties::Percentage>
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

[JsonConverter(typeof(VariantConverter<Amount, DiscountProperties::Amount>))]
public sealed record class Amount(DiscountProperties::Amount Value)
    : Discount,
        IVariant<Amount, DiscountProperties::Amount>
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
