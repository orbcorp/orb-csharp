using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionSubscriptions, SubscriptionSubscriptionsFromRaw>))]
public sealed record class SubscriptionSubscriptions : ModelBase
{
    public required IReadOnlyList<Subscription> Data
    {
        get { return ModelBase.GetNotNullClass<List<Subscription>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return ModelBase.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
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

    public SubscriptionSubscriptions(SubscriptionSubscriptions subscriptionSubscriptions)
        : base(subscriptionSubscriptions) { }

    public SubscriptionSubscriptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionSubscriptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SubscriptionSubscriptionsFromRaw : IFromRaw<SubscriptionSubscriptions>
{
    /// <inheritdoc/>
    public SubscriptionSubscriptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionSubscriptions.FromRawUnchecked(rawData);
}
