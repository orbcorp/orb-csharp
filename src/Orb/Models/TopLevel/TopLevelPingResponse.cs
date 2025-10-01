using System;
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
            if (!this.Properties.TryGetValue("response", out JsonElement element))
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
        set
        {
            this.Properties["response"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopLevelPingResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TopLevelPingResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TopLevelPingResponse(string response)
        : this()
    {
        this.Response = response;
    }
}
