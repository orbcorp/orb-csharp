using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TieredBPSConfig>))]
public sealed record class TieredBPSConfig : ModelBase, IFromRaw<TieredBPSConfig>
{
    /// <summary>
    /// Tiers for a Graduated BPS pricing model, where usage is bucketed into specified tiers
    /// </summary>
    public required List<BPSTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<BPSTier>>(element)
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

    public TieredBPSConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredBPSConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredBPSConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
