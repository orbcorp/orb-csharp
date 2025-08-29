using Models = Orb.Models;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddAdjustmentProperties.AdjustmentVariants;

public sealed record class NewPercentageDiscount(Models::NewPercentageDiscount Value)
    : Adjustment,
        IVariant<NewPercentageDiscount, Models::NewPercentageDiscount>
{
    public static NewPercentageDiscount From(Models::NewPercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewUsageDiscount(Models::NewUsageDiscount Value)
    : Adjustment,
        IVariant<NewUsageDiscount, Models::NewUsageDiscount>
{
    public static NewUsageDiscount From(Models::NewUsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewAmountDiscount(Models::NewAmountDiscount Value)
    : Adjustment,
        IVariant<NewAmountDiscount, Models::NewAmountDiscount>
{
    public static NewAmountDiscount From(Models::NewAmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewMinimum(Models::NewMinimum Value)
    : Adjustment,
        IVariant<NewMinimum, Models::NewMinimum>
{
    public static NewMinimum From(Models::NewMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NewMaximum(Models::NewMaximum Value)
    : Adjustment,
        IVariant<NewMaximum, Models::NewMaximum>
{
    public static NewMaximum From(Models::NewMaximum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
