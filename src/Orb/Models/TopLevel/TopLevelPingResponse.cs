using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.TopLevel;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TopLevelPingResponse>))]
public sealed record class TopLevelPingResponse
    : Orb::ModelBase,
        Orb::IFromRaw<TopLevelPingResponse>
{
    public required string Response
    {
        get
        {
            if (!this.Properties.TryGetValue("response", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "response",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("response");
        }
        set { this.Properties["response"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Response;
    }

    public TopLevelPingResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TopLevelPingResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TopLevelPingResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
