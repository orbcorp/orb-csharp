using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Events.Volume.EventVolumesProperties;

/// <summary>
/// An EventVolume contains the event volume ingested in an hourly window. The timestamp
/// used for the aggregation is the `timestamp` datetime field on events.
/// </summary>
[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// The number of events ingested with a timestamp between the timeframe
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out JsonElement element))
                throw new ArgumentOutOfRangeException("count", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["count"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out JsonElement element))
                throw new ArgumentOutOfRangeException("timeframe_end", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.Properties["timeframe_end"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime>(element);
        }
        set { this.Properties["timeframe_start"] = JsonSerializer.SerializeToElement(value); }
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

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
