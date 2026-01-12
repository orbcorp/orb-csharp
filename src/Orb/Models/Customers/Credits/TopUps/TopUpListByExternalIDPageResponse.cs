using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            return this._rawData.GetNotNullStruct<ImmutableArray<TopUpListByExternalIDResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopUpListByExternalIDResponse>>(
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

    public TopUpListByExternalIDPageResponse() { }

    public TopUpListByExternalIDPageResponse(
        TopUpListByExternalIDPageResponse topUpListByExternalIDPageResponse
    )
        : base(topUpListByExternalIDPageResponse) { }

    public TopUpListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
