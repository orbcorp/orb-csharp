using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using BulkWithProrationConfigProperties = Orb.Models.PriceProperties.BulkWithProrationProperties.BulkWithProrationConfigProperties;

namespace Orb.Models.PriceProperties.BulkWithProrationProperties;

/// <summary>
/// Configuration for bulk_with_proration pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithProrationConfig>))]
public sealed record class BulkWithProrationConfig : ModelBase, IFromRaw<BulkWithProrationConfig>
{
    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<BulkWithProrationConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BulkWithProrationConfigProperties::Tier>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentNullException("tiers")
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

    public BulkWithProrationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithProrationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkWithProrationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BulkWithProrationConfig(List<BulkWithProrationConfigProperties::Tier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}
