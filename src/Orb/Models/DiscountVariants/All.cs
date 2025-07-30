using System.Text.Json.Serialization;

namespace Orb.Models.DiscountVariants;

[JsonConverter(typeof(VariantConverter<PercentageDiscountVariant, PercentageDiscount>))]
public sealed record class PercentageDiscountVariant(PercentageDiscount Value)
    : Discount2,
        IVariant<PercentageDiscountVariant, PercentageDiscount>
{
    public static PercentageDiscountVariant From(PercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<TrialDiscountVariant, TrialDiscount>))]
public sealed record class TrialDiscountVariant(TrialDiscount Value)
    : Discount2,
        IVariant<TrialDiscountVariant, TrialDiscount>
{
    public static TrialDiscountVariant From(TrialDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<UsageDiscountVariant, UsageDiscount>))]
public sealed record class UsageDiscountVariant(UsageDiscount Value)
    : Discount2,
        IVariant<UsageDiscountVariant, UsageDiscount>
{
    public static UsageDiscountVariant From(UsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<AmountDiscountVariant, AmountDiscount>))]
public sealed record class AmountDiscountVariant(AmountDiscount Value)
    : Discount2,
        IVariant<AmountDiscountVariant, AmountDiscount>
{
    public static AmountDiscountVariant From(AmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
