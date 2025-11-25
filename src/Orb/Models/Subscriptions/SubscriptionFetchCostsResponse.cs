using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(ModelConverter<SubscriptionFetchCostsResponse, SubscriptionFetchCostsResponseFromRaw>)
)]
public sealed record class SubscriptionFetchCostsResponse : ModelBase
{
    public required List<AggregatedCost> Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<AggregatedCost>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public SubscriptionFetchCostsResponse() { }

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
    public SubscriptionFetchCostsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionFetchCostsResponse.FromRawUnchecked(rawData);
}
