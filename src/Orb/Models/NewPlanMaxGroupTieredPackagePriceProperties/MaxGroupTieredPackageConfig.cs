using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxGroupTieredPackageConfigProperties = Orb.Models.NewPlanMaxGroupTieredPackagePriceProperties.MaxGroupTieredPackageConfigProperties;

namespace Orb.Models.NewPlanMaxGroupTieredPackagePriceProperties;

/// <summary>
/// Configuration for max_group_tiered_package pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<MaxGroupTieredPackageConfig>))]
public sealed record class MaxGroupTieredPackageConfig
    : ModelBase,
        IFromRaw<MaxGroupTieredPackageConfig>
{
    /// <summary>
    /// The event property used to group before tiering the group with the highest value
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
    /// Package size
    /// </summary>
    public required string PackageSize
    {
        get
        {
            if (!this.Properties.TryGetValue("package_size", out JsonElement element))
                throw new ArgumentOutOfRangeException("package_size", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("package_size");
        }
        set
        {
            this.Properties["package_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Apply tiered pricing to the largest group after grouping with the provided key.
    /// </summary>
    public required List<MaxGroupTieredPackageConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<MaxGroupTieredPackageConfigProperties::Tier>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("tiers");
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
        _ = this.PackageSize;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public MaxGroupTieredPackageConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaxGroupTieredPackageConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MaxGroupTieredPackageConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
