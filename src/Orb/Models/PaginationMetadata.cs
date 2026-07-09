using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<PaginationMetadata, PaginationMetadataFromRaw>))]
public sealed record class PaginationMetadata : JsonModel
{
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    public required string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public PaginationMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginationMetadata(PaginationMetadata paginationMetadata)
        : base(paginationMetadata) { }
#pragma warning restore CS8618

    public PaginationMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationMetadataFromRaw.FromRawUnchecked"/>
    public static PaginationMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationMetadataFromRaw : IFromRawJson<PaginationMetadata>
{
    /// <inheritdoc/>
    public PaginationMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginationMetadata.FromRawUnchecked(rawData);
}
