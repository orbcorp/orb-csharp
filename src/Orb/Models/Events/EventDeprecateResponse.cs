using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventDeprecateResponse>))]
public sealed record class EventDeprecateResponse : ModelBase, IFromRaw<EventDeprecateResponse>
{
    /// <summary>
    /// event_id of the deprecated event, if successfully updated
    /// </summary>
    public required string Deprecated
    {
        get
        {
            if (!this.Properties.TryGetValue("deprecated", out JsonElement element))
                throw new ArgumentOutOfRangeException("deprecated", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("deprecated");
        }
        set { this.Properties["deprecated"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Deprecated;
    }

    public EventDeprecateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventDeprecateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EventDeprecateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
