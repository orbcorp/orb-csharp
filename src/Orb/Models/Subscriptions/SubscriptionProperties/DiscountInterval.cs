using System.Text.Json.Serialization;
using DiscountIntervalVariants = Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;

namespace Orb.Models.Subscriptions.SubscriptionProperties;

[JsonConverter(typeof(UnionConverter<DiscountInterval>))]
public abstract record class DiscountInterval
{
    internal DiscountInterval() { }

    public static implicit operator DiscountInterval(AmountDiscountInterval value) =>
        new DiscountIntervalVariants::AmountDiscountIntervalVariant(value);

    public static implicit operator DiscountInterval(PercentageDiscountInterval value) =>
        new DiscountIntervalVariants::PercentageDiscountIntervalVariant(value);

    public static implicit operator DiscountInterval(UsageDiscountInterval value) =>
        new DiscountIntervalVariants::UsageDiscountIntervalVariant(value);

    public abstract void Validate();
}
