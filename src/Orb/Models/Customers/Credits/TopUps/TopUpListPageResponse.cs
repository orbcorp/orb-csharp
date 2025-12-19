using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(typeof(JsonModelConverter<TopUpListPageResponse, TopUpListPageResponseFromRaw>))]
public sealed record class TopUpListPageResponse : JsonModel
{
    public required IReadOnlyList<TopUpListResponse> Data
    {
        get { return JsonModel.GetNotNullClass<List<TopUpListResponse>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return JsonModel.GetNotNullClass<PaginationMetadata>(
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

    public TopUpListPageResponse() { }

    public TopUpListPageResponse(TopUpListPageResponse topUpListPageResponse)
        : base(topUpListPageResponse) { }

    public TopUpListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUpListPageResponseFromRaw.FromRawUnchecked"/>
    public static TopUpListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpListPageResponseFromRaw : IFromRawJson<TopUpListPageResponse>
{
    /// <inheritdoc/>
    public TopUpListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUpListPageResponse.FromRawUnchecked(rawData);
}
