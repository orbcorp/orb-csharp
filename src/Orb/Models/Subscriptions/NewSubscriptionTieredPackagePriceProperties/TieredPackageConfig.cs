using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TieredPackageConfigProperties = Orb.Models.Subscriptions.NewSubscriptionTieredPackagePriceProperties.TieredPackageConfigProperties;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredPackagePriceProperties;

/// <summary>
/// Configuration for tiered_package pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredPackageConfig>))]
public sealed record class TieredPackageConfig : ModelBase, IFromRaw<TieredPackageConfig>
{
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
    /// are defined using exclusive lower bounds. The tier bounds are defined based
    /// on the total quantity rather than the number of packages, so they must be
    /// multiples of the package size.
    /// </summary>
    public required List<TieredPackageConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<TieredPackageConfigProperties::Tier>>(
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
        _ = this.PackageSize;
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredPackageConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPackageConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredPackageConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
