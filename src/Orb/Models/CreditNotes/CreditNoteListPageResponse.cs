using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.CreditNotes;

[JsonConverter(
    typeof(ModelConverter<CreditNoteListPageResponse, CreditNoteListPageResponseFromRaw>)
)]
public sealed record class CreditNoteListPageResponse : ModelBase
{
    public required IReadOnlyList<SharedCreditNote> Data
    {
        get { return ModelBase.GetNotNullClass<List<SharedCreditNote>>(this.RawData, "data"); }
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

    public CreditNoteListPageResponse(CreditNoteListPageResponse creditNoteListPageResponse)
        : base(creditNoteListPageResponse) { }

    public CreditNoteListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class CreditNoteListPageResponseFromRaw : IFromRaw<CreditNoteListPageResponse>
{
    /// <inheritdoc/>
    public CreditNoteListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditNoteListPageResponse.FromRawUnchecked(rawData);
}
