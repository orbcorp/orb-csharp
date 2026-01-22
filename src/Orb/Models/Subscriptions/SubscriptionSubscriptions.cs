using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionSubscriptions, SubscriptionSubscriptionsFromRaw>)
)]
public sealed record class SubscriptionSubscriptions : JsonModel
{
    public required IReadOnlyList<Subscription> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Subscription>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Subscription>>(
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

    public SubscriptionSubscriptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionSubscriptions(SubscriptionSubscriptions subscriptionSubscriptions)
        : base(subscriptionSubscriptions) { }
#pragma warning restore CS8618

    public SubscriptionSubscriptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSubscriptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionSubscriptionsFromRaw.FromRawUnchecked"/>
    public static SubscriptionSubscriptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionSubscriptionsFromRaw : IFromRawJson<SubscriptionSubscriptions>
{
    /// <inheritdoc/>
    public SubscriptionSubscriptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSubscriptions.FromRawUnchecked(rawData);
}
