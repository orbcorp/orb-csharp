using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EventSearchResponseProperties = Orb.Models.Events.EventSearchResponseProperties;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventSearchResponse>))]
public sealed record class EventSearchResponse : ModelBase, IFromRaw<EventSearchResponse>
{
    public required List<EventSearchResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<EventSearchResponseProperties::Data>>(
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

    public EventSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventSearchResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventSearchResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public EventSearchResponse(List<EventSearchResponseProperties::Data> data)
    {
        this.Data = data;
    }
}
