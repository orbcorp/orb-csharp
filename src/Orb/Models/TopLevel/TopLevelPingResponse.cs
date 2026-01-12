using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.TopLevel;

[JsonConverter(typeof(JsonModelConverter<TopLevelPingResponse, TopLevelPingResponseFromRaw>))]
public sealed record class TopLevelPingResponse : JsonModel
{
    public required string Response
    {
        get { return this._rawData.GetNotNullClass<string>("response"); }
        init { this._rawData.Set("response", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Response;
    }

    public TopLevelPingResponse() { }

    public TopLevelPingResponse(TopLevelPingResponse topLevelPingResponse)
        : base(topLevelPingResponse) { }

    public TopLevelPingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopLevelPingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopLevelPingResponseFromRaw.FromRawUnchecked"/>
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

class TopLevelPingResponseFromRaw : IFromRawJson<TopLevelPingResponse>
{
    /// <inheritdoc/>
    public TopLevelPingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopLevelPingResponse.FromRawUnchecked(rawData);
}
