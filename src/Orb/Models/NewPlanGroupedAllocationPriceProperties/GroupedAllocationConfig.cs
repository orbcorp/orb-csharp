using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.NewPlanGroupedAllocationPriceProperties;

/// <summary>
/// Configuration for grouped_allocation pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedAllocationConfig>))]
public sealed record class GroupedAllocationConfig : ModelBase, IFromRaw<GroupedAllocationConfig>
{
    /// <summary>
    /// Usage allocation per group
    /// </summary>
    public required string Allocation
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new ArgumentOutOfRangeException("allocation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'allocation' cannot be null",
                    new ArgumentNullException("allocation")
                );
        }
        set
        {
            this.Properties["allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How to determine the groups that should each be allocated some quantity
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
    /// Unit rate for post-allocation
    /// </summary>
    public required string OverageUnitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("overage_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'overage_unit_rate' cannot be null",
                    new ArgumentOutOfRangeException(
                        "overage_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'overage_unit_rate' cannot be null",
                    new ArgumentNullException("overage_unit_rate")
                );
        }
        set
        {
            this.Properties["overage_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Allocation;
        _ = this.GroupingKey;
        _ = this.OverageUnitRate;
    }

    public GroupedAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedAllocationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedAllocationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
