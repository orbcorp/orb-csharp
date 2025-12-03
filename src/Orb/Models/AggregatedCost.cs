using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AggregatedCost, AggregatedCostFromRaw>))]
public sealed record class AggregatedCost : ModelBase
{
    public required IReadOnlyList<PerPriceCost> PerPriceCosts
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PerPriceCost>>(this.RawData, "per_price_costs");
        }
        init { ModelBase.Set(this._rawData, "per_price_costs", value); }
    }

    /// <summary>
    /// Total costs for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subtotal"); }
        init { ModelBase.Set(this._rawData, "subtotal", value); }
    }

    public required DateTimeOffset TimeframeEnd
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "timeframe_end"); }
        init { ModelBase.Set(this._rawData, "timeframe_end", value); }
    }

    public required DateTimeOffset TimeframeStart
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "timeframe_start"); }
        init { ModelBase.Set(this._rawData, "timeframe_start", value); }
    }

    /// <summary>
    /// Total costs for the timeframe, including any minimums and discounts.
    /// </summary>
    public required string Total
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AggregatedCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AggregatedCostFromRaw.FromRawUnchecked"/>
    public static AggregatedCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AggregatedCostFromRaw : IFromRaw<AggregatedCost>
{
    /// <inheritdoc/>
    public AggregatedCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AggregatedCost.FromRawUnchecked(rawData);
}
