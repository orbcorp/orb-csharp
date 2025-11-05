using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Events.Volume;

[JsonConverter(typeof(ModelConverter<EventVolumes>))]
public sealed record class EventVolumes : ModelBase, IFromRaw<EventVolumes>
{
    public required List<global::Orb.Models.Events.Volume.Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Events.Volume.Data>>(
                    element,
                    ModelBase.SerializerOptions
                )
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

    [SetsRequiredMembers]
    public EventVolumes(List<global::Orb.Models.Events.Volume.Data> data)
        : this()
    {
        this.Data = data;
    }
}

/// <summary>
/// An EventVolume contains the event volume ingested in an hourly window. The timestamp
/// used for the aggregation is the `timestamp` datetime field on events.
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Events.Volume.Data>))]
public sealed record class Data : ModelBase, IFromRaw<global::Orb.Models.Events.Volume.Data>
{
    /// <summary>
    /// The number of events ingested with a timestamp between the timeframe
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'count' cannot be null",
                    new ArgumentOutOfRangeException("count", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["count"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_end' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_end", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timeframe_end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timeframe_start' cannot be null",
                    new ArgumentOutOfRangeException("timeframe_start", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timeframe_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Events.Volume.Data FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
