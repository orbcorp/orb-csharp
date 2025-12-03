using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PaginationMetadata, PaginationMetadataFromRaw>))]
public sealed record class PaginationMetadata : ModelBase
{
    public required bool HasMore
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { ModelBase.Set(this._rawData, "has_more", value); }
    }

    public required string? NextCursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next_cursor"); }
        init { ModelBase.Set(this._rawData, "next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public PaginationMetadata() { }

    public PaginationMetadata(PaginationMetadata paginationMetadata)
        : base(paginationMetadata) { }

    public PaginationMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class PaginationMetadataFromRaw : IFromRaw<PaginationMetadata>
{
    /// <inheritdoc/>
    public PaginationMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginationMetadata.FromRawUnchecked(rawData);
}
