using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.ReplacePriceProperties.PriceProperties.TieredWithProrationProperties.TieredWithProrationConfigProperties;

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(typeof(ModelConverter<Tier>))]
public sealed record class Tier : ModelBase, IFromRaw<Tier>
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this.Properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "tier_lower_bound",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("tier_lower_bound");
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
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException("unit_amount", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("unit_amount");
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

    public static Tier FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
