using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Subscriptions.NewSubscriptionGroupedWithMeteredMinimumPriceProperties.GroupedWithMeteredMinimumConfigProperties;

namespace Orb.Models.Subscriptions.NewSubscriptionGroupedWithMeteredMinimumPriceProperties;

/// <summary>
/// Configuration for grouped_with_metered_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedWithMeteredMinimumConfig>))]
public sealed record class GroupedWithMeteredMinimumConfig
    : ModelBase,
        IFromRaw<GroupedWithMeteredMinimumConfig>
{
    /// <summary>
    /// Used to partition the usage into groups. The minimum amount is applied to
    /// each group.
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
    /// The minimum amount to charge per group per unit
    /// </summary>
    public required string MinimumUnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_unit_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "minimum_unit_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("minimum_unit_amount");
        }
        set
        {
            this.Properties["minimum_unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate
    /// </summary>
    public required string PricingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("pricing_key", out JsonElement element))
                throw new ArgumentOutOfRangeException("pricing_key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("pricing_key");
        }
        set
        {
            this.Properties["pricing_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scale the unit rates by the scaling factor.
    /// </summary>
    public required List<ScalingFactor> ScalingFactors
    {
        get
        {
            if (!this.Properties.TryGetValue("scaling_factors", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "scaling_factors",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<ScalingFactor>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("scaling_factors");
        }
        set
        {
            this.Properties["scaling_factors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine the unit rate scaling factor
    /// </summary>
    public required string ScalingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("scaling_key", out JsonElement element))
                throw new ArgumentOutOfRangeException("scaling_key", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("scaling_key");
        }
        set
        {
            this.Properties["scaling_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply per unit pricing to each pricing value. The minimum amount is applied
    /// any unmatched usage.
    /// </summary>
    public required List<UnitAmount> UnitAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amounts", out JsonElement element))
                throw new ArgumentOutOfRangeException("unit_amounts", "Missing required argument");

            return JsonSerializer.Deserialize<List<UnitAmount>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("unit_amounts");
        }
        set
        {
            this.Properties["unit_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MinimumUnitAmount;
        _ = this.PricingKey;
        foreach (var item in this.ScalingFactors)
        {
            item.Validate();
        }
        _ = this.ScalingKey;
        foreach (var item in this.UnitAmounts)
        {
            item.Validate();
        }
    }

    public GroupedWithMeteredMinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMeteredMinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedWithMeteredMinimumConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
