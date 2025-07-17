using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static DiscountVariants::Amount Create(DiscountProperties::Amount value) => new(value);

    public static DiscountVariants::Percentage Create(DiscountProperties::Percentage value) =>
        new(value);

    public static DiscountVariants::Usage Create(DiscountProperties::Usage value) => new(value);

    public abstract void Validate();
}
