using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events.Volume.EventVolumesProperties;

/// <summary>
/// An EventVolume contains the event volume ingested in an hourly window. The timestamp
/// used for the aggregation is the `timestamp` datetime field on events.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Data>))]
public sealed record class Data : Orb::ModelBase, Orb::IFromRaw<Data>
{
    /// <summary>
    /// The number of events ingested with a timestamp between the timeframe
    /// </summary>
    public required long Count
    {
        get
        {
            if (!this.Properties.TryGetValue("count", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("count", "Missing required argument");

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["count"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeEnd
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_end", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_end",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_end"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime TimeframeStart
    {
        get
        {
            if (!this.Properties.TryGetValue("timeframe_start", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timeframe_start",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["timeframe_start"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Count;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public Data() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Data(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
