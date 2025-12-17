using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Prices;

[JsonConverter(
    typeof(JsonModelConverter<PriceEvaluateMultipleResponse, PriceEvaluateMultipleResponseFromRaw>)
)]
public sealed record class PriceEvaluateMultipleResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get { return JsonModel.GetNotNullClass<List<Data>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PriceEvaluateMultipleResponse() { }

    public PriceEvaluateMultipleResponse(
        PriceEvaluateMultipleResponse priceEvaluateMultipleResponse
    )
        : base(priceEvaluateMultipleResponse) { }

    public PriceEvaluateMultipleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluateMultipleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceEvaluateMultipleResponseFromRaw.FromRawUnchecked"/>
    public static PriceEvaluateMultipleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceEvaluateMultipleResponse(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class PriceEvaluateMultipleResponseFromRaw : IFromRawJson<PriceEvaluateMultipleResponse>
{
    /// <inheritdoc/>
    public PriceEvaluateMultipleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceEvaluateMultipleResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The computed price groups associated with input price.
    /// </summary>
    public required IReadOnlyList<EvaluatePriceGroup> PriceGroups
    {
        get
        {
            return JsonModel.GetNotNullClass<List<EvaluatePriceGroup>>(
                this.RawData,
                "price_groups"
            );
        }
        init { JsonModel.Set(this._rawData, "price_groups", value); }
    }

    /// <summary>
    /// The external ID of the price
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// The index of the inline price
    /// </summary>
    public long? InlinePriceIndex
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "inline_price_index"); }
        init { JsonModel.Set(this._rawData, "inline_price_index", value); }
    }

    /// <summary>
    /// The ID of the price
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
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

    public Data() { }

    public Data(Data data)
        : base(data) { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
