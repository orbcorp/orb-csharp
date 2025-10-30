using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.BulkWithFiltersProperties.BulkWithFiltersConfigProperties;

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.BulkWithFiltersProperties.BulkWithFiltersConfigProperties.Tier>)
)]
public sealed record class Tier
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.BulkWithFiltersProperties.BulkWithFiltersConfigProperties.Tier>
{
    /// <summary>
    /// Amount per unit
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

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this.Properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
        _ = this.UnitAmount;
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

    public static global::Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.AddPriceProperties.PriceProperties.BulkWithFiltersProperties.BulkWithFiltersConfigProperties.Tier FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}
