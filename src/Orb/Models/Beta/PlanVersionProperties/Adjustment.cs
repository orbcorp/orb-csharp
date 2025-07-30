using System.Text.Json.Serialization;
using AdjustmentVariants = Orb.Models.Beta.PlanVersionProperties.AdjustmentVariants;

namespace Orb.Models.Beta.PlanVersionProperties;

[JsonConverter(typeof(UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(PlanPhaseUsageDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseUsageDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(PlanPhaseAmountDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseAmountDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(PlanPhasePercentageDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhasePercentageDiscountAdjustmentVariant(value);

    public static implicit operator Adjustment(PlanPhaseMinimumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMinimumAdjustmentVariant(value);

    public static implicit operator Adjustment(PlanPhaseMaximumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMaximumAdjustmentVariant(value);

    public abstract void Validate();
}
