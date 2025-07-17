using AdjustmentVariants = Orb.Models.AdjustmentIntervalProperties.AdjustmentVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.AdjustmentIntervalProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static AdjustmentVariants::PlanPhaseUsageDiscountAdjustment Create(
        Models::PlanPhaseUsageDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::PlanPhaseAmountDiscountAdjustment Create(
        Models::PlanPhaseAmountDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::PlanPhasePercentageDiscountAdjustment Create(
        Models::PlanPhasePercentageDiscountAdjustment value
    ) => new(value);

    public static AdjustmentVariants::PlanPhaseMinimumAdjustment Create(
        Models::PlanPhaseMinimumAdjustment value
    ) => new(value);

    public static AdjustmentVariants::PlanPhaseMaximumAdjustment Create(
        Models::PlanPhaseMaximumAdjustment value
    ) => new(value);

    public abstract void Validate();
}
