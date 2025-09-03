using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TieredPackageWithMinimumConfigProperties = Orb.Models.NewPlanTieredPackageWithMinimumPriceProperties.TieredPackageWithMinimumConfigProperties;

namespace Orb.Models.NewPlanTieredPackageWithMinimumPriceProperties;

/// <summary>
/// Configuration for tiered_package_with_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredPackageWithMinimumConfig>))]
public sealed record class TieredPackageWithMinimumConfig
    : ModelBase,
        IFromRaw<TieredPackageWithMinimumConfig>
{
    /// <summary>
    /// Package size
    /// </summary>
    public required double PackageSize
    {
        get
        {
            if (!this.Properties.TryGetValue("package_size", out JsonElement element))
                throw new ArgumentOutOfRangeException("package_size", "Missing required argument");

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
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
    public required List<TieredPackageWithMinimumConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<TieredPackageWithMinimumConfigProperties::Tier>>(
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

    public TieredPackageWithMinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPackageWithMinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredPackageWithMinimumConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
