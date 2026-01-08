using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.SubscriptionChanges;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionChangeListPageResponse,
        SubscriptionChangeListPageResponseFromRaw
    >)
)]
public sealed record class SubscriptionChangeListPageResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionChangeListResponse> Data
    {
        get
        {
            return JsonModel.GetNotNullClass<List<SubscriptionChangeListResponse>>(
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

    public SubscriptionChangeListPageResponse() { }

    public SubscriptionChangeListPageResponse(
        SubscriptionChangeListPageResponse subscriptionChangeListPageResponse
    )
        : base(subscriptionChangeListPageResponse) { }

    public SubscriptionChangeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangeListPageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionChangeListPageResponseFromRaw : IFromRawJson<SubscriptionChangeListPageResponse>
{
    /// <inheritdoc/>
    public SubscriptionChangeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeListPageResponse.FromRawUnchecked(rawData);
}
