using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionFetchSchedulePageResponse,
        SubscriptionFetchSchedulePageResponseFromRaw
    >)
)]
public sealed record class SubscriptionFetchSchedulePageResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionFetchScheduleResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<SubscriptionFetchScheduleResponse>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionFetchScheduleResponse>>(
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

    public SubscriptionFetchSchedulePageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionFetchSchedulePageResponse(
        SubscriptionFetchSchedulePageResponse subscriptionFetchSchedulePageResponse
    )
        : base(subscriptionFetchSchedulePageResponse) { }
#pragma warning restore CS8618

    public SubscriptionFetchSchedulePageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchSchedulePageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFetchSchedulePageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionFetchSchedulePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFetchSchedulePageResponseFromRaw
    : IFromRawJson<SubscriptionFetchSchedulePageResponse>
{
    /// <inheritdoc/>
    public SubscriptionFetchSchedulePageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionFetchSchedulePageResponse.FromRawUnchecked(rawData);
}
