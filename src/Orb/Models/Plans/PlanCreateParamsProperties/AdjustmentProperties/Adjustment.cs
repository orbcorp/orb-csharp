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

    public static AdjustmentVariants::NewPercentageDiscount Create(
        Models::NewPercentageDiscount value
    ) => new(value);

    public static AdjustmentVariants::NewUsageDiscount Create(Models::NewUsageDiscount value) =>
        new(value);

    public static AdjustmentVariants::NewAmountDiscount Create(Models::NewAmountDiscount value) =>
        new(value);

    public static AdjustmentVariants::NewMinimum Create(Models::NewMinimum value) => new(value);

    public static AdjustmentVariants::NewMaximum Create(Models::NewMaximum value) => new(value);

    public abstract void Validate();
}
