using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties;

[JsonConverter(typeof(ModelConverter<MetricGroup>))]
public sealed record class MetricGroup : ModelBase, IFromRaw<MetricGroup>
{
    public required string PropertyKey
    {
        get
        {
            if (!this.Properties.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new ArgumentOutOfRangeException("property_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new ArgumentNullException("property_key")
                );
        }
        set
        {
            this.Properties["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PropertyValue
    {
        get
        {
            if (!this.Properties.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new ArgumentOutOfRangeException("property_value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new ArgumentNullException("property_value")
                );
        }
        set
        {
            this.Properties["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public MetricGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricGroup(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MetricGroup FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
