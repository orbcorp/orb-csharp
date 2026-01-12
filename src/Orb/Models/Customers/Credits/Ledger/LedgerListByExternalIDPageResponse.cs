using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(
    typeof(JsonModelConverter<
        LedgerListByExternalIDPageResponse,
        LedgerListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class LedgerListByExternalIDPageResponse : JsonModel
{
    public required IReadOnlyList<LedgerListByExternalIDResponse> Data
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<LedgerListByExternalIDResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<LedgerListByExternalIDResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get { return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata"); }
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

    public LedgerListByExternalIDPageResponse() { }

    public LedgerListByExternalIDPageResponse(
        LedgerListByExternalIDPageResponse ledgerListByExternalIDPageResponse
    )
        : base(ledgerListByExternalIDPageResponse) { }

    public LedgerListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LedgerListByExternalIDPageResponseFromRaw.FromRawUnchecked"/>
    public static LedgerListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LedgerListByExternalIDPageResponseFromRaw : IFromRawJson<LedgerListByExternalIDPageResponse>
{
    /// <inheritdoc/>
    public LedgerListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerListByExternalIDPageResponse.FromRawUnchecked(rawData);
}
