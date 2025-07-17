using CouponProperties = Orb.Models.Coupons.CouponProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponProperties.DiscountVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PercentageDiscount, Models::PercentageDiscount>)
)]
public sealed record class PercentageDiscount(Models::PercentageDiscount Value)
    : CouponProperties::Discount,
        Orb::IVariant<PercentageDiscount, Models::PercentageDiscount>
{
    public static PercentageDiscount From(Models::PercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<AmountDiscount, Models::AmountDiscount>)
)]
public sealed record class AmountDiscount(Models::AmountDiscount Value)
    : CouponProperties::Discount,
        Orb::IVariant<AmountDiscount, Models::AmountDiscount>
{
    public static AmountDiscount From(Models::AmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
