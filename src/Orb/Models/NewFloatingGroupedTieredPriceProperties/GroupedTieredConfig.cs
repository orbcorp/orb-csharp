using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using GroupedTieredConfigProperties = Orb.Models.NewFloatingGroupedTieredPriceProperties.GroupedTieredConfigProperties;

namespace Orb.Models.NewFloatingGroupedTieredPriceProperties;

/// <summary>
/// Configuration for grouped_tiered pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedTieredConfig>))]
public sealed record class GroupedTieredConfig : ModelBase, IFromRaw<GroupedTieredConfig>
{
    /// <summary>
    /// The billable metric property used to group before tiering
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
    /// Apply tiered pricing to each segment generated after grouping with the provided key
    /// </summary>
    public required List<GroupedTieredConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<GroupedTieredConfigProperties::Tier>>(
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
        _ = this.GroupingKey;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public GroupedTieredConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedTieredConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedTieredConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
