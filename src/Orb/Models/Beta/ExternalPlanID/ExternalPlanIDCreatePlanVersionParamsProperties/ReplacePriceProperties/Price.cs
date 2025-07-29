using Models = Orb.Models;
using Orb = Orb;
using PriceVariants = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties;

/// <summary>
/// The price to add to the plan
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(Models::NewPlanUnitPrice value) =>
        new PriceVariants::NewPlanUnitPrice(value);

    public static implicit operator Price(Models::NewPlanPackagePrice value) =>
        new PriceVariants::NewPlanPackagePrice(value);

    public static implicit operator Price(Models::NewPlanMatrixPrice value) =>
        new PriceVariants::NewPlanMatrixPrice(value);

    public static implicit operator Price(Models::NewPlanTieredPrice value) =>
        new PriceVariants::NewPlanTieredPrice(value);

    public static implicit operator Price(Models::NewPlanTieredBPSPrice value) =>
        new PriceVariants::NewPlanTieredBPSPrice(value);

    public static implicit operator Price(Models::NewPlanBPSPrice value) =>
        new PriceVariants::NewPlanBPSPrice(value);

    public static implicit operator Price(Models::NewPlanBulkBPSPrice value) =>
        new PriceVariants::NewPlanBulkBPSPrice(value);

    public static implicit operator Price(Models::NewPlanBulkPrice value) =>
        new PriceVariants::NewPlanBulkPrice(value);

    public static implicit operator Price(Models::NewPlanThresholdTotalAmountPrice value) =>
        new PriceVariants::NewPlanThresholdTotalAmountPrice(value);

    public static implicit operator Price(Models::NewPlanTieredPackagePrice value) =>
        new PriceVariants::NewPlanTieredPackagePrice(value);

    public static implicit operator Price(Models::NewPlanTieredWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredWithMinimumPrice(value);

    public static implicit operator Price(Models::NewPlanUnitWithPercentPrice value) =>
        new PriceVariants::NewPlanUnitWithPercentPrice(value);

    public static implicit operator Price(Models::NewPlanPackageWithAllocationPrice value) =>
        new PriceVariants::NewPlanPackageWithAllocationPrice(value);

    public static implicit operator Price(Models::NewPlanTierWithProrationPrice value) =>
        new PriceVariants::NewPlanTierWithProrationPrice(value);

    public static implicit operator Price(Models::NewPlanUnitWithProrationPrice value) =>
        new PriceVariants::NewPlanUnitWithProrationPrice(value);

    public static implicit operator Price(Models::NewPlanGroupedAllocationPrice value) =>
        new PriceVariants::NewPlanGroupedAllocationPrice(value);

    public static implicit operator Price(Models::NewPlanGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(Models::NewPlanGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(Models::NewPlanMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewPlanMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(Models::NewPlanBulkWithProrationPrice value) =>
        new PriceVariants::NewPlanBulkWithProrationPrice(value);

    public static implicit operator Price(Models::NewPlanGroupedTieredPackagePrice value) =>
        new PriceVariants::NewPlanGroupedTieredPackagePrice(value);

    public static implicit operator Price(Models::NewPlanMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewPlanMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(
        Models::NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(
        Models::NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(Models::NewPlanCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewPlanCumulativeGroupedBulkPrice(value);

    public static implicit operator Price(Models::NewPlanTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(Models::NewPlanMatrixWithAllocationPrice value) =>
        new PriceVariants::NewPlanMatrixWithAllocationPrice(value);

    public static implicit operator Price(Models::NewPlanGroupedTieredPrice value) =>
        new PriceVariants::NewPlanGroupedTieredPrice(value);

    public abstract void Validate();
}
