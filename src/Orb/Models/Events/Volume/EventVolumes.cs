using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EventVolumesProperties = Orb.Models.Events.Volume.EventVolumesProperties;

namespace Orb.Models.Events.Volume;

[JsonConverter(typeof(ModelConverter<EventVolumes>))]
public sealed record class EventVolumes : ModelBase, IFromRaw<EventVolumes>
{
    public required List<EventVolumesProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<EventVolumesProperties::Data>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public EventVolumes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventVolumes(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventVolumes FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
