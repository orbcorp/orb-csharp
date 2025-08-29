using Models = Orb.Models;

namespace Orb.Models.Coupons.CouponProperties.DiscountVariants;

public sealed record class PercentageDiscount(Models::PercentageDiscount Value)
    : Discount,
        IVariant<PercentageDiscount, Models::PercentageDiscount>
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

public sealed record class AmountDiscount(Models::AmountDiscount Value)
    : Discount,
        IVariant<AmountDiscount, Models::AmountDiscount>
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
