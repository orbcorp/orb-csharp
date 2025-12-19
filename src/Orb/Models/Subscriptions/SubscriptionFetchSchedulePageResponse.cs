using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNotNullClass<List<SubscriptionFetchScheduleResponse>>(
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

    public SubscriptionFetchSchedulePageResponse() { }

    public SubscriptionFetchSchedulePageResponse(
        SubscriptionFetchSchedulePageResponse subscriptionFetchSchedulePageResponse
    )
        : base(subscriptionFetchSchedulePageResponse) { }

    public SubscriptionFetchSchedulePageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchSchedulePageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
