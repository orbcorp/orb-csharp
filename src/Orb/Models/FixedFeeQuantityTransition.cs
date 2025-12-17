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
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "effective_date"); }
        init { JsonModel.Set(this._rawData, "effective_date", value); }
    }

    public required string PriceID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
    }

    public required long Quantity
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.PriceID;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

    public FixedFeeQuantityTransition(FixedFeeQuantityTransition fixedFeeQuantityTransition)
        : base(fixedFeeQuantityTransition) { }

    public FixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
