using Orb = Orb;
using PriceProperties = Orb.Models.PriceProperties;
using PriceVariants = Orb.Models.PriceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models;

/// <summary>
/// The Price resource represents a price that can be billed on a subscription, resulting
/// in a charge on an invoice in the form of an invoice line item. Prices take a
/// quantity and determine an amount to bill.
///
/// Orb supports a few different pricing models out of the box. Each of these models
/// is serialized differently in a given Price object. The model_type field determines
/// the key for the configuration object that is present.
///
/// For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static PriceVariants::Unit Create(PriceProperties::Unit value) => new(value);

    public static PriceVariants::Package Create(PriceProperties::Package value) => new(value);

    public static PriceVariants::Matrix Create(PriceProperties::Matrix value) => new(value);

    public static PriceVariants::Tiered Create(PriceProperties::Tiered value) => new(value);

    public static PriceVariants::TieredBPS Create(PriceProperties::TieredBPS value) => new(value);

    public static PriceVariants::BPS Create(PriceProperties::BPS value) => new(value);

    public static PriceVariants::BulkBPS Create(PriceProperties::BulkBPS value) => new(value);

    public static PriceVariants::Bulk Create(PriceProperties::Bulk value) => new(value);

    public static PriceVariants::ThresholdTotalAmount Create(
        PriceProperties::ThresholdTotalAmount value
    ) => new(value);

    public static PriceVariants::TieredPackage Create(PriceProperties::TieredPackage value) =>
        new(value);

    public static PriceVariants::GroupedTiered Create(PriceProperties::GroupedTiered value) =>
        new(value);

    public static PriceVariants::TieredWithMinimum Create(
        PriceProperties::TieredWithMinimum value
    ) => new(value);

    public static PriceVariants::TieredPackageWithMinimum Create(
        PriceProperties::TieredPackageWithMinimum value
    ) => new(value);

    public static PriceVariants::PackageWithAllocation Create(
        PriceProperties::PackageWithAllocation value
    ) => new(value);

    public static PriceVariants::UnitWithPercent Create(PriceProperties::UnitWithPercent value) =>
        new(value);

    public static PriceVariants::MatrixWithAllocation Create(
        PriceProperties::MatrixWithAllocation value
    ) => new(value);

    public static PriceVariants::TieredWithProration Create(
        PriceProperties::TieredWithProration value
    ) => new(value);

    public static PriceVariants::UnitWithProration Create(
        PriceProperties::UnitWithProration value
    ) => new(value);

    public static PriceVariants::GroupedAllocation Create(
        PriceProperties::GroupedAllocation value
    ) => new(value);

    public static PriceVariants::GroupedWithProratedMinimum Create(
        PriceProperties::GroupedWithProratedMinimum value
    ) => new(value);

    public static PriceVariants::GroupedWithMeteredMinimum Create(
        PriceProperties::GroupedWithMeteredMinimum value
    ) => new(value);

    public static PriceVariants::MatrixWithDisplayName Create(
        PriceProperties::MatrixWithDisplayName value
    ) => new(value);

    public static PriceVariants::BulkWithProration Create(
        PriceProperties::BulkWithProration value
    ) => new(value);

    public static PriceVariants::GroupedTieredPackage Create(
        PriceProperties::GroupedTieredPackage value
    ) => new(value);

    public static PriceVariants::MaxGroupTieredPackage Create(
        PriceProperties::MaxGroupTieredPackage value
    ) => new(value);

    public static PriceVariants::ScalableMatrixWithUnitPricing Create(
        PriceProperties::ScalableMatrixWithUnitPricing value
    ) => new(value);

    public static PriceVariants::ScalableMatrixWithTieredPricing Create(
        PriceProperties::ScalableMatrixWithTieredPricing value
    ) => new(value);

    public static PriceVariants::CumulativeGroupedBulk Create(
        PriceProperties::CumulativeGroupedBulk value
    ) => new(value);

    public static PriceVariants::GroupedWithMinMaxThresholds Create(
        PriceProperties::GroupedWithMinMaxThresholds value
    ) => new(value);

    public abstract void Validate();
}
