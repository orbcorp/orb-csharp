using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using BulkWithFiltersConfigProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.BulkWithFiltersProperties.BulkWithFiltersConfigProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties.PriceProperties.BulkWithFiltersProperties;

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithFiltersConfig>))]
public sealed record class BulkWithFiltersConfig : ModelBase, IFromRaw<BulkWithFiltersConfig>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<BulkWithFiltersConfigProperties::Filter> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BulkWithFiltersConfigProperties::Filter>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new ArgumentNullException("filters")
                );
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<BulkWithFiltersConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<BulkWithFiltersConfigProperties::Tier>>(
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
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public BulkWithFiltersConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkWithFiltersConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
