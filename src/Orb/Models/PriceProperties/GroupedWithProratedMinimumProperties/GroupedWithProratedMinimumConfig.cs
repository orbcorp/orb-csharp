using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.PriceProperties.GroupedWithProratedMinimumProperties;

/// <summary>
/// Configuration for grouped_with_prorated_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedWithProratedMinimumConfig>))]
public sealed record class GroupedWithProratedMinimumConfig
    : ModelBase,
        IFromRaw<GroupedWithProratedMinimumConfig>
{
    /// <summary>
    /// How to determine the groups that should each have a minimum
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
    /// The minimum amount to charge per group
    /// </summary>
    public required string Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum' cannot be null",
                    new ArgumentOutOfRangeException("minimum", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum' cannot be null",
                    new ArgumentNullException("minimum")
                );
        }
        set
        {
            this.Properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge per unit
    /// </summary>
    public required string UnitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rate' cannot be null",
                    new ArgumentOutOfRangeException("unit_rate", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rate' cannot be null",
                    new ArgumentNullException("unit_rate")
                );
        }
        set
        {
            this.Properties["unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.Minimum;
        _ = this.UnitRate;
    }

    public GroupedWithProratedMinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithProratedMinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedWithProratedMinimumConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
