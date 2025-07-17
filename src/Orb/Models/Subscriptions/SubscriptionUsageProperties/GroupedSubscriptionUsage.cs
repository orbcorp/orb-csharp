using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using GroupedSubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<GroupedSubscriptionUsage>))]
public sealed record class GroupedSubscriptionUsage
    : Orb::ModelBase,
        Orb::IFromRaw<GroupedSubscriptionUsage>
{
    public required Generic::List<GroupedSubscriptionUsageProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<GroupedSubscriptionUsageProperties::Data>>(
                    element
                ) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Models::PaginationMetadata? PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::PaginationMetadata?>(element);
        }
        set
        {
            this.Properties["pagination_metadata"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata?.Validate();
    }

    public GroupedSubscriptionUsage() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    GroupedSubscriptionUsage(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedSubscriptionUsage FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
