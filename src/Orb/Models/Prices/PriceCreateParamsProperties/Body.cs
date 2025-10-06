using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Prices.PriceCreateParamsProperties.BodyProperties;
using BodyVariants = Orb.Models.Prices.PriceCreateParamsProperties.BodyVariants;

namespace Orb.Models.Prices.PriceCreateParamsProperties;

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(NewFloatingUnitPrice value) =>
        new BodyVariants::NewFloatingUnitPrice(value);

    public static implicit operator Body(NewFloatingTieredPrice value) =>
        new BodyVariants::NewFloatingTieredPrice(value);

    public static implicit operator Body(NewFloatingBulkPrice value) =>
        new BodyVariants::NewFloatingBulkPrice(value);

    public static implicit operator Body(NewFloatingPackagePrice value) =>
        new BodyVariants::NewFloatingPackagePrice(value);

    public static implicit operator Body(NewFloatingMatrixPrice value) =>
        new BodyVariants::NewFloatingMatrixPrice(value);

    public static implicit operator Body(NewFloatingThresholdTotalAmountPrice value) =>
        new BodyVariants::NewFloatingThresholdTotalAmountPrice(value);

    public static implicit operator Body(NewFloatingTieredPackagePrice value) =>
        new BodyVariants::NewFloatingTieredPackagePrice(value);

    public static implicit operator Body(NewFloatingTieredWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredWithMinimumPrice(value);

    public static implicit operator Body(NewFloatingGroupedTieredPrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPrice(value);

    public static implicit operator Body(NewFloatingTieredPackageWithMinimumPrice value) =>
        new BodyVariants::NewFloatingTieredPackageWithMinimumPrice(value);

    public static implicit operator Body(NewFloatingPackageWithAllocationPrice value) =>
        new BodyVariants::NewFloatingPackageWithAllocationPrice(value);

    public static implicit operator Body(NewFloatingUnitWithPercentPrice value) =>
        new BodyVariants::NewFloatingUnitWithPercentPrice(value);

    public static implicit operator Body(NewFloatingMatrixWithAllocationPrice value) =>
        new BodyVariants::NewFloatingMatrixWithAllocationPrice(value);

    public static implicit operator Body(NewFloatingTieredWithProrationPrice value) =>
        new BodyVariants::NewFloatingTieredWithProrationPrice(value);

    public static implicit operator Body(NewFloatingUnitWithProrationPrice value) =>
        new BodyVariants::NewFloatingUnitWithProrationPrice(value);

    public static implicit operator Body(NewFloatingGroupedAllocationPrice value) =>
        new BodyVariants::NewFloatingGroupedAllocationPrice(value);

    public static implicit operator Body(NewFloatingBulkWithProrationPrice value) =>
        new BodyVariants::NewFloatingBulkWithProrationPrice(value);

    public static implicit operator Body(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new BodyVariants::NewFloatingGroupedWithProratedMinimumPrice(value);

    public static implicit operator Body(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice(value);

    public static implicit operator Body(GroupedWithMinMaxThresholds value) =>
        new BodyVariants::GroupedWithMinMaxThresholds(value);

    public static implicit operator Body(NewFloatingMatrixWithDisplayNamePrice value) =>
        new BodyVariants::NewFloatingMatrixWithDisplayNamePrice(value);

    public static implicit operator Body(NewFloatingGroupedTieredPackagePrice value) =>
        new BodyVariants::NewFloatingGroupedTieredPackagePrice(value);

    public static implicit operator Body(NewFloatingMaxGroupTieredPackagePrice value) =>
        new BodyVariants::NewFloatingMaxGroupTieredPackagePrice(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithUnitPricingPrice value) =>
        new BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice(value);

    public static implicit operator Body(NewFloatingScalableMatrixWithTieredPricingPrice value) =>
        new BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice(value);

    public static implicit operator Body(NewFloatingCumulativeGroupedBulkPrice value) =>
        new BodyVariants::NewFloatingCumulativeGroupedBulkPrice(value);

    public static implicit operator Body(NewFloatingMinimumCompositePrice value) =>
        new BodyVariants::NewFloatingMinimumCompositePrice(value);

    public static implicit operator Body(EventOutput value) => new BodyVariants::EventOutput(value);

    public bool TryPickNewFloatingUnitPrice([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = (this as BodyVariants::NewFloatingUnitPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPrice([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = (this as BodyVariants::NewFloatingTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingBulkPrice([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = (this as BodyVariants::NewFloatingBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingPackagePrice(
        [NotNullWhen(true)] out NewFloatingPackagePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixPrice([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = (this as BodyVariants::NewFloatingMatrixPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingThresholdTotalAmountPrice(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingThresholdTotalAmountPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithMinimumPrice(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingTieredWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPrice(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingGroupedTieredPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackageWithMinimumPrice(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingTieredPackageWithMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingPackageWithAllocationPrice(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingPackageWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithPercentPrice(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingUnitWithPercentPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithAllocationPrice(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingMatrixWithAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingTieredWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingUnitWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedAllocationPrice(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingGroupedAllocationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingBulkWithProrationPrice(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingBulkWithProrationPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithProratedMinimumPrice(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingGroupedWithProratedMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithMeteredMinimumPrice(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice)?.Value;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds? value
    )
    {
        value = (this as BodyVariants::GroupedWithMinMaxThresholds)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithDisplayNamePrice(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingMatrixWithDisplayNamePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingGroupedTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMaxGroupTieredPackagePrice(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingMaxGroupTieredPackagePrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithUnitPricingPrice(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithTieredPricingPrice(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingCumulativeGroupedBulkPrice(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingCumulativeGroupedBulkPrice)?.Value;
        return value != null;
    }

    public bool TryPickNewFloatingMinimumCompositePrice(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = (this as BodyVariants::NewFloatingMinimumCompositePrice)?.Value;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput? value)
    {
        value = (this as BodyVariants::EventOutput)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BodyVariants::NewFloatingUnitPrice> newFloatingUnitPrice,
        Action<BodyVariants::NewFloatingTieredPrice> newFloatingTieredPrice,
        Action<BodyVariants::NewFloatingBulkPrice> newFloatingBulkPrice,
        Action<BodyVariants::NewFloatingPackagePrice> newFloatingPackagePrice,
        Action<BodyVariants::NewFloatingMatrixPrice> newFloatingMatrixPrice,
        Action<BodyVariants::NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmountPrice,
        Action<BodyVariants::NewFloatingTieredPackagePrice> newFloatingTieredPackagePrice,
        Action<BodyVariants::NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimumPrice,
        Action<BodyVariants::NewFloatingGroupedTieredPrice> newFloatingGroupedTieredPrice,
        Action<BodyVariants::NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimumPrice,
        Action<BodyVariants::NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocationPrice,
        Action<BodyVariants::NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercentPrice,
        Action<BodyVariants::NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocationPrice,
        Action<BodyVariants::NewFloatingTieredWithProrationPrice> newFloatingTieredWithProrationPrice,
        Action<BodyVariants::NewFloatingUnitWithProrationPrice> newFloatingUnitWithProrationPrice,
        Action<BodyVariants::NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocationPrice,
        Action<BodyVariants::NewFloatingBulkWithProrationPrice> newFloatingBulkWithProrationPrice,
        Action<BodyVariants::NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimumPrice,
        Action<BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimumPrice,
        Action<BodyVariants::GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        Action<BodyVariants::NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayNamePrice,
        Action<BodyVariants::NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackagePrice,
        Action<BodyVariants::NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackagePrice,
        Action<BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricingPrice,
        Action<BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricingPrice,
        Action<BodyVariants::NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulkPrice,
        Action<BodyVariants::NewFloatingMinimumCompositePrice> newFloatingMinimumCompositePrice,
        Action<BodyVariants::EventOutput> eventOutput
    )
    {
        switch (this)
        {
            case BodyVariants::NewFloatingUnitPrice inner:
                newFloatingUnitPrice(inner);
                break;
            case BodyVariants::NewFloatingTieredPrice inner:
                newFloatingTieredPrice(inner);
                break;
            case BodyVariants::NewFloatingBulkPrice inner:
                newFloatingBulkPrice(inner);
                break;
            case BodyVariants::NewFloatingPackagePrice inner:
                newFloatingPackagePrice(inner);
                break;
            case BodyVariants::NewFloatingMatrixPrice inner:
                newFloatingMatrixPrice(inner);
                break;
            case BodyVariants::NewFloatingThresholdTotalAmountPrice inner:
                newFloatingThresholdTotalAmountPrice(inner);
                break;
            case BodyVariants::NewFloatingTieredPackagePrice inner:
                newFloatingTieredPackagePrice(inner);
                break;
            case BodyVariants::NewFloatingTieredWithMinimumPrice inner:
                newFloatingTieredWithMinimumPrice(inner);
                break;
            case BodyVariants::NewFloatingGroupedTieredPrice inner:
                newFloatingGroupedTieredPrice(inner);
                break;
            case BodyVariants::NewFloatingTieredPackageWithMinimumPrice inner:
                newFloatingTieredPackageWithMinimumPrice(inner);
                break;
            case BodyVariants::NewFloatingPackageWithAllocationPrice inner:
                newFloatingPackageWithAllocationPrice(inner);
                break;
            case BodyVariants::NewFloatingUnitWithPercentPrice inner:
                newFloatingUnitWithPercentPrice(inner);
                break;
            case BodyVariants::NewFloatingMatrixWithAllocationPrice inner:
                newFloatingMatrixWithAllocationPrice(inner);
                break;
            case BodyVariants::NewFloatingTieredWithProrationPrice inner:
                newFloatingTieredWithProrationPrice(inner);
                break;
            case BodyVariants::NewFloatingUnitWithProrationPrice inner:
                newFloatingUnitWithProrationPrice(inner);
                break;
            case BodyVariants::NewFloatingGroupedAllocationPrice inner:
                newFloatingGroupedAllocationPrice(inner);
                break;
            case BodyVariants::NewFloatingBulkWithProrationPrice inner:
                newFloatingBulkWithProrationPrice(inner);
                break;
            case BodyVariants::NewFloatingGroupedWithProratedMinimumPrice inner:
                newFloatingGroupedWithProratedMinimumPrice(inner);
                break;
            case BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice inner:
                newFloatingGroupedWithMeteredMinimumPrice(inner);
                break;
            case BodyVariants::GroupedWithMinMaxThresholds inner:
                groupedWithMinMaxThresholds(inner);
                break;
            case BodyVariants::NewFloatingMatrixWithDisplayNamePrice inner:
                newFloatingMatrixWithDisplayNamePrice(inner);
                break;
            case BodyVariants::NewFloatingGroupedTieredPackagePrice inner:
                newFloatingGroupedTieredPackagePrice(inner);
                break;
            case BodyVariants::NewFloatingMaxGroupTieredPackagePrice inner:
                newFloatingMaxGroupTieredPackagePrice(inner);
                break;
            case BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice inner:
                newFloatingScalableMatrixWithUnitPricingPrice(inner);
                break;
            case BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice inner:
                newFloatingScalableMatrixWithTieredPricingPrice(inner);
                break;
            case BodyVariants::NewFloatingCumulativeGroupedBulkPrice inner:
                newFloatingCumulativeGroupedBulkPrice(inner);
                break;
            case BodyVariants::NewFloatingMinimumCompositePrice inner:
                newFloatingMinimumCompositePrice(inner);
                break;
            case BodyVariants::EventOutput inner:
                eventOutput(inner);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    public T Match<T>(
        Func<BodyVariants::NewFloatingUnitPrice, T> newFloatingUnitPrice,
        Func<BodyVariants::NewFloatingTieredPrice, T> newFloatingTieredPrice,
        Func<BodyVariants::NewFloatingBulkPrice, T> newFloatingBulkPrice,
        Func<BodyVariants::NewFloatingPackagePrice, T> newFloatingPackagePrice,
        Func<BodyVariants::NewFloatingMatrixPrice, T> newFloatingMatrixPrice,
        Func<
            BodyVariants::NewFloatingThresholdTotalAmountPrice,
            T
        > newFloatingThresholdTotalAmountPrice,
        Func<BodyVariants::NewFloatingTieredPackagePrice, T> newFloatingTieredPackagePrice,
        Func<BodyVariants::NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimumPrice,
        Func<BodyVariants::NewFloatingGroupedTieredPrice, T> newFloatingGroupedTieredPrice,
        Func<
            BodyVariants::NewFloatingTieredPackageWithMinimumPrice,
            T
        > newFloatingTieredPackageWithMinimumPrice,
        Func<
            BodyVariants::NewFloatingPackageWithAllocationPrice,
            T
        > newFloatingPackageWithAllocationPrice,
        Func<BodyVariants::NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercentPrice,
        Func<
            BodyVariants::NewFloatingMatrixWithAllocationPrice,
            T
        > newFloatingMatrixWithAllocationPrice,
        Func<
            BodyVariants::NewFloatingTieredWithProrationPrice,
            T
        > newFloatingTieredWithProrationPrice,
        Func<BodyVariants::NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProrationPrice,
        Func<BodyVariants::NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocationPrice,
        Func<BodyVariants::NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProrationPrice,
        Func<
            BodyVariants::NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimumPrice,
        Func<
            BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimumPrice,
        Func<BodyVariants::GroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        Func<
            BodyVariants::NewFloatingMatrixWithDisplayNamePrice,
            T
        > newFloatingMatrixWithDisplayNamePrice,
        Func<
            BodyVariants::NewFloatingGroupedTieredPackagePrice,
            T
        > newFloatingGroupedTieredPackagePrice,
        Func<
            BodyVariants::NewFloatingMaxGroupTieredPackagePrice,
            T
        > newFloatingMaxGroupTieredPackagePrice,
        Func<
            BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricingPrice,
        Func<
            BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricingPrice,
        Func<
            BodyVariants::NewFloatingCumulativeGroupedBulkPrice,
            T
        > newFloatingCumulativeGroupedBulkPrice,
        Func<BodyVariants::NewFloatingMinimumCompositePrice, T> newFloatingMinimumCompositePrice,
        Func<BodyVariants::EventOutput, T> eventOutput
    )
    {
        return this switch
        {
            BodyVariants::NewFloatingUnitPrice inner => newFloatingUnitPrice(inner),
            BodyVariants::NewFloatingTieredPrice inner => newFloatingTieredPrice(inner),
            BodyVariants::NewFloatingBulkPrice inner => newFloatingBulkPrice(inner),
            BodyVariants::NewFloatingPackagePrice inner => newFloatingPackagePrice(inner),
            BodyVariants::NewFloatingMatrixPrice inner => newFloatingMatrixPrice(inner),
            BodyVariants::NewFloatingThresholdTotalAmountPrice inner =>
                newFloatingThresholdTotalAmountPrice(inner),
            BodyVariants::NewFloatingTieredPackagePrice inner => newFloatingTieredPackagePrice(
                inner
            ),
            BodyVariants::NewFloatingTieredWithMinimumPrice inner =>
                newFloatingTieredWithMinimumPrice(inner),
            BodyVariants::NewFloatingGroupedTieredPrice inner => newFloatingGroupedTieredPrice(
                inner
            ),
            BodyVariants::NewFloatingTieredPackageWithMinimumPrice inner =>
                newFloatingTieredPackageWithMinimumPrice(inner),
            BodyVariants::NewFloatingPackageWithAllocationPrice inner =>
                newFloatingPackageWithAllocationPrice(inner),
            BodyVariants::NewFloatingUnitWithPercentPrice inner => newFloatingUnitWithPercentPrice(
                inner
            ),
            BodyVariants::NewFloatingMatrixWithAllocationPrice inner =>
                newFloatingMatrixWithAllocationPrice(inner),
            BodyVariants::NewFloatingTieredWithProrationPrice inner =>
                newFloatingTieredWithProrationPrice(inner),
            BodyVariants::NewFloatingUnitWithProrationPrice inner =>
                newFloatingUnitWithProrationPrice(inner),
            BodyVariants::NewFloatingGroupedAllocationPrice inner =>
                newFloatingGroupedAllocationPrice(inner),
            BodyVariants::NewFloatingBulkWithProrationPrice inner =>
                newFloatingBulkWithProrationPrice(inner),
            BodyVariants::NewFloatingGroupedWithProratedMinimumPrice inner =>
                newFloatingGroupedWithProratedMinimumPrice(inner),
            BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice inner =>
                newFloatingGroupedWithMeteredMinimumPrice(inner),
            BodyVariants::GroupedWithMinMaxThresholds inner => groupedWithMinMaxThresholds(inner),
            BodyVariants::NewFloatingMatrixWithDisplayNamePrice inner =>
                newFloatingMatrixWithDisplayNamePrice(inner),
            BodyVariants::NewFloatingGroupedTieredPackagePrice inner =>
                newFloatingGroupedTieredPackagePrice(inner),
            BodyVariants::NewFloatingMaxGroupTieredPackagePrice inner =>
                newFloatingMaxGroupTieredPackagePrice(inner),
            BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice inner =>
                newFloatingScalableMatrixWithUnitPricingPrice(inner),
            BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice inner =>
                newFloatingScalableMatrixWithTieredPricingPrice(inner),
            BodyVariants::NewFloatingCumulativeGroupedBulkPrice inner =>
                newFloatingCumulativeGroupedBulkPrice(inner),
            BodyVariants::NewFloatingMinimumCompositePrice inner =>
                newFloatingMinimumCompositePrice(inner),
            BodyVariants::EventOutput inner => eventOutput(inner),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public abstract void Validate();
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingUnitPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingUnitPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingTieredPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingTieredPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingBulkPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingBulkPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingPackagePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingPackagePrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingMatrixPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingMatrixPrice",
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
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingThresholdTotalAmountPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingThresholdTotalAmountPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingTieredPackagePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingTieredPackagePrice",
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingTieredWithMinimumPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingTieredWithMinimumPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingGroupedTieredPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingGroupedTieredPrice",
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
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingTieredPackageWithMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingTieredPackageWithMinimumPrice",
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
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingPackageWithAllocationPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingPackageWithAllocationPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingUnitWithPercentPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingUnitWithPercentPrice",
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingMatrixWithAllocationPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingMatrixWithAllocationPrice",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingTieredWithProrationPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingTieredWithProrationPrice",
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
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingUnitWithProrationPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingUnitWithProrationPrice",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingGroupedAllocationPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingGroupedAllocationPrice",
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
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingBulkWithProrationPrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingBulkWithProrationPrice",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingGroupedWithProratedMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingGroupedWithProratedMinimumPrice",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice",
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
                        return new BodyVariants::GroupedWithMinMaxThresholds(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::GroupedWithMinMaxThresholds",
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingMatrixWithDisplayNamePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingMatrixWithDisplayNamePrice",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingGroupedTieredPackagePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingGroupedTieredPackagePrice",
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
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingMaxGroupTieredPackagePrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingMaxGroupTieredPackagePrice",
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice",
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice",
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
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingCumulativeGroupedBulkPrice(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingCumulativeGroupedBulkPrice",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::NewFloatingMinimumCompositePrice(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::NewFloatingMinimumCompositePrice",
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
                        return new BodyVariants::EventOutput(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant BodyVariants::EventOutput",
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

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BodyVariants::NewFloatingUnitPrice(var newFloatingUnitPrice) => newFloatingUnitPrice,
            BodyVariants::NewFloatingTieredPrice(var newFloatingTieredPrice) =>
                newFloatingTieredPrice,
            BodyVariants::NewFloatingBulkPrice(var newFloatingBulkPrice) => newFloatingBulkPrice,
            BodyVariants::NewFloatingPackagePrice(var newFloatingPackagePrice) =>
                newFloatingPackagePrice,
            BodyVariants::NewFloatingMatrixPrice(var newFloatingMatrixPrice) =>
                newFloatingMatrixPrice,
            BodyVariants::NewFloatingThresholdTotalAmountPrice(
                var newFloatingThresholdTotalAmountPrice
            ) => newFloatingThresholdTotalAmountPrice,
            BodyVariants::NewFloatingTieredPackagePrice(var newFloatingTieredPackagePrice) =>
                newFloatingTieredPackagePrice,
            BodyVariants::NewFloatingTieredWithMinimumPrice(
                var newFloatingTieredWithMinimumPrice
            ) => newFloatingTieredWithMinimumPrice,
            BodyVariants::NewFloatingGroupedTieredPrice(var newFloatingGroupedTieredPrice) =>
                newFloatingGroupedTieredPrice,
            BodyVariants::NewFloatingTieredPackageWithMinimumPrice(
                var newFloatingTieredPackageWithMinimumPrice
            ) => newFloatingTieredPackageWithMinimumPrice,
            BodyVariants::NewFloatingPackageWithAllocationPrice(
                var newFloatingPackageWithAllocationPrice
            ) => newFloatingPackageWithAllocationPrice,
            BodyVariants::NewFloatingUnitWithPercentPrice(var newFloatingUnitWithPercentPrice) =>
                newFloatingUnitWithPercentPrice,
            BodyVariants::NewFloatingMatrixWithAllocationPrice(
                var newFloatingMatrixWithAllocationPrice
            ) => newFloatingMatrixWithAllocationPrice,
            BodyVariants::NewFloatingTieredWithProrationPrice(
                var newFloatingTieredWithProrationPrice
            ) => newFloatingTieredWithProrationPrice,
            BodyVariants::NewFloatingUnitWithProrationPrice(
                var newFloatingUnitWithProrationPrice
            ) => newFloatingUnitWithProrationPrice,
            BodyVariants::NewFloatingGroupedAllocationPrice(
                var newFloatingGroupedAllocationPrice
            ) => newFloatingGroupedAllocationPrice,
            BodyVariants::NewFloatingBulkWithProrationPrice(
                var newFloatingBulkWithProrationPrice
            ) => newFloatingBulkWithProrationPrice,
            BodyVariants::NewFloatingGroupedWithProratedMinimumPrice(
                var newFloatingGroupedWithProratedMinimumPrice
            ) => newFloatingGroupedWithProratedMinimumPrice,
            BodyVariants::NewFloatingGroupedWithMeteredMinimumPrice(
                var newFloatingGroupedWithMeteredMinimumPrice
            ) => newFloatingGroupedWithMeteredMinimumPrice,
            BodyVariants::GroupedWithMinMaxThresholds(var groupedWithMinMaxThresholds) =>
                groupedWithMinMaxThresholds,
            BodyVariants::NewFloatingMatrixWithDisplayNamePrice(
                var newFloatingMatrixWithDisplayNamePrice
            ) => newFloatingMatrixWithDisplayNamePrice,
            BodyVariants::NewFloatingGroupedTieredPackagePrice(
                var newFloatingGroupedTieredPackagePrice
            ) => newFloatingGroupedTieredPackagePrice,
            BodyVariants::NewFloatingMaxGroupTieredPackagePrice(
                var newFloatingMaxGroupTieredPackagePrice
            ) => newFloatingMaxGroupTieredPackagePrice,
            BodyVariants::NewFloatingScalableMatrixWithUnitPricingPrice(
                var newFloatingScalableMatrixWithUnitPricingPrice
            ) => newFloatingScalableMatrixWithUnitPricingPrice,
            BodyVariants::NewFloatingScalableMatrixWithTieredPricingPrice(
                var newFloatingScalableMatrixWithTieredPricingPrice
            ) => newFloatingScalableMatrixWithTieredPricingPrice,
            BodyVariants::NewFloatingCumulativeGroupedBulkPrice(
                var newFloatingCumulativeGroupedBulkPrice
            ) => newFloatingCumulativeGroupedBulkPrice,
            BodyVariants::NewFloatingMinimumCompositePrice(var newFloatingMinimumCompositePrice) =>
                newFloatingMinimumCompositePrice,
            BodyVariants::EventOutput(var eventOutput) => eventOutput,
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
