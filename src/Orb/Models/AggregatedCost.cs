using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<AggregatedCost, AggregatedCostFromRaw>))]
public sealed record class AggregatedCost : JsonModel
{
    public required IReadOnlyList<PerPriceCost> PerPriceCosts
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<PerPriceCost>>("per_price_costs");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PerPriceCost>>(
                "per_price_costs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total costs for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get { return this._rawData.GetNotNullClass<string>("subtotal"); }
        init { this._rawData.Set("subtotal", value); }
    }

    public required DateTimeOffset TimeframeEnd
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("timeframe_end"); }
        init { this._rawData.Set("timeframe_end", value); }
    }

    public required DateTimeOffset TimeframeStart
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("timeframe_start"); }
        init { this._rawData.Set("timeframe_start", value); }
    }

    /// <summary>
    /// Total costs for the timeframe, including any minimums and discounts.
    /// </summary>
    public required string Total
    {
        get { return this._rawData.GetNotNullClass<string>("total"); }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
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

    public AggregatedCost(AggregatedCost aggregatedCost)
        : base(aggregatedCost) { }

    public AggregatedCost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AggregatedCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregatedCostFromRaw.FromRawUnchecked"/>
    public static AggregatedCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregatedCostFromRaw : IFromRawJson<AggregatedCost>
{
    /// <inheritdoc/>
    public AggregatedCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AggregatedCost.FromRawUnchecked(rawData);
}
