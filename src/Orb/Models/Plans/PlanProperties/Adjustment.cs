using AdjustmentVariants = Orb.Models.Plans.PlanProperties.AdjustmentVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(Models::PlanPhaseUsageDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseUsageDiscountAdjustment(value);

    public static implicit operator Adjustment(Models::PlanPhaseAmountDiscountAdjustment value) =>
        new AdjustmentVariants::PlanPhaseAmountDiscountAdjustment(value);

    public static implicit operator Adjustment(
        Models::PlanPhasePercentageDiscountAdjustment value
    ) => new AdjustmentVariants::PlanPhasePercentageDiscountAdjustment(value);

    public static implicit operator Adjustment(Models::PlanPhaseMinimumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMinimumAdjustment(value);

    public static implicit operator Adjustment(Models::PlanPhaseMaximumAdjustment value) =>
        new AdjustmentVariants::PlanPhaseMaximumAdjustment(value);

    public abstract void Validate();
}
