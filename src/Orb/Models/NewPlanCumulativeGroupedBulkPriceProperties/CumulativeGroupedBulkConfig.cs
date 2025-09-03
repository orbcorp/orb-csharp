using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.NewPlanCumulativeGroupedBulkPriceProperties.CumulativeGroupedBulkConfigProperties;

namespace Orb.Models.NewPlanCumulativeGroupedBulkPriceProperties;

/// <summary>
/// Configuration for cumulative_grouped_bulk pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<CumulativeGroupedBulkConfig>))]
public sealed record class CumulativeGroupedBulkConfig
    : ModelBase,
        IFromRaw<CumulativeGroupedBulkConfig>
{
    /// <summary>
    /// Each tier lower bound must have the same group of values.
    /// </summary>
    public required List<DimensionValue> DimensionValues
    {
        get
        {
            if (!this.Properties.TryGetValue("dimension_values", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "dimension_values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<DimensionValue>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("dimension_values");
        }
        set
        {
            this.Properties["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Grouping key name
    /// </summary>
    public required string Group
    {
        get
        {
            if (!this.Properties.TryGetValue("group", out JsonElement element))
                throw new ArgumentOutOfRangeException("group", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("group");
        }
        set
        {
            this.Properties["group"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.DimensionValues)
        {
            item.Validate();
        }
        _ = this.Group;
    }

    public CumulativeGroupedBulkConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedBulkConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CumulativeGroupedBulkConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
