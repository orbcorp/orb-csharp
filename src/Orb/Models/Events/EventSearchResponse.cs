using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using EventSearchResponseProperties = Orb.Models.Events.EventSearchResponseProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<EventSearchResponse>))]
public sealed record class EventSearchResponse : Orb::ModelBase, Orb::IFromRaw<EventSearchResponse>
{
    public required Generic::List<EventSearchResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<EventSearchResponseProperties::Data>>(
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

    public EventSearchResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    EventSearchResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventSearchResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
