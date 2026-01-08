using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Plans.Migrations;

[JsonConverter(
    typeof(JsonModelConverter<MigrationListPageResponse, MigrationListPageResponseFromRaw>)
)]
public sealed record class MigrationListPageResponse : JsonModel
{
    public required IReadOnlyList<MigrationListResponse> Data
    {
        get { return JsonModel.GetNotNullClass<List<MigrationListResponse>>(this.RawData, "data"); }
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

    public MigrationListPageResponse() { }

    public MigrationListPageResponse(MigrationListPageResponse migrationListPageResponse)
        : base(migrationListPageResponse) { }

    public MigrationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MigrationListPageResponseFromRaw.FromRawUnchecked"/>
    public static MigrationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MigrationListPageResponseFromRaw : IFromRawJson<MigrationListPageResponse>
{
    /// <inheritdoc/>
    public MigrationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MigrationListPageResponse.FromRawUnchecked(rawData);
}
