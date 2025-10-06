using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties;
using PriceVariants = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceVariants;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties;

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(PriceConverter))]
public abstract record class Price
{
    internal Price() { }

    public static implicit operator Price(NewPlanUnitPrice value) =>
        new PriceVariants::NewPlanUnitPrice(value);

    public static implicit operator Price(NewPlanTieredPrice value) =>
        new PriceVariants::NewPlanTieredPrice(value);

    public static implicit operator Price(NewPlanBulkPrice value) =>
        new PriceVariants::NewPlanBulkPrice(value);

    public static implicit operator Price(NewPlanPackagePrice value) =>
        new PriceVariants::NewPlanPackagePrice(value);

    public static implicit operator Price(NewPlanMatrixPrice value) =>
        new PriceVariants::NewPlanMatrixPrice(value);

    public static implicit operator Price(NewPlanThresholdTotalAmountPrice value) =>
        new PriceVariants::NewPlanThresholdTotalAmountPrice(value);

    public static implicit operator Price(NewPlanTieredPackagePrice value) =>
        new PriceVariants::NewPlanTieredPackagePrice(value);

    public static implicit operator Price(NewPlanTieredWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredWithMinimumPrice(value);

    public static implicit operator Price(NewPlanGroupedTieredPrice value) =>
        new PriceVariants::NewPlanGroupedTieredPrice(value);

    public static implicit operator Price(NewPlanTieredPackageWithMinimumPrice value) =>
        new PriceVariants::NewPlanTieredPackageWithMinimumPrice(value);

    public static implicit operator Price(NewPlanPackageWithAllocationPrice value) =>
        new PriceVariants::NewPlanPackageWithAllocationPrice(value);

    public static implicit operator Price(NewPlanUnitWithPercentPrice value) =>
        new PriceVariants::NewPlanUnitWithPercentPrice(value);

    public static implicit operator Price(NewPlanMatrixWithAllocationPrice value) =>
        new PriceVariants::NewPlanMatrixWithAllocationPrice(value);

    public static implicit operator Price(TieredWithProration value) =>
        new PriceVariants::TieredWithProration(value);

    public static implicit operator Price(NewPlanUnitWithProrationPrice value) =>
        new PriceVariants::NewPlanUnitWithProrationPrice(value);

    public static implicit operator Price(NewPlanGroupedAllocationPrice value) =>
        new PriceVariants::NewPlanGroupedAllocationPrice(value);

    public static implicit operator Price(NewPlanBulkWithProrationPrice value) =>
        new PriceVariants::NewPlanBulkWithProrationPrice(value);

    public static implicit operator Price(NewPlanGroupedWithProratedMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithProratedMinimumPrice(value);

    public static implicit operator Price(NewPlanGroupedWithMeteredMinimumPrice value) =>
        new PriceVariants::NewPlanGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Price(GroupedWithMinMaxThresholds value) =>
        new PriceVariants::GroupedWithMinMaxThresholds(value);

    public static implicit operator Price(NewPlanMatrixWithDisplayNamePrice value) =>
        new PriceVariants::NewPlanMatrixWithDisplayNamePrice(value);

    public static implicit operator Price(NewPlanGroupedTieredPackagePrice value) =>
        new PriceVariants::NewPlanGroupedTieredPackagePrice(value);

    public static implicit operator Price(NewPlanMaxGroupTieredPackagePrice value) =>
        new PriceVariants::NewPlanMaxGroupTieredPackagePrice(value);

    public static implicit operator Price(NewPlanScalableMatrixWithUnitPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Price(NewPlanScalableMatrixWithTieredPricingPrice value) =>
        new PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Price(NewPlanCumulativeGroupedBulkPrice value) =>
        new PriceVariants::NewPlanCumulativeGroupedBulkPrice(value);

    public static implicit operator Price(NewPlanMinimumCompositePrice value) =>
        new PriceVariants::NewPlanMinimumCompositePrice(value);

    public static implicit operator Price(EventOutput value) =>
        new PriceVariants::EventOutput(value);

    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = (this as PriceVariants::NewPlanUnitPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = (this as PriceVariants::NewPlanTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = (this as PriceVariants::NewPlanBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = (this as PriceVariants::NewPlanPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = (this as PriceVariants::NewPlanMatrixPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanThresholdTotalAmountPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanTieredPackageWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanPackageWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanUnitWithPercentPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMatrixWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProration? value)
    {
        value = (this as PriceVariants::TieredWithProration)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanUnitWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanBulkWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedWithProratedMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedWithMeteredMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as PriceVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMatrixWithDisplayNamePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanGroupedTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMaxGroupTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = (this as PriceVariants::NewPlanCumulativeGroupedBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = (this as PriceVariants::NewPlanMinimumCompositePrice)?.Value;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput? value)
    {
        value = (this as PriceVariants::EventOutput)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PriceVariants::NewPlanUnitPrice> newPlanUnit,
        Action<PriceVariants::NewPlanTieredPrice> newPlanTiered,
        Action<PriceVariants::NewPlanBulkPrice> newPlanBulk,
        Action<PriceVariants::NewPlanPackagePrice> newPlanPackage,
        Action<PriceVariants::NewPlanMatrixPrice> newPlanMatrix,
        Action<PriceVariants::NewPlanThresholdTotalAmountPrice> newPlanThresholdTotalAmount,
        Action<PriceVariants::NewPlanTieredPackagePrice> newPlanTieredPackage,
        Action<PriceVariants::NewPlanTieredWithMinimumPrice> newPlanTieredWithMinimum,
        Action<PriceVariants::NewPlanGroupedTieredPrice> newPlanGroupedTiered,
        Action<PriceVariants::NewPlanTieredPackageWithMinimumPrice> newPlanTieredPackageWithMinimum,
        Action<PriceVariants::NewPlanPackageWithAllocationPrice> newPlanPackageWithAllocation,
        Action<PriceVariants::NewPlanUnitWithPercentPrice> newPlanUnitWithPercent,
        Action<PriceVariants::NewPlanMatrixWithAllocationPrice> newPlanMatrixWithAllocation,
        Action<PriceVariants::TieredWithProration> tieredWithProration,
        Action<PriceVariants::NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        Action<PriceVariants::NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        Action<PriceVariants::NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        Action<PriceVariants::NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        Action<PriceVariants::NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        Action<PriceVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<PriceVariants::NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        Action<PriceVariants::NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        Action<PriceVariants::NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        Action<PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        Action<PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        Action<PriceVariants::NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        Action<PriceVariants::NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        Action<PriceVariants::EventOutput> eventOutput
    )
    {
        switch (this)
        {
            case PriceVariants::NewPlanUnitPrice inner:
                newPlanUnit(inner);
                break;
            case PriceVariants::NewPlanTieredPrice inner:
                newPlanTiered(inner);
                break;
            case PriceVariants::NewPlanBulkPrice inner:
                newPlanBulk(inner);
                break;
            case PriceVariants::NewPlanPackagePrice inner:
                newPlanPackage(inner);
                break;
            case PriceVariants::NewPlanMatrixPrice inner:
                newPlanMatrix(inner);
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
            case PriceVariants::NewPlanGroupedTieredPrice inner:
                newPlanGroupedTiered(inner);
                break;
            case PriceVariants::NewPlanTieredPackageWithMinimumPrice inner:
                newPlanTieredPackageWithMinimum(inner);
                break;
            case PriceVariants::NewPlanPackageWithAllocationPrice inner:
                newPlanPackageWithAllocation(inner);
                break;
            case PriceVariants::NewPlanUnitWithPercentPrice inner:
                newPlanUnitWithPercent(inner);
                break;
            case PriceVariants::NewPlanMatrixWithAllocationPrice inner:
                newPlanMatrixWithAllocation(inner);
                break;
            case PriceVariants::TieredWithProration inner:
                tieredWithProration(inner);
                break;
            case PriceVariants::NewPlanUnitWithProrationPrice inner:
                newPlanUnitWithProration(inner);
                break;
            case PriceVariants::NewPlanGroupedAllocationPrice inner:
                newPlanGroupedAllocation(inner);
                break;
            case PriceVariants::NewPlanBulkWithProrationPrice inner:
                newPlanBulkWithProration(inner);
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
            case PriceVariants::NewPlanMinimumCompositePrice inner:
                newPlanMinimumComposite(inner);
                break;
            case PriceVariants::EventOutput inner:
                eventOutput(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    public T Match<T>(
        Func<PriceVariants::NewPlanUnitPrice, T> newPlanUnit,
        Func<PriceVariants::NewPlanTieredPrice, T> newPlanTiered,
        Func<PriceVariants::NewPlanBulkPrice, T> newPlanBulk,
        Func<PriceVariants::NewPlanPackagePrice, T> newPlanPackage,
        Func<PriceVariants::NewPlanMatrixPrice, T> newPlanMatrix,
        Func<PriceVariants::NewPlanThresholdTotalAmountPrice, T> newPlanThresholdTotalAmount,
        Func<PriceVariants::NewPlanTieredPackagePrice, T> newPlanTieredPackage,
        Func<PriceVariants::NewPlanTieredWithMinimumPrice, T> newPlanTieredWithMinimum,
        Func<PriceVariants::NewPlanGroupedTieredPrice, T> newPlanGroupedTiered,
        Func<
            PriceVariants::NewPlanTieredPackageWithMinimumPrice,
            T
        > newPlanTieredPackageWithMinimum,
        Func<PriceVariants::NewPlanPackageWithAllocationPrice, T> newPlanPackageWithAllocation,
        Func<PriceVariants::NewPlanUnitWithPercentPrice, T> newPlanUnitWithPercent,
        Func<PriceVariants::NewPlanMatrixWithAllocationPrice, T> newPlanMatrixWithAllocation,
        Func<PriceVariants::TieredWithProration, T> tieredWithProration,
        Func<PriceVariants::NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        Func<PriceVariants::NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        Func<PriceVariants::NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
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
        Func<PriceVariants::NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        Func<PriceVariants::EventOutput, T> eventOutput
    )
    {
        return this switch
        {
            PriceVariants::NewPlanUnitPrice inner => newPlanUnit(inner),
            PriceVariants::NewPlanTieredPrice inner => newPlanTiered(inner),
            PriceVariants::NewPlanBulkPrice inner => newPlanBulk(inner),
            PriceVariants::NewPlanPackagePrice inner => newPlanPackage(inner),
            PriceVariants::NewPlanMatrixPrice inner => newPlanMatrix(inner),
            PriceVariants::NewPlanThresholdTotalAmountPrice inner => newPlanThresholdTotalAmount(
                inner
            ),
            PriceVariants::NewPlanTieredPackagePrice inner => newPlanTieredPackage(inner),
            PriceVariants::NewPlanTieredWithMinimumPrice inner => newPlanTieredWithMinimum(inner),
            PriceVariants::NewPlanGroupedTieredPrice inner => newPlanGroupedTiered(inner),
            PriceVariants::NewPlanTieredPackageWithMinimumPrice inner =>
                newPlanTieredPackageWithMinimum(inner),
            PriceVariants::NewPlanPackageWithAllocationPrice inner => newPlanPackageWithAllocation(
                inner
            ),
            PriceVariants::NewPlanUnitWithPercentPrice inner => newPlanUnitWithPercent(inner),
            PriceVariants::NewPlanMatrixWithAllocationPrice inner => newPlanMatrixWithAllocation(
                inner
            ),
            PriceVariants::TieredWithProration inner => tieredWithProration(inner),
            PriceVariants::NewPlanUnitWithProrationPrice inner => newPlanUnitWithProration(inner),
            PriceVariants::NewPlanGroupedAllocationPrice inner => newPlanGroupedAllocation(inner),
            PriceVariants::NewPlanBulkWithProrationPrice inner => newPlanBulkWithProration(inner),
            PriceVariants::NewPlanGroupedWithProratedMinimumPrice inner =>
                newPlanGroupedWithProratedMinimum(inner),
            PriceVariants::NewPlanGroupedWithMeteredMinimumPrice inner =>
                newPlanGroupedWithMeteredMinimum(inner),
            PriceVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            PriceVariants::NewPlanMatrixWithDisplayNamePrice inner => newPlanMatrixWithDisplayName(
                inner
            ),
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
            PriceVariants::NewPlanMinimumCompositePrice inner => newPlanMinimumComposite(inner),
            PriceVariants::EventOutput inner => eventOutput(inner),
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanUnitPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanUnitPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanTieredPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanBulkPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanBulkPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanPackagePrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanMatrixPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanThresholdTotalAmountPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanTieredPackagePrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanTieredWithMinimumPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanGroupedTieredPrice",
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
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanTieredPackageWithMinimumPrice",
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
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanPackageWithAllocationPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanUnitWithPercentPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanMatrixWithAllocationPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanUnitWithProrationPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanGroupedAllocationPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanBulkWithProrationPrice",
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
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanGroupedWithProratedMinimumPrice",
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
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanGroupedWithMeteredMinimumPrice",
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
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanMatrixWithDisplayNamePrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanGroupedTieredPackagePrice",
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
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanMaxGroupTieredPackagePrice",
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
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanScalableMatrixWithUnitPricingPrice",
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
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanScalableMatrixWithTieredPricingPrice",
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
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
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
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanCumulativeGroupedBulkPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PriceVariants::NewPlanMinimumCompositePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::NewPlanMinimumCompositePrice",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutput>(json, options);
                    if (deserialized != null)
                    {
                        return new PriceVariants::EventOutput(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant PriceVariants::EventOutput",
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
            PriceVariants::NewPlanUnitPrice(var newPlanUnit) => newPlanUnit,
            PriceVariants::NewPlanTieredPrice(var newPlanTiered) => newPlanTiered,
            PriceVariants::NewPlanBulkPrice(var newPlanBulk) => newPlanBulk,
            PriceVariants::NewPlanPackagePrice(var newPlanPackage) => newPlanPackage,
            PriceVariants::NewPlanMatrixPrice(var newPlanMatrix) => newPlanMatrix,
            PriceVariants::NewPlanThresholdTotalAmountPrice(var newPlanThresholdTotalAmount) =>
                newPlanThresholdTotalAmount,
            PriceVariants::NewPlanTieredPackagePrice(var newPlanTieredPackage) =>
                newPlanTieredPackage,
            PriceVariants::NewPlanTieredWithMinimumPrice(var newPlanTieredWithMinimum) =>
                newPlanTieredWithMinimum,
            PriceVariants::NewPlanGroupedTieredPrice(var newPlanGroupedTiered) =>
                newPlanGroupedTiered,
            PriceVariants::NewPlanTieredPackageWithMinimumPrice(
                var newPlanTieredPackageWithMinimum
            ) => newPlanTieredPackageWithMinimum,
            PriceVariants::NewPlanPackageWithAllocationPrice(var newPlanPackageWithAllocation) =>
                newPlanPackageWithAllocation,
            PriceVariants::NewPlanUnitWithPercentPrice(var newPlanUnitWithPercent) =>
                newPlanUnitWithPercent,
            PriceVariants::NewPlanMatrixWithAllocationPrice(var newPlanMatrixWithAllocation) =>
                newPlanMatrixWithAllocation,
            PriceVariants::TieredWithProration(var tieredWithProration) => tieredWithProration,
            PriceVariants::NewPlanUnitWithProrationPrice(var newPlanUnitWithProration) =>
                newPlanUnitWithProration,
            PriceVariants::NewPlanGroupedAllocationPrice(var newPlanGroupedAllocation) =>
                newPlanGroupedAllocation,
            PriceVariants::NewPlanBulkWithProrationPrice(var newPlanBulkWithProration) =>
                newPlanBulkWithProration,
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
            PriceVariants::NewPlanMinimumCompositePrice(var newPlanMinimumComposite) =>
                newPlanMinimumComposite,
            PriceVariants::EventOutput(var eventOutput) => eventOutput,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
