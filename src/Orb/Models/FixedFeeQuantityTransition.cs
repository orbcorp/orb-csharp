using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<FixedFeeQuantityTransition, FixedFeeQuantityTransitionFromRaw>)
)]
public sealed record class FixedFeeQuantityTransition : ModelBase
{
    public required DateTimeOffset EffectiveDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "effective_date"); }
        init { ModelBase.Set(this._rawData, "effective_date", value); }
    }

    public required string PriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

    public required long Quantity
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.PriceID;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

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

    public static FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionFromRaw : IFromRaw<FixedFeeQuantityTransition>
{
    public FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityTransition.FromRawUnchecked(rawData);
}
