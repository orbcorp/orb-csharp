using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.DiscountVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PercentageDiscount, Models::PercentageDiscount>)
)]
public sealed record class PercentageDiscount(Models::PercentageDiscount Value)
    : Models::Discount,
        Orb::IVariant<PercentageDiscount, Models::PercentageDiscount>
{
    public static PercentageDiscount From(Models::PercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<TrialDiscount, Models::TrialDiscount>))]
public sealed record class TrialDiscount(Models::TrialDiscount Value)
    : Models::Discount,
        Orb::IVariant<TrialDiscount, Models::TrialDiscount>
{
    public static TrialDiscount From(Models::TrialDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<UsageDiscount, Models::UsageDiscount>))]
public sealed record class UsageDiscount(Models::UsageDiscount Value)
    : Models::Discount,
        Orb::IVariant<UsageDiscount, Models::UsageDiscount>
{
    public static UsageDiscount From(Models::UsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<AmountDiscount, Models::AmountDiscount>)
)]
public sealed record class AmountDiscount(Models::AmountDiscount Value)
    : Models::Discount,
        Orb::IVariant<AmountDiscount, Models::AmountDiscount>
{
    public static AmountDiscount From(Models::AmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
