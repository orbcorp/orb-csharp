using System.Text.Json.Serialization;
using PriceVariants = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceVariants;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;

/// <summary>
/// The price to add to the plan
/// </summary>
[JsonConverter(typeof(UnionConverter<Price2>))]
public abstract record class Price2
{
    internal Price2() { }

    public static implicit operator Price2(NewPlanUnitPrice value) =>
        new PriceVariants::NewPlanUnitPriceVariant(value);

    public static implicit operator Price2(NewPlanPackagePrice value) =>
        new PriceVariants::NewPlanPackagePriceVariant(value);

    public static implicit operator Price2(NewPlanMatrixPrice value) =>
        new PriceVariants::NewPlanMatrixPriceVariant(value);

    public static implicit operator Price2(NewPlanTieredPrice value) =>
        new PriceVariants::NewPlanTieredPriceVariant(value);

    public static implicit operator Price2(NewPlanTieredBPSPrice value) =>
        new PriceVariants::NewPlanTieredBPSPriceVariant(value);

    public static implicit operator Price2(NewPlanBPSPrice value) =>
        new PriceVariants::NewPlanBPSPriceVariant(value);

    public static implicit operator Price2(NewPlanBulkBPSPrice value) =>
        new PriceVariants::NewPlanBulkBPSPriceVariant(value);

    public static implicit operator Price2(NewPlanBulkPrice value) =>
        new PriceVariants::NewPlanBulkPriceVariant(value);

    public static implicit operator Price2(NewPlanThresholdTotalAmountPrice value) =>
        new PriceVariants::NewPlanThresholdTotalAmountPriceVariant(value);

    public static implicit operator Price2(NewPlanTieredPackagePrice value) =>
        new PriceVariants::NewPlanTieredPackagePriceVariant(value);

    public static implicit operator Price2(NewPlanTieredWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredWithMinimumPriceVariant(value);

    public static implicit operator Price2(NewPlanUnitWithPercentPrice value) =>
        new PriceVariants::NewPlanUnitWithPercentPriceVariant(value);

    public static implicit operator Price2(NewPlanPackageWithAllocationPrice value) =>
        new PriceVariants::NewPlanPackageWithAllocationPriceVariant(value);

    public static implicit operator Price2(NewPlanTierWithProrationPrice value) =>
        new PriceVariants::NewPlanTierWithProrationPriceVariant(value);

    public static implicit operator Price2(NewPlanUnitWithProrationPrice value) =>
        new PriceVariants::NewPlanUnitWithProrationPriceVariant(value);

    public static implicit operator Price2(NewPlanGroupedAllocationPrice value) =>
        new PriceVariants::NewPlanGroupedAllocationPriceVariant(value);

    public static implicit operator Price2(NewPlanGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithProratedMinimumPriceVariant(value);

    public static implicit operator Price2(NewPlanGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithMeteredMinimumPriceVariant(value);

    public static implicit operator Price2(NewPlanMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewPlanMatrixWithDisplayNamePriceVariant(value);

    public static implicit operator Price2(NewPlanBulkWithProrationPrice value) =>
        new PriceVariants::NewPlanBulkWithProrationPriceVariant(value);

    public static implicit operator Price2(NewPlanGroupedTieredPackagePrice value) =>
        new PriceVariants::NewPlanGroupedTieredPackagePriceVariant(value);

    public static implicit operator Price2(NewPlanMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewPlanMaxGroupTieredPackagePriceVariant(value);

    public static implicit operator Price2(NewPlanScalableMatrixWithUnitPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithUnitPricingPriceVariant(value);

    public static implicit operator Price2(NewPlanScalableMatrixWithTieredPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithTieredPricingPriceVariant(value);

    public static implicit operator Price2(NewPlanCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewPlanCumulativeGroupedBulkPriceVariant(value);

    public static implicit operator Price2(NewPlanTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredPackageWithMinimumPriceVariant(value);

    public static implicit operator Price2(NewPlanMatrixWithAllocationPrice value) =>
        new PriceVariants::NewPlanMatrixWithAllocationPriceVariant(value);

    public static implicit operator Price2(NewPlanGroupedTieredPrice value) =>
        new PriceVariants::NewPlanGroupedTieredPriceVariant(value);

    public abstract void Validate();
}
