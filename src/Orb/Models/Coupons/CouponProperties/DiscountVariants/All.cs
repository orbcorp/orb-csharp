using System.Text.Json.Serialization;

namespace Orb.Models.Coupons.CouponProperties.DiscountVariants;

[JsonConverter(typeof(VariantConverter<PercentageDiscountVariant, PercentageDiscount>))]
public sealed record class PercentageDiscountVariant(PercentageDiscount Value)
    : Discount,
        IVariant<PercentageDiscountVariant, PercentageDiscount>
{
    public static PercentageDiscountVariant From(PercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<AmountDiscountVariant, AmountDiscount>))]
public sealed record class AmountDiscountVariant(AmountDiscount Value)
    : Discount,
        IVariant<AmountDiscountVariant, AmountDiscount>
{
    public static AmountDiscountVariant From(AmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
