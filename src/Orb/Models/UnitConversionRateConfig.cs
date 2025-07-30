using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<UnitConversionRateConfig>))]
public sealed record class UnitConversionRateConfig : ModelBase, IFromRaw<UnitConversionRateConfig>
{
    public required UnitConversionRateConfigProperties::ConversionRateType ConversionRateType
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<UnitConversionRateConfigProperties::ConversionRateType>(
                    element
                ) ?? throw new System::ArgumentNullException("conversion_rate_type");
        }
        set { this.Properties["conversion_rate_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_config", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_config",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ConversionRateUnitConfig>(element)
                ?? throw new System::ArgumentNullException("unit_config");
        }
        set { this.Properties["unit_config"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.UnitConfig.Validate();
    }

    public UnitConversionRateConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitConversionRateConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitConversionRateConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
