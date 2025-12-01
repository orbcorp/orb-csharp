using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Events;

[JsonConverter(typeof(ModelConverter<EventDeprecateResponse, EventDeprecateResponseFromRaw>))]
public sealed record class EventDeprecateResponse : ModelBase
{
    /// <summary>
    /// event_id of the deprecated event, if successfully updated
    /// </summary>
    public required string Deprecated
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "deprecated"); }
        init { ModelBase.Set(this._rawData, "deprecated", value); }
    }

    public override void Validate()
    {
        _ = this.Deprecated;
    }

    public EventDeprecateResponse() { }

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

class EventDeprecateResponseFromRaw : IFromRaw<EventDeprecateResponse>
{
    public EventDeprecateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventDeprecateResponse.FromRawUnchecked(rawData);
}
