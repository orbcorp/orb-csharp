using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ConversionRateTieredConfig>))]
public sealed record class ConversionRateTieredConfig
    : ModelBase,
        IFromRaw<ConversionRateTieredConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required List<ConversionRateTier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<ConversionRateTier>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("tiers");
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

    public ConversionRateTieredConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateTieredConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ConversionRateTieredConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
