using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties.ReplacePriceProperties.PriceProperties.EventOutputProperties;

/// <summary>
/// Configuration for event_output pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<EventOutputConfig>))]
public sealed record class EventOutputConfig : ModelBase, IFromRaw<EventOutputConfig>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new ArgumentOutOfRangeException("unit_rating_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new ArgumentNullException("unit_rating_key")
                );
        }
        set
        {
            this.Properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventOutputConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}
