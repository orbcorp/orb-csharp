using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;
using PriceProperties = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties;
using PriceVariants = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceVariants;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties;

/// <summary>
/// The price to add to the plan
/// </summary>
[JsonConverter(typeof(PriceConverter))]
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

    public static implicit operator Price(PriceProperties::GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

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

    public static implicit operator Price(PriceProperties::Minimum value) =>
        new PriceVariants::Minimum(value);

    public bool TryPickNewPlanUnit([NotNullWhen(true)] out Models::NewPlanUnitPrice? value)
    {
        value = (this as PriceVariants::NewPlanUnitPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanPackage([NotNullWhen(true)] out Models::NewPlanPackagePrice? value)
    {
        value = (this as PriceVariants::NewPlanPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out Models::NewPlanMatrixPrice? value)
    {
        value = (this as PriceVariants::NewPlanMatrixPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTiered([NotNullWhen(true)] out Models::NewPlanTieredPrice? value)
    {
        value = (this as PriceVariants::NewPlanTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanBulk([NotNullWhen(true)] out Models::NewPlanBulkPrice? value)
    {
        value = (this as PriceVariants::NewPlanBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out Models::NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanThresholdTotalAmountPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out Models::NewPlanTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out Models::NewPlanTieredWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out Models::NewPlanUnitWithPercentPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanUnitWithPercentPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out Models::NewPlanPackageWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanPackageWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTierWithProration(
        [NotNullWhen(true)] out Models::NewPlanTierWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTierWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out Models::NewPlanUnitWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanUnitWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out Models::NewPlanGroupedAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out Models::NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedWithProratedMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out Models::NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedWithMeteredMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceProperties::GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out Models::NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMatrixWithDisplayNamePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out Models::NewPlanBulkWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanBulkWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out Models::NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out Models::NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMaxGroupTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out Models::NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out Models::NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out Models::NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanCumulativeGroupedBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out Models::NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredPackageWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out Models::NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMatrixWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out Models::NewPlanGroupedTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickMinimum([NotNullWhen(true)] out PriceProperties::Minimum? value)
    {
        value = (this as PriceVariants::Minimum)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::NewPlanUnitPrice> newPlanUnit,
        Action<PriceVariants::NewPlanPackagePrice> newPlanPackage,
        Action<PriceVariants::NewPlanMatrixPrice> newPlanMatrix,
        Action<PriceVariants::NewPlanTieredPrice> newPlanTiered,
        Action<PriceVariants::NewPlanBulkPrice> newPlanBulk,
        Action<PriceVariants::NewPlanThresholdTotalAmountPrice> newPlanThresholdTotalAmount,
        Action<PriceVariants::NewPlanTieredPackagePrice> newPlanTieredPackage,
        Action<PriceVariants::NewPlanTieredWithMinimumPrice> newPlanTieredWithMinimum,
        Action<PriceVariants::NewPlanUnitWithPercentPrice> newPlanUnitWithPercent,
        Action<PriceVariants::NewPlanPackageWithAllocationPrice> newPlanPackageWithAllocation,
        Action<PriceVariants::NewPlanTierWithProrationPrice> newPlanTierWithProration,
        Action<PriceVariants::NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        Action<PriceVariants::NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        Action<PriceVariants::NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        Action<PriceVariants::NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceVariants::NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        Action<PriceVariants::NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        Action<PriceVariants::NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        Action<PriceVariants::NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        Action<PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        Action<PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        Action<PriceVariants::NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        Action<PriceVariants::NewPlanTieredPackageWithMinimumPrice> newPlanTieredPackageWithMinimum,
        Action<PriceVariants::NewPlanMatrixWithAllocationPrice> newPlanMatrixWithAllocation,
        Action<PriceVariants::NewPlanGroupedTieredPrice> newPlanGroupedTiered,
        Action<PriceVariants::Minimum> minimum
    )
    {
        switch (this)
        {
            case PriceVariants::NewPlanUnitPrice inner:
                newPlanUnit(inner);
                break;
            case PriceVariants::NewPlanPackagePrice inner:
                newPlanPackage(inner);
                break;
            case PriceVariants::NewPlanMatrixPrice inner:
                newPlanMatrix(inner);
                break;
            case PriceVariants::NewPlanTieredPrice inner:
                newPlanTiered(inner);
                break;
            case PriceVariants::NewPlanBulkPrice inner:
                newPlanBulk(inner);
                break;
            case PriceVariants::NewPlanThresholdTotalAmountPrice inner:
                newPlanThresholdTotalAmount(inner);
                break;
            case PriceVariants::NewPlanTieredPackagePrice inner:
                newPlanTieredPackage(inner);
                break;
            case PriceVariants::NewPlanTieredWithMinimumPrice inner:
                newPlanTieredWithMinimum(inner);
                break;
            case PriceVariants::NewPlanUnitWithPercentPrice inner:
                newPlanUnitWithPercent(inner);
                break;
            case PriceVariants::NewPlanPackageWithAllocationPrice inner:
                newPlanPackageWithAllocation(inner);
                break;
            case PriceVariants::NewPlanTierWithProrationPrice inner:
                newPlanTierWithProration(inner);
                break;
            case PriceVariants::NewPlanUnitWithProrationPrice inner:
                newPlanUnitWithProration(inner);
                break;
            case PriceVariants::NewPlanGroupedAllocationPrice inner:
                newPlanGroupedAllocation(inner);
                break;
            case PriceVariants::NewPlanGroupedWithProratedMinimumPrice inner:
                newPlanGroupedWithProratedMinimum(inner);
                break;
            case PriceVariants::NewPlanGroupedWithMeteredMinimumPrice inner:
                newPlanGroupedWithMeteredMinimum(inner);
                break;
            case PriceVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            case PriceVariants::NewPlanMatrixWithDisplayNamePrice inner:
                newPlanMatrixWithDisplayName(inner);
                break;
            case PriceVariants::NewPlanBulkWithProrationPrice inner:
                newPlanBulkWithProration(inner);
                break;
            case PriceVariants::NewPlanGroupedTieredPackagePrice inner:
                newPlanGroupedTieredPackage(inner);
                break;
            case PriceVariants::NewPlanMaxGroupTieredPackagePrice inner:
                newPlanMaxGroupTieredPackage(inner);
                break;
            case PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice inner:
                newPlanScalableMatrixWithUnitPricing(inner);
                break;
            case PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice inner:
                newPlanScalableMatrixWithTieredPricing(inner);
                break;
            case PriceVariants::NewPlanCumulativeGroupedBulkPrice inner:
                newPlanCumulativeGroupedBulk(inner);
                break;
            case PriceVariants::NewPlanTieredPackageWithMinimumPrice inner:
                newPlanTieredPackageWithMinimum(inner);
                break;
            case PriceVariants::NewPlanMatrixWithAllocationPrice inner:
                newPlanMatrixWithAllocation(inner);
                break;
            case PriceVariants::NewPlanGroupedTieredPrice inner:
                newPlanGroupedTiered(inner);
                break;
            case PriceVariants::Minimum inner:
                minimum(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PriceVariants::NewPlanUnitPrice, T> newPlanUnit,
        Func<PriceVariants::NewPlanPackagePrice, T> newPlanPackage,
        Func<PriceVariants::NewPlanMatrixPrice, T> newPlanMatrix,
        Func<PriceVariants::NewPlanTieredPrice, T> newPlanTiered,
        Func<PriceVariants::NewPlanBulkPrice, T> newPlanBulk,
        Func<PriceVariants::NewPlanThresholdTotalAmountPrice, T> newPlanThresholdTotalAmount,
        Func<PriceVariants::NewPlanTieredPackagePrice, T> newPlanTieredPackage,
        Func<PriceVariants::NewPlanTieredWithMinimumPrice, T> newPlanTieredWithMinimum,
        Func<PriceVariants::NewPlanUnitWithPercentPrice, T> newPlanUnitWithPercent,
        Func<PriceVariants::NewPlanPackageWithAllocationPrice, T> newPlanPackageWithAllocation,
        Func<PriceVariants::NewPlanTierWithProrationPrice, T> newPlanTierWithProration,
        Func<PriceVariants::NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        Func<PriceVariants::NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        Func<
            PriceVariants::NewPlanGroupedWithProratedMinimumPrice,
            T
        > newPlanGroupedWithProratedMinimum,
        Func<
            PriceVariants::NewPlanGroupedWithMeteredMinimumPrice,
            T
        > newPlanGroupedWithMeteredMinimum,
        Func<PriceVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<PriceVariants::NewPlanMatrixWithDisplayNamePrice, T> newPlanMatrixWithDisplayName,
        Func<PriceVariants::NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        Func<PriceVariants::NewPlanGroupedTieredPackagePrice, T> newPlanGroupedTieredPackage,
        Func<PriceVariants::NewPlanMaxGroupTieredPackagePrice, T> newPlanMaxGroupTieredPackage,
        Func<
            PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice,
            T
        > newPlanScalableMatrixWithUnitPricing,
        Func<
            PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice,
            T
        > newPlanScalableMatrixWithTieredPricing,
        Func<PriceVariants::NewPlanCumulativeGroupedBulkPrice, T> newPlanCumulativeGroupedBulk,
        Func<
            PriceVariants::NewPlanTieredPackageWithMinimumPrice,
            T
        > newPlanTieredPackageWithMinimum,
        Func<PriceVariants::NewPlanMatrixWithAllocationPrice, T> newPlanMatrixWithAllocation,
        Func<PriceVariants::NewPlanGroupedTieredPrice, T> newPlanGroupedTiered,
        Func<PriceVariants::Minimum, T> minimum
    )
    {
        return this switch
        {
            PriceVariants::NewPlanUnitPrice inner => newPlanUnit(inner),
            PriceVariants::NewPlanPackagePrice inner => newPlanPackage(inner),
            PriceVariants::NewPlanMatrixPrice inner => newPlanMatrix(inner),
            PriceVariants::NewPlanTieredPrice inner => newPlanTiered(inner),
            PriceVariants::NewPlanBulkPrice inner => newPlanBulk(inner),
            PriceVariants::NewPlanThresholdTotalAmountPrice inner => newPlanThresholdTotalAmount(
                inner
            ),
            PriceVariants::NewPlanTieredPackagePrice inner => newPlanTieredPackage(inner),
            PriceVariants::NewPlanTieredWithMinimumPrice inner => newPlanTieredWithMinimum(inner),
            PriceVariants::NewPlanUnitWithPercentPrice inner => newPlanUnitWithPercent(inner),
            PriceVariants::NewPlanPackageWithAllocationPrice inner => newPlanPackageWithAllocation(
                inner
            ),
            PriceVariants::NewPlanTierWithProrationPrice inner => newPlanTierWithProration(inner),
            PriceVariants::NewPlanUnitWithProrationPrice inner => newPlanUnitWithProration(inner),
            PriceVariants::NewPlanGroupedAllocationPrice inner => newPlanGroupedAllocation(inner),
            PriceVariants::NewPlanGroupedWithProratedMinimumPrice inner =>
                newPlanGroupedWithProratedMinimum(inner),
            PriceVariants::NewPlanGroupedWithMeteredMinimumPrice inner =>
                newPlanGroupedWithMeteredMinimum(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            PriceVariants::NewPlanMatrixWithDisplayNamePrice inner => newPlanMatrixWithDisplayName(
                inner
            ),
            PriceVariants::NewPlanBulkWithProrationPrice inner => newPlanBulkWithProration(inner),
            PriceVariants::NewPlanGroupedTieredPackagePrice inner => newPlanGroupedTieredPackage(
                inner
            ),
            PriceVariants::NewPlanMaxGroupTieredPackagePrice inner => newPlanMaxGroupTieredPackage(
                inner
            ),
            PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice inner =>
                newPlanScalableMatrixWithUnitPricing(inner),
            PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice inner =>
                newPlanScalableMatrixWithTieredPricing(inner),
            PriceVariants::NewPlanCumulativeGroupedBulkPrice inner => newPlanCumulativeGroupedBulk(
                inner
            ),
            PriceVariants::NewPlanTieredPackageWithMinimumPrice inner =>
                newPlanTieredPackageWithMinimum(inner),
            PriceVariants::NewPlanMatrixWithAllocationPrice inner => newPlanMatrixWithAllocation(
                inner
            ),
            PriceVariants::NewPlanGroupedTieredPrice inner => newPlanGroupedTiered(inner),
            PriceVariants::Minimum inner => minimum(inner),
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewPlanUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanUnitPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanPackagePrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanMatrixPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanTieredPrice(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Models::NewPlanBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanBulkPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanThresholdTotalAmountPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanTieredPackagePrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanTieredWithMinimumPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanUnitWithPercentPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanUnitWithPercentPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanPackageWithAllocationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanTierWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanTierWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanUnitWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanGroupedAllocationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanGroupedWithProratedMinimumPrice(
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
                        JsonSerializer.Deserialize<Models::NewPlanGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanGroupedWithMeteredMinimumPrice(
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
                        JsonSerializer.Deserialize<Models::NewPlanMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanMatrixWithDisplayNamePrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanBulkWithProrationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanGroupedTieredPackagePrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanMaxGroupTieredPackagePrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice(
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
                        JsonSerializer.Deserialize<Models::NewPlanScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice(
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
                        JsonSerializer.Deserialize<Models::NewPlanCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanCumulativeGroupedBulkPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanTieredPackageWithMinimumPrice(
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
            case "matrix_with_allocation":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Models::NewPlanMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanMatrixWithAllocationPrice(deserialized);
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
                        JsonSerializer.Deserialize<Models::NewPlanGroupedTieredPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanGroupedTieredPrice(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Price? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            PriceVariants::NewPlanUnitPrice(var newPlanUnit) => newPlanUnit,
            PriceVariants::NewPlanPackagePrice(var newPlanPackage) => newPlanPackage,
            PriceVariants::NewPlanMatrixPrice(var newPlanMatrix) => newPlanMatrix,
            PriceVariants::NewPlanTieredPrice(var newPlanTiered) => newPlanTiered,
            PriceVariants::NewPlanBulkPrice(var newPlanBulk) => newPlanBulk,
            PriceVariants::NewPlanThresholdTotalAmountPrice(var newPlanThresholdTotalAmount) =>
                newPlanThresholdTotalAmount,
            PriceVariants::NewPlanTieredPackagePrice(var newPlanTieredPackage) =>
                newPlanTieredPackage,
            PriceVariants::NewPlanTieredWithMinimumPrice(var newPlanTieredWithMinimum) =>
                newPlanTieredWithMinimum,
            PriceVariants::NewPlanUnitWithPercentPrice(var newPlanUnitWithPercent) =>
                newPlanUnitWithPercent,
            PriceVariants::NewPlanPackageWithAllocationPrice(var newPlanPackageWithAllocation) =>
                newPlanPackageWithAllocation,
            PriceVariants::NewPlanTierWithProrationPrice(var newPlanTierWithProration) =>
                newPlanTierWithProration,
            PriceVariants::NewPlanUnitWithProrationPrice(var newPlanUnitWithProration) =>
                newPlanUnitWithProration,
            PriceVariants::NewPlanGroupedAllocationPrice(var newPlanGroupedAllocation) =>
                newPlanGroupedAllocation,
            PriceVariants::NewPlanGroupedWithProratedMinimumPrice(
                var newPlanGroupedWithProratedMinimum
            ) => newPlanGroupedWithProratedMinimum,
            PriceVariants::NewPlanGroupedWithMeteredMinimumPrice(
                var newPlanGroupedWithMeteredMinimum
            ) => newPlanGroupedWithMeteredMinimum,
            PriceVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            PriceVariants::NewPlanMatrixWithDisplayNamePrice(var newPlanMatrixWithDisplayName) =>
                newPlanMatrixWithDisplayName,
            PriceVariants::NewPlanBulkWithProrationPrice(var newPlanBulkWithProration) =>
                newPlanBulkWithProration,
            PriceVariants::NewPlanGroupedTieredPackagePrice(var newPlanGroupedTieredPackage) =>
                newPlanGroupedTieredPackage,
            PriceVariants::NewPlanMaxGroupTieredPackagePrice(var newPlanMaxGroupTieredPackage) =>
                newPlanMaxGroupTieredPackage,
            PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice(
                var newPlanScalableMatrixWithUnitPricing
            ) => newPlanScalableMatrixWithUnitPricing,
            PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice(
                var newPlanScalableMatrixWithTieredPricing
            ) => newPlanScalableMatrixWithTieredPricing,
            PriceVariants::NewPlanCumulativeGroupedBulkPrice(var newPlanCumulativeGroupedBulk) =>
                newPlanCumulativeGroupedBulk,
            PriceVariants::NewPlanTieredPackageWithMinimumPrice(
                var newPlanTieredPackageWithMinimum
            ) => newPlanTieredPackageWithMinimum,
            PriceVariants::NewPlanMatrixWithAllocationPrice(var newPlanMatrixWithAllocation) =>
                newPlanMatrixWithAllocation,
            PriceVariants::NewPlanGroupedTieredPrice(var newPlanGroupedTiered) =>
                newPlanGroupedTiered,
            PriceVariants::Minimum(var minimum) => minimum,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
