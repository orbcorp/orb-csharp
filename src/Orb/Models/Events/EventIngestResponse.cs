using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using EventIngestResponseProperties = Orb.Models.Events.EventIngestResponseProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<EventIngestResponse>))]
public sealed record class EventIngestResponse : Orb::ModelBase, Orb::IFromRaw<EventIngestResponse>
{
    /// <summary>
    /// Contains all failing validation events. In the case of a 200, this array will
    /// always be empty. This field will always be present.
    /// </summary>
    public required Generic::List<EventIngestResponseProperties::ValidationFailed> ValidationFailed
    {
        get
        {
            if (!this.Properties.TryGetValue("validation_failed", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "validation_failed",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<EventIngestResponseProperties::ValidationFailed>>(
                    element
                ) ?? throw new System::ArgumentNullException("validation_failed");
        }
        set
        {
            this.Properties["validation_failed"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Optional debug information (only present when debug=true is passed to the endpoint).
    /// Contains ingested and duplicate event idempotency keys.
    /// </summary>
    public EventIngestResponseProperties::Debug? Debug
    {
        get
        {
            if (!this.Properties.TryGetValue("debug", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<EventIngestResponseProperties::Debug?>(element);
        }
        set { this.Properties["debug"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    EventIngestResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventIngestResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
