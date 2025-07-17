using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ConversionRateUnitConfig>))]
public sealed record class ConversionRateUnitConfig
    : Orb::ModelBase,
        Orb::IFromRaw<ConversionRateUnitConfig>
{
    /// <summary>
    /// Amount per unit of overage
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("unit_amount");
        }
        set { this.Properties["unit_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
    }

    public ConversionRateUnitConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ConversionRateUnitConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ConversionRateUnitConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
