using DiscountIntervalVariants = Orb.Models.Subscriptions.SubscriptionProperties.DiscountIntervalVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<DiscountInterval>))]
public abstract record class DiscountInterval
{
    internal DiscountInterval() { }

    public static implicit operator DiscountInterval(Models::AmountDiscountInterval value) =>
        new DiscountIntervalVariants::AmountDiscountInterval(value);

    public static implicit operator DiscountInterval(Models::PercentageDiscountInterval value) =>
        new DiscountIntervalVariants::PercentageDiscountInterval(value);

    public static implicit operator DiscountInterval(Models::UsageDiscountInterval value) =>
        new DiscountIntervalVariants::UsageDiscountInterval(value);

    public abstract void Validate();
}
