using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BulkConfig>))]
public sealed record class BulkConfig : ModelBase, IFromRaw<BulkConfig>
{
    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<BulkTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<BulkTier>>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("tiers");
        }
        set { this.Properties["tiers"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    BulkConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public BulkConfig(List<BulkTier> tiers)
    {
        this.Tiers = tiers;
    }
}
