using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Prices;

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluatePreviewEventsResponse,
        PriceEvaluatePreviewEventsResponseFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsResponse : ModelBase
{
    public required IReadOnlyList<PriceEvaluatePreviewEventsResponseData> Data
    {
        get
        {
            return ModelBase.GetNotNullClass<List<PriceEvaluatePreviewEventsResponseData>>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PriceEvaluatePreviewEventsResponse() { }

    public PriceEvaluatePreviewEventsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class PriceEvaluatePreviewEventsResponseFromRaw : IFromRaw<PriceEvaluatePreviewEventsResponse>
{
    public PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        PriceEvaluatePreviewEventsResponseData,
        PriceEvaluatePreviewEventsResponseDataFromRaw
    >)
)]
public sealed record class PriceEvaluatePreviewEventsResponseData : ModelBase
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The computed price groups associated with input price.
    /// </summary>
    public required IReadOnlyList<EvaluatePriceGroup> PriceGroups
    {
        get
        {
            return ModelBase.GetNotNullClass<List<EvaluatePriceGroup>>(
                this.RawData,
                "price_groups"
            );
        }
        init { ModelBase.Set(this._rawData, "price_groups", value); }
    }

    /// <summary>
    /// The external ID of the price
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// The index of the inline price
    /// </summary>
    public long? InlinePriceIndex
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "inline_price_index"); }
        init { ModelBase.Set(this._rawData, "inline_price_index", value); }
    }

    /// <summary>
    /// The ID of the price
    /// </summary>
    public string? PriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

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

    public PriceEvaluatePreviewEventsResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceEvaluatePreviewEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceEvaluatePreviewEventsResponseDataFromRaw
    : IFromRaw<PriceEvaluatePreviewEventsResponseData>
{
    public PriceEvaluatePreviewEventsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluatePreviewEventsResponseData.FromRawUnchecked(rawData);
}
