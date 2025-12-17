using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events.Volume;

[JsonConverter(typeof(JsonModelConverter<EventVolumes, EventVolumesFromRaw>))]
public sealed record class EventVolumes : JsonModel
{
    public required IReadOnlyList<global::Orb.Models.Events.Volume.Data> Data
    {
        get
        {
            return JsonModel.GetNotNullClass<List<global::Orb.Models.Events.Volume.Data>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public EventVolumes() { }

    public EventVolumes(EventVolumes eventVolumes)
        : base(eventVolumes) { }

    public EventVolumes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventVolumes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventVolumesFromRaw.FromRawUnchecked"/>
    public static EventVolumes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventVolumes(List<global::Orb.Models.Events.Volume.Data> data)
        : this()
    {
        this.Data = data;
    }
}

class EventVolumesFromRaw : IFromRawJson<EventVolumes>
{
    /// <inheritdoc/>
    public EventVolumes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventVolumes.FromRawUnchecked(rawData);
}

/// <summary>
/// An EventVolume contains the event volume ingested in an hourly window. The timestamp
/// used for the aggregation is the `timestamp` datetime field on events.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Events.Volume.Data,
        global::Orb.Models.Events.Volume.DataFromRaw
    >)
)]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The number of events ingested with a timestamp between the timeframe
    /// </summary>
    public required long Count
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "count"); }
        init { JsonModel.Set(this._rawData, "count", value); }
    }

    public required DateTimeOffset TimeframeEnd
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "timeframe_end"); }
        init { JsonModel.Set(this._rawData, "timeframe_end", value); }
    }

    public required DateTimeOffset TimeframeStart
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "timeframe_start"); }
        init { JsonModel.Set(this._rawData, "timeframe_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public Data() { }

    public Data(global::Orb.Models.Events.Volume.Data data)
        : base(data) { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Events.Volume.DataFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Events.Volume.Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<global::Orb.Models.Events.Volume.Data>
{
    /// <inheritdoc/>
    public global::Orb.Models.Events.Volume.Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Events.Volume.Data.FromRawUnchecked(rawData);
}
