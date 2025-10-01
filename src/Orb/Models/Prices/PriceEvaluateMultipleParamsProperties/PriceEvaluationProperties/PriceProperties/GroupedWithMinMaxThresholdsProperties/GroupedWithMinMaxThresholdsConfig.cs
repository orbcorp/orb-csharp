using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceProperties.GroupedWithMinMaxThresholdsProperties;

/// <summary>
/// Configuration for grouped_with_min_max_thresholds pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsConfig>))]
public sealed record class GroupedWithMinMaxThresholdsConfig
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsConfig>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new ArgumentOutOfRangeException("grouping_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new ArgumentNullException("grouping_key")
                );
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
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new ArgumentOutOfRangeException("maximum_charge", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new ArgumentNullException("maximum_charge")
                );
        }
        set
        {
            this.Properties["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new ArgumentOutOfRangeException("minimum_charge", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new ArgumentNullException("minimum_charge")
                );
        }
        set
        {
            this.Properties["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new ArgumentOutOfRangeException("per_unit_rate", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new ArgumentNullException("per_unit_rate")
                );
        }
        set
        {
            this.Properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
