using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BackfillListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BackfillListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata");
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

    public BackfillListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BackfillListPageResponse(BackfillListPageResponse backfillListPageResponse)
        : base(backfillListPageResponse) { }
#pragma warning restore CS8618

    public BackfillListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BackfillListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
