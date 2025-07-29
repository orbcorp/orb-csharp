using BodyVariants = Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Body>))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(Models::NewFloatingUnitPrice value) =>
        new BodyVariants::NewFloatingUnitPrice(value);

    public static implicit operator Body(Models::NewFloatingPackagePrice value) =>
        new BodyVariants::NewFloatingPackagePrice(value);

    public static implicit operator Body(Models::NewFloatingMatrixPrice value) =>
        new BodyVariants::NewFloatingMatrixPrice(value);

    public static implicit operator Body(Models::NewFloatingMatrixWithAllocationPrice value) =>
        new BodyVariants::NewFloatingMatrixWithAllocationPrice(value);

    public static implicit operator Body(Models::NewFloatingTieredPrice value) =>
        new BodyVariants::NewFloatingTieredPrice(value);

    public static implicit operator Body(Models::NewFloatingTieredBPSPrice value) =>
        new BodyVariants::NewFloatingTieredBPSPrice(value);

    public static implicit operator Body(Models::NewFloatingBPSPrice value) =>
        new BodyVariants::NewFloatingBPSPrice(value);

    public static implicit operator Body(Models::NewFloatingBulkBPSPrice value) =>
        new BodyVariants::NewFloatingBulkBPSPrice(value);

    public static implicit operator Body(Models::NewFloatingBulkPrice value) =>
        new BodyVariants::NewFloatingBulkPrice(value);

    public static implicit operator Body(Models::NewFloatingThresholdTotalAmountPrice value) =>
        new BodyVariants::NewFloatingThresholdTotalAmountPrice(value);

    public static implicit operator Body(Models::NewFloatingTieredPackagePrice value) =>
        new BodyVariants::NewFloatingTieredPackagePrice(value);

    public static implicit operator Body(Models::NewFloatingGroupedTieredPrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPrice(value);

    public static implicit operator Body(Models::NewFloatingMaxGroupTieredPackagePrice value) =>
        new BodyVariants::NewFloatingMaxGroupTieredPackagePrice(value);

    public static implicit operator Body(Models::NewFloatingTieredWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredWithMinimumPrice(value);

    public static implicit operator Body(Models::NewFloatingPackageWithAllocationPrice value) =>
        new BodyVariants::NewFloatingPackageWithAllocationPrice(value);

    public static implicit operator Body(Models::NewFloatingTieredPackageWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredPackageWithMinimumPrice(value);

    public static implicit operator Body(Models::NewFloatingUnitWithPercentPrice value) =>
        new BodyVariants::NewFloatingUnitWithPercentPrice(value);

    public static implicit operator Body(Models::NewFloatingTieredWithProrationPrice value) =>
        new BodyVariants::NewFloatingTieredWithProrationPrice(value);

    public static implicit operator Body(Models::NewFloatingUnitWithProrationPrice value) =>
        new BodyVariants::NewFloatingUnitWithProrationPrice(value);

    public static implicit operator Body(Models::NewFloatingGroupedAllocationPrice value) =>
        new BodyVariants::NewFloatingGroupedAllocationPrice(value);

    public static implicit operator Body(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    ) => new BodyVariants::NewFloatingGroupedWithProratedMinimumPrice(value);

    public static implicit operator Body(Models::NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Body(Models::NewFloatingMatrixWithDisplayNamePrice value) =>
        new BodyVariants::NewFloatingMatrixWithDisplayNamePrice(value);

    public static implicit operator Body(Models::NewFloatingBulkWithProrationPrice value) =>
        new BodyVariants::NewFloatingBulkWithProrationPrice(value);

    public static implicit operator Body(Models::NewFloatingGroupedTieredPackagePrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPackagePrice(value);

    public static implicit operator Body(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Body(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Body(Models::NewFloatingCumulativeGroupedBulkPrice value) =>
        new BodyVariants::NewFloatingCumulativeGroupedBulkPrice(value);

    public abstract void Validate();
}
