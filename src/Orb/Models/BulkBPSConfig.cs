using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BulkBPSConfig>))]
public sealed record class BulkBPSConfig : Orb::ModelBase, Orb::IFromRaw<BulkBPSConfig>
{
    /// <summary>
    /// Tiers for a bulk BPS pricing model where all usage is aggregated to a single
    /// tier based on total volume
    /// </summary>
    public required Generic::List<BulkBPSTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<BulkBPSTier>>(element)
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

    public BulkBPSConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BulkBPSConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkBPSConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
