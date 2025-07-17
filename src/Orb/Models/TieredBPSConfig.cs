using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TieredBPSConfig>))]
public sealed record class TieredBPSConfig : Orb::ModelBase, Orb::IFromRaw<TieredBPSConfig>
{
    /// <summary>
    /// Tiers for a Graduated BPS pricing model, where usage is bucketed into specified tiers
    /// </summary>
    public required Generic::List<BPSTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<BPSTier>>(element)
                ?? throw new System::ArgumentNullException("tiers");
        }
        set { this.Properties["tiers"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredBPSConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TieredBPSConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredBPSConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
