using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using GroupedSubscriptionUsageProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties;
using Models = Orb.Models;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties;

[JsonConverter(typeof(ModelConverter<GroupedSubscriptionUsage>))]
public sealed record class GroupedSubscriptionUsage : ModelBase, IFromRaw<GroupedSubscriptionUsage>
{
    public required List<GroupedSubscriptionUsageProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<GroupedSubscriptionUsageProperties::Data>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public Models::PaginationMetadata? PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::PaginationMetadata?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    GroupedSubscriptionUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedSubscriptionUsage FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
