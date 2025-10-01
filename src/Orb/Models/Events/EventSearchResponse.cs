using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Events.EventSearchResponseProperties;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventSearchResponse>))]
public sealed record class EventSearchResponse : ModelBase, IFromRaw<EventSearchResponse>
{
    public required List<Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Data>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    [SetsRequiredMembers]
    public EventSearchResponse(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}
