using Orb = Orb;
using PriceVariants = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceVariants;
using Serialization = System.Text.Json.Serialization;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties;

/// <summary>
/// The definition of a new price to create and add to the subscription.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static PriceVariants::NewSubscriptionUnitPrice Create(
        Subscriptions::NewSubscriptionUnitPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionPackagePrice Create(
        Subscriptions::NewSubscriptionPackagePrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionMatrixPrice Create(
        Subscriptions::NewSubscriptionMatrixPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTieredPrice Create(
        Subscriptions::NewSubscriptionTieredPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTieredBPSPrice Create(
        Subscriptions::NewSubscriptionTieredBPSPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionBPSPrice Create(
        Subscriptions::NewSubscriptionBPSPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionBulkBPSPrice Create(
        Subscriptions::NewSubscriptionBulkBPSPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionBulkPrice Create(
        Subscriptions::NewSubscriptionBulkPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionThresholdTotalAmountPrice Create(
        Subscriptions::NewSubscriptionThresholdTotalAmountPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTieredPackagePrice Create(
        Subscriptions::NewSubscriptionTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTieredWithMinimumPrice Create(
        Subscriptions::NewSubscriptionTieredWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionUnitWithPercentPrice Create(
        Subscriptions::NewSubscriptionUnitWithPercentPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionPackageWithAllocationPrice Create(
        Subscriptions::NewSubscriptionPackageWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTierWithProrationPrice Create(
        Subscriptions::NewSubscriptionTierWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionUnitWithProrationPrice Create(
        Subscriptions::NewSubscriptionUnitWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionGroupedAllocationPrice Create(
        Subscriptions::NewSubscriptionGroupedAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice Create(
        Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionBulkWithProrationPrice Create(
        Subscriptions::NewSubscriptionBulkWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice Create(
        Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice Create(
        Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice Create(
        Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice Create(
        Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice Create(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice Create(
        Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionGroupedTieredPackagePrice Create(
        Subscriptions::NewSubscriptionGroupedTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionMatrixWithAllocationPrice Create(
        Subscriptions::NewSubscriptionMatrixWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice Create(
        Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewSubscriptionGroupedTieredPrice Create(
        Subscriptions::NewSubscriptionGroupedTieredPrice value
    ) => new(value);

    public abstract void Validate();
}
