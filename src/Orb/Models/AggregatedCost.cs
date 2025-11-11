using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AggregatedCost>))]
public sealed record class AggregatedCost : ModelBase, IFromRaw<AggregatedCost>
{
    public required List<PerPriceCost> PerPriceCosts
    {
        get
        {
            if (!this._properties.TryGetValue("per_price_costs", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_price_costs' cannot be null",
                    new ArgumentOutOfRangeException("per_price_costs", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<PerPriceCost>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'per_price_costs' cannot be null",
                    new ArgumentNullException("per_price_costs")
                );
        }
        init
        {
            this._properties["per_price_costs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total costs for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this._properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new ArgumentNullException("subtotal")
                );
        }
        init
        {
            this._properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTimeOffset TimeframeEnd
    {
        get
        {
            if (!this._properties.TryGetValue("timeframe_end", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_end' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_end", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTimeOffset TimeframeStart
    {
        get
        {
            if (!this._properties.TryGetValue("timeframe_start", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_start' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_start", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total costs for the timeframe, including any minimums and discounts.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this._properties.TryGetValue("total", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new ArgumentNullException("total")
                );
        }
        init
        {
            this._properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.PerPriceCosts)
        {
            item.Validate();
        }
        _ = this.Subtotal;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
        _ = this.Total;
    }

    public AggregatedCost() { }

    public AggregatedCost(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AggregatedCost(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AggregatedCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
