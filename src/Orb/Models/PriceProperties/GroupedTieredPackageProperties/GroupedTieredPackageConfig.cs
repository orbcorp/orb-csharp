using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using GroupedTieredPackageConfigProperties = Orb.Models.PriceProperties.GroupedTieredPackageProperties.GroupedTieredPackageConfigProperties;

namespace Orb.Models.PriceProperties.GroupedTieredPackageProperties;

/// <summary>
/// Configuration for grouped_tiered_package pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<GroupedTieredPackageConfig>))]
public sealed record class GroupedTieredPackageConfig
    : ModelBase,
        IFromRaw<GroupedTieredPackageConfig>
{
    /// <summary>
    /// The event property used to group before tiering
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
    /// Apply tiered pricing after rounding up the quantity to the package size. Tiers
    /// are defined using exclusive lower bounds.
    /// </summary>
    public required List<GroupedTieredPackageConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<GroupedTieredPackageConfigProperties::Tier>>(
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

    public GroupedTieredPackageConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedTieredPackageConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GroupedTieredPackageConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
