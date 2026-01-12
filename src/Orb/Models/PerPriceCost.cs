using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<PerPriceCost, PerPriceCostFromRaw>))]
public sealed record class PerPriceCost : JsonModel
{
    /// <summary>
    /// The price object
    /// </summary>
    public required Price Price
    {
        get { return this._rawData.GetNotNullClass<Price>("price"); }
        init { this._rawData.Set("price", value); }
    }

    /// <summary>
    /// The price the cost is associated with
    /// </summary>
    public required string PriceID
    {
        get { return this._rawData.GetNotNullClass<string>("price_id"); }
        init { this._rawData.Set("price_id", value); }
    }

    /// <summary>
    /// Price's contributions for the timeframe, excluding any minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get { return this._rawData.GetNotNullClass<string>("subtotal"); }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// Price's contributions for the timeframe, including minimums and discounts.
    /// </summary>
    public required string Total
    {
        get { return this._rawData.GetNotNullClass<string>("total"); }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// The price's quantity for the timeframe
    /// </summary>
    public double? Quantity
    {
        get { return this._rawData.GetNullableStruct<double>("quantity"); }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Price.Validate();
        _ = this.PriceID;
        _ = this.Subtotal;
        _ = this.Total;
        _ = this.Quantity;
    }

    public PerPriceCost() { }

    public PerPriceCost(PerPriceCost perPriceCost)
        : base(perPriceCost) { }

    public PerPriceCost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PerPriceCost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PerPriceCostFromRaw.FromRawUnchecked"/>
    public static PerPriceCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PerPriceCostFromRaw : IFromRawJson<PerPriceCost>
{
    /// <inheritdoc/>
    public PerPriceCost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PerPriceCost.FromRawUnchecked(rawData);
}
