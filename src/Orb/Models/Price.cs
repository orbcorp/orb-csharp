using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
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
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(PriceProperties::Unit value) =>
        new PriceVariants::Unit(value);

    public static implicit operator Price(PriceProperties::Tiered value) =>
        new PriceVariants::Tiered(value);

    public static implicit operator Price(PriceProperties::Bulk value) =>
        new PriceVariants::Bulk(value);

    public static implicit operator Price(PriceProperties::Package value) =>
        new PriceVariants::Package(value);

    public static implicit operator Price(PriceProperties::Matrix value) =>
        new PriceVariants::Matrix(value);

    public static implicit operator Price(PriceProperties::ThresholdTotalAmount value) =>
        new PriceVariants::ThresholdTotalAmount(value);

    public static implicit operator Price(PriceProperties::TieredPackage value) =>
        new PriceVariants::TieredPackage(value);

    public static implicit operator Price(PriceProperties::TieredWithMinimum value) =>
        new PriceVariants::TieredWithMinimum(value);

    public static implicit operator Price(PriceProperties::GroupedTiered value) =>
        new PriceVariants::GroupedTiered(value);

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

    public static implicit operator Price(PriceProperties::BulkWithProration value) =>
        new PriceVariants::BulkWithProration(value);

    public static implicit operator Price(PriceProperties::GroupedWithProratedMinimum value) =>
        new PriceVariants::GroupedWithProratedMinimum(value);

    public static implicit operator Price(PriceProperties::GroupedWithMeteredMinimum value) =>
        new PriceVariants::GroupedWithMeteredMinimum(value);

    public static implicit operator Price(PriceProperties::GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public static implicit operator Price(PriceProperties::MatrixWithDisplayName value) =>
        new PriceVariants::MatrixWithDisplayName(value);

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

    public static implicit operator Price(PriceProperties::Minimum value) =>
        new PriceVariants::Minimum(value);

    public bool TryPickUnit([NotNullWhen(true)] out PriceProperties::Unit? value)
    {
        value = (this as PriceVariants::Unit)?.Value;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out PriceProperties::Tiered? value)
    {
        value = (this as PriceVariants::Tiered)?.Value;
        return value != null;
    }

    public bool TryPickBulk([NotNullWhen(true)] out PriceProperties::Bulk? value)
    {
        value = (this as PriceVariants::Bulk)?.Value;
        return value != null;
    }

    public bool TryPickPackage([NotNullWhen(true)] out PriceProperties::Package? value)
    {
        value = (this as PriceVariants::Package)?.Value;
        return value != null;
    }

    public bool TryPickMatrix([NotNullWhen(true)] out PriceProperties::Matrix? value)
    {
        value = (this as PriceVariants::Matrix)?.Value;
        return value != null;
    }

    public bool TryPickThresholdTotalAmount(
        [NotNullWhen(true)] out PriceProperties::ThresholdTotalAmount? value
    )
    {
        value = (this as PriceVariants::ThresholdTotalAmount)?.Value;
        return value != null;
    }

    public bool TryPickTieredPackage([NotNullWhen(true)] out PriceProperties::TieredPackage? value)
    {
        value = (this as PriceVariants::TieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithMinimum(
        [NotNullWhen(true)] out PriceProperties::TieredWithMinimum? value
    )
    {
        value = (this as PriceVariants::TieredWithMinimum)?.Value;
        return value != null;
    }

    public bool TryPickGroupedTiered([NotNullWhen(true)] out PriceProperties::GroupedTiered? value)
    {
        value = (this as PriceVariants::GroupedTiered)?.Value;
        return value != null;
    }

    public bool TryPickTieredPackageWithMinimum(
        [NotNullWhen(true)] out PriceProperties::TieredPackageWithMinimum? value
    )
    {
        value = (this as PriceVariants::TieredPackageWithMinimum)?.Value;
        return value != null;
    }

    public bool TryPickPackageWithAllocation(
        [NotNullWhen(true)] out PriceProperties::PackageWithAllocation? value
    )
    {
        value = (this as PriceVariants::PackageWithAllocation)?.Value;
        return value != null;
    }

    public bool TryPickUnitWithPercent(
        [NotNullWhen(true)] out PriceProperties::UnitWithPercent? value
    )
    {
        value = (this as PriceVariants::UnitWithPercent)?.Value;
        return value != null;
    }

    public bool TryPickMatrixWithAllocation(
        [NotNullWhen(true)] out PriceProperties::MatrixWithAllocation? value
    )
    {
        value = (this as PriceVariants::MatrixWithAllocation)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out PriceProperties::TieredWithProration? value
    )
    {
        value = (this as PriceVariants::TieredWithProration)?.Value;
        return value != null;
    }

    public bool TryPickUnitWithProration(
        [NotNullWhen(true)] out PriceProperties::UnitWithProration? value
    )
    {
        value = (this as PriceVariants::UnitWithProration)?.Value;
        return value != null;
    }

    public bool TryPickGroupedAllocation(
        [NotNullWhen(true)] out PriceProperties::GroupedAllocation? value
    )
    {
        value = (this as PriceVariants::GroupedAllocation)?.Value;
        return value != null;
    }

    public bool TryPickBulkWithProration(
        [NotNullWhen(true)] out PriceProperties::BulkWithProration? value
    )
    {
        value = (this as PriceVariants::BulkWithProration)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithProratedMinimum(
        [NotNullWhen(true)] out PriceProperties::GroupedWithProratedMinimum? value
    )
    {
        value = (this as PriceVariants::GroupedWithProratedMinimum)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out PriceProperties::GroupedWithMeteredMinimum? value
    )
    {
        value = (this as PriceVariants::GroupedWithMeteredMinimum)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceProperties::GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickMatrixWithDisplayName(
        [NotNullWhen(true)] out PriceProperties::MatrixWithDisplayName? value
    )
    {
        value = (this as PriceVariants::MatrixWithDisplayName)?.Value;
        return value != null;
    }

    public bool TryPickGroupedTieredPackage(
        [NotNullWhen(true)] out PriceProperties::GroupedTieredPackage? value
    )
    {
        value = (this as PriceVariants::GroupedTieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickMaxGroupTieredPackage(
        [NotNullWhen(true)] out PriceProperties::MaxGroupTieredPackage? value
    )
    {
        value = (this as PriceVariants::MaxGroupTieredPackage)?.Value;
        return value != null;
    }

    public bool TryPickScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out PriceProperties::ScalableMatrixWithUnitPricing? value
    )
    {
        value = (this as PriceVariants::ScalableMatrixWithUnitPricing)?.Value;
        return value != null;
    }

    public bool TryPickScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out PriceProperties::ScalableMatrixWithTieredPricing? value
    )
    {
        value = (this as PriceVariants::ScalableMatrixWithTieredPricing)?.Value;
        return value != null;
    }

    public bool TryPickCumulativeGroupedBulk(
        [NotNullWhen(true)] out PriceProperties::CumulativeGroupedBulk? value
    )
    {
        value = (this as PriceVariants::CumulativeGroupedBulk)?.Value;
        return value != null;
    }

    public bool TryPickMinimum([NotNullWhen(true)] out PriceProperties::Minimum? value)
    {
        value = (this as PriceVariants::Minimum)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::Unit> unit,
        Action<PriceVariants::Tiered> tiered,
        Action<PriceVariants::Bulk> bulk,
        Action<PriceVariants::Package> package,
        Action<PriceVariants::Matrix> matrix,
        Action<PriceVariants::ThresholdTotalAmount> thresholdTotalAmount,
        Action<PriceVariants::TieredPackage> tieredPackage,
        Action<PriceVariants::TieredWithMinimum> tieredWithMinimum,
        Action<PriceVariants::GroupedTiered> groupedTiered,
        Action<PriceVariants::TieredPackageWithMinimum> tieredPackageWithMinimum,
        Action<PriceVariants::PackageWithAllocation> packageWithAllocation,
        Action<PriceVariants::UnitWithPercent> unitWithPercent,
        Action<PriceVariants::MatrixWithAllocation> matrixWithAllocation,
        Action<PriceVariants::TieredWithProration> tieredWithProration,
        Action<PriceVariants::UnitWithProration> unitWithProration,
        Action<PriceVariants::GroupedAllocation> groupedAllocation,
        Action<PriceVariants::BulkWithProration> bulkWithProration,
        Action<PriceVariants::GroupedWithProratedMinimum> groupedWithProratedMinimum,
        Action<PriceVariants::GroupedWithMeteredMinimum> groupedWithMeteredMinimum,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceVariants::MatrixWithDisplayName> matrixWithDisplayName,
        Action<PriceVariants::GroupedTieredPackage> groupedTieredPackage,
        Action<PriceVariants::MaxGroupTieredPackage> maxGroupTieredPackage,
        Action<PriceVariants::ScalableMatrixWithUnitPricing> scalableMatrixWithUnitPricing,
        Action<PriceVariants::ScalableMatrixWithTieredPricing> scalableMatrixWithTieredPricing,
        Action<PriceVariants::CumulativeGroupedBulk> cumulativeGroupedBulk,
        Action<PriceVariants::Minimum> minimum
    )
    {
        switch (this)
        {
            case PriceVariants::Unit inner:
                unit(inner);
                break;
            case PriceVariants::Tiered inner:
                tiered(inner);
                break;
            case PriceVariants::Bulk inner:
                bulk(inner);
                break;
            case PriceVariants::Package inner:
                package(inner);
                break;
            case PriceVariants::Matrix inner:
                matrix(inner);
                break;
            case PriceVariants::ThresholdTotalAmount inner:
                thresholdTotalAmount(inner);
                break;
            case PriceVariants::TieredPackage inner:
                tieredPackage(inner);
                break;
            case PriceVariants::TieredWithMinimum inner:
                tieredWithMinimum(inner);
                break;
            case PriceVariants::GroupedTiered inner:
                groupedTiered(inner);
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
            case PriceVariants::BulkWithProration inner:
                bulkWithProration(inner);
                break;
            case PriceVariants::GroupedWithProratedMinimum inner:
                groupedWithProratedMinimum(inner);
                break;
            case PriceVariants::GroupedWithMeteredMinimum inner:
                groupedWithMeteredMinimum(inner);
                break;
            case PriceVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            case PriceVariants::MatrixWithDisplayName inner:
                matrixWithDisplayName(inner);
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
            case PriceVariants::Minimum inner:
                minimum(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PriceVariants::Unit, T> unit,
        Func<PriceVariants::Tiered, T> tiered,
        Func<PriceVariants::Bulk, T> bulk,
        Func<PriceVariants::Package, T> package,
        Func<PriceVariants::Matrix, T> matrix,
        Func<PriceVariants::ThresholdTotalAmount, T> thresholdTotalAmount,
        Func<PriceVariants::TieredPackage, T> tieredPackage,
        Func<PriceVariants::TieredWithMinimum, T> tieredWithMinimum,
        Func<PriceVariants::GroupedTiered, T> groupedTiered,
        Func<PriceVariants::TieredPackageWithMinimum, T> tieredPackageWithMinimum,
        Func<PriceVariants::PackageWithAllocation, T> packageWithAllocation,
        Func<PriceVariants::UnitWithPercent, T> unitWithPercent,
        Func<PriceVariants::MatrixWithAllocation, T> matrixWithAllocation,
        Func<PriceVariants::TieredWithProration, T> tieredWithProration,
        Func<PriceVariants::UnitWithProration, T> unitWithProration,
        Func<PriceVariants::GroupedAllocation, T> groupedAllocation,
        Func<PriceVariants::BulkWithProration, T> bulkWithProration,
        Func<PriceVariants::GroupedWithProratedMinimum, T> groupedWithProratedMinimum,
        Func<PriceVariants::GroupedWithMeteredMinimum, T> groupedWithMeteredMinimum,
        Func<PriceVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<PriceVariants::MatrixWithDisplayName, T> matrixWithDisplayName,
        Func<PriceVariants::GroupedTieredPackage, T> groupedTieredPackage,
        Func<PriceVariants::MaxGroupTieredPackage, T> maxGroupTieredPackage,
        Func<PriceVariants::ScalableMatrixWithUnitPricing, T> scalableMatrixWithUnitPricing,
        Func<PriceVariants::ScalableMatrixWithTieredPricing, T> scalableMatrixWithTieredPricing,
        Func<PriceVariants::CumulativeGroupedBulk, T> cumulativeGroupedBulk,
        Func<PriceVariants::Minimum, T> minimum
    )
    {
        return this switch
        {
            PriceVariants::Unit inner => unit(inner),
            PriceVariants::Tiered inner => tiered(inner),
            PriceVariants::Bulk inner => bulk(inner),
            PriceVariants::Package inner => package(inner),
            PriceVariants::Matrix inner => matrix(inner),
            PriceVariants::ThresholdTotalAmount inner => thresholdTotalAmount(inner),
            PriceVariants::TieredPackage inner => tieredPackage(inner),
            PriceVariants::TieredWithMinimum inner => tieredWithMinimum(inner),
            PriceVariants::GroupedTiered inner => groupedTiered(inner),
            PriceVariants::TieredPackageWithMinimum inner => tieredPackageWithMinimum(inner),
            PriceVariants::PackageWithAllocation inner => packageWithAllocation(inner),
            PriceVariants::UnitWithPercent inner => unitWithPercent(inner),
            PriceVariants::MatrixWithAllocation inner => matrixWithAllocation(inner),
            PriceVariants::TieredWithProration inner => tieredWithProration(inner),
            PriceVariants::UnitWithProration inner => unitWithProration(inner),
            PriceVariants::GroupedAllocation inner => groupedAllocation(inner),
            PriceVariants::BulkWithProration inner => bulkWithProration(inner),
            PriceVariants::GroupedWithProratedMinimum inner => groupedWithProratedMinimum(inner),
            PriceVariants::GroupedWithMeteredMinimum inner => groupedWithMeteredMinimum(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            PriceVariants::MatrixWithDisplayName inner => matrixWithDisplayName(inner),
            PriceVariants::GroupedTieredPackage inner => groupedTieredPackage(inner),
            PriceVariants::MaxGroupTieredPackage inner => maxGroupTieredPackage(inner),
            PriceVariants::ScalableMatrixWithUnitPricing inner => scalableMatrixWithUnitPricing(
                inner
            ),
            PriceVariants::ScalableMatrixWithTieredPricing inner => scalableMatrixWithTieredPricing(
                inner
            ),
            PriceVariants::CumulativeGroupedBulk inner => cumulativeGroupedBulk(inner),
            PriceVariants::Minimum inner => minimum(inner),
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Unit>(
                        json,
                        options
                    );
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
            case "tiered":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Tiered>(
                        json,
                        options
                    );
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
            case "bulk":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Bulk>(
                        json,
                        options
                    );
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
            case "package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Package>(
                        json,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Matrix>(
                        json,
                        options
                    );
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
            case "threshold_total_amount":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::ThresholdTotalAmount>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::TieredPackage>(
                        json,
                        options
                    );
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
            case "tiered_with_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::TieredWithMinimum>(
                            json,
                            options
                        );
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
            case "grouped_tiered":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::GroupedTiered>(
                        json,
                        options
                    );
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
            case "tiered_package_with_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::TieredPackageWithMinimum>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::PackageWithAllocation>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::UnitWithPercent>(
                        json,
                        options
                    );
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::MatrixWithAllocation>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::TieredWithProration>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::UnitWithProration>(
                            json,
                            options
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedAllocation>(
                            json,
                            options
                        );
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
            case "bulk_with_proration":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::BulkWithProration>(
                            json,
                            options
                        );
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
            case "grouped_with_prorated_minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithProratedMinimum>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithMeteredMinimum>(
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
            case "grouped_with_min_max_thresholds":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedWithMinMaxThresholds>(
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
            case "matrix_with_display_name":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::MatrixWithDisplayName>(
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
            case "grouped_tiered_package":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::GroupedTieredPackage>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::MaxGroupTieredPackage>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::ScalableMatrixWithUnitPricing>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::ScalableMatrixWithTieredPricing>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<PriceProperties::CumulativeGroupedBulk>(
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
            case "minimum":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceProperties::Minimum>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::Minimum(deserialized);
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
            PriceVariants::Tiered(var tiered) => tiered,
            PriceVariants::Bulk(var bulk) => bulk,
            PriceVariants::Package(var package) => package,
            PriceVariants::Matrix(var matrix) => matrix,
            PriceVariants::ThresholdTotalAmount(var thresholdTotalAmount) => thresholdTotalAmount,
            PriceVariants::TieredPackage(var tieredPackage) => tieredPackage,
            PriceVariants::TieredWithMinimum(var tieredWithMinimum) => tieredWithMinimum,
            PriceVariants::GroupedTiered(var groupedTiered) => groupedTiered,
            PriceVariants::TieredPackageWithMinimum(var tieredPackageWithMinimum) =>
                tieredPackageWithMinimum,
            PriceVariants::PackageWithAllocation(var packageWithAllocation) =>
                packageWithAllocation,
            PriceVariants::UnitWithPercent(var unitWithPercent) => unitWithPercent,
            PriceVariants::MatrixWithAllocation(var matrixWithAllocation) => matrixWithAllocation,
            PriceVariants::TieredWithProration(var tieredWithProration) => tieredWithProration,
            PriceVariants::UnitWithProration(var unitWithProration) => unitWithProration,
            PriceVariants::GroupedAllocation(var groupedAllocation) => groupedAllocation,
            PriceVariants::BulkWithProration(var bulkWithProration) => bulkWithProration,
            PriceVariants::GroupedWithProratedMinimum(var groupedWithProratedMinimum) =>
                groupedWithProratedMinimum,
            PriceVariants::GroupedWithMeteredMinimum(var groupedWithMeteredMinimum) =>
                groupedWithMeteredMinimum,
            PriceVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            PriceVariants::MatrixWithDisplayName(var matrixWithDisplayName) =>
                matrixWithDisplayName,
            PriceVariants::GroupedTieredPackage(var groupedTieredPackage) => groupedTieredPackage,
            PriceVariants::MaxGroupTieredPackage(var maxGroupTieredPackage) =>
                maxGroupTieredPackage,
            PriceVariants::ScalableMatrixWithUnitPricing(var scalableMatrixWithUnitPricing) =>
                scalableMatrixWithUnitPricing,
            PriceVariants::ScalableMatrixWithTieredPricing(var scalableMatrixWithTieredPricing) =>
                scalableMatrixWithTieredPricing,
            PriceVariants::CumulativeGroupedBulk(var cumulativeGroupedBulk) =>
                cumulativeGroupedBulk,
            PriceVariants::Minimum(var minimum) => minimum,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
