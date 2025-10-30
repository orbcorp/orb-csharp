using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.NewPlanGroupedTieredPackagePriceProperties.GroupedTieredPackageConfigProperties;

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.NewPlanGroupedTieredPackagePriceProperties.GroupedTieredPackageConfigProperties.Tier>)
)]
public sealed record class Tier
    : ModelBase,
        IFromRaw<global::Orb.Models.NewPlanGroupedTieredPackagePriceProperties.GroupedTieredPackageConfigProperties.Tier>
{
    /// <summary>
    /// Price per package
    /// </summary>
    public required string PerUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit' cannot be null",
                    new ArgumentOutOfRangeException("per_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit' cannot be null",
                    new ArgumentNullException("per_unit")
                );
        }
        set
        {
            this.Properties["per_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tier lower bound
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this.Properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new ArgumentOutOfRangeException("tier_lower_bound", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new ArgumentNullException("tier_lower_bound")
                );
        }
        set
        {
            this.Properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PerUnit;
        _ = this.TierLowerBound;
    }

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.NewPlanGroupedTieredPackagePriceProperties.GroupedTieredPackageConfigProperties.Tier FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
