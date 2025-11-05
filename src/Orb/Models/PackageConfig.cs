using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

/// <summary>
/// Configuration for package pricing
/// </summary>
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
            if (!this._properties.TryGetValue("package_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'package_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "package_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'package_amount' cannot be null",
                    new System::ArgumentNullException("package_amount")
                );
        }
        init
        {
            this._properties["package_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An integer amount to represent package size. For example, 1000 here would
    /// divide usage by 1000 before multiplying by package_amount in rating
    /// </summary>
    public required long PackageSize
    {
        get
        {
            if (!this._properties.TryGetValue("package_size", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'package_size' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "package_size",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["package_size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PackageAmount;
        _ = this.PackageSize;
    }

    public PackageConfig() { }

    public PackageConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PackageConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PackageConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
