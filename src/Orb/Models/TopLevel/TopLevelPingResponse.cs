using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.TopLevel;

[JsonConverter(typeof(ModelConverter<TopLevelPingResponse, TopLevelPingResponseFromRaw>))]
public sealed record class TopLevelPingResponse : ModelBase
{
    public required string Response
    {
        get
        {
            if (!this._rawData.TryGetValue("response", out JsonElement element))
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
            this._rawData["response"] = JsonSerializer.SerializeToElement(
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

    public TopLevelPingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopLevelPingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TopLevelPingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopLevelPingResponse(string response)
        : this()
    {
        this.Response = response;
    }
}

class TopLevelPingResponseFromRaw : IFromRaw<TopLevelPingResponse>
{
    public TopLevelPingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopLevelPingResponse.FromRawUnchecked(rawData);
}
