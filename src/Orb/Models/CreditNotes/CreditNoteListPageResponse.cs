using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.CreditNotes;

[JsonConverter(
    typeof(JsonModelConverter<CreditNoteListPageResponse, CreditNoteListPageResponseFromRaw>)
)]
public sealed record class CreditNoteListPageResponse : JsonModel
{
    public required IReadOnlyList<SharedCreditNote> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SharedCreditNote>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SharedCreditNote>>(
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

    public CreditNoteListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditNoteListPageResponse(CreditNoteListPageResponse creditNoteListPageResponse)
        : base(creditNoteListPageResponse) { }
#pragma warning restore CS8618

    public CreditNoteListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditNoteListPageResponseFromRaw.FromRawUnchecked"/>
    public static CreditNoteListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditNoteListPageResponseFromRaw : IFromRawJson<CreditNoteListPageResponse>
{
    /// <inheritdoc/>
    public CreditNoteListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditNoteListPageResponse.FromRawUnchecked(rawData);
}
