using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.NewFloatingGroupedTieredPriceProperties.GroupedTieredConfigProperties;

/// <summary>
/// Configuration for a single tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.NewFloatingGroupedTieredPriceProperties.GroupedTieredConfigProperties.Tier>)
)]
public sealed record class Tier
    : ModelBase,
        IFromRaw<global::Orb.Models.NewFloatingGroupedTieredPriceProperties.GroupedTieredConfigProperties.Tier>
{
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

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentOutOfRangeException("unit_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentNullException("unit_amount")
                );
        }
        set
        {
            this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.NewFloatingGroupedTieredPriceProperties.GroupedTieredConfigProperties.Tier FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
