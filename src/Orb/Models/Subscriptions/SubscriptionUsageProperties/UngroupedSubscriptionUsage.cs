using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using UngroupedSubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<UngroupedSubscriptionUsage>))]
public sealed record class UngroupedSubscriptionUsage
    : Orb::ModelBase,
        Orb::IFromRaw<UngroupedSubscriptionUsage>
{
    public required Generic::List<UngroupedSubscriptionUsageProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<UngroupedSubscriptionUsageProperties::Data>>(
                    element
                ) ?? throw new System::ArgumentNullException("data");
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

    public UngroupedSubscriptionUsage() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    UngroupedSubscriptionUsage(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UngroupedSubscriptionUsage FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
