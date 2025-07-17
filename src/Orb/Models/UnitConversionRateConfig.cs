using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<UnitConversionRateConfig>))]
public sealed record class UnitConversionRateConfig
    : Orb::ModelBase,
        Orb::IFromRaw<UnitConversionRateConfig>
{
    public required UnitConversionRateConfigProperties::ConversionRateType ConversionRateType
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<UnitConversionRateConfigProperties::ConversionRateType>(
                    element
                ) ?? throw new System::ArgumentNullException("conversion_rate_type");
        }
        set
        {
            this.Properties["conversion_rate_type"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_config", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ConversionRateUnitConfig>(element)
                ?? throw new System::ArgumentNullException("unit_config");
        }
        set { this.Properties["unit_config"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.UnitConfig.Validate();
    }

    public UnitConversionRateConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    UnitConversionRateConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitConversionRateConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
