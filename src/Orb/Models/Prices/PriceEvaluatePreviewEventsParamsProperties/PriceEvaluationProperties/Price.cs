using Models = Orb.Models;
using Orb = Orb;
using PriceVariants = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties.PriceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties;

/// <summary>
/// An inline price definition to evaluate, allowing you to test price configurations
/// before adding them to Orb.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(Models::NewFloatingUnitPrice value) =>
        new PriceVariants::NewFloatingUnitPrice(value);

    public static implicit operator Price(Models::NewFloatingPackagePrice value) =>
        new PriceVariants::NewFloatingPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingMatrixPrice value) =>
        new PriceVariants::NewFloatingMatrixPrice(value);

    public static implicit operator Price(Models::NewFloatingMatrixWithAllocationPrice value) =>
        new PriceVariants::NewFloatingMatrixWithAllocationPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPrice value) =>
        new PriceVariants::NewFloatingTieredPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredBPSPrice value) =>
        new PriceVariants::NewFloatingTieredBPSPrice(value);

    public static implicit operator Price(Models::NewFloatingBPSPrice value) =>
        new PriceVariants::NewFloatingBPSPrice(value);

    public static implicit operator Price(Models::NewFloatingBulkBPSPrice value) =>
        new PriceVariants::NewFloatingBulkBPSPrice(value);

    public static implicit operator Price(Models::NewFloatingBulkPrice value) =>
        new PriceVariants::NewFloatingBulkPrice(value);

    public static implicit operator Price(Models::NewFloatingThresholdTotalAmountPrice value) =>
        new PriceVariants::NewFloatingThresholdTotalAmountPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPackagePrice value) =>
        new PriceVariants::NewFloatingTieredPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedTieredPrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPrice(value);

    public static implicit operator Price(Models::NewFloatingMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewFloatingMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingTieredWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredWithMinimumPrice(value);

    public static implicit operator Price(Models::NewFloatingPackageWithAllocationPrice value) =>
        new PriceVariants::NewFloatingPackageWithAllocationPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(Models::NewFloatingUnitWithPercentPrice value) =>
        new PriceVariants::NewFloatingUnitWithPercentPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredWithProrationPrice value) =>
        new PriceVariants::NewFloatingTieredWithProrationPrice(value);

    public static implicit operator Price(Models::NewFloatingUnitWithProrationPrice value) =>
        new PriceVariants::NewFloatingUnitWithProrationPrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedAllocationPrice value) =>
        new PriceVariants::NewFloatingGroupedAllocationPrice(value);

    public static implicit operator Price(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    ) => new PriceVariants::NewFloatingGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(Models::NewFloatingMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewFloatingMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(Models::NewFloatingBulkWithProrationPrice value) =>
        new PriceVariants::NewFloatingBulkWithProrationPrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedTieredPackagePrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPackagePrice(value);

    public static implicit operator Price(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(Models::NewFloatingCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewFloatingCumulativeGroupedBulkPrice(value);

    public abstract void Validate();
}
