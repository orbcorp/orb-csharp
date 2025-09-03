using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceProperties;
using Models = Orb.Models;
using PriceVariants = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceVariants;

namespace Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties;

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(Models::NewFloatingUnitPrice value) =>
        new PriceVariants::NewFloatingUnitPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPrice value) =>
        new PriceVariants::NewFloatingTieredPrice(value);

    public static implicit operator Price(Models::NewFloatingBulkPrice value) =>
        new PriceVariants::NewFloatingBulkPrice(value);

    public static implicit operator Price(Models::NewFloatingPackagePrice value) =>
        new PriceVariants::NewFloatingPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingMatrixPrice value) =>
        new PriceVariants::NewFloatingMatrixPrice(value);

    public static implicit operator Price(Models::NewFloatingThresholdTotalAmountPrice value) =>
        new PriceVariants::NewFloatingThresholdTotalAmountPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPackagePrice value) =>
        new PriceVariants::NewFloatingTieredPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingTieredWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredWithMinimumPrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedTieredPrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewFloatingTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(Models::NewFloatingPackageWithAllocationPrice value) =>
        new PriceVariants::NewFloatingPackageWithAllocationPrice(value);

    public static implicit operator Price(Models::NewFloatingUnitWithPercentPrice value) =>
        new PriceVariants::NewFloatingUnitWithPercentPrice(value);

    public static implicit operator Price(Models::NewFloatingMatrixWithAllocationPrice value) =>
        new PriceVariants::NewFloatingMatrixWithAllocationPrice(value);

    public static implicit operator Price(Models::NewFloatingTieredWithProrationPrice value) =>
        new PriceVariants::NewFloatingTieredWithProrationPrice(value);

    public static implicit operator Price(Models::NewFloatingUnitWithProrationPrice value) =>
        new PriceVariants::NewFloatingUnitWithProrationPrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedAllocationPrice value) =>
        new PriceVariants::NewFloatingGroupedAllocationPrice(value);

    public static implicit operator Price(Models::NewFloatingBulkWithProrationPrice value) =>
        new PriceVariants::NewFloatingBulkWithProrationPrice(value);

    public static implicit operator Price(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    ) => new PriceVariants::NewFloatingGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
    ) => new PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public static implicit operator Price(Models::NewFloatingMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewFloatingMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(Models::NewFloatingGroupedTieredPackagePrice value) =>
        new PriceVariants::NewFloatingGroupedTieredPackagePrice(value);

    public static implicit operator Price(Models::NewFloatingMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewFloatingMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(Models::NewFloatingCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewFloatingCumulativeGroupedBulkPrice(value);

    public static implicit operator Price(Models::NewFloatingMinimumCompositePrice value) =>
        new PriceVariants::NewFloatingMinimumCompositePrice(value);

    public bool TryPickNewFloatingUnit([NotNullWhen(true)] out Models::NewFloatingUnitPrice? value)
    {
        value = (this as PriceVariants::NewFloatingUnitPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTiered(
        [NotNullWhen(true)] out Models::NewFloatingTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingBulk([NotNullWhen(true)] out Models::NewFloatingBulkPrice? value)
    {
        value = (this as PriceVariants::NewFloatingBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingPackage(
        [NotNullWhen(true)] out Models::NewFloatingPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrix(
        [NotNullWhen(true)] out Models::NewFloatingMatrixPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingMatrixPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingThresholdTotalAmount(
        [NotNullWhen(true)] out Models::NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingThresholdTotalAmountPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackage(
        [NotNullWhen(true)] out Models::NewFloatingTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithMinimum(
        [NotNullWhen(true)] out Models::NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingTieredWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTiered(
        [NotNullWhen(true)] out Models::NewFloatingGroupedTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingGroupedTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackageWithMinimum(
        [NotNullWhen(true)] out Models::NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingTieredPackageWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingPackageWithAllocation(
        [NotNullWhen(true)] out Models::NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingPackageWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithPercent(
        [NotNullWhen(true)] out Models::NewFloatingUnitWithPercentPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingUnitWithPercentPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithAllocation(
        [NotNullWhen(true)] out Models::NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingMatrixWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithProration(
        [NotNullWhen(true)] out Models::NewFloatingTieredWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingTieredWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithProration(
        [NotNullWhen(true)] out Models::NewFloatingUnitWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingUnitWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedAllocation(
        [NotNullWhen(true)] out Models::NewFloatingGroupedAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingGroupedAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingBulkWithProration(
        [NotNullWhen(true)] out Models::NewFloatingBulkWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingBulkWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithProratedMinimum(
        [NotNullWhen(true)] out Models::NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingGroupedWithProratedMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out Models::NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithDisplayName(
        [NotNullWhen(true)] out Models::NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingMatrixWithDisplayNamePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPackage(
        [NotNullWhen(true)] out Models::NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingGroupedTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMaxGroupTieredPackage(
        [NotNullWhen(true)] out Models::NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingMaxGroupTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out Models::NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out Models::NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingCumulativeGroupedBulk(
        [NotNullWhen(true)] out Models::NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingCumulativeGroupedBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out Models::NewFloatingMinimumCompositePrice? value
    )
    {
        value = (this as PriceVariants::NewFloatingMinimumCompositePrice)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::NewFloatingUnitPrice> newFloatingUnit,
        Action<PriceVariants::NewFloatingTieredPrice> newFloatingTiered,
        Action<PriceVariants::NewFloatingBulkPrice> newFloatingBulk,
        Action<PriceVariants::NewFloatingPackagePrice> newFloatingPackage,
        Action<PriceVariants::NewFloatingMatrixPrice> newFloatingMatrix,
        Action<PriceVariants::NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmount,
        Action<PriceVariants::NewFloatingTieredPackagePrice> newFloatingTieredPackage,
        Action<PriceVariants::NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimum,
        Action<PriceVariants::NewFloatingGroupedTieredPrice> newFloatingGroupedTiered,
        Action<PriceVariants::NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimum,
        Action<PriceVariants::NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocation,
        Action<PriceVariants::NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercent,
        Action<PriceVariants::NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocation,
        Action<PriceVariants::NewFloatingTieredWithProrationPrice> newFloatingTieredWithProration,
        Action<PriceVariants::NewFloatingUnitWithProrationPrice> newFloatingUnitWithProration,
        Action<PriceVariants::NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocation,
        Action<PriceVariants::NewFloatingBulkWithProrationPrice> newFloatingBulkWithProration,
        Action<PriceVariants::NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimum,
        Action<PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimum,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceVariants::NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayName,
        Action<PriceVariants::NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackage,
        Action<PriceVariants::NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackage,
        Action<PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricing,
        Action<PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricing,
        Action<PriceVariants::NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulk,
        Action<PriceVariants::NewFloatingMinimumCompositePrice> newFloatingMinimumComposite
    )
    {
        switch (this)
        {
            case PriceVariants::NewFloatingUnitPrice inner:
                newFloatingUnit(inner);
                break;
            case PriceVariants::NewFloatingTieredPrice inner:
                newFloatingTiered(inner);
                break;
            case PriceVariants::NewFloatingBulkPrice inner:
                newFloatingBulk(inner);
                break;
            case PriceVariants::NewFloatingPackagePrice inner:
                newFloatingPackage(inner);
                break;
            case PriceVariants::NewFloatingMatrixPrice inner:
                newFloatingMatrix(inner);
                break;
            case PriceVariants::NewFloatingThresholdTotalAmountPrice inner:
                newFloatingThresholdTotalAmount(inner);
                break;
            case PriceVariants::NewFloatingTieredPackagePrice inner:
                newFloatingTieredPackage(inner);
                break;
            case PriceVariants::NewFloatingTieredWithMinimumPrice inner:
                newFloatingTieredWithMinimum(inner);
                break;
            case PriceVariants::NewFloatingGroupedTieredPrice inner:
                newFloatingGroupedTiered(inner);
                break;
            case PriceVariants::NewFloatingTieredPackageWithMinimumPrice inner:
                newFloatingTieredPackageWithMinimum(inner);
                break;
            case PriceVariants::NewFloatingPackageWithAllocationPrice inner:
                newFloatingPackageWithAllocation(inner);
                break;
            case PriceVariants::NewFloatingUnitWithPercentPrice inner:
                newFloatingUnitWithPercent(inner);
                break;
            case PriceVariants::NewFloatingMatrixWithAllocationPrice inner:
                newFloatingMatrixWithAllocation(inner);
                break;
            case PriceVariants::NewFloatingTieredWithProrationPrice inner:
                newFloatingTieredWithProration(inner);
                break;
            case PriceVariants::NewFloatingUnitWithProrationPrice inner:
                newFloatingUnitWithProration(inner);
                break;
            case PriceVariants::NewFloatingGroupedAllocationPrice inner:
                newFloatingGroupedAllocation(inner);
                break;
            case PriceVariants::NewFloatingBulkWithProrationPrice inner:
                newFloatingBulkWithProration(inner);
                break;
            case PriceVariants::NewFloatingGroupedWithProratedMinimumPrice inner:
                newFloatingGroupedWithProratedMinimum(inner);
                break;
            case PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice inner:
                newFloatingGroupedWithMeteredMinimum(inner);
                break;
            case PriceVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            case PriceVariants::NewFloatingMatrixWithDisplayNamePrice inner:
                newFloatingMatrixWithDisplayName(inner);
                break;
            case PriceVariants::NewFloatingGroupedTieredPackagePrice inner:
                newFloatingGroupedTieredPackage(inner);
                break;
            case PriceVariants::NewFloatingMaxGroupTieredPackagePrice inner:
                newFloatingMaxGroupTieredPackage(inner);
                break;
            case PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice inner:
                newFloatingScalableMatrixWithUnitPricing(inner);
                break;
            case PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice inner:
                newFloatingScalableMatrixWithTieredPricing(inner);
                break;
            case PriceVariants::NewFloatingCumulativeGroupedBulkPrice inner:
                newFloatingCumulativeGroupedBulk(inner);
                break;
            case PriceVariants::NewFloatingMinimumCompositePrice inner:
                newFloatingMinimumComposite(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PriceVariants::NewFloatingUnitPrice, T> newFloatingUnit,
        Func<PriceVariants::NewFloatingTieredPrice, T> newFloatingTiered,
        Func<PriceVariants::NewFloatingBulkPrice, T> newFloatingBulk,
        Func<PriceVariants::NewFloatingPackagePrice, T> newFloatingPackage,
        Func<PriceVariants::NewFloatingMatrixPrice, T> newFloatingMatrix,
        Func<
            PriceVariants::NewFloatingThresholdTotalAmountPrice,
            T
        > newFloatingThresholdTotalAmount,
        Func<PriceVariants::NewFloatingTieredPackagePrice, T> newFloatingTieredPackage,
        Func<PriceVariants::NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimum,
        Func<PriceVariants::NewFloatingGroupedTieredPrice, T> newFloatingGroupedTiered,
        Func<
            PriceVariants::NewFloatingTieredPackageWithMinimumPrice,
            T
        > newFloatingTieredPackageWithMinimum,
        Func<
            PriceVariants::NewFloatingPackageWithAllocationPrice,
            T
        > newFloatingPackageWithAllocation,
        Func<PriceVariants::NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercent,
        Func<
            PriceVariants::NewFloatingMatrixWithAllocationPrice,
            T
        > newFloatingMatrixWithAllocation,
        Func<PriceVariants::NewFloatingTieredWithProrationPrice, T> newFloatingTieredWithProration,
        Func<PriceVariants::NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProration,
        Func<PriceVariants::NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocation,
        Func<PriceVariants::NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProration,
        Func<
            PriceVariants::NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimum,
        Func<
            PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimum,
        Func<PriceVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<
            PriceVariants::NewFloatingMatrixWithDisplayNamePrice,
            T
        > newFloatingMatrixWithDisplayName,
        Func<
            PriceVariants::NewFloatingGroupedTieredPackagePrice,
            T
        > newFloatingGroupedTieredPackage,
        Func<
            PriceVariants::NewFloatingMaxGroupTieredPackagePrice,
            T
        > newFloatingMaxGroupTieredPackage,
        Func<
            PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricing,
        Func<
            PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricing,
        Func<
            PriceVariants::NewFloatingCumulativeGroupedBulkPrice,
            T
        > newFloatingCumulativeGroupedBulk,
        Func<PriceVariants::NewFloatingMinimumCompositePrice, T> newFloatingMinimumComposite
    )
    {
        return this switch
        {
            PriceVariants::NewFloatingUnitPrice inner => newFloatingUnit(inner),
            PriceVariants::NewFloatingTieredPrice inner => newFloatingTiered(inner),
            PriceVariants::NewFloatingBulkPrice inner => newFloatingBulk(inner),
            PriceVariants::NewFloatingPackagePrice inner => newFloatingPackage(inner),
            PriceVariants::NewFloatingMatrixPrice inner => newFloatingMatrix(inner),
            PriceVariants::NewFloatingThresholdTotalAmountPrice inner =>
                newFloatingThresholdTotalAmount(inner),
            PriceVariants::NewFloatingTieredPackagePrice inner => newFloatingTieredPackage(inner),
            PriceVariants::NewFloatingTieredWithMinimumPrice inner => newFloatingTieredWithMinimum(
                inner
            ),
            PriceVariants::NewFloatingGroupedTieredPrice inner => newFloatingGroupedTiered(inner),
            PriceVariants::NewFloatingTieredPackageWithMinimumPrice inner =>
                newFloatingTieredPackageWithMinimum(inner),
            PriceVariants::NewFloatingPackageWithAllocationPrice inner =>
                newFloatingPackageWithAllocation(inner),
            PriceVariants::NewFloatingUnitWithPercentPrice inner => newFloatingUnitWithPercent(
                inner
            ),
            PriceVariants::NewFloatingMatrixWithAllocationPrice inner =>
                newFloatingMatrixWithAllocation(inner),
            PriceVariants::NewFloatingTieredWithProrationPrice inner =>
                newFloatingTieredWithProration(inner),
            PriceVariants::NewFloatingUnitWithProrationPrice inner => newFloatingUnitWithProration(
                inner
            ),
            PriceVariants::NewFloatingGroupedAllocationPrice inner => newFloatingGroupedAllocation(
                inner
            ),
            PriceVariants::NewFloatingBulkWithProrationPrice inner => newFloatingBulkWithProration(
                inner
            ),
            PriceVariants::NewFloatingGroupedWithProratedMinimumPrice inner =>
                newFloatingGroupedWithProratedMinimum(inner),
            PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice inner =>
                newFloatingGroupedWithMeteredMinimum(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            PriceVariants::NewFloatingMatrixWithDisplayNamePrice inner =>
                newFloatingMatrixWithDisplayName(inner),
            PriceVariants::NewFloatingGroupedTieredPackagePrice inner =>
                newFloatingGroupedTieredPackage(inner),
            PriceVariants::NewFloatingMaxGroupTieredPackagePrice inner =>
                newFloatingMaxGroupTieredPackage(inner),
            PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice inner =>
                newFloatingScalableMatrixWithUnitPricing(inner),
            PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice inner =>
                newFloatingScalableMatrixWithTieredPricing(inner),
            PriceVariants::NewFloatingCumulativeGroupedBulkPrice inner =>
                newFloatingCumulativeGroupedBulk(inner),
            PriceVariants::NewFloatingMinimumCompositePrice inner => newFloatingMinimumComposite(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class PriceConverter : JsonConverter<Price?>
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewFloatingUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingUnitPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewFloatingTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingTieredPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewFloatingBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingBulkPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewFloatingPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingPackagePrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewFloatingMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingMatrixPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingThresholdTotalAmountPrice(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewFloatingTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingTieredPackagePrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingTieredWithMinimumPrice(deserialized);
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
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewFloatingGroupedTieredPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingGroupedTieredPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingTieredPackageWithMinimumPrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingPackageWithAllocationPrice(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewFloatingUnitWithPercentPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingUnitWithPercentPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingMatrixWithAllocationPrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingTieredWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingTieredWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingUnitWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingGroupedAllocationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingBulkWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewFloatingGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingGroupedWithProratedMinimumPrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice(
                            deserialized
                        );
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
            case "matrix_with_display_name":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewFloatingMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingMatrixWithDisplayNamePrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingGroupedTieredPackagePrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingMaxGroupTieredPackagePrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice(
                            deserialized
                        );
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
                        JsonSerializer.Deserialize<Models::NewFloatingCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingCumulativeGroupedBulkPrice(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewFloatingMinimumCompositePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewFloatingMinimumCompositePrice(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Price? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            PriceVariants::NewFloatingUnitPrice(var newFloatingUnit) => newFloatingUnit,
            PriceVariants::NewFloatingTieredPrice(var newFloatingTiered) => newFloatingTiered,
            PriceVariants::NewFloatingBulkPrice(var newFloatingBulk) => newFloatingBulk,
            PriceVariants::NewFloatingPackagePrice(var newFloatingPackage) => newFloatingPackage,
            PriceVariants::NewFloatingMatrixPrice(var newFloatingMatrix) => newFloatingMatrix,
            PriceVariants::NewFloatingThresholdTotalAmountPrice(
                var newFloatingThresholdTotalAmount
            ) => newFloatingThresholdTotalAmount,
            PriceVariants::NewFloatingTieredPackagePrice(var newFloatingTieredPackage) =>
                newFloatingTieredPackage,
            PriceVariants::NewFloatingTieredWithMinimumPrice(var newFloatingTieredWithMinimum) =>
                newFloatingTieredWithMinimum,
            PriceVariants::NewFloatingGroupedTieredPrice(var newFloatingGroupedTiered) =>
                newFloatingGroupedTiered,
            PriceVariants::NewFloatingTieredPackageWithMinimumPrice(
                var newFloatingTieredPackageWithMinimum
            ) => newFloatingTieredPackageWithMinimum,
            PriceVariants::NewFloatingPackageWithAllocationPrice(
                var newFloatingPackageWithAllocation
            ) => newFloatingPackageWithAllocation,
            PriceVariants::NewFloatingUnitWithPercentPrice(var newFloatingUnitWithPercent) =>
                newFloatingUnitWithPercent,
            PriceVariants::NewFloatingMatrixWithAllocationPrice(
                var newFloatingMatrixWithAllocation
            ) => newFloatingMatrixWithAllocation,
            PriceVariants::NewFloatingTieredWithProrationPrice(
                var newFloatingTieredWithProration
            ) => newFloatingTieredWithProration,
            PriceVariants::NewFloatingUnitWithProrationPrice(var newFloatingUnitWithProration) =>
                newFloatingUnitWithProration,
            PriceVariants::NewFloatingGroupedAllocationPrice(var newFloatingGroupedAllocation) =>
                newFloatingGroupedAllocation,
            PriceVariants::NewFloatingBulkWithProrationPrice(var newFloatingBulkWithProration) =>
                newFloatingBulkWithProration,
            PriceVariants::NewFloatingGroupedWithProratedMinimumPrice(
                var newFloatingGroupedWithProratedMinimum
            ) => newFloatingGroupedWithProratedMinimum,
            PriceVariants::NewFloatingGroupedWithMeteredMinimumPrice(
                var newFloatingGroupedWithMeteredMinimum
            ) => newFloatingGroupedWithMeteredMinimum,
            PriceVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            PriceVariants::NewFloatingMatrixWithDisplayNamePrice(
                var newFloatingMatrixWithDisplayName
            ) => newFloatingMatrixWithDisplayName,
            PriceVariants::NewFloatingGroupedTieredPackagePrice(
                var newFloatingGroupedTieredPackage
            ) => newFloatingGroupedTieredPackage,
            PriceVariants::NewFloatingMaxGroupTieredPackagePrice(
                var newFloatingMaxGroupTieredPackage
            ) => newFloatingMaxGroupTieredPackage,
            PriceVariants::NewFloatingScalableMatrixWithUnitPricingPrice(
                var newFloatingScalableMatrixWithUnitPricing
            ) => newFloatingScalableMatrixWithUnitPricing,
            PriceVariants::NewFloatingScalableMatrixWithTieredPricingPrice(
                var newFloatingScalableMatrixWithTieredPricing
            ) => newFloatingScalableMatrixWithTieredPricing,
            PriceVariants::NewFloatingCumulativeGroupedBulkPrice(
                var newFloatingCumulativeGroupedBulk
            ) => newFloatingCumulativeGroupedBulk,
            PriceVariants::NewFloatingMinimumCompositePrice(var newFloatingMinimumComposite) =>
                newFloatingMinimumComposite,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
