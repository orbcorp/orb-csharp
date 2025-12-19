using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(
    typeof(JsonModelConverter<
        TopUpListByExternalIDPageResponse,
        TopUpListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class TopUpListByExternalIDPageResponse : JsonModel
{
    public required IReadOnlyList<TopUpListByExternalIDResponse> Data
    {
        get
        {
            return JsonModel.GetNotNullClass<List<TopUpListByExternalIDResponse>>(
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

    public TopUpListByExternalIDPageResponse() { }

    public TopUpListByExternalIDPageResponse(
        TopUpListByExternalIDPageResponse topUpListByExternalIDPageResponse
    )
        : base(topUpListByExternalIDPageResponse) { }

    public TopUpListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUpListByExternalIDPageResponseFromRaw.FromRawUnchecked"/>
    public static TopUpListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpListByExternalIDPageResponseFromRaw : IFromRawJson<TopUpListByExternalIDPageResponse>
{
    /// <inheritdoc/>
    public TopUpListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUpListByExternalIDPageResponse.FromRawUnchecked(rawData);
}
