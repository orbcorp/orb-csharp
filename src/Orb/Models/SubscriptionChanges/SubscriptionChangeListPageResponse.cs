using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubscriptionChangeListResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionChangeListResponse>>(
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

    public SubscriptionChangeListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangeListPageResponse(
        SubscriptionChangeListPageResponse subscriptionChangeListPageResponse
    )
        : base(subscriptionChangeListPageResponse) { }
#pragma warning restore CS8618

    public SubscriptionChangeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
