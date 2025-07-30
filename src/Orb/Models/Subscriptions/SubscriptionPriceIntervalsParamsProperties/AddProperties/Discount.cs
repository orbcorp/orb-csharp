using System.Text.Json.Serialization;
using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using DiscountVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

[JsonConverter(typeof(UnionConverter<Discount>))]
public abstract record class Discount
{
    internal Discount() { }

    public static implicit operator Discount(DiscountProperties::Amount value) =>
        new DiscountVariants::Amount(value);

    public static implicit operator Discount(DiscountProperties::Percentage value) =>
        new DiscountVariants::Percentage(value);

    public static implicit operator Discount(DiscountProperties::Usage value) =>
        new DiscountVariants::Usage(value);

    public abstract void Validate();
}
