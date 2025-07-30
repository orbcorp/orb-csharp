using System.Text.Json.Serialization;
using PriceVariants = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceVariants;

namespace Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties;

/// <summary>
/// An inline price definition to evaluate, allowing you to test price configurations
/// before adding them to Orb.
/// </summary>
[JsonConverter(typeof(UnionConverter<Price1>))]
public abstract record class Price1
{
    internal Price1() { }

    public static implicit operator Price1(NewFloatingUnitPrice value) =>
        new PriceVariants::NewFloatingUnitPriceVariant(value);

    public static implicit operator Price1(NewFloatingPackagePrice value) =>
        new PriceVariants::NewFloatingPackagePriceVariant(value);

    public static implicit operator Price1(NewFloatingMatrixPrice value) =>
        new PriceVariants::NewFloatingMatrixPriceVariant(value);

    public static implicit operator Price1(NewFloatingMatrixWithAllocationPrice value) =>
        new PriceVariants::NewFloatingMatrixWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredPrice value) =>
        new PriceVariants::NewFloatingTieredPriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredBPSPrice value) =>
        new PriceVariants::NewFloatingTieredBPSPriceVariant(value);

    public static implicit operator Price1(NewFloatingBPSPrice value) =>
        new PriceVariants::NewFloatingBPSPriceVariant(value);

    public static implicit operator Price1(NewFloatingBulkBPSPrice value) =>
        new PriceVariants::NewFloatingBulkBPSPriceVariant(value);

    public static implicit operator Price1(NewFloatingBulkPrice value) =>
        new PriceVariants::NewFloatingBulkPriceVariant(value);

    public static implicit operator Price1(NewFloatingThresholdTotalAmountPrice value) =>
        new PriceVariants::NewFloatingThresholdTotalAmountPriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredPackagePrice value) =>
        new PriceVariants::NewFloatingTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewFloatingGroupedTieredPrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPriceVariant(value);

    public static implicit operator Price1(NewFloatingMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewFloatingMaxGroupTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewFloatingPackageWithAllocationPrice value) =>
        new PriceVariants::NewFloatingPackageWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredPackageWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewFloatingUnitWithPercentPrice value) =>
        new PriceVariants::NewFloatingUnitWithPercentPriceVariant(value);

    public static implicit operator Price1(NewFloatingTieredWithProrationPrice value) =>
        new PriceVariants::NewFloatingTieredWithProrationPriceVariant(value);

    public static implicit operator Price1(NewFloatingUnitWithProrationPrice value) =>
        new PriceVariants::NewFloatingUnitWithProrationPriceVariant(value);

    public static implicit operator Price1(NewFloatingGroupedAllocationPrice value) =>
        new PriceVariants::NewFloatingGroupedAllocationPriceVariant(value);

    public static implicit operator Price1(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewFloatingGroupedWithProratedMinimumPriceVariant(value);

    public static implicit operator Price1(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewFloatingGroupedWithMeteredMinimumPriceVariant(value);

    public static implicit operator Price1(NewFloatingMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewFloatingMatrixWithDisplayNamePriceVariant(value);

    public static implicit operator Price1(NewFloatingBulkWithProrationPrice value) =>
        new PriceVariants::NewFloatingBulkWithProrationPriceVariant(value);

    public static implicit operator Price1(NewFloatingGroupedTieredPackagePrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewFloatingScalableMatrixWithUnitPricingPrice value) =>
        new PriceVariants::NewFloatingScalableMatrixWithUnitPricingPriceVariant(value);

    public static implicit operator Price1(NewFloatingScalableMatrixWithTieredPricingPrice value) =>
        new PriceVariants::NewFloatingScalableMatrixWithTieredPricingPriceVariant(value);

    public static implicit operator Price1(NewFloatingCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewFloatingCumulativeGroupedBulkPriceVariant(value);

    public abstract void Validate();
}
