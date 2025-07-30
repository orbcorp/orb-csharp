using System.Text.Json.Serialization;
using BodyVariants = Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;

namespace Orb.Models.Prices.PriceCreateParamsProperties;

[JsonConverter(typeof(UnionConverter<Body>))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(NewFloatingUnitPrice value) =>
        new BodyVariants::NewFloatingUnitPriceVariant(value);

    public static implicit operator Body(NewFloatingPackagePrice value) =>
        new BodyVariants::NewFloatingPackagePriceVariant(value);

    public static implicit operator Body(NewFloatingMatrixPrice value) =>
        new BodyVariants::NewFloatingMatrixPriceVariant(value);

    public static implicit operator Body(NewFloatingMatrixWithAllocationPrice value) =>
        new BodyVariants::NewFloatingMatrixWithAllocationPriceVariant(value);

    public static implicit operator Body(NewFloatingTieredPrice value) =>
        new BodyVariants::NewFloatingTieredPriceVariant(value);

    public static implicit operator Body(NewFloatingTieredBPSPrice value) =>
        new BodyVariants::NewFloatingTieredBPSPriceVariant(value);

    public static implicit operator Body(NewFloatingBPSPrice value) =>
        new BodyVariants::NewFloatingBPSPriceVariant(value);

    public static implicit operator Body(NewFloatingBulkBPSPrice value) =>
        new BodyVariants::NewFloatingBulkBPSPriceVariant(value);

    public static implicit operator Body(NewFloatingBulkPrice value) =>
        new BodyVariants::NewFloatingBulkPriceVariant(value);

    public static implicit operator Body(NewFloatingThresholdTotalAmountPrice value) =>
        new BodyVariants::NewFloatingThresholdTotalAmountPriceVariant(value);

    public static implicit operator Body(NewFloatingTieredPackagePrice value) =>
        new BodyVariants::NewFloatingTieredPackagePriceVariant(value);

    public static implicit operator Body(NewFloatingGroupedTieredPrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPriceVariant(value);

    public static implicit operator Body(NewFloatingMaxGroupTieredPackagePrice value) =>
        new BodyVariants::NewFloatingMaxGroupTieredPackagePriceVariant(value);

    public static implicit operator Body(NewFloatingTieredWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredWithMinimumPriceVariant(value);

    public static implicit operator Body(NewFloatingPackageWithAllocationPrice value) =>
        new BodyVariants::NewFloatingPackageWithAllocationPriceVariant(value);

    public static implicit operator Body(NewFloatingTieredPackageWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredPackageWithMinimumPriceVariant(value);

    public static implicit operator Body(NewFloatingUnitWithPercentPrice value) =>
        new BodyVariants::NewFloatingUnitWithPercentPriceVariant(value);

    public static implicit operator Body(NewFloatingTieredWithProrationPrice value) =>
        new BodyVariants::NewFloatingTieredWithProrationPriceVariant(value);

    public static implicit operator Body(NewFloatingUnitWithProrationPrice value) =>
        new BodyVariants::NewFloatingUnitWithProrationPriceVariant(value);

    public static implicit operator Body(NewFloatingGroupedAllocationPrice value) =>
        new BodyVariants::NewFloatingGroupedAllocationPriceVariant(value);

    public static implicit operator Body(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new BodyVariants::NewFloatingGroupedWithProratedMinimumPriceVariant(value);

    public static implicit operator Body(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new BodyVariants::NewFloatingGroupedWithMeteredMinimumPriceVariant(value);

    public static implicit operator Body(NewFloatingMatrixWithDisplayNamePrice value) =>
        new BodyVariants::NewFloatingMatrixWithDisplayNamePriceVariant(value);

    public static implicit operator Body(NewFloatingBulkWithProrationPrice value) =>
        new BodyVariants::NewFloatingBulkWithProrationPriceVariant(value);

    public static implicit operator Body(NewFloatingGroupedTieredPackagePrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPackagePriceVariant(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithUnitPricingPrice value) =>
        new BodyVariants::NewFloatingScalableMatrixWithUnitPricingPriceVariant(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithTieredPricingPrice value) =>
        new BodyVariants::NewFloatingScalableMatrixWithTieredPricingPriceVariant(value);

    public static implicit operator Body(NewFloatingCumulativeGroupedBulkPrice value) =>
        new BodyVariants::NewFloatingCumulativeGroupedBulkPriceVariant(value);

    public abstract void Validate();
}
