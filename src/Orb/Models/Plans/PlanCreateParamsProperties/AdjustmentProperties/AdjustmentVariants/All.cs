using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties.AdjustmentVariants;

[JsonConverter(typeof(VariantConverter<NewPercentageDiscountVariant, NewPercentageDiscount>))]
public sealed record class NewPercentageDiscountVariant(NewPercentageDiscount Value)
    : Adjustment1,
        IVariant<NewPercentageDiscountVariant, NewPercentageDiscount>
{
    public static NewPercentageDiscountVariant From(NewPercentageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewUsageDiscountVariant, NewUsageDiscount>))]
public sealed record class NewUsageDiscountVariant(NewUsageDiscount Value)
    : Adjustment1,
        IVariant<NewUsageDiscountVariant, NewUsageDiscount>
{
    public static NewUsageDiscountVariant From(NewUsageDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewAmountDiscountVariant, NewAmountDiscount>))]
public sealed record class NewAmountDiscountVariant(NewAmountDiscount Value)
    : Adjustment1,
        IVariant<NewAmountDiscountVariant, NewAmountDiscount>
{
    public static NewAmountDiscountVariant From(NewAmountDiscount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewMinimumVariant, NewMinimum>))]
public sealed record class NewMinimumVariant(NewMinimum Value)
    : Adjustment1,
        IVariant<NewMinimumVariant, NewMinimum>
{
    public static NewMinimumVariant From(NewMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NewMaximumVariant, NewMaximum>))]
public sealed record class NewMaximumVariant(NewMaximum Value)
    : Adjustment1,
        IVariant<NewMaximumVariant, NewMaximum>
{
    public static NewMaximumVariant From(NewMaximum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
