using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Prices;

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsResponse,
        PriceEvaluatePreviewEventsResponseFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsResponse : JsonModel
{
    public required IReadOnlyList<PriceEvaluatePreviewEventsResponseData> Data
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PriceEvaluatePreviewEventsResponseData>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PriceEvaluatePreviewEventsResponseData>>(
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

    public PriceEvaluatePreviewEventsResponse() { }

    public PriceEvaluatePreviewEventsResponse(
        PriceEvaluatePreviewEventsResponse priceEvaluatePreviewEventsResponse
    )
        : base(priceEvaluatePreviewEventsResponse) { }

    public PriceEvaluatePreviewEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsResponseFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsResponse(List<PriceEvaluatePreviewEventsResponseData> data)
        : this()
    {
        this.Data = data;
    }
}

class PriceEvaluatePreviewEventsResponseFromRaw : IFromRawJson<PriceEvaluatePreviewEventsResponse>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PriceEvaluatePreviewEventsResponseData,
        PriceEvaluatePreviewEventsResponseDataFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsResponseData : JsonModel
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get { return this._rawData.GetNotNullClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The computed price groups associated with input price.
    /// </summary>
    public required IReadOnlyList<EvaluatePriceGroup> PriceGroups
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<EvaluatePriceGroup>>(
                "price_groups"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EvaluatePriceGroup>>(
                "price_groups",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The external ID of the price
    /// </summary>
    public string? ExternalPriceID
    {
        get { return this._rawData.GetNullableClass<string>("external_price_id"); }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// The index of the inline price
    /// </summary>
    public long? InlinePriceIndex
    {
        get { return this._rawData.GetNullableStruct<long>("inline_price_index"); }
        init { this._rawData.Set("inline_price_index", value); }
    }

    /// <summary>
    /// The ID of the price
    /// </summary>
    public string? PriceID
    {
        get { return this._rawData.GetNullableClass<string>("price_id"); }
        init { this._rawData.Set("price_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        foreach (var item in this.PriceGroups)
        {
            item.Validate();
        }
        _ = this.ExternalPriceID;
        _ = this.InlinePriceIndex;
        _ = this.PriceID;
    }

    public PriceEvaluatePreviewEventsResponseData() { }

    public PriceEvaluatePreviewEventsResponseData(
        PriceEvaluatePreviewEventsResponseData priceEvaluatePreviewEventsResponseData
    )
        : base(priceEvaluatePreviewEventsResponseData) { }

    public PriceEvaluatePreviewEventsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluatePreviewEventsResponseDataFromRaw.FromRawUnchecked"/>
    public static PriceEvaluatePreviewEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsResponseDataFromRaw
    : IFromRawJson<PriceEvaluatePreviewEventsResponseData>
{
    /// <inheritdoc/>
    public PriceEvaluatePreviewEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsResponseData.FromRawUnchecked(rawData);
}
