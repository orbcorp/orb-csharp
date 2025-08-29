using Models = Orb.Models;

namespace Orb.Models.DiscountVariants;

public sealed record class PercentageDiscount(Models::PercentageDiscount Value)
    : Models::Discount,
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

public sealed record class TrialDiscount(Models::TrialDiscount Value)
    : Models::Discount,
        IVariant<TrialDiscount, Models::TrialDiscount>
{
    public static TrialDiscount From(Models::TrialDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UsageDiscount(Models::UsageDiscount Value)
    : Models::Discount,
        IVariant<UsageDiscount, Models::UsageDiscount>
{
    public static UsageDiscount From(Models::UsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AmountDiscount(Models::AmountDiscount Value)
    : Models::Discount,
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
