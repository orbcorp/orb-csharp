using Models = Orb.Models;
using Orb = Orb;
using PriceVariants = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;

/// <summary>
/// The price to add to the plan
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static PriceVariants::NewPlanUnitPrice Create(Models::NewPlanUnitPrice value) =>
        new(value);

    public static PriceVariants::NewPlanPackagePrice Create(Models::NewPlanPackagePrice value) =>
        new(value);

    public static PriceVariants::NewPlanMatrixPrice Create(Models::NewPlanMatrixPrice value) =>
        new(value);

    public static PriceVariants::NewPlanTieredPrice Create(Models::NewPlanTieredPrice value) =>
        new(value);

    public static PriceVariants::NewPlanTieredBPSPrice Create(
        Models::NewPlanTieredBPSPrice value
    ) => new(value);

    public static PriceVariants::NewPlanBPSPrice Create(Models::NewPlanBPSPrice value) =>
        new(value);

    public static PriceVariants::NewPlanBulkBPSPrice Create(Models::NewPlanBulkBPSPrice value) =>
        new(value);

    public static PriceVariants::NewPlanBulkPrice Create(Models::NewPlanBulkPrice value) =>
        new(value);

    public static PriceVariants::NewPlanThresholdTotalAmountPrice Create(
        Models::NewPlanThresholdTotalAmountPrice value
    ) => new(value);

    public static PriceVariants::NewPlanTieredPackagePrice Create(
        Models::NewPlanTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewPlanTieredWithMinimumPrice Create(
        Models::NewPlanTieredWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewPlanUnitWithPercentPrice Create(
        Models::NewPlanUnitWithPercentPrice value
    ) => new(value);

    public static PriceVariants::NewPlanPackageWithAllocationPrice Create(
        Models::NewPlanPackageWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanTierWithProrationPrice Create(
        Models::NewPlanTierWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanUnitWithProrationPrice Create(
        Models::NewPlanUnitWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanGroupedAllocationPrice Create(
        Models::NewPlanGroupedAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanGroupedWithProratedMinimumPrice Create(
        Models::NewPlanGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewPlanGroupedWithMeteredMinimumPrice Create(
        Models::NewPlanGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewPlanMatrixWithDisplayNamePrice Create(
        Models::NewPlanMatrixWithDisplayNamePrice value
    ) => new(value);

    public static PriceVariants::NewPlanBulkWithProrationPrice Create(
        Models::NewPlanBulkWithProrationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanGroupedTieredPackagePrice Create(
        Models::NewPlanGroupedTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewPlanMaxGroupTieredPackagePrice Create(
        Models::NewPlanMaxGroupTieredPackagePrice value
    ) => new(value);

    public static PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice Create(
        Models::NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice Create(
        Models::NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static PriceVariants::NewPlanCumulativeGroupedBulkPrice Create(
        Models::NewPlanCumulativeGroupedBulkPrice value
    ) => new(value);

    public static PriceVariants::NewPlanTieredPackageWithMinimumPrice Create(
        Models::NewPlanTieredPackageWithMinimumPrice value
    ) => new(value);

    public static PriceVariants::NewPlanMatrixWithAllocationPrice Create(
        Models::NewPlanMatrixWithAllocationPrice value
    ) => new(value);

    public static PriceVariants::NewPlanGroupedTieredPrice Create(
        Models::NewPlanGroupedTieredPrice value
    ) => new(value);

    public abstract void Validate();
}
