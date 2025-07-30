using System.Text.Json.Serialization;

namespace Orb.Models.InvoiceLevelDiscountVariants;

[JsonConverter(typeof(VariantConverter<PercentageDiscountVariant, PercentageDiscount>))]
public sealed record class PercentageDiscountVariant(PercentageDiscount Value)
    : InvoiceLevelDiscount,
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

[JsonConverter(typeof(VariantConverter<AmountDiscountVariant, AmountDiscount>))]
public sealed record class AmountDiscountVariant(AmountDiscount Value)
    : InvoiceLevelDiscount,
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

[JsonConverter(typeof(VariantConverter<TrialDiscountVariant, TrialDiscount>))]
public sealed record class TrialDiscountVariant(TrialDiscount Value)
    : InvoiceLevelDiscount,
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
