using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.PriceProperties.PackageWithAllocationProperties;

/// <summary>
/// Configuration for package_with_allocation pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<PackageWithAllocationConfig>))]
public sealed record class PackageWithAllocationConfig
    : ModelBase,
        IFromRaw<PackageWithAllocationConfig>
{
    /// <summary>
    /// Usage allocation
    /// </summary>
    public required string Allocation
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation", out JsonElement element))
                throw new ArgumentOutOfRangeException("allocation", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("allocation");
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
    /// Price per package
    /// </summary>
    public required string PackageAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("package_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "package_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("package_amount");
        }
        set
        {
            this.Properties["package_amount"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        _ = this.Allocation;
        _ = this.PackageAmount;
        _ = this.PackageSize;
    }

    public PackageWithAllocationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PackageWithAllocationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PackageWithAllocationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
