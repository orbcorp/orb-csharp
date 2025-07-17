using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<EventUpdateResponse>))]
public sealed record class EventUpdateResponse : Orb::ModelBase, Orb::IFromRaw<EventUpdateResponse>
{
    /// <summary>
    /// event_id of the amended event, if successfully ingested
    /// </summary>
    public required string Amended
    {
        get
        {
            if (!this.Properties.TryGetValue("amended", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amended",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amended");
        }
        set { this.Properties["amended"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amended;
    }

    public EventUpdateResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    EventUpdateResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventUpdateResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
