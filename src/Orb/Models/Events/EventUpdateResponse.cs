using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventUpdateResponse, EventUpdateResponseFromRaw>))]
public sealed record class EventUpdateResponse : JsonModel
{
    /// <summary>
    /// event_id of the amended event, if successfully ingested
    /// </summary>
    public required string Amended
    {
        get { return this._rawData.GetNotNullClass<string>("amended"); }
        init { this._rawData.Set("amended", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amended;
    }

    public EventUpdateResponse() { }

    public EventUpdateResponse(EventUpdateResponse eventUpdateResponse)
        : base(eventUpdateResponse) { }

    public EventUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventUpdateResponseFromRaw.FromRawUnchecked"/>
    public static EventUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventUpdateResponse(string amended)
        : this()
    {
        this.Amended = amended;
    }
}

class EventUpdateResponseFromRaw : IFromRawJson<EventUpdateResponse>
{
    /// <inheritdoc/>
    public EventUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventUpdateResponse.FromRawUnchecked(rawData);
}
