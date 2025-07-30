using System.Text.Json.Serialization;
using AdjustmentVariants = Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties.AdjustmentVariants;

namespace Orb.Models.Plans.PlanCreateParamsProperties.AdjustmentProperties;

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(UnionConverter<Adjustment1>))]
public abstract record class Adjustment1
{
    internal Adjustment1() { }

    public static implicit operator Adjustment1(NewPercentageDiscount value) =>
        new AdjustmentVariants::NewPercentageDiscountVariant(value);

    public static implicit operator Adjustment1(NewUsageDiscount value) =>
        new AdjustmentVariants::NewUsageDiscountVariant(value);

    public static implicit operator Adjustment1(NewAmountDiscount value) =>
        new AdjustmentVariants::NewAmountDiscountVariant(value);

    public static implicit operator Adjustment1(NewMinimum value) =>
        new AdjustmentVariants::NewMinimumVariant(value);

    public static implicit operator Adjustment1(NewMaximum value) =>
        new AdjustmentVariants::NewMaximumVariant(value);

    public abstract void Validate();
}
