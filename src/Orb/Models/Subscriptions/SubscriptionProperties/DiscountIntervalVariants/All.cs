using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubscriptionProperties = Orb.Models.Subscriptions.SubscriptionProperties;

namespace Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<AmountDiscountInterval, Models::AmountDiscountInterval>)
)]
public sealed record class AmountDiscountInterval(Models::AmountDiscountInterval Value)
    : SubscriptionProperties::DiscountInterval,
        Orb::IVariant<AmountDiscountInterval, Models::AmountDiscountInterval>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PercentageDiscountInterval, Models::PercentageDiscountInterval>)
)]
public sealed record class PercentageDiscountInterval(Models::PercentageDiscountInterval Value)
    : SubscriptionProperties::DiscountInterval,
        Orb::IVariant<PercentageDiscountInterval, Models::PercentageDiscountInterval>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<UsageDiscountInterval, Models::UsageDiscountInterval>)
)]
public sealed record class UsageDiscountInterval(Models::UsageDiscountInterval Value)
    : SubscriptionProperties::DiscountInterval,
        Orb::IVariant<UsageDiscountInterval, Models::UsageDiscountInterval>
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
