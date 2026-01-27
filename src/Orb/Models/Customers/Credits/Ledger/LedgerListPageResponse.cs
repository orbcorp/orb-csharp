using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<LedgerListPageResponse, LedgerListPageResponseFromRaw>))]
public sealed record class LedgerListPageResponse : JsonModel
{
    public required IReadOnlyList<LedgerListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LedgerListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LedgerListResponse>>(
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

    public LedgerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LedgerListPageResponse(LedgerListPageResponse ledgerListPageResponse)
        : base(ledgerListPageResponse) { }
#pragma warning restore CS8618

    public LedgerListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LedgerListPageResponseFromRaw.FromRawUnchecked"/>
    public static LedgerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LedgerListPageResponseFromRaw : IFromRawJson<LedgerListPageResponse>
{
    /// <inheritdoc/>
    public LedgerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerListPageResponse.FromRawUnchecked(rawData);
}
