using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events;

[JsonConverter(typeof(JsonModelConverter<EventDeprecateResponse, EventDeprecateResponseFromRaw>))]
public sealed record class EventDeprecateResponse : JsonModel
{
    /// <summary>
    /// event_id of the deprecated event, if successfully updated
    /// </summary>
    public required string Deprecated
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "deprecated"); }
        init { JsonModel.Set(this._rawData, "deprecated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deprecated;
    }

    public EventDeprecateResponse() { }

    public EventDeprecateResponse(EventDeprecateResponse eventDeprecateResponse)
        : base(eventDeprecateResponse) { }

    public EventDeprecateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventDeprecateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventDeprecateResponseFromRaw.FromRawUnchecked"/>
    public static EventDeprecateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventDeprecateResponse(string deprecated)
        : this()
    {
        this.Deprecated = deprecated;
    }
}

class EventDeprecateResponseFromRaw : IFromRawJson<EventDeprecateResponse>
{
    /// <inheritdoc/>
    public EventDeprecateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventDeprecateResponse.FromRawUnchecked(rawData);
}
