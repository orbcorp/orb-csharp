using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PackageConfig>))]
public sealed record class PackageConfig : ModelBase, IFromRaw<PackageConfig>
{
    /// <summary>
    /// A currency amount to rate usage by
    /// </summary>
    public required string PackageAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("package_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "package_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("package_amount");
        }
        set { this.Properties["package_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An integer amount to represent package size. For example, 1000 here would divide
    /// usage by 1000 before multiplying by package_amount in rating
    /// </summary>
    public required long PackageSize
    {
        get
        {
            if (!this.Properties.TryGetValue("package_size", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "package_size",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["package_size"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PackageAmount;
        _ = this.PackageSize;
    }

    public PackageConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PackageConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PackageConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
