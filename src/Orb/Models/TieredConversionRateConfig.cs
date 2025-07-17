using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using TieredConversionRateConfigProperties = Orb.Models.TieredConversionRateConfigProperties;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TieredConversionRateConfig>))]
public sealed record class TieredConversionRateConfig
    : Orb::ModelBase,
        Orb::IFromRaw<TieredConversionRateConfig>
{
    public required TieredConversionRateConfigProperties::ConversionRateType ConversionRateType
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<TieredConversionRateConfigProperties::ConversionRateType>(
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

    public required ConversionRateTieredConfig TieredConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("tiered_config", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tiered_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ConversionRateTieredConfig>(element)
                ?? throw new System::ArgumentNullException("tiered_config");
        }
        set { this.Properties["tiered_config"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.TieredConfig.Validate();
    }

    public TieredConversionRateConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TieredConversionRateConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredConversionRateConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
