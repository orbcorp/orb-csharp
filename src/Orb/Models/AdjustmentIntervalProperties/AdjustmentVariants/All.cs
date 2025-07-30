using System.Text.Json.Serialization;

namespace Orb.Models.AdjustmentIntervalProperties.AdjustmentVariants;

[JsonConverter(
    typeof(VariantConverter<
        PlanPhaseUsageDiscountAdjustmentVariant,
        PlanPhaseUsageDiscountAdjustment
    >)
)]
public sealed record class PlanPhaseUsageDiscountAdjustmentVariant(
    PlanPhaseUsageDiscountAdjustment Value
) : Adjustment, IVariant<PlanPhaseUsageDiscountAdjustmentVariant, PlanPhaseUsageDiscountAdjustment>
{
    public static PlanPhaseUsageDiscountAdjustmentVariant From(
        PlanPhaseUsageDiscountAdjustment value
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
        PlanPhaseAmountDiscountAdjustmentVariant,
        PlanPhaseAmountDiscountAdjustment
    >)
)]
public sealed record class PlanPhaseAmountDiscountAdjustmentVariant(
    PlanPhaseAmountDiscountAdjustment Value
)
    : Adjustment,
        IVariant<PlanPhaseAmountDiscountAdjustmentVariant, PlanPhaseAmountDiscountAdjustment>
{
    public static PlanPhaseAmountDiscountAdjustmentVariant From(
        PlanPhaseAmountDiscountAdjustment value
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
        PlanPhasePercentageDiscountAdjustmentVariant,
        PlanPhasePercentageDiscountAdjustment
    >)
)]
public sealed record class PlanPhasePercentageDiscountAdjustmentVariant(
    PlanPhasePercentageDiscountAdjustment Value
)
    : Adjustment,
        IVariant<
            PlanPhasePercentageDiscountAdjustmentVariant,
            PlanPhasePercentageDiscountAdjustment
        >
{
    public static PlanPhasePercentageDiscountAdjustmentVariant From(
        PlanPhasePercentageDiscountAdjustment value
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
    typeof(VariantConverter<PlanPhaseMinimumAdjustmentVariant, PlanPhaseMinimumAdjustment>)
)]
public sealed record class PlanPhaseMinimumAdjustmentVariant(PlanPhaseMinimumAdjustment Value)
    : Adjustment,
        IVariant<PlanPhaseMinimumAdjustmentVariant, PlanPhaseMinimumAdjustment>
{
    public static PlanPhaseMinimumAdjustmentVariant From(PlanPhaseMinimumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<PlanPhaseMaximumAdjustmentVariant, PlanPhaseMaximumAdjustment>)
)]
public sealed record class PlanPhaseMaximumAdjustmentVariant(PlanPhaseMaximumAdjustment Value)
    : Adjustment,
        IVariant<PlanPhaseMaximumAdjustmentVariant, PlanPhaseMaximumAdjustment>
{
    public static PlanPhaseMaximumAdjustmentVariant From(PlanPhaseMaximumAdjustment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
