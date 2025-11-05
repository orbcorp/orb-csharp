using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.TopLevel;

[JsonConverter(typeof(ModelConverter<TopLevelPingResponse>))]
public sealed record class TopLevelPingResponse : ModelBase, IFromRaw<TopLevelPingResponse>
{
    public required string Response
    {
        get
        {
            if (!this._properties.TryGetValue("response", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'response' cannot be null",
                    new ArgumentOutOfRangeException("response", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'response' cannot be null",
                    new ArgumentNullException("response")
                );
        }
        init
        {
            this._properties["response"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Response;
    }

    public TopLevelPingResponse() { }

    public TopLevelPingResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopLevelPingResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TopLevelPingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TopLevelPingResponse(string response)
        : this()
    {
        this.Response = response;
    }
}
