using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<CreditListResponse>>(this.RawData, "data"); }
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

    public CreditListPageResponse() { }

    public CreditListPageResponse(CreditListPageResponse creditListPageResponse)
        : base(creditListPageResponse) { }

    public CreditListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
