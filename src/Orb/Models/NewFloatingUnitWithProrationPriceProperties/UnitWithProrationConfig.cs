using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingUnitWithProrationPriceProperties;

/// <summary>
/// Configuration for unit_with_proration pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<UnitWithProrationConfig>))]
public sealed record class UnitWithProrationConfig : ModelBase, IFromRaw<UnitWithProrationConfig>
{
    /// <summary>
    /// Rate per unit of usage
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
        _ = this.UnitAmount;
    }

    public UnitWithProrationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitWithProrationConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitWithProrationConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public UnitWithProrationConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}
