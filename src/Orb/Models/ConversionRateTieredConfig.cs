using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ConversionRateTieredConfig>))]
public sealed record class ConversionRateTieredConfig
    : Orb::ModelBase,
        Orb::IFromRaw<ConversionRateTieredConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required Generic::List<ConversionRateTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<ConversionRateTier>>(element)
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

    public ConversionRateTieredConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ConversionRateTieredConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ConversionRateTieredConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
