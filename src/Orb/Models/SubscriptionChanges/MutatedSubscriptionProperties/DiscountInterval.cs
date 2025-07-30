using System.Text.Json.Serialization;
using DiscountIntervalVariants = Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties.DiscountIntervalVariants;

namespace Orb.Models.SubscriptionChanges.MutatedSubscriptionProperties;

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
