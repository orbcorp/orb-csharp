using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TieredWithMinimumConfigProperties = Orb.Models.Subscriptions.NewSubscriptionTieredWithMinimumPriceProperties.TieredWithMinimumConfigProperties;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredWithMinimumPriceProperties;

/// <summary>
/// Configuration for tiered_with_minimum pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<TieredWithMinimumConfig>))]
public sealed record class TieredWithMinimumConfig : ModelBase, IFromRaw<TieredWithMinimumConfig>
{
    /// <summary>
    /// Tiered pricing with a minimum amount dependent on the volume tier. Tiers are
    /// defined using exclusive lower bounds.
    /// </summary>
    public required List<TieredWithMinimumConfigProperties::Tier> Tiers
    {
        get
        {
            if (!this.Properties.TryGetValue("tiers", out JsonElement element))
                throw new ArgumentOutOfRangeException("tiers", "Missing required argument");

            return JsonSerializer.Deserialize<List<TieredWithMinimumConfigProperties::Tier>>(
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

    /// <summary>
    /// If true, tiers with an accrued amount of 0 will not be included in the rating.
    /// </summary>
    public bool? HideZeroAmountTiers
    {
        get
        {
            if (!this.Properties.TryGetValue("hide_zero_amount_tiers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hide_zero_amount_tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get
        {
            if (!this.Properties.TryGetValue("prorate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prorate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.HideZeroAmountTiers;
        _ = this.Prorate;
    }

    public TieredWithMinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithMinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredWithMinimumConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TieredWithMinimumConfig(List<TieredWithMinimumConfigProperties::Tier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}
