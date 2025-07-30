using System.Text.Json.Serialization;
using PriceVariants = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceVariants;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties;

/// <summary>
/// The price to add to the plan
/// </summary>
[JsonConverter(typeof(UnionConverter<Price1>))]
public abstract record class Price1
{
    internal Price1() { }

    public static implicit operator Price1(NewPlanUnitPrice value) =>
        new PriceVariants::NewPlanUnitPriceVariant(value);

    public static implicit operator Price1(NewPlanPackagePrice value) =>
        new PriceVariants::NewPlanPackagePriceVariant(value);

    public static implicit operator Price1(NewPlanMatrixPrice value) =>
        new PriceVariants::NewPlanMatrixPriceVariant(value);

    public static implicit operator Price1(NewPlanTieredPrice value) =>
        new PriceVariants::NewPlanTieredPriceVariant(value);

    public static implicit operator Price1(NewPlanTieredBPSPrice value) =>
        new PriceVariants::NewPlanTieredBPSPriceVariant(value);

    public static implicit operator Price1(NewPlanBPSPrice value) =>
        new PriceVariants::NewPlanBPSPriceVariant(value);

    public static implicit operator Price1(NewPlanBulkBPSPrice value) =>
        new PriceVariants::NewPlanBulkBPSPriceVariant(value);

    public static implicit operator Price1(NewPlanBulkPrice value) =>
        new PriceVariants::NewPlanBulkPriceVariant(value);

    public static implicit operator Price1(NewPlanThresholdTotalAmountPrice value) =>
        new PriceVariants::NewPlanThresholdTotalAmountPriceVariant(value);

    public static implicit operator Price1(NewPlanTieredPackagePrice value) =>
        new PriceVariants::NewPlanTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewPlanTieredWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewPlanUnitWithPercentPrice value) =>
        new PriceVariants::NewPlanUnitWithPercentPriceVariant(value);

    public static implicit operator Price1(NewPlanPackageWithAllocationPrice value) =>
        new PriceVariants::NewPlanPackageWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewPlanTierWithProrationPrice value) =>
        new PriceVariants::NewPlanTierWithProrationPriceVariant(value);

    public static implicit operator Price1(NewPlanUnitWithProrationPrice value) =>
        new PriceVariants::NewPlanUnitWithProrationPriceVariant(value);

    public static implicit operator Price1(NewPlanGroupedAllocationPrice value) =>
        new PriceVariants::NewPlanGroupedAllocationPriceVariant(value);

    public static implicit operator Price1(NewPlanGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithProratedMinimumPriceVariant(value);

    public static implicit operator Price1(NewPlanGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithMeteredMinimumPriceVariant(value);

    public static implicit operator Price1(NewPlanMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewPlanMatrixWithDisplayNamePriceVariant(value);

    public static implicit operator Price1(NewPlanBulkWithProrationPrice value) =>
        new PriceVariants::NewPlanBulkWithProrationPriceVariant(value);

    public static implicit operator Price1(NewPlanGroupedTieredPackagePrice value) =>
        new PriceVariants::NewPlanGroupedTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewPlanMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewPlanMaxGroupTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewPlanScalableMatrixWithUnitPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithUnitPricingPriceVariant(value);

    public static implicit operator Price1(NewPlanScalableMatrixWithTieredPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithTieredPricingPriceVariant(value);

    public static implicit operator Price1(NewPlanCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewPlanCumulativeGroupedBulkPriceVariant(value);

    public static implicit operator Price1(NewPlanTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredPackageWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewPlanMatrixWithAllocationPrice value) =>
        new PriceVariants::NewPlanMatrixWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewPlanGroupedTieredPrice value) =>
        new PriceVariants::NewPlanGroupedTieredPriceVariant(value);

    public abstract void Validate();
}
