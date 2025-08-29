using Models = Orb.Models;

namespace Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;

public sealed record class AmountDiscountInterval(Models::AmountDiscountInterval Value)
    : DiscountInterval,
        IVariant<AmountDiscountInterval, Models::AmountDiscountInterval>
{
    public static AmountDiscountInterval From(Models::AmountDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PercentageDiscountInterval(Models::PercentageDiscountInterval Value)
    : DiscountInterval,
        IVariant<PercentageDiscountInterval, Models::PercentageDiscountInterval>
{
    public static PercentageDiscountInterval From(Models::PercentageDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UsageDiscountInterval(Models::UsageDiscountInterval Value)
    : DiscountInterval,
        IVariant<UsageDiscountInterval, Models::UsageDiscountInterval>
{
    public static UsageDiscountInterval From(Models::UsageDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
