using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PackageConfig>))]
public sealed record class PackageConfig : Orb::ModelBase, Orb::IFromRaw<PackageConfig>
{
    /// <summary>
    /// A currency amount to rate usage by
    /// </summary>
    public required string PackageAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("package_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "package_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("package_amount");
        }
        set { this.Properties["package_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An integer amount to represent package size. For example, 1000 here would divide
    /// usage by 1000 before multiplying by package_amount in rating
    /// </summary>
    public required long PackageSize
    {
        get
        {
            if (!this.Properties.TryGetValue("package_size", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "package_size",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["package_size"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PackageAmount;
        _ = this.PackageSize;
    }

    public PackageConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PackageConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PackageConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
