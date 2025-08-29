using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventUpdateResponse>))]
public sealed record class EventUpdateResponse : ModelBase, IFromRaw<EventUpdateResponse>
{
    /// <summary>
    /// event_id of the amended event, if successfully ingested
    /// </summary>
    public required string Amended
    {
        get
        {
            if (!this.Properties.TryGetValue("amended", out JsonElement element))
                throw new ArgumentOutOfRangeException("amended", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("amended");
        }
        set
        {
            this.Properties["amended"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amended;
    }

    public EventUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventUpdateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventUpdateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EventUpdateResponse(string amended)
        : this()
    {
        this.Amended = amended;
    }
}
