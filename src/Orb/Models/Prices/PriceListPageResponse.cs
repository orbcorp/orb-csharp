using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceListPageResponse, PriceListPageResponseFromRaw>))]
public sealed record class PriceListPageResponse : ModelBase
{
    public required IReadOnlyList<Models::Price> Data
    {
        get { return ModelBase.GetNotNullClass<List<Models::Price>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return ModelBase.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public PriceListPageResponse() { }

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

    public static PriceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceListPageResponseFromRaw : IFromRaw<PriceListPageResponse>
{
    public PriceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceListPageResponse.FromRawUnchecked(rawData);
}
