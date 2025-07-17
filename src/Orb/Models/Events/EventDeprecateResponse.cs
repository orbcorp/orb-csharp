using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<EventDeprecateResponse>))]
public sealed record class EventDeprecateResponse
    : Orb::ModelBase,
        Orb::IFromRaw<EventDeprecateResponse>
{
    /// <summary>
    /// event_id of the deprecated event, if successfully updated
    /// </summary>
    public required string Deprecated
    {
        get
        {
            if (!this.Properties.TryGetValue("deprecated", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "deprecated",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("deprecated");
        }
        set { this.Properties["deprecated"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Deprecated;
    }

    public EventDeprecateResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    EventDeprecateResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventDeprecateResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
