using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.PriceProperties;
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
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(Unit value) => new PriceVariants::Unit(value);

    public static implicit operator Price(Package value) => new PriceVariants::Package(value);

    public static implicit operator Price(Matrix value) => new PriceVariants::Matrix(value);

    public static implicit operator Price(Tiered value) => new PriceVariants::Tiered(value);

    public static implicit operator Price(TieredBPS value) => new PriceVariants::TieredBPS(value);

    public static implicit operator Price(BPS value) => new PriceVariants::BPS(value);

    public static implicit operator Price(BulkBPS value) => new PriceVariants::BulkBPS(value);

    public static implicit operator Price(Bulk value) => new PriceVariants::Bulk(value);

    public static implicit operator Price(ThresholdTotalAmount value) =>
        new PriceVariants::ThresholdTotalAmount(value);

    public static implicit operator Price(TieredPackage value) =>
        new PriceVariants::TieredPackage(value);

    public static implicit operator Price(GroupedTiered value) =>
        new PriceVariants::GroupedTiered(value);

    public static implicit operator Price(TieredWithMinimum value) =>
        new PriceVariants::TieredWithMinimum(value);

    public static implicit operator Price(TieredPackageWithMinimum value) =>
        new PriceVariants::TieredPackageWithMinimum(value);

    public static implicit operator Price(PackageWithAllocation value) =>
        new PriceVariants::PackageWithAllocation(value);

    public static implicit operator Price(UnitWithPercent value) =>
        new PriceVariants::UnitWithPercent(value);

    public static implicit operator Price(MatrixWithAllocation value) =>
        new PriceVariants::MatrixWithAllocation(value);

    public static implicit operator Price(TieredWithProration value) =>
        new PriceVariants::TieredWithProration(value);

    public static implicit operator Price(UnitWithProration value) =>
        new PriceVariants::UnitWithProration(value);

    public static implicit operator Price(GroupedAllocation value) =>
        new PriceVariants::GroupedAllocation(value);

    public static implicit operator Price(GroupedWithProratedMinimum value) =>
        new PriceVariants::GroupedWithProratedMinimum(value);

    public static implicit operator Price(GroupedWithMeteredMinimum value) =>
        new PriceVariants::GroupedWithMeteredMinimum(value);

    public static implicit operator Price(MatrixWithDisplayName value) =>
        new PriceVariants::MatrixWithDisplayName(value);

    public static implicit operator Price(BulkWithProration value) =>
        new PriceVariants::BulkWithProration(value);

    public static implicit operator Price(GroupedTieredPackage value) =>
        new PriceVariants::GroupedTieredPackage(value);

    public static implicit operator Price(MaxGroupTieredPackage value) =>
        new PriceVariants::MaxGroupTieredPackage(value);

    public static implicit operator Price(ScalableMatrixWithUnitPricing value) =>
        new PriceVariants::ScalableMatrixWithUnitPricing(value);

    public static implicit operator Price(ScalableMatrixWithTieredPricing value) =>
        new PriceVariants::ScalableMatrixWithTieredPricing(value);

    public static implicit operator Price(CumulativeGroupedBulk value) =>
        new PriceVariants::CumulativeGroupedBulk(value);

    public static implicit operator Price(GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public bool TryPickUnit([NotNullWhen(true)] out Unit? value)
    {
        value = (this as PriceVariants::Unit)?.Value;
        return value != null;
    }

    public bool TryPickPackage([NotNullWhen(true)] out Package? value)
    {
        value = (this as PriceVariants::Package)?.Value;
        return value != null;
    }

    public bool TryPickMatrix([NotNullWhen(true)] out Matrix? value)
    {
        value = (this as PriceVariants::Matrix)?.Value;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out Tiered? value)
    {
        value = (this as PriceVariants::Tiered)?.Value;
        return value != null;
    }

    public bool TryPickTieredBPS([NotNullWhen(true)] out TieredBPS? value)
    {
        value = (this as PriceVariants::TieredBPS)?.Value;
        return value != null;
    }

    public bool TryPickBPS([NotNullWhen(true)] out BPS? value)
    {
        value = (this as PriceVariants::BPS)?.Value;
        return value != null;
    }

    public bool TryPickBulkBPS([NotNullWhen(true)] out BulkBPS? value)
    {
        value = (this as PriceVariants::BulkBPS)?.Value;
        return value != null;
    }

    public bool TryPickBulk([NotNullWhen(true)] out Bulk? value)
    {
        value = (this as PriceVariants::Bulk)?.Value;
        return value != null;
    }

    public bool TryPickThresholdTotalAmount([NotNullWhen(true)] out ThresholdTotalAmount? value)
    {
        value = (this as PriceVariants::ThresholdTotalAmount)?.Value;
        return value != null;
    }

    public bool TryPickTieredPackage([NotNullWhen(true)] out TieredPackage? value)
    {
        value = (this as PriceVariants::TieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickGroupedTiered([NotNullWhen(true)] out GroupedTiered? value)
    {
        value = (this as PriceVariants::GroupedTiered)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithMinimum([NotNullWhen(true)] out TieredWithMinimum? value)
    {
        value = (this as PriceVariants::TieredWithMinimum)?.Value;
        return value != null;
    }

    public bool TryPickTieredPackageWithMinimum(
        [NotNullWhen(true)] out TieredPackageWithMinimum? value
    )
    {
        value = (this as PriceVariants::TieredPackageWithMinimum)?.Value;
        return value != null;
    }

    public bool TryPickPackageWithAllocation([NotNullWhen(true)] out PackageWithAllocation? value)
    {
        value = (this as PriceVariants::PackageWithAllocation)?.Value;
        return value != null;
    }

    public bool TryPickUnitWithPercent([NotNullWhen(true)] out UnitWithPercent? value)
    {
        value = (this as PriceVariants::UnitWithPercent)?.Value;
        return value != null;
    }

    public bool TryPickMatrixWithAllocation([NotNullWhen(true)] out MatrixWithAllocation? value)
    {
        value = (this as PriceVariants::MatrixWithAllocation)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration? value)
    {
        value = (this as PriceVariants::TieredWithProration)?.Value;
        return value != null;
    }

    public bool TryPickUnitWithProration([NotNullWhen(true)] out UnitWithProration? value)
    {
        value = (this as PriceVariants::UnitWithProration)?.Value;
        return value != null;
    }

    public bool TryPickGroupedAllocation([NotNullWhen(true)] out GroupedAllocation? value)
    {
        value = (this as PriceVariants::GroupedAllocation)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithProratedMinimum(
        [NotNullWhen(true)] out GroupedWithProratedMinimum? value
    )
    {
        value = (this as PriceVariants::GroupedWithProratedMinimum)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out GroupedWithMeteredMinimum? value
    )
    {
        value = (this as PriceVariants::GroupedWithMeteredMinimum)?.Value;
        return value != null;
    }

    public bool TryPickMatrixWithDisplayName([NotNullWhen(true)] out MatrixWithDisplayName? value)
    {
        value = (this as PriceVariants::MatrixWithDisplayName)?.Value;
        return value != null;
    }

    public bool TryPickBulkWithProration([NotNullWhen(true)] out BulkWithProration? value)
    {
        value = (this as PriceVariants::BulkWithProration)?.Value;
        return value != null;
    }

    public bool TryPickGroupedTieredPackage([NotNullWhen(true)] out GroupedTieredPackage? value)
    {
        value = (this as PriceVariants::GroupedTieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickMaxGroupTieredPackage([NotNullWhen(true)] out MaxGroupTieredPackage? value)
    {
        value = (this as PriceVariants::MaxGroupTieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out ScalableMatrixWithUnitPricing? value
    )
    {
        value = (this as PriceVariants::ScalableMatrixWithUnitPricing)?.Value;
        return value != null;
    }

    public bool TryPickScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out ScalableMatrixWithTieredPricing? value
    )
    {
        value = (this as PriceVariants::ScalableMatrixWithTieredPricing)?.Value;
        return value != null;
    }

    public bool TryPickCumulativeGroupedBulk([NotNullWhen(true)] out CumulativeGroupedBulk? value)
    {
        value = (this as PriceVariants::CumulativeGroupedBulk)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::Unit> unit,
        Action<PriceVariants::Package> package,
        Action<PriceVariants::Matrix> matrix,
        Action<PriceVariants::Tiered> tiered,
        Action<PriceVariants::TieredBPS> tieredBPS,
        Action<PriceVariants::BPS> bps,
        Action<PriceVariants::BulkBPS> bulkBPS,
        Action<PriceVariants::Bulk> bulk,
        Action<PriceVariants::ThresholdTotalAmount> thresholdTotalAmount,
        Action<PriceVariants::TieredPackage> tieredPackage,
        Action<PriceVariants::GroupedTiered> groupedTiered,
        Action<PriceVariants::TieredWithMinimum> tieredWithMinimum,
        Action<PriceVariants::TieredPackageWithMinimum> tieredPackageWithMinimum,
        Action<PriceVariants::PackageWithAllocation> packageWithAllocation,
        Action<PriceVariants::UnitWithPercent> unitWithPercent,
        Action<PriceVariants::MatrixWithAllocation> matrixWithAllocation,
        Action<PriceVariants::TieredWithProration> tieredWithProration,
        Action<PriceVariants::UnitWithProration> unitWithProration,
        Action<PriceVariants::GroupedAllocation> groupedAllocation,
        Action<PriceVariants::GroupedWithProratedMinimum> groupedWithProratedMinimum,
        Action<PriceVariants::GroupedWithMeteredMinimum> groupedWithMeteredMinimum,
        Action<PriceVariants::MatrixWithDisplayName> matrixWithDisplayName,
        Action<PriceVariants::BulkWithProration> bulkWithProration,
        Action<PriceVariants::GroupedTieredPackage> groupedTieredPackage,
        Action<PriceVariants::MaxGroupTieredPackage> maxGroupTieredPackage,
        Action<PriceVariants::ScalableMatrixWithUnitPricing> scalableMatrixWithUnitPricing,
        Action<PriceVariants::ScalableMatrixWithTieredPricing> scalableMatrixWithTieredPricing,
        Action<PriceVariants::CumulativeGroupedBulk> cumulativeGroupedBulk,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds
    )
    {
        switch (this)
        {
            case PriceVariants::Unit inner:
                unit(inner);
                break;
            case PriceVariants::Package inner:
                package(inner);
                break;
            case PriceVariants::Matrix inner:
                matrix(inner);
                break;
            case PriceVariants::Tiered inner:
                tiered(inner);
                break;
            case PriceVariants::TieredBPS inner:
                tieredBPS(inner);
                break;
            case PriceVariants::BPS inner:
                bps(inner);
                break;
            case PriceVariants::BulkBPS inner:
                bulkBPS(inner);
                break;
            case PriceVariants::Bulk inner:
                bulk(inner);
                break;
            case PriceVariants::ThresholdTotalAmount inner:
                thresholdTotalAmount(inner);
                break;
            case PriceVariants::TieredPackage inner:
                tieredPackage(inner);
                break;
            case PriceVariants::GroupedTiered inner:
                groupedTiered(inner);
                break;
            case PriceVariants::TieredWithMinimum inner:
                tieredWithMinimum(inner);
                break;
            case PriceVariants::TieredPackageWithMinimum inner:
                tieredPackageWithMinimum(inner);
                break;
            case PriceVariants::PackageWithAllocation inner:
                packageWithAllocation(inner);
                break;
            case PriceVariants::UnitWithPercent inner:
                unitWithPercent(inner);
                break;
            case PriceVariants::MatrixWithAllocation inner:
                matrixWithAllocation(inner);
                break;
            case PriceVariants::TieredWithProration inner:
                tieredWithProration(inner);
                break;
            case PriceVariants::UnitWithProration inner:
                unitWithProration(inner);
                break;
            case PriceVariants::GroupedAllocation inner:
                groupedAllocation(inner);
                break;
            case PriceVariants::GroupedWithProratedMinimum inner:
                groupedWithProratedMinimum(inner);
                break;
            case PriceVariants::GroupedWithMeteredMinimum inner:
                groupedWithMeteredMinimum(inner);
                break;
            case PriceVariants::MatrixWithDisplayName inner:
                matrixWithDisplayName(inner);
                break;
            case PriceVariants::BulkWithProration inner:
                bulkWithProration(inner);
                break;
            case PriceVariants::GroupedTieredPackage inner:
                groupedTieredPackage(inner);
                break;
            case PriceVariants::MaxGroupTieredPackage inner:
                maxGroupTieredPackage(inner);
                break;
            case PriceVariants::ScalableMatrixWithUnitPricing inner:
                scalableMatrixWithUnitPricing(inner);
                break;
            case PriceVariants::ScalableMatrixWithTieredPricing inner:
                scalableMatrixWithTieredPricing(inner);
                break;
            case PriceVariants::CumulativeGroupedBulk inner:
                cumulativeGroupedBulk(inner);
                break;
            case PriceVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PriceVariants::Unit, T> unit,
        Func<PriceVariants::Package, T> package,
        Func<PriceVariants::Matrix, T> matrix,
        Func<PriceVariants::Tiered, T> tiered,
        Func<PriceVariants::TieredBPS, T> tieredBPS,
        Func<PriceVariants::BPS, T> bps,
        Func<PriceVariants::BulkBPS, T> bulkBPS,
        Func<PriceVariants::Bulk, T> bulk,
        Func<PriceVariants::ThresholdTotalAmount, T> thresholdTotalAmount,
        Func<PriceVariants::TieredPackage, T> tieredPackage,
        Func<PriceVariants::GroupedTiered, T> groupedTiered,
        Func<PriceVariants::TieredWithMinimum, T> tieredWithMinimum,
        Func<PriceVariants::TieredPackageWithMinimum, T> tieredPackageWithMinimum,
        Func<PriceVariants::PackageWithAllocation, T> packageWithAllocation,
        Func<PriceVariants::UnitWithPercent, T> unitWithPercent,
        Func<PriceVariants::MatrixWithAllocation, T> matrixWithAllocation,
        Func<PriceVariants::TieredWithProration, T> tieredWithProration,
        Func<PriceVariants::UnitWithProration, T> unitWithProration,
        Func<PriceVariants::GroupedAllocation, T> groupedAllocation,
        Func<PriceVariants::GroupedWithProratedMinimum, T> groupedWithProratedMinimum,
        Func<PriceVariants::GroupedWithMeteredMinimum, T> groupedWithMeteredMinimum,
        Func<PriceVariants::MatrixWithDisplayName, T> matrixWithDisplayName,
        Func<PriceVariants::BulkWithProration, T> bulkWithProration,
        Func<PriceVariants::GroupedTieredPackage, T> groupedTieredPackage,
        Func<PriceVariants::MaxGroupTieredPackage, T> maxGroupTieredPackage,
        Func<PriceVariants::ScalableMatrixWithUnitPricing, T> scalableMatrixWithUnitPricing,
        Func<PriceVariants::ScalableMatrixWithTieredPricing, T> scalableMatrixWithTieredPricing,
        Func<PriceVariants::CumulativeGroupedBulk, T> cumulativeGroupedBulk,
        Func<PriceVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds
    )
    {
        return this switch
        {
            PriceVariants::Unit inner => unit(inner),
            PriceVariants::Package inner => package(inner),
            PriceVariants::Matrix inner => matrix(inner),
            PriceVariants::Tiered inner => tiered(inner),
            PriceVariants::TieredBPS inner => tieredBPS(inner),
            PriceVariants::BPS inner => bps(inner),
            PriceVariants::BulkBPS inner => bulkBPS(inner),
            PriceVariants::Bulk inner => bulk(inner),
            PriceVariants::ThresholdTotalAmount inner => thresholdTotalAmount(inner),
            PriceVariants::TieredPackage inner => tieredPackage(inner),
            PriceVariants::GroupedTiered inner => groupedTiered(inner),
            PriceVariants::TieredWithMinimum inner => tieredWithMinimum(inner),
            PriceVariants::TieredPackageWithMinimum inner => tieredPackageWithMinimum(inner),
            PriceVariants::PackageWithAllocation inner => packageWithAllocation(inner),
            PriceVariants::UnitWithPercent inner => unitWithPercent(inner),
            PriceVariants::MatrixWithAllocation inner => matrixWithAllocation(inner),
            PriceVariants::TieredWithProration inner => tieredWithProration(inner),
            PriceVariants::UnitWithProration inner => unitWithProration(inner),
            PriceVariants::GroupedAllocation inner => groupedAllocation(inner),
            PriceVariants::GroupedWithProratedMinimum inner => groupedWithProratedMinimum(inner),
            PriceVariants::GroupedWithMeteredMinimum inner => groupedWithMeteredMinimum(inner),
            PriceVariants::MatrixWithDisplayName inner => matrixWithDisplayName(inner),
            PriceVariants::BulkWithProration inner => bulkWithProration(inner),
            PriceVariants::GroupedTieredPackage inner => groupedTieredPackage(inner),
            PriceVariants::MaxGroupTieredPackage inner => maxGroupTieredPackage(inner),
            PriceVariants::ScalableMatrixWithUnitPricing inner => scalableMatrixWithUnitPricing(
                inner
            ),
            PriceVariants::ScalableMatrixWithTieredPricing inner => scalableMatrixWithTieredPricing(
                inner
            ),
            PriceVariants::CumulativeGroupedBulk inner => cumulativeGroupedBulk(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class PriceConverter : JsonConverter<Price>
{
    public override Price? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
        }
        catch
        {
            modelType = null;
        }

        switch (modelType)
        {
            case "unit":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Unit>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::Unit(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Package>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::Package(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "matrix":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Matrix>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::Matrix(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Tiered>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::Tiered(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_bps":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredBPS>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::TieredBPS(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "bps":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BPS>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::BPS(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "bulk_bps":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkBPS>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::BulkBPS(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "bulk":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Bulk>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::Bulk(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThresholdTotalAmount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::ThresholdTotalAmount(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredPackage>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::TieredPackage(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedTiered>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedTiered(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithMinimum>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::TieredWithMinimum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredPackageWithMinimum>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::TieredPackageWithMinimum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PackageWithAllocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::PackageWithAllocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitWithPercent>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::UnitWithPercent(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixWithAllocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::MatrixWithAllocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithProration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::TieredWithProration(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitWithProration>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::UnitWithProration(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedAllocation>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedAllocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithProratedMinimum>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedWithProratedMinimum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMeteredMinimum>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedWithMeteredMinimum(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixWithDisplayName>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::MatrixWithDisplayName(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithProration>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::BulkWithProration(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedTieredPackage>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedTieredPackage(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MaxGroupTieredPackage>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::MaxGroupTieredPackage(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ScalableMatrixWithUnitPricing>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::ScalableMatrixWithUnitPricing(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ScalableMatrixWithTieredPricing>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::ScalableMatrixWithTieredPricing(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CumulativeGroupedBulk>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::CumulativeGroupedBulk(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::GroupedWithMinMaxThresholds(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Price value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PriceVariants::Unit(var unit) => unit,
            PriceVariants::Package(var package) => package,
            PriceVariants::Matrix(var matrix) => matrix,
            PriceVariants::Tiered(var tiered) => tiered,
            PriceVariants::TieredBPS(var tieredBPS) => tieredBPS,
            PriceVariants::BPS(var bps) => bps,
            PriceVariants::BulkBPS(var bulkBPS) => bulkBPS,
            PriceVariants::Bulk(var bulk) => bulk,
            PriceVariants::ThresholdTotalAmount(var thresholdTotalAmount) => thresholdTotalAmount,
            PriceVariants::TieredPackage(var tieredPackage) => tieredPackage,
            PriceVariants::GroupedTiered(var groupedTiered) => groupedTiered,
            PriceVariants::TieredWithMinimum(var tieredWithMinimum) => tieredWithMinimum,
            PriceVariants::TieredPackageWithMinimum(var tieredPackageWithMinimum) =>
                tieredPackageWithMinimum,
            PriceVariants::PackageWithAllocation(var packageWithAllocation) =>
                packageWithAllocation,
            PriceVariants::UnitWithPercent(var unitWithPercent) => unitWithPercent,
            PriceVariants::MatrixWithAllocation(var matrixWithAllocation) => matrixWithAllocation,
            PriceVariants::TieredWithProration(var tieredWithProration) => tieredWithProration,
            PriceVariants::UnitWithProration(var unitWithProration) => unitWithProration,
            PriceVariants::GroupedAllocation(var groupedAllocation) => groupedAllocation,
            PriceVariants::GroupedWithProratedMinimum(var groupedWithProratedMinimum) =>
                groupedWithProratedMinimum,
            PriceVariants::GroupedWithMeteredMinimum(var groupedWithMeteredMinimum) =>
                groupedWithMeteredMinimum,
            PriceVariants::MatrixWithDisplayName(var matrixWithDisplayName) =>
                matrixWithDisplayName,
            PriceVariants::BulkWithProration(var bulkWithProration) => bulkWithProration,
            PriceVariants::GroupedTieredPackage(var groupedTieredPackage) => groupedTieredPackage,
            PriceVariants::MaxGroupTieredPackage(var maxGroupTieredPackage) =>
                maxGroupTieredPackage,
            PriceVariants::ScalableMatrixWithUnitPricing(var scalableMatrixWithUnitPricing) =>
                scalableMatrixWithUnitPricing,
            PriceVariants::ScalableMatrixWithTieredPricing(var scalableMatrixWithTieredPricing) =>
                scalableMatrixWithTieredPricing,
            PriceVariants::CumulativeGroupedBulk(var cumulativeGroupedBulk) =>
                cumulativeGroupedBulk,
            PriceVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
