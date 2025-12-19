using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNotNullClass<List<CreditListByExternalIDResponse>>(
                this.RawData,
                "data"
            );
        }
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

    public CreditListByExternalIDPageResponse() { }

    public CreditListByExternalIDPageResponse(
        CreditListByExternalIDPageResponse creditListByExternalIDPageResponse
    )
        : base(creditListByExternalIDPageResponse) { }

    public CreditListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
