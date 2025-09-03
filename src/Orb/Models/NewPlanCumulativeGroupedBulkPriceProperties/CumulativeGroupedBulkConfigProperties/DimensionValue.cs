using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanCumulativeGroupedBulkPriceProperties.CumulativeGroupedBulkConfigProperties;

/// <summary>
/// Configuration for a dimension value entry
/// </summary>
[JsonConverter(typeof(ModelConverter<DimensionValue>))]
public sealed record class DimensionValue : ModelBase, IFromRaw<DimensionValue>
{
    /// <summary>
    /// Grouping key value
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_key", out JsonElement element))
                throw new ArgumentOutOfRangeException("grouping_key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("grouping_key");
        }
        set
        {
            this.Properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this.Properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "tier_lower_bound",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("tier_lower_bound");
        }
        set
        {
            this.Properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unit amount for this combination
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("unit_amount", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("unit_amount");
        }
        set
        {
            this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public DimensionValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionValue(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DimensionValue FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
