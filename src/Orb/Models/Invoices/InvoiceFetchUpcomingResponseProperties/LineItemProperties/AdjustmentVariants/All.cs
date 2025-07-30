using System.Text.Json.Serialization;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.LineItemProperties.AdjustmentVariants;

[JsonConverter(
    typeof(VariantConverter<
        MonetaryUsageDiscountAdjustmentVariant,
        MonetaryUsageDiscountAdjustment
    >)
)]
public sealed record class MonetaryUsageDiscountAdjustmentVariant(
    MonetaryUsageDiscountAdjustment Value
) : Adjustment, IVariant<MonetaryUsageDiscountAdjustmentVariant, MonetaryUsageDiscountAdjustment>
{
    public static MonetaryUsageDiscountAdjustmentVariant From(MonetaryUsageDiscountAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        MonetaryAmountDiscountAdjustmentVariant,
        MonetaryAmountDiscountAdjustment
    >)
)]
public sealed record class MonetaryAmountDiscountAdjustmentVariant(
    MonetaryAmountDiscountAdjustment Value
) : Adjustment, IVariant<MonetaryAmountDiscountAdjustmentVariant, MonetaryAmountDiscountAdjustment>
{
    public static MonetaryAmountDiscountAdjustmentVariant From(
        MonetaryAmountDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        MonetaryPercentageDiscountAdjustmentVariant,
        MonetaryPercentageDiscountAdjustment
    >)
)]
public sealed record class MonetaryPercentageDiscountAdjustmentVariant(
    MonetaryPercentageDiscountAdjustment Value
)
    : Adjustment,
        IVariant<MonetaryPercentageDiscountAdjustmentVariant, MonetaryPercentageDiscountAdjustment>
{
    public static MonetaryPercentageDiscountAdjustmentVariant From(
        MonetaryPercentageDiscountAdjustment value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<MonetaryMinimumAdjustmentVariant, MonetaryMinimumAdjustment>)
)]
public sealed record class MonetaryMinimumAdjustmentVariant(MonetaryMinimumAdjustment Value)
    : Adjustment,
        IVariant<MonetaryMinimumAdjustmentVariant, MonetaryMinimumAdjustment>
{
    public static MonetaryMinimumAdjustmentVariant From(MonetaryMinimumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<MonetaryMaximumAdjustmentVariant, MonetaryMaximumAdjustment>)
)]
public sealed record class MonetaryMaximumAdjustmentVariant(MonetaryMaximumAdjustment Value)
    : Adjustment,
        IVariant<MonetaryMaximumAdjustmentVariant, MonetaryMaximumAdjustment>
{
    public static MonetaryMaximumAdjustmentVariant From(MonetaryMaximumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
