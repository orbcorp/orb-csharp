using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Models::Price>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Models::Price>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Models::PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
