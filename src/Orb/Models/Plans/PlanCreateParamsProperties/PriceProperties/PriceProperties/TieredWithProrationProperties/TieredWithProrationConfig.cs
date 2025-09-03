using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TieredWithProrationConfigProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProrationProperties.TieredWithProrationConfigProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.TieredWithProrationProperties;

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredWithProrationConfig>))]
public sealed record class TieredWithProrationConfig
    : ModelBase,
        IFromRaw<TieredWithProrationConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier with proration
    /// </summary>
    public required List<TieredWithProrationConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<TieredWithProrationConfigProperties::Tier>>(
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

    public TieredWithProrationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredWithProrationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig(List<TieredWithProrationConfigProperties::Tier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}
