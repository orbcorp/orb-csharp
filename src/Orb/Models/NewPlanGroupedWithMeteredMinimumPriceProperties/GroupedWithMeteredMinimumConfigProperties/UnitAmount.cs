using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.NewPlanGroupedWithMeteredMinimumPriceProperties.GroupedWithMeteredMinimumConfigProperties;

/// <summary>
/// Configuration for a unit amount
/// </summary>
[JsonConverter(typeof(ModelConverter<UnitAmount>))]
public sealed record class UnitAmount : ModelBase, IFromRaw<UnitAmount>
{
    /// <summary>
    /// Pricing value
    /// </summary>
    public required string PricingValue
    {
        get
        {
            if (!this.Properties.TryGetValue("pricing_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pricing_value' cannot be null",
                    new ArgumentOutOfRangeException("pricing_value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'pricing_value' cannot be null",
                    new ArgumentNullException("pricing_value")
                );
        }
        set
        {
            this.Properties["pricing_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Per unit amount
    /// </summary>
    public required string UnitAmount1
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
        _ = this.PricingValue;
        _ = this.UnitAmount1;
    }

    public UnitAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitAmount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitAmount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
