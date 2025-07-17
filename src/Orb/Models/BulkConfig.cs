using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BulkConfig>))]
public sealed record class BulkConfig : Orb::ModelBase, Orb::IFromRaw<BulkConfig>
{
    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required Generic::List<BulkTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<BulkTier>>(element)
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

    public BulkConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BulkConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
