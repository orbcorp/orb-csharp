using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<MetricGroup>))]
public sealed record class MetricGroup : Orb::ModelBase, Orb::IFromRaw<MetricGroup>
{
    public required string PropertyKey
    {
        get
        {
            if (!this.Properties.TryGetValue("property_key", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "property_key",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("property_key");
        }
        set { this.Properties["property_key"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string PropertyValue
    {
        get
        {
            if (!this.Properties.TryGetValue("property_value", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "property_value",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("property_value");
        }
        set { this.Properties["property_value"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public MetricGroup() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MetricGroup(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MetricGroup FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
