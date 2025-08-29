using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ConversionRateUnitConfig>))]
public sealed record class ConversionRateUnitConfig : ModelBase, IFromRaw<ConversionRateUnitConfig>
{
    /// <summary>
    /// Amount per unit of overage
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

    public ConversionRateUnitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversionRateUnitConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ConversionRateUnitConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ConversionRateUnitConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}
