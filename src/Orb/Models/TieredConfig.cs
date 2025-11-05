using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

/// <summary>
/// Configuration for tiered pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredConfig>))]
public sealed record class TieredConfig : ModelBase, IFromRaw<TieredConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// </summary>
    public required List<Tier26> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Tier26>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
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

    public TieredConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TieredConfig(List<Tier26> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}
