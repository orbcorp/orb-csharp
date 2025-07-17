using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TieredConfig>))]
public sealed record class TieredConfig : Orb::ModelBase, Orb::IFromRaw<TieredConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required Generic::List<Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<Tier>>(element)
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

    public TieredConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TieredConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
