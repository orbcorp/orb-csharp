using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EventIngestResponseProperties = Orb.Models.Events.EventIngestResponseProperties;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventIngestResponse>))]
public sealed record class EventIngestResponse : ModelBase, IFromRaw<EventIngestResponse>
{
    /// <summary>
    /// Contains all failing validation events. In the case of a 200, this array
    /// will always be empty. This field will always be present.
    /// </summary>
    public required List<EventIngestResponseProperties::ValidationFailed> ValidationFailed
    {
        get
        {
            if (!this.Properties.TryGetValue("validation_failed", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "validation_failed",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<
                    List<EventIngestResponseProperties::ValidationFailed>
                >(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("validation_failed");
        }
        set { this.Properties["validation_failed"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional debug information (only present when debug=true is passed to the
    /// endpoint). Contains ingested and duplicate event idempotency keys.
    /// </summary>
    public EventIngestResponseProperties::Debug? Debug
    {
        get
        {
            if (!this.Properties.TryGetValue("debug", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EventIngestResponseProperties::Debug?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["debug"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.ValidationFailed)
        {
            item.Validate();
        }
        this.Debug?.Validate();
    }

    public EventIngestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventIngestResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventIngestResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
