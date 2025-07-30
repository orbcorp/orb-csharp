using System.Text.Json.Serialization;
using PriceProperties = Orb.Models.PriceProperties;
using PriceVariants = Orb.Models.PriceVariants;

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
[JsonConverter(typeof(UnionConverter<Price>))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(PriceProperties::Unit value) =>
        new PriceVariants::Unit(value);

    public static implicit operator Price(PriceProperties::Package value) =>
        new PriceVariants::Package(value);

    public static implicit operator Price(PriceProperties::Matrix value) =>
        new PriceVariants::Matrix(value);

    public static implicit operator Price(PriceProperties::Tiered value) =>
        new PriceVariants::Tiered(value);

    public static implicit operator Price(PriceProperties::TieredBPS value) =>
        new PriceVariants::TieredBPS(value);

    public static implicit operator Price(PriceProperties::BPS value) =>
        new PriceVariants::BPS(value);

    public static implicit operator Price(PriceProperties::BulkBPS value) =>
        new PriceVariants::BulkBPS(value);

    public static implicit operator Price(PriceProperties::Bulk value) =>
        new PriceVariants::Bulk(value);

    public static implicit operator Price(PriceProperties::ThresholdTotalAmount value) =>
        new PriceVariants::ThresholdTotalAmount(value);

    public static implicit operator Price(PriceProperties::TieredPackage value) =>
        new PriceVariants::TieredPackage(value);

    public static implicit operator Price(PriceProperties::GroupedTiered value) =>
        new PriceVariants::GroupedTiered(value);

    public static implicit operator Price(PriceProperties::TieredWithMinimum value) =>
        new PriceVariants::TieredWithMinimum(value);

    public static implicit operator Price(PriceProperties::TieredPackageWithMinimum value) =>
        new PriceVariants::TieredPackageWithMinimum(value);

    public static implicit operator Price(PriceProperties::PackageWithAllocation value) =>
        new PriceVariants::PackageWithAllocation(value);

    public static implicit operator Price(PriceProperties::UnitWithPercent value) =>
        new PriceVariants::UnitWithPercent(value);

    public static implicit operator Price(PriceProperties::MatrixWithAllocation value) =>
        new PriceVariants::MatrixWithAllocation(value);

    public static implicit operator Price(PriceProperties::TieredWithProration value) =>
        new PriceVariants::TieredWithProration(value);

    public static implicit operator Price(PriceProperties::UnitWithProration value) =>
        new PriceVariants::UnitWithProration(value);

    public static implicit operator Price(PriceProperties::GroupedAllocation value) =>
        new PriceVariants::GroupedAllocation(value);

    public static implicit operator Price(PriceProperties::GroupedWithProratedMinimum value) =>
        new PriceVariants::GroupedWithProratedMinimum(value);

    public static implicit operator Price(PriceProperties::GroupedWithMeteredMinimum value) =>
        new PriceVariants::GroupedWithMeteredMinimum(value);

    public static implicit operator Price(PriceProperties::MatrixWithDisplayName value) =>
        new PriceVariants::MatrixWithDisplayName(value);

    public static implicit operator Price(PriceProperties::BulkWithProration value) =>
        new PriceVariants::BulkWithProration(value);

    public static implicit operator Price(PriceProperties::GroupedTieredPackage value) =>
        new PriceVariants::GroupedTieredPackage(value);

    public static implicit operator Price(PriceProperties::MaxGroupTieredPackage value) =>
        new PriceVariants::MaxGroupTieredPackage(value);

    public static implicit operator Price(PriceProperties::ScalableMatrixWithUnitPricing value) =>
        new PriceVariants::ScalableMatrixWithUnitPricing(value);

    public static implicit operator Price(PriceProperties::ScalableMatrixWithTieredPricing value) =>
        new PriceVariants::ScalableMatrixWithTieredPricing(value);

    public static implicit operator Price(PriceProperties::CumulativeGroupedBulk value) =>
        new PriceVariants::CumulativeGroupedBulk(value);

    public static implicit operator Price(PriceProperties::GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public abstract void Validate();
}
