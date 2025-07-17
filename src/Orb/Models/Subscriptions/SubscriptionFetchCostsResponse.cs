using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<SubscriptionFetchCostsResponse>))]
public sealed record class SubscriptionFetchCostsResponse
    : Orb::ModelBase,
        Orb::IFromRaw<SubscriptionFetchCostsResponse>
{
    public required Generic::List<Models::AggregatedCost> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<Models::AggregatedCost>>(element)
                ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    SubscriptionFetchCostsResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionFetchCostsResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
