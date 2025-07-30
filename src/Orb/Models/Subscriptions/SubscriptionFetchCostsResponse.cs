using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionFetchCostsResponse>))]
public sealed record class SubscriptionFetchCostsResponse
    : ModelBase,
        IFromRaw<SubscriptionFetchCostsResponse>
{
    public required List<AggregatedCost> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<AggregatedCost>>(element)
                ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public SubscriptionFetchCostsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchCostsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionFetchCostsResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
