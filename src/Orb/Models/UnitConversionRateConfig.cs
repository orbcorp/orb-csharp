using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<UnitConversionRateConfig>))]
public sealed record class UnitConversionRateConfig : ModelBase, IFromRaw<UnitConversionRateConfig>
{
    public required ApiEnum<string, ConversionRateType> ConversionRateType
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'conversion_rate_type' cannot be null",
                    new ArgumentOutOfRangeException(
                        "conversion_rate_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ConversionRateType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["conversion_rate_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ConversionRateUnitConfig UnitConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new ArgumentOutOfRangeException("unit_config", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ConversionRateUnitConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new ArgumentNullException("unit_config")
                );
        }
        set
        {
            this.Properties["unit_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
