using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<FixedFeeQuantityTransition, FixedFeeQuantityTransitionFromRaw>)
)]
public sealed record class FixedFeeQuantityTransition : JsonModel
{
    public required DateTimeOffset EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    public required string PriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("price_id");
        }
        init { this._rawData.Set("price_id", value); }
    }

    public required long Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.PriceID;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FixedFeeQuantityTransition(FixedFeeQuantityTransition fixedFeeQuantityTransition)
        : base(fixedFeeQuantityTransition) { }
#pragma warning restore CS8618

    public FixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FixedFeeQuantityTransitionFromRaw.FromRawUnchecked"/>
    public static FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionFromRaw : IFromRawJson<FixedFeeQuantityTransition>
{
    /// <inheritdoc/>
    public FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityTransition.FromRawUnchecked(rawData);
}
