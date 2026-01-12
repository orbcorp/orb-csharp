using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDPageResponse,
        CreditListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class CreditListByExternalIDPageResponse : JsonModel
{
    public required IReadOnlyList<CreditListByExternalIDResponse> Data
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<CreditListByExternalIDResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditListByExternalIDResponse>>(
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

    public CreditListByExternalIDPageResponse() { }

    public CreditListByExternalIDPageResponse(
        CreditListByExternalIDPageResponse creditListByExternalIDPageResponse
    )
        : base(creditListByExternalIDPageResponse) { }

    public CreditListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDPageResponseFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDPageResponseFromRaw : IFromRawJson<CreditListByExternalIDPageResponse>
{
    /// <inheritdoc/>
    public CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDPageResponse.FromRawUnchecked(rawData);
}
