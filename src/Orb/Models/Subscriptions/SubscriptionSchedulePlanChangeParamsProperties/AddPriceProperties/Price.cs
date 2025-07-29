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

    public static implicit operator Price(Subscriptions::NewSubscriptionUnitPrice value) =>
        new PriceVariants::NewSubscriptionUnitPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionPackagePrice value) =>
        new PriceVariants::NewSubscriptionPackagePrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionMatrixPrice value) =>
        new PriceVariants::NewSubscriptionMatrixPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionTieredPrice value) =>
        new PriceVariants::NewSubscriptionTieredPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionTieredBPSPrice value) =>
        new PriceVariants::NewSubscriptionTieredBPSPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionBPSPrice value) =>
        new PriceVariants::NewSubscriptionBPSPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionBulkBPSPrice value) =>
        new PriceVariants::NewSubscriptionBulkBPSPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionBulkPrice value) =>
        new PriceVariants::NewSubscriptionBulkPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionThresholdTotalAmountPrice value
    ) => new PriceVariants::NewSubscriptionThresholdTotalAmountPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionTieredPackagePrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionTieredWithMinimumPrice value
    ) => new PriceVariants::NewSubscriptionTieredWithMinimumPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionUnitWithPercentPrice value
    ) => new PriceVariants::NewSubscriptionUnitWithPercentPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionPackageWithAllocationPrice value
    ) => new PriceVariants::NewSubscriptionPackageWithAllocationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionTierWithProrationPrice value
    ) => new PriceVariants::NewSubscriptionTierWithProrationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionUnitWithProrationPrice value
    ) => new PriceVariants::NewSubscriptionUnitWithProrationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionGroupedAllocationPrice value
    ) => new PriceVariants::NewSubscriptionGroupedAllocationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionGroupedWithProratedMinimumPrice value
    ) => new PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionBulkWithProrationPrice value
    ) => new PriceVariants::NewSubscriptionBulkWithProrationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionCumulativeGroupedBulkPrice value
    ) => new PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionMaxGroupTieredPackagePrice value
    ) => new PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionGroupedWithMeteredMinimumPrice value
    ) => new PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionMatrixWithDisplayNamePrice value
    ) => new PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionGroupedTieredPackagePrice value
    ) => new PriceVariants::NewSubscriptionGroupedTieredPackagePrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionMatrixWithAllocationPrice value
    ) => new PriceVariants::NewSubscriptionMatrixWithAllocationPrice(value);

    public static implicit operator Price(
        Subscriptions::NewSubscriptionTieredPackageWithMinimumPrice value
    ) => new PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(Subscriptions::NewSubscriptionGroupedTieredPrice value) =>
        new PriceVariants::NewSubscriptionGroupedTieredPrice(value);

    public abstract void Validate();
}
