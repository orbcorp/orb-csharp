using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.InvoiceLevelDiscountVariants;

public sealed record class PercentageDiscount(Models::PercentageDiscount Value)
    : Models::InvoiceLevelDiscount,
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
    : Models::InvoiceLevelDiscount,
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

public sealed record class TrialDiscount(Models::TrialDiscount Value)
    : Models::InvoiceLevelDiscount,
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
