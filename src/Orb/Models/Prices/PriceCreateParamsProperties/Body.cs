using BodyVariants = Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Body>))]
public abstract record class Body
{
    internal Body() { }

    public static BodyVariants::NewFloatingUnitPrice Create(Models::NewFloatingUnitPrice value) =>
        new(value);

    public static BodyVariants::NewFloatingPackagePrice Create(
        Models::NewFloatingPackagePrice value
    ) => new(value);

    public static BodyVariants::NewFloatingMatrixPrice Create(
        Models::NewFloatingMatrixPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingMatrixWithAllocationPrice Create(
        Models::NewFloatingMatrixWithAllocationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredPrice Create(
        Models::NewFloatingTieredPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredBPSPrice Create(
        Models::NewFloatingTieredBPSPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingBPSPrice Create(Models::NewFloatingBPSPrice value) =>
        new(value);

    public static BodyVariants::NewFloatingBulkBPSPrice Create(
        Models::NewFloatingBulkBPSPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingBulkPrice Create(Models::NewFloatingBulkPrice value) =>
        new(value);

    public static BodyVariants::NewFloatingThresholdTotalAmountPrice Create(
        Models::NewFloatingThresholdTotalAmountPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredPackagePrice Create(
        Models::NewFloatingTieredPackagePrice value
    ) => new(value);

    public static BodyVariants::NewFloatingGroupedTieredPrice Create(
        Models::NewFloatingGroupedTieredPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingMaxGroupTieredPackagePrice Create(
        Models::NewFloatingMaxGroupTieredPackagePrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredWithMinimumPrice Create(
        Models::NewFloatingTieredWithMinimumPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingPackageWithAllocationPrice Create(
        Models::NewFloatingPackageWithAllocationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredPackageWithMinimumPrice Create(
        Models::NewFloatingTieredPackageWithMinimumPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingUnitWithPercentPrice Create(
        Models::NewFloatingUnitWithPercentPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingTieredWithProrationPrice Create(
        Models::NewFloatingTieredWithProrationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingUnitWithProrationPrice Create(
        Models::NewFloatingUnitWithProrationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingGroupedAllocationPrice Create(
        Models::NewFloatingGroupedAllocationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingGroupedWithProratedMinimumPrice Create(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice Create(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingMatrixWithDisplayNamePrice Create(
        Models::NewFloatingMatrixWithDisplayNamePrice value
    ) => new(value);

    public static BodyVariants::NewFloatingBulkWithProrationPrice Create(
        Models::NewFloatingBulkWithProrationPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingGroupedTieredPackagePrice Create(
        Models::NewFloatingGroupedTieredPackagePrice value
    ) => new(value);

    public static BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice Create(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice Create(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static BodyVariants::NewFloatingCumulativeGroupedBulkPrice Create(
        Models::NewFloatingCumulativeGroupedBulkPrice value
    ) => new(value);

    public abstract void Validate();
}
