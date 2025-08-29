using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BulkBPSConfig>))]
public sealed record class BulkBPSConfig : ModelBase, IFromRaw<BulkBPSConfig>
{
    /// <summary>
    /// Tiers for a bulk BPS pricing model where all usage is aggregated to a single
    /// tier based on total volume
    /// </summary>
    public required List<BulkBPSTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<BulkBPSTier>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("tiers");
        }
        set
        {
            this.Properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
    [SetsRequiredMembers]
    BulkBPSConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkBPSConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BulkBPSConfig(List<BulkBPSTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}
