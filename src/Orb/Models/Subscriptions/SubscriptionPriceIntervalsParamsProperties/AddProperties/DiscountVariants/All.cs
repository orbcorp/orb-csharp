using Orb.Core;
using AddProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;
using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountVariants;

public sealed record class Amount(DiscountProperties::Amount Value)
    : AddProperties::Discount,
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

public sealed record class Percentage(DiscountProperties::Percentage Value)
    : AddProperties::Discount,
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

public sealed record class Usage(DiscountProperties::Usage Value)
    : AddProperties::Discount,
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
