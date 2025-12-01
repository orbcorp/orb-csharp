using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PerPriceCost, PerPriceCostFromRaw>))]
public sealed record class PerPriceCost : ModelBase
{
    /// <summary>
    /// The price object
    /// </summary>
    public required Price Price
    {
        get { return ModelBase.GetNotNullClass<Price>(this.RawData, "price"); }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The price the cost is associated with
    /// </summary>
    public required string PriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

    /// <summary>
    /// Price's contributions for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subtotal"); }
        init { ModelBase.Set(this._rawData, "subtotal", value); }
    }

    /// <summary>
    /// Price's contributions for the timeframe, including minimums and discounts.
    /// </summary>
    public required string Total
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    /// <summary>
    /// The price's quantity for the timeframe
    /// </summary>
    public double? Quantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public override void Validate()
    {
        this.Price.Validate();
        _ = this.PriceID;
        _ = this.Subtotal;
        _ = this.Total;
        _ = this.Quantity;
    }

    public PerPriceCost() { }

    public PerPriceCost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PerPriceCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PerPriceCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PerPriceCostFromRaw : IFromRaw<PerPriceCost>
{
    public PerPriceCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PerPriceCost.FromRawUnchecked(rawData);
}
