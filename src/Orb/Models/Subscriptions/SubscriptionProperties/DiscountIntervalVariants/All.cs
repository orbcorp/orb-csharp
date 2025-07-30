using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;

[JsonConverter(typeof(VariantConverter<AmountDiscountIntervalVariant, AmountDiscountInterval>))]
public sealed record class AmountDiscountIntervalVariant(AmountDiscountInterval Value)
    : DiscountInterval,
        IVariant<AmountDiscountIntervalVariant, AmountDiscountInterval>
{
    public static AmountDiscountIntervalVariant From(AmountDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<PercentageDiscountIntervalVariant, PercentageDiscountInterval>)
)]
public sealed record class PercentageDiscountIntervalVariant(PercentageDiscountInterval Value)
    : DiscountInterval,
        IVariant<PercentageDiscountIntervalVariant, PercentageDiscountInterval>
{
    public static PercentageDiscountIntervalVariant From(PercentageDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<UsageDiscountIntervalVariant, UsageDiscountInterval>))]
public sealed record class UsageDiscountIntervalVariant(UsageDiscountInterval Value)
    : DiscountInterval,
        IVariant<UsageDiscountIntervalVariant, UsageDiscountInterval>
{
    public static UsageDiscountIntervalVariant From(UsageDiscountInterval value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
