using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BPSConfig>))]
public sealed record class BPSConfig : Orb::ModelBase, Orb::IFromRaw<BPSConfig>
{
    /// <summary>
    /// Basis point take rate per event
    /// </summary>
    public required double BPS
    {
        get
        {
            if (!this.Properties.TryGetValue("bps", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("bps", "Missing required argument");

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["bps"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional currency amount maximum to cap spend per event
    /// </summary>
    public string? PerUnitMaximum
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_maximum", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["per_unit_maximum"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.BPS;
        _ = this.PerUnitMaximum;
    }

    public BPSConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BPSConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BPSConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
