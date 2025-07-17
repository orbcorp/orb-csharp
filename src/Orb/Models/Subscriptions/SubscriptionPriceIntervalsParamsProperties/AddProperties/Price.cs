using Models = Orb.Models;
using Orb = Orb;
using PriceVariants = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.PriceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;

/// <summary>
/// The definition of a new price to create and add to the subscription.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static PriceVariants::NewFloatingUnitPrice Create(Models::NewFloatingUnitPrice value) =>
        new(value);

    public static PriceVariants::NewFloatingPackagePrice Create(
        Models::NewFloatingPackagePrice value
    ) => new(value);

    public static PriceVariants::NewFloatingMatrixPrice Create(
        Models::NewFloatingMatrixPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingMatrixWithAllocationPrice Create(
        Models::NewFloatingMatrixWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredPrice Create(
        Models::NewFloatingTieredPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredBPSPrice Create(
        Models::NewFloatingTieredBPSPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingBPSPrice Create(Models::NewFloatingBPSPrice value) =>
        new(value);

    public static PriceVariants::NewFloatingBulkBPSPrice Create(
        Models::NewFloatingBulkBPSPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingBulkPrice Create(Models::NewFloatingBulkPrice value) =>
        new(value);

    public static PriceVariants::NewFloatingThresholdTotalAmountPrice Create(
        Models::NewFloatingThresholdTotalAmountPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredPackagePrice Create(
        Models::NewFloatingTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewFloatingGroupedTieredPrice Create(
        Models::NewFloatingGroupedTieredPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingMaxGroupTieredPackagePrice Create(
        Models::NewFloatingMaxGroupTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredWithMinimumPrice Create(
        Models::NewFloatingTieredWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingPackageWithAllocationPrice Create(
        Models::NewFloatingPackageWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredPackageWithMinimumPrice Create(
        Models::NewFloatingTieredPackageWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingUnitWithPercentPrice Create(
        Models::NewFloatingUnitWithPercentPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingTieredWithProrationPrice Create(
        Models::NewFloatingTieredWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingUnitWithProrationPrice Create(
        Models::NewFloatingUnitWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingGroupedAllocationPrice Create(
        Models::NewFloatingGroupedAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingGroupedWithProratedMinimumPrice Create(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice Create(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingMatrixWithDisplayNamePrice Create(
        Models::NewFloatingMatrixWithDisplayNamePrice value
    ) => new(value);

    public static PriceVariants::NewFloatingBulkWithProrationPrice Create(
        Models::NewFloatingBulkWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingGroupedTieredPackagePrice Create(
        Models::NewFloatingGroupedTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice Create(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice Create(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static PriceVariants::NewFloatingCumulativeGroupedBulkPrice Create(
        Models::NewFloatingCumulativeGroupedBulkPrice value
    ) => new(value);

    public abstract void Validate();
}
