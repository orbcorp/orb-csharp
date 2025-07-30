using System.Text.Json.Serialization;
using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;

[JsonConverter(typeof(VariantConverter<Amount, DiscountProperties::Amount>))]
public sealed record class Amount(DiscountProperties::Amount Value)
    : Discount,
        IVariant<Amount, DiscountProperties::Amount>
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

[JsonConverter(typeof(VariantConverter<Percentage, DiscountProperties::Percentage>))]
public sealed record class Percentage(DiscountProperties::Percentage Value)
    : Discount,
        IVariant<Percentage, DiscountProperties::Percentage>
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

[JsonConverter(typeof(VariantConverter<Usage, DiscountProperties::Usage>))]
public sealed record class Usage(DiscountProperties::Usage Value)
    : Discount,
        IVariant<Usage, DiscountProperties::Usage>
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
