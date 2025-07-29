using AdjustmentVariants = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties.AdjustmentVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(Models::NewPercentageDiscount value) =>
        new AdjustmentVariants::NewPercentageDiscount(value);

    public static implicit operator Adjustment(Models::NewUsageDiscount value) =>
        new AdjustmentVariants::NewUsageDiscount(value);

    public static implicit operator Adjustment(Models::NewAmountDiscount value) =>
        new AdjustmentVariants::NewAmountDiscount(value);

    public static implicit operator Adjustment(Models::NewMinimum value) =>
        new AdjustmentVariants::NewMinimum(value);

    public static implicit operator Adjustment(Models::NewMaximum value) =>
        new AdjustmentVariants::NewMaximum(value);

    public abstract void Validate();
}
