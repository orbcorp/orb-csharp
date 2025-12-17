using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.Prices;

[JsonConverter(typeof(JsonModelConverter<PriceListPageResponse, PriceListPageResponseFromRaw>))]
public sealed record class PriceListPageResponse : JsonModel
{
    public required IReadOnlyList<Models::Price> Data
    {
        get { return JsonModel.GetNotNullClass<List<Models::Price>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Models::PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public PriceListPageResponse() { }

    public PriceListPageResponse(PriceListPageResponse priceListPageResponse)
        : base(priceListPageResponse) { }

    public PriceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceListPageResponseFromRaw.FromRawUnchecked"/>
    public static PriceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceListPageResponseFromRaw : IFromRawJson<PriceListPageResponse>
{
    /// <inheritdoc/>
    public PriceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceListPageResponse.FromRawUnchecked(rawData);
}
