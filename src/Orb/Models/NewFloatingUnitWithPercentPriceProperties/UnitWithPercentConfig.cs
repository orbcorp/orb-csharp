using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingUnitWithPercentPriceProperties;

/// <summary>
/// Configuration for unit_with_percent pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<UnitWithPercentConfig>))]
public sealed record class UnitWithPercentConfig : ModelBase, IFromRaw<UnitWithPercentConfig>
{
    /// <summary>
    /// What percent, out of 100, of the calculated total to charge
    /// </summary>
    public required string Percent
    {
        get
        {
            if (!this.Properties.TryGetValue("percent", out JsonElement element))
                throw new ArgumentOutOfRangeException("percent", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("percent");
        }
        set
        {
            this.Properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        _ = this.Percent;
        _ = this.UnitAmount;
    }

    public UnitWithPercentConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitWithPercentConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitWithPercentConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
