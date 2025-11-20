using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

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
            if (!this._rawData.TryGetValue("deprecated", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'deprecated' cannot be null",
                    new ArgumentOutOfRangeException("deprecated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'deprecated' cannot be null",
                    new ArgumentNullException("deprecated")
                );
        }
        init
        {
            this._rawData["deprecated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
