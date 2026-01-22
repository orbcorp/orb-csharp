using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits;

[JsonConverter(typeof(JsonModelConverter<CreditListPageResponse, CreditListPageResponseFromRaw>))]
public sealed record class CreditListPageResponse : JsonModel
{
    public required IReadOnlyList<CreditListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditListResponse>>(
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

    public CreditListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListPageResponse(CreditListPageResponse creditListPageResponse)
        : base(creditListPageResponse) { }
#pragma warning restore CS8618

    public CreditListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListPageResponseFromRaw.FromRawUnchecked"/>
    public static CreditListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListPageResponseFromRaw : IFromRawJson<CreditListPageResponse>
{
    /// <inheritdoc/>
    public CreditListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListPageResponse.FromRawUnchecked(rawData);
}
