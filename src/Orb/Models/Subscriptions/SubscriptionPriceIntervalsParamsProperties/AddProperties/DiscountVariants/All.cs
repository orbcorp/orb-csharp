using AddProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;
using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Amount, DiscountProperties::Amount>))]
public sealed record class Amount(DiscountProperties::Amount Value)
    : AddProperties::Discount,
        Orb::IVariant<Amount, DiscountProperties::Amount>
{
    public static Amount From(DiscountProperties::Amount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<Percentage, DiscountProperties::Percentage>)
)]
public sealed record class Percentage(DiscountProperties::Percentage Value)
    : AddProperties::Discount,
        Orb::IVariant<Percentage, DiscountProperties::Percentage>
{
    public static Percentage From(DiscountProperties::Percentage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Usage, DiscountProperties::Usage>))]
public sealed record class Usage(DiscountProperties::Usage Value)
    : AddProperties::Discount,
        Orb::IVariant<Usage, DiscountProperties::Usage>
{
    public static Usage From(DiscountProperties::Usage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
