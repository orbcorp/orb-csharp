using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Prices;

[JsonConverter(typeof(JsonModelConverter<PriceEvaluateResponse, PriceEvaluateResponseFromRaw>))]
public sealed record class PriceEvaluateResponse : JsonModel
{
    public required IReadOnlyList<EvaluatePriceGroup> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EvaluatePriceGroup>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<EvaluatePriceGroup>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PriceEvaluateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PriceEvaluateResponse(PriceEvaluateResponse priceEvaluateResponse)
        : base(priceEvaluateResponse) { }
#pragma warning restore CS8618

    public PriceEvaluateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluateResponseFromRaw.FromRawUnchecked"/>
    public static PriceEvaluateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluateResponse(IReadOnlyList<EvaluatePriceGroup> data)
        : this()
    {
        this.Data = data;
    }
}

class PriceEvaluateResponseFromRaw : IFromRawJson<PriceEvaluateResponse>
{
    /// <inheritdoc/>
    public PriceEvaluateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluateResponse.FromRawUnchecked(rawData);
}
