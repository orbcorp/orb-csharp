using DiscountIntervalVariants = Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<DiscountInterval>))]
public abstract record class DiscountInterval
{
    internal DiscountInterval() { }

    public static DiscountIntervalVariants::AmountDiscountInterval Create(
        Models::AmountDiscountInterval value
    ) => new(value);

    public static DiscountIntervalVariants::PercentageDiscountInterval Create(
        Models::PercentageDiscountInterval value
    ) => new(value);

    public static DiscountIntervalVariants::UsageDiscountInterval Create(
        Models::UsageDiscountInterval value
    ) => new(value);

    public abstract void Validate();
}
