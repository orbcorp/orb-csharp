using System.Text.Json.Serialization;
using AdjustmentVariants = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddAdjustmentProperties.AdjustmentVariants;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddAdjustmentProperties;

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(UnionConverter<Adjustment>))]
public abstract record class Adjustment
{
    internal Adjustment() { }

    public static implicit operator Adjustment(NewPercentageDiscount value) =>
        new AdjustmentVariants::NewPercentageDiscountVariant(value);

    public static implicit operator Adjustment(NewUsageDiscount value) =>
        new AdjustmentVariants::NewUsageDiscountVariant(value);

    public static implicit operator Adjustment(NewAmountDiscount value) =>
        new AdjustmentVariants::NewAmountDiscountVariant(value);

    public static implicit operator Adjustment(NewMinimum value) =>
        new AdjustmentVariants::NewMinimumVariant(value);

    public static implicit operator Adjustment(NewMaximum value) =>
        new AdjustmentVariants::NewMaximumVariant(value);

    public abstract void Validate();
}
