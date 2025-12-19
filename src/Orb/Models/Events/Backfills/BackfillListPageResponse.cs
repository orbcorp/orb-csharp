using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events.Backfills;

[JsonConverter(
    typeof(JsonModelConverter<BackfillListPageResponse, BackfillListPageResponseFromRaw>)
)]
public sealed record class BackfillListPageResponse : JsonModel
{
    public required IReadOnlyList<BackfillListResponse> Data
    {
        get { return JsonModel.GetNotNullClass<List<BackfillListResponse>>(this.RawData, "data"); }
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

    public BackfillListPageResponse() { }

    public BackfillListPageResponse(BackfillListPageResponse backfillListPageResponse)
        : base(backfillListPageResponse) { }

    public BackfillListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BackfillListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BackfillListPageResponseFromRaw.FromRawUnchecked"/>
    public static BackfillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BackfillListPageResponseFromRaw : IFromRawJson<BackfillListPageResponse>
{
    /// <inheritdoc/>
    public BackfillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BackfillListPageResponse.FromRawUnchecked(rawData);
}
