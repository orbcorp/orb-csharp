using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties;
using PriceVariants = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceVariants;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties;

/// <summary>
/// New subscription price request body params.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(NewSubscriptionUnitPrice value) =>
        new PriceVariants::NewSubscriptionUnitPrice(value);

    public static implicit operator Price(NewSubscriptionTieredPrice value) =>
        new PriceVariants::NewSubscriptionTieredPrice(value);

    public static implicit operator Price(NewSubscriptionBulkPrice value) =>
        new PriceVariants::NewSubscriptionBulkPrice(value);

    public static implicit operator Price(NewSubscriptionPackagePrice value) =>
        new PriceVariants::NewSubscriptionPackagePrice(value);

    public static implicit operator Price(NewSubscriptionMatrixPrice value) =>
        new PriceVariants::NewSubscriptionMatrixPrice(value);

    public static implicit operator Price(NewSubscriptionThresholdTotalAmountPrice value) =>
        new PriceVariants::NewSubscriptionThresholdTotalAmountPrice(value);

    public static implicit operator Price(NewSubscriptionTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionTieredPackagePrice(value);

    public static implicit operator Price(NewSubscriptionTieredWithMinimumPrice value) =>
        new PriceVariants::NewSubscriptionTieredWithMinimumPrice(value);

    public static implicit operator Price(NewSubscriptionGroupedTieredPrice value) =>
        new PriceVariants::NewSubscriptionGroupedTieredPrice(value);

    public static implicit operator Price(NewSubscriptionTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(NewSubscriptionPackageWithAllocationPrice value) =>
        new PriceVariants::NewSubscriptionPackageWithAllocationPrice(value);

    public static implicit operator Price(NewSubscriptionUnitWithPercentPrice value) =>
        new PriceVariants::NewSubscriptionUnitWithPercentPrice(value);

    public static implicit operator Price(NewSubscriptionMatrixWithAllocationPrice value) =>
        new PriceVariants::NewSubscriptionMatrixWithAllocationPrice(value);

    public static implicit operator Price(TieredWithProration value) =>
        new PriceVariants::TieredWithProration(value);

    public static implicit operator Price(NewSubscriptionUnitWithProrationPrice value) =>
        new PriceVariants::NewSubscriptionUnitWithProrationPrice(value);

    public static implicit operator Price(NewSubscriptionGroupedAllocationPrice value) =>
        new PriceVariants::NewSubscriptionGroupedAllocationPrice(value);

    public static implicit operator Price(NewSubscriptionBulkWithProrationPrice value) =>
        new PriceVariants::NewSubscriptionBulkWithProrationPrice(value);

    public static implicit operator Price(NewSubscriptionGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(NewSubscriptionGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public static implicit operator Price(NewSubscriptionMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(NewSubscriptionGroupedTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionGroupedTieredPackagePrice(value);

    public static implicit operator Price(NewSubscriptionMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(
        NewSubscriptionScalableMatrixWithUnitPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(
        NewSubscriptionScalableMatrixWithTieredPricingPrice value
    ) => new PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(NewSubscriptionCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice(value);

    public static implicit operator Price(NewSubscriptionMinimumCompositePrice value) =>
        new PriceVariants::NewSubscriptionMinimumCompositePrice(value);

    public bool TryPickNewSubscriptionUnit([NotNullWhen(true)] out NewSubscriptionUnitPrice? value)
    {
        value = (this as PriceVariants::NewSubscriptionUnitPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionTiered(
        [NotNullWhen(true)] out NewSubscriptionTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulk([NotNullWhen(true)] out NewSubscriptionBulkPrice? value)
    {
        value = (this as PriceVariants::NewSubscriptionBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackage(
        [NotNullWhen(true)] out NewSubscriptionPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrix(
        [NotNullWhen(true)] out NewSubscriptionMatrixPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionMatrixPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionThresholdTotalAmount(
        [NotNullWhen(true)] out NewSubscriptionThresholdTotalAmountPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionThresholdTotalAmountPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionTieredWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTiered(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionGroupedTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewSubscriptionTieredPackageWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionPackageWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionPackageWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionPackageWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithPercent(
        [NotNullWhen(true)] out NewSubscriptionUnitWithPercentPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionUnitWithPercentPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithAllocation(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionMatrixWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration? value)
    {
        value = (this as PriceVariants::TieredWithProration)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionUnitWithProration(
        [NotNullWhen(true)] out NewSubscriptionUnitWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionUnitWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedAllocation(
        [NotNullWhen(true)] out NewSubscriptionGroupedAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionGroupedAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionBulkWithProration(
        [NotNullWhen(true)] out NewSubscriptionBulkWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionBulkWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithProratedMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewSubscriptionGroupedWithMeteredMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionMatrixWithDisplayName(
        [NotNullWhen(true)] out NewSubscriptionMatrixWithDisplayNamePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionGroupedTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionGroupedTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionGroupedTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewSubscriptionMaxGroupTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewSubscriptionScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewSubscriptionCumulativeGroupedBulkPrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewSubscriptionMinimumComposite(
        [NotNullWhen(true)] out NewSubscriptionMinimumCompositePrice? value
    )
    {
        value = (this as PriceVariants::NewSubscriptionMinimumCompositePrice)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::NewSubscriptionUnitPrice> newSubscriptionUnit,
        Action<PriceVariants::NewSubscriptionTieredPrice> newSubscriptionTiered,
        Action<PriceVariants::NewSubscriptionBulkPrice> newSubscriptionBulk,
        Action<PriceVariants::NewSubscriptionPackagePrice> newSubscriptionPackage,
        Action<PriceVariants::NewSubscriptionMatrixPrice> newSubscriptionMatrix,
        Action<PriceVariants::NewSubscriptionThresholdTotalAmountPrice> newSubscriptionThresholdTotalAmount,
        Action<PriceVariants::NewSubscriptionTieredPackagePrice> newSubscriptionTieredPackage,
        Action<PriceVariants::NewSubscriptionTieredWithMinimumPrice> newSubscriptionTieredWithMinimum,
        Action<PriceVariants::NewSubscriptionGroupedTieredPrice> newSubscriptionGroupedTiered,
        Action<PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice> newSubscriptionTieredPackageWithMinimum,
        Action<PriceVariants::NewSubscriptionPackageWithAllocationPrice> newSubscriptionPackageWithAllocation,
        Action<PriceVariants::NewSubscriptionUnitWithPercentPrice> newSubscriptionUnitWithPercent,
        Action<PriceVariants::NewSubscriptionMatrixWithAllocationPrice> newSubscriptionMatrixWithAllocation,
        Action<PriceVariants::TieredWithProration> tieredWithProration,
        Action<PriceVariants::NewSubscriptionUnitWithProrationPrice> newSubscriptionUnitWithProration,
        Action<PriceVariants::NewSubscriptionGroupedAllocationPrice> newSubscriptionGroupedAllocation,
        Action<PriceVariants::NewSubscriptionBulkWithProrationPrice> newSubscriptionBulkWithProration,
        Action<PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice> newSubscriptionGroupedWithProratedMinimum,
        Action<PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice> newSubscriptionGroupedWithMeteredMinimum,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice> newSubscriptionMatrixWithDisplayName,
        Action<PriceVariants::NewSubscriptionGroupedTieredPackagePrice> newSubscriptionGroupedTieredPackage,
        Action<PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice> newSubscriptionMaxGroupTieredPackage,
        Action<PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice> newSubscriptionScalableMatrixWithUnitPricing,
        Action<PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice> newSubscriptionScalableMatrixWithTieredPricing,
        Action<PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice> newSubscriptionCumulativeGroupedBulk,
        Action<PriceVariants::NewSubscriptionMinimumCompositePrice> newSubscriptionMinimumComposite
    )
    {
        switch (this)
        {
            case PriceVariants::NewSubscriptionUnitPrice inner:
                newSubscriptionUnit(inner);
                break;
            case PriceVariants::NewSubscriptionTieredPrice inner:
                newSubscriptionTiered(inner);
                break;
            case PriceVariants::NewSubscriptionBulkPrice inner:
                newSubscriptionBulk(inner);
                break;
            case PriceVariants::NewSubscriptionPackagePrice inner:
                newSubscriptionPackage(inner);
                break;
            case PriceVariants::NewSubscriptionMatrixPrice inner:
                newSubscriptionMatrix(inner);
                break;
            case PriceVariants::NewSubscriptionThresholdTotalAmountPrice inner:
                newSubscriptionThresholdTotalAmount(inner);
                break;
            case PriceVariants::NewSubscriptionTieredPackagePrice inner:
                newSubscriptionTieredPackage(inner);
                break;
            case PriceVariants::NewSubscriptionTieredWithMinimumPrice inner:
                newSubscriptionTieredWithMinimum(inner);
                break;
            case PriceVariants::NewSubscriptionGroupedTieredPrice inner:
                newSubscriptionGroupedTiered(inner);
                break;
            case PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice inner:
                newSubscriptionTieredPackageWithMinimum(inner);
                break;
            case PriceVariants::NewSubscriptionPackageWithAllocationPrice inner:
                newSubscriptionPackageWithAllocation(inner);
                break;
            case PriceVariants::NewSubscriptionUnitWithPercentPrice inner:
                newSubscriptionUnitWithPercent(inner);
                break;
            case PriceVariants::NewSubscriptionMatrixWithAllocationPrice inner:
                newSubscriptionMatrixWithAllocation(inner);
                break;
            case PriceVariants::TieredWithProration inner:
                tieredWithProration(inner);
                break;
            case PriceVariants::NewSubscriptionUnitWithProrationPrice inner:
                newSubscriptionUnitWithProration(inner);
                break;
            case PriceVariants::NewSubscriptionGroupedAllocationPrice inner:
                newSubscriptionGroupedAllocation(inner);
                break;
            case PriceVariants::NewSubscriptionBulkWithProrationPrice inner:
                newSubscriptionBulkWithProration(inner);
                break;
            case PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice inner:
                newSubscriptionGroupedWithProratedMinimum(inner);
                break;
            case PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice inner:
                newSubscriptionGroupedWithMeteredMinimum(inner);
                break;
            case PriceVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            case PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice inner:
                newSubscriptionMatrixWithDisplayName(inner);
                break;
            case PriceVariants::NewSubscriptionGroupedTieredPackagePrice inner:
                newSubscriptionGroupedTieredPackage(inner);
                break;
            case PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice inner:
                newSubscriptionMaxGroupTieredPackage(inner);
                break;
            case PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice inner:
                newSubscriptionScalableMatrixWithUnitPricing(inner);
                break;
            case PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice inner:
                newSubscriptionScalableMatrixWithTieredPricing(inner);
                break;
            case PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice inner:
                newSubscriptionCumulativeGroupedBulk(inner);
                break;
            case PriceVariants::NewSubscriptionMinimumCompositePrice inner:
                newSubscriptionMinimumComposite(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    public T Match<T>(
        Func<PriceVariants::NewSubscriptionUnitPrice, T> newSubscriptionUnit,
        Func<PriceVariants::NewSubscriptionTieredPrice, T> newSubscriptionTiered,
        Func<PriceVariants::NewSubscriptionBulkPrice, T> newSubscriptionBulk,
        Func<PriceVariants::NewSubscriptionPackagePrice, T> newSubscriptionPackage,
        Func<PriceVariants::NewSubscriptionMatrixPrice, T> newSubscriptionMatrix,
        Func<
            PriceVariants::NewSubscriptionThresholdTotalAmountPrice,
            T
        > newSubscriptionThresholdTotalAmount,
        Func<PriceVariants::NewSubscriptionTieredPackagePrice, T> newSubscriptionTieredPackage,
        Func<
            PriceVariants::NewSubscriptionTieredWithMinimumPrice,
            T
        > newSubscriptionTieredWithMinimum,
        Func<PriceVariants::NewSubscriptionGroupedTieredPrice, T> newSubscriptionGroupedTiered,
        Func<
            PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice,
            T
        > newSubscriptionTieredPackageWithMinimum,
        Func<
            PriceVariants::NewSubscriptionPackageWithAllocationPrice,
            T
        > newSubscriptionPackageWithAllocation,
        Func<PriceVariants::NewSubscriptionUnitWithPercentPrice, T> newSubscriptionUnitWithPercent,
        Func<
            PriceVariants::NewSubscriptionMatrixWithAllocationPrice,
            T
        > newSubscriptionMatrixWithAllocation,
        Func<PriceVariants::TieredWithProration, T> tieredWithProration,
        Func<
            PriceVariants::NewSubscriptionUnitWithProrationPrice,
            T
        > newSubscriptionUnitWithProration,
        Func<
            PriceVariants::NewSubscriptionGroupedAllocationPrice,
            T
        > newSubscriptionGroupedAllocation,
        Func<
            PriceVariants::NewSubscriptionBulkWithProrationPrice,
            T
        > newSubscriptionBulkWithProration,
        Func<
            PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice,
            T
        > newSubscriptionGroupedWithProratedMinimum,
        Func<
            PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice,
            T
        > newSubscriptionGroupedWithMeteredMinimum,
        Func<PriceVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<
            PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice,
            T
        > newSubscriptionMatrixWithDisplayName,
        Func<
            PriceVariants::NewSubscriptionGroupedTieredPackagePrice,
            T
        > newSubscriptionGroupedTieredPackage,
        Func<
            PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice,
            T
        > newSubscriptionMaxGroupTieredPackage,
        Func<
            PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice,
            T
        > newSubscriptionScalableMatrixWithUnitPricing,
        Func<
            PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice,
            T
        > newSubscriptionScalableMatrixWithTieredPricing,
        Func<
            PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice,
            T
        > newSubscriptionCumulativeGroupedBulk,
        Func<PriceVariants::NewSubscriptionMinimumCompositePrice, T> newSubscriptionMinimumComposite
    )
    {
        return this switch
        {
            PriceVariants::NewSubscriptionUnitPrice inner => newSubscriptionUnit(inner),
            PriceVariants::NewSubscriptionTieredPrice inner => newSubscriptionTiered(inner),
            PriceVariants::NewSubscriptionBulkPrice inner => newSubscriptionBulk(inner),
            PriceVariants::NewSubscriptionPackagePrice inner => newSubscriptionPackage(inner),
            PriceVariants::NewSubscriptionMatrixPrice inner => newSubscriptionMatrix(inner),
            PriceVariants::NewSubscriptionThresholdTotalAmountPrice inner =>
                newSubscriptionThresholdTotalAmount(inner),
            PriceVariants::NewSubscriptionTieredPackagePrice inner => newSubscriptionTieredPackage(
                inner
            ),
            PriceVariants::NewSubscriptionTieredWithMinimumPrice inner =>
                newSubscriptionTieredWithMinimum(inner),
            PriceVariants::NewSubscriptionGroupedTieredPrice inner => newSubscriptionGroupedTiered(
                inner
            ),
            PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice inner =>
                newSubscriptionTieredPackageWithMinimum(inner),
            PriceVariants::NewSubscriptionPackageWithAllocationPrice inner =>
                newSubscriptionPackageWithAllocation(inner),
            PriceVariants::NewSubscriptionUnitWithPercentPrice inner =>
                newSubscriptionUnitWithPercent(inner),
            PriceVariants::NewSubscriptionMatrixWithAllocationPrice inner =>
                newSubscriptionMatrixWithAllocation(inner),
            PriceVariants::TieredWithProration inner => tieredWithProration(inner),
            PriceVariants::NewSubscriptionUnitWithProrationPrice inner =>
                newSubscriptionUnitWithProration(inner),
            PriceVariants::NewSubscriptionGroupedAllocationPrice inner =>
                newSubscriptionGroupedAllocation(inner),
            PriceVariants::NewSubscriptionBulkWithProrationPrice inner =>
                newSubscriptionBulkWithProration(inner),
            PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice inner =>
                newSubscriptionGroupedWithProratedMinimum(inner),
            PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice inner =>
                newSubscriptionGroupedWithMeteredMinimum(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice inner =>
                newSubscriptionMatrixWithDisplayName(inner),
            PriceVariants::NewSubscriptionGroupedTieredPackagePrice inner =>
                newSubscriptionGroupedTieredPackage(inner),
            PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice inner =>
                newSubscriptionMaxGroupTieredPackage(inner),
            PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice inner =>
                newSubscriptionScalableMatrixWithUnitPricing(inner),
            PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice inner =>
                newSubscriptionScalableMatrixWithTieredPricing(inner),
            PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice inner =>
                newSubscriptionCumulativeGroupedBulk(inner),
            PriceVariants::NewSubscriptionMinimumCompositePrice inner =>
                newSubscriptionMinimumComposite(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionUnitPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionUnitPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionTieredPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionTieredPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionBulkPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionBulkPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionPackagePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionPackagePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSubscriptionMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionMatrixPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionMatrixPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionThresholdTotalAmountPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionThresholdTotalAmountPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionTieredPackagePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionTieredPackagePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionTieredWithMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionTieredWithMinimumPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionGroupedTieredPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionGroupedTieredPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionPackageWithAllocationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionPackageWithAllocationPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithPercentPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionUnitWithPercentPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionUnitWithPercentPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionMatrixWithAllocationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionMatrixWithAllocationPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::TieredWithProration",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionUnitWithProrationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionUnitWithProrationPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionGroupedAllocationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionGroupedAllocationPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionBulkWithProrationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionBulkWithProrationPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::GroupedWithMinMaxThresholds",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionGroupedTieredPackagePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionGroupedTieredPackagePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewSubscriptionMinimumCompositePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewSubscriptionMinimumCompositePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewSubscriptionMinimumCompositePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Price? value, JsonSerializerOptions options)
    {
        object? variant = value switch
        {
            null => null,
            PriceVariants::NewSubscriptionUnitPrice(var newSubscriptionUnit) => newSubscriptionUnit,
            PriceVariants::NewSubscriptionTieredPrice(var newSubscriptionTiered) =>
                newSubscriptionTiered,
            PriceVariants::NewSubscriptionBulkPrice(var newSubscriptionBulk) => newSubscriptionBulk,
            PriceVariants::NewSubscriptionPackagePrice(var newSubscriptionPackage) =>
                newSubscriptionPackage,
            PriceVariants::NewSubscriptionMatrixPrice(var newSubscriptionMatrix) =>
                newSubscriptionMatrix,
            PriceVariants::NewSubscriptionThresholdTotalAmountPrice(
                var newSubscriptionThresholdTotalAmount
            ) => newSubscriptionThresholdTotalAmount,
            PriceVariants::NewSubscriptionTieredPackagePrice(var newSubscriptionTieredPackage) =>
                newSubscriptionTieredPackage,
            PriceVariants::NewSubscriptionTieredWithMinimumPrice(
                var newSubscriptionTieredWithMinimum
            ) => newSubscriptionTieredWithMinimum,
            PriceVariants::NewSubscriptionGroupedTieredPrice(var newSubscriptionGroupedTiered) =>
                newSubscriptionGroupedTiered,
            PriceVariants::NewSubscriptionTieredPackageWithMinimumPrice(
                var newSubscriptionTieredPackageWithMinimum
            ) => newSubscriptionTieredPackageWithMinimum,
            PriceVariants::NewSubscriptionPackageWithAllocationPrice(
                var newSubscriptionPackageWithAllocation
            ) => newSubscriptionPackageWithAllocation,
            PriceVariants::NewSubscriptionUnitWithPercentPrice(
                var newSubscriptionUnitWithPercent
            ) => newSubscriptionUnitWithPercent,
            PriceVariants::NewSubscriptionMatrixWithAllocationPrice(
                var newSubscriptionMatrixWithAllocation
            ) => newSubscriptionMatrixWithAllocation,
            PriceVariants::TieredWithProration(var tieredWithProration) => tieredWithProration,
            PriceVariants::NewSubscriptionUnitWithProrationPrice(
                var newSubscriptionUnitWithProration
            ) => newSubscriptionUnitWithProration,
            PriceVariants::NewSubscriptionGroupedAllocationPrice(
                var newSubscriptionGroupedAllocation
            ) => newSubscriptionGroupedAllocation,
            PriceVariants::NewSubscriptionBulkWithProrationPrice(
                var newSubscriptionBulkWithProration
            ) => newSubscriptionBulkWithProration,
            PriceVariants::NewSubscriptionGroupedWithProratedMinimumPrice(
                var newSubscriptionGroupedWithProratedMinimum
            ) => newSubscriptionGroupedWithProratedMinimum,
            PriceVariants::NewSubscriptionGroupedWithMeteredMinimumPrice(
                var newSubscriptionGroupedWithMeteredMinimum
            ) => newSubscriptionGroupedWithMeteredMinimum,
            PriceVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            PriceVariants::NewSubscriptionMatrixWithDisplayNamePrice(
                var newSubscriptionMatrixWithDisplayName
            ) => newSubscriptionMatrixWithDisplayName,
            PriceVariants::NewSubscriptionGroupedTieredPackagePrice(
                var newSubscriptionGroupedTieredPackage
            ) => newSubscriptionGroupedTieredPackage,
            PriceVariants::NewSubscriptionMaxGroupTieredPackagePrice(
                var newSubscriptionMaxGroupTieredPackage
            ) => newSubscriptionMaxGroupTieredPackage,
            PriceVariants::NewSubscriptionScalableMatrixWithUnitPricingPrice(
                var newSubscriptionScalableMatrixWithUnitPricing
            ) => newSubscriptionScalableMatrixWithUnitPricing,
            PriceVariants::NewSubscriptionScalableMatrixWithTieredPricingPrice(
                var newSubscriptionScalableMatrixWithTieredPricing
            ) => newSubscriptionScalableMatrixWithTieredPricing,
            PriceVariants::NewSubscriptionCumulativeGroupedBulkPrice(
                var newSubscriptionCumulativeGroupedBulk
            ) => newSubscriptionCumulativeGroupedBulk,
            PriceVariants::NewSubscriptionMinimumCompositePrice(
                var newSubscriptionMinimumComposite
            ) => newSubscriptionMinimumComposite,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
