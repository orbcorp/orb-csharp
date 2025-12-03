using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<SubscriptionFetchCostsResponse, SubscriptionFetchCostsResponseFromRaw>)
)]
public sealed record class SubscriptionFetchCostsResponse : ModelBase
{
    public required IReadOnlyList<AggregatedCost> Data
    {
        get { return ModelBase.GetNotNullClass<List<AggregatedCost>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public SubscriptionFetchCostsResponse() { }

    public SubscriptionFetchCostsResponse(
        SubscriptionFetchCostsResponse subscriptionFetchCostsResponse
    )
        : base(subscriptionFetchCostsResponse) { }

    public SubscriptionFetchCostsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchCostsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFetchCostsResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionFetchCostsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionFetchCostsResponse(List<AggregatedCost> data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionFetchCostsResponseFromRaw : IFromRaw<SubscriptionFetchCostsResponse>
{
    /// <inheritdoc/>
    public SubscriptionFetchCostsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionFetchCostsResponse.FromRawUnchecked(rawData);
}
