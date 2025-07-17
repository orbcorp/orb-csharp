using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Events.EventIngestResponseProperties;

/// <summary>
/// Optional debug information (only present when debug=true is passed to the endpoint).
/// Contains ingested and duplicate event idempotency keys.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Debug>))]
public sealed record class Debug : Orb::ModelBase, Orb::IFromRaw<Debug>
{
    public required Generic::List<string> Duplicate
    {
        get
        {
            if (!this.Properties.TryGetValue("duplicate", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duplicate",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("duplicate");
        }
        set { this.Properties["duplicate"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<string> Ingested
    {
        get
        {
            if (!this.Properties.TryGetValue("ingested", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ingested",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("ingested");
        }
        set { this.Properties["ingested"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Duplicate)
        {
            _ = item;
        }
        foreach (var item in this.Ingested)
        {
            _ = item;
        }
    }

    public Debug() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Debug(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Debug FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
