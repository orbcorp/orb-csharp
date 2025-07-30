using System.Text.Json.Serialization;
using PriceVariants = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceVariants;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties;

/// <summary>
/// The definition of a new price to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(UnionConverter<Price1>))]
public abstract record class Price1
{
    internal Price1() { }

    public static implicit operator Price1(NewSubscriptionUnitPrice value) =>
        new PriceVariants::NewSubscriptionUnitPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionPackagePrice value) =>
        new PriceVariants::NewSubscriptionPackagePriceVariant(value);

    public static implicit operator Price1(NewSubscriptionMatrixPrice value) =>
        new PriceVariants::NewSubscriptionMatrixPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTieredPrice value) =>
        new PriceVariants::NewSubscriptionTieredPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTieredBPSPrice value) =>
        new PriceVariants::NewSubscriptionTieredBPSPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionBPSPrice value) =>
        new PriceVariants::NewSubscriptionBPSPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionBulkBPSPrice value) =>
        new PriceVariants::NewSubscriptionBulkBPSPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionBulkPrice value) =>
        new PriceVariants::NewSubscriptionBulkPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionThresholdTotalAmountPrice value) =>
        new PriceVariants::NewSubscriptionThresholdTotalAmountPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTieredWithMinimumPrice value) =>
        new PriceVariants::NewSubscriptionTieredWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionUnitWithPercentPrice value) =>
        new PriceVariants::NewSubscriptionUnitWithPercentPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionPackageWithAllocationPrice value) =>
        new PriceVariants::NewSubscriptionPackageWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTierWithProrationPrice value) =>
        new PriceVariants::NewSubscriptionTierWithProrationPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionUnitWithProrationPrice value) =>
        new PriceVariants::NewSubscriptionUnitWithProrationPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionGroupedAllocationPrice value) =>
        new PriceVariants::NewSubscriptionGroupedAllocationPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewSubscriptionGroupedWithProratedMinimumPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionBulkWithProrationPrice value) =>
        new PriceVariants::NewSubscriptionBulkWithProrationPriceVariant(value);

    public static implicit operator Price1(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPriceVariant(value);

    public static implicit operator Price1(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewSubscriptionCumulativeGroupedBulkPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionMaxGroupTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewSubscriptionGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewSubscriptionMatrixWithDisplayNamePriceVariant(value);

    public static implicit operator Price1(NewSubscriptionGroupedTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionGroupedTieredPackagePriceVariant(value);

    public static implicit operator Price1(NewSubscriptionMatrixWithAllocationPrice value) =>
        new PriceVariants::NewSubscriptionMatrixWithAllocationPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewSubscriptionTieredPackageWithMinimumPriceVariant(value);

    public static implicit operator Price1(NewSubscriptionGroupedTieredPrice value) =>
        new PriceVariants::NewSubscriptionGroupedTieredPriceVariant(value);

    public abstract void Validate();
}
